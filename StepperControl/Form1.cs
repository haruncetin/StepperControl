using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;

namespace MyRobotControl
{
    public partial class frm_main : Form
    {
        private const int WM_DEVICECHANGE = 0x0219;
        private const int DBT_DEVICEARRIVAL = 0x8000;
        private const int DBT_DEVICEREMOVEPENDING = 0x8003;
        private const int DBT_DEVICEREMOVECOMPLETE = 0x8004;
        private const int DBT_DEVTYP_PORT = 0x00000003;

        Stepper stepper = new Stepper();

        protected override void WndProc(ref Message m)
        {
            int devType;
            base.WndProc(ref m);

            switch (m.Msg)
            {
                case WM_DEVICECHANGE:
                    switch ((int)m.WParam)
                    {
                        case DBT_DEVICEARRIVAL:
                            devType = Marshal.ReadInt32(m.LParam, 4);
                            if (devType == DBT_DEVTYP_PORT)
                            {
                                fillDevicesList(cb_ports);
                            }
                            break;
                        case DBT_DEVICEREMOVECOMPLETE:
                            disconnect();
                            fillDevicesList(cb_ports);
                            break;
                        case DBT_DEVICEREMOVEPENDING:
                            break;
                    }

                    break;
            }
        }

        public frm_main()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string incoming = string.Empty;
            while (!incoming.EndsWith("\r\n"))
            {
                incoming += serialPort1.ReadExisting();
            }
            if (incoming.Contains(":")) // command:parameter pair
            {
                string[] incomingSplit = incoming.Split(':');
                string cmd = incomingSplit[0];
                string param = incomingSplit[1];

                if (cmd == "STEPS")
                {
                    try
                    {
                        stepper.Steps = int.Parse(param);
                        nud_steps.Value = stepper.Steps;
                    }
                    catch (Exception) { }
                }
                if (cmd == "SPR")
                {
                    try
                    {
                        stepper.StepsPerRevolution = int.Parse(param);
                        nud_spr.Value = decimal.Parse(stepper.RotationAngle.ToString());
                    }
                    catch (Exception) { }
                }
            }
            else
            {
                if (incoming.StartsWith("TURNINGCW"))
                {
                    stepper.Status = StepperStatus.TURNINGCW;
                    lbl_statusBar.Text = ("Turning toward Clockwise..");
                }
                if (incoming.StartsWith("TURNINGCCW"))
                {
                    stepper.Status = StepperStatus.TURNINGCCW;
                    lbl_statusBar.Text = ("Turning toward Counter Clockwise..");
                }
                if (incoming.Contains("TURNINGCWOK"))
                {
                    btn_cw.Text = "CW";
                    btn_cw.Enabled = true;
                    stepper.Status = StepperStatus.IDLE;
                    lbl_statusBar.Text += ("OK");
                }
                if (incoming.Contains("TURNINGCCWOK"))
                {
                    btn_ccw.Text = "CCW";
                    btn_ccw.Enabled = true;
                    stepper.Status = StepperStatus.IDLE;
                    lbl_statusBar.Text += ("OK");
                }
                if (incoming.Contains("EEWRITEOK"))
                {
                    lbl_statusBar.Text = "Config Write SUCCESS.";
                    btn_sprOk.Enabled = true;
                    btn_stepsOk.Enabled = true;
                }
                if (incoming.Contains("EEWRITEFAIL"))
                {
                    lbl_statusBar.Text = "Config Write FAIL!";
                    btn_sprOk.Enabled = true;
                    btn_stepsOk.Enabled = true;
                }
            }
        }

        private void disconnect()
        {
            serialPort1.Close();
            while (serialPort1.IsOpen) ;
            if (!serialPort1.IsOpen)
            {
                lbl_statusBar.Text = "Disconnected";
                ts_statusLed.Image = Properties.Resources.status_red;
                btn_connect.Enabled = true;
                btn_connect.Text = "Connect";
            }
        }
        private void connect()
        {
            if (cb_ports.Text != String.Empty)
            {
                serialPort1.PortName = cb_ports.SelectedItem.ToString();
                serialPort1.Parity = (Parity)cb_parity.SelectedIndex;
                serialPort1.DataBits = rb_dataBits_7.Checked ? 7 : rb_dataBits_8.Checked ? 8 : 0;
                serialPort1.BaudRate = int.Parse(cb_baud.SelectedItem.ToString());
                serialPort1.RtsEnable = cbx_rts.Checked;
                btn_connect.Enabled = false;
                ts_statusLed.Image = Properties.Resources.status_orange;
                serialPort1.Open();
                while (!serialPort1.IsOpen) ;
                if (serialPort1.IsOpen)
                {
                    btn_connect.Enabled = true;
                    btn_connect.Text = "Disconnect";
                    serialPort1.Write(new byte[] { 0x1 }, 0, 1); // request steps per revolution
                    Thread.Sleep(100);
                    serialPort1.Write(new byte[] { 0x2 }, 0, 1); // request steps
                    Thread.Sleep(100);
                    ts_statusLed.Image = Properties.Resources.status_green;
                    lbl_statusBar.Text = "Connected";
                }
            }
            else
            {
                lbl_statusBar.Text = "Select a port from the ports list!";
            }
        }

        public void fillDevicesList(ComboBox control)
        {
            control.Items.Clear();
            foreach (string item in SerialPort.GetPortNames())
            {
                control.Items.Add(item);
            }
            if (control.Items.Count > 0)
            {
                control.SelectedIndex = 0;
            }
        }

        private void saveSettings()
        {
            Properties.Settings.Default.dev_port = cb_ports.SelectedIndex;
            Properties.Settings.Default.dev_baud = cb_baud.SelectedIndex;
            Properties.Settings.Default.dev_parity = cb_parity.SelectedIndex;
            Properties.Settings.Default.dev_dataBits = rb_dataBits_7.Checked ? 7 : rb_dataBits_8.Checked ? 8 : 0;
            Properties.Settings.Default.dev_rts = cbx_rts.Checked;
            Properties.Settings.Default.Save();
        }
        private void loadSettings()
        {
            if (cb_ports.Items.Count > 0)
            {
                cb_ports.SelectedIndex = Properties.Settings.Default.dev_port;
            }
            cb_baud.SelectedIndex = Properties.Settings.Default.dev_baud;
            cb_parity.SelectedIndex = Properties.Settings.Default.dev_parity;
            if (Properties.Settings.Default.dev_parity == 7)
            {
                rb_dataBits_7.Checked = true;
            }
            else
            {
                rb_dataBits_8.Checked = true;
            }
            cbx_rts.Checked = Properties.Settings.Default.dev_rts;
        }
        private void btn_connect_Click(object sender, EventArgs e)
        {
            saveSettings();
            if (serialPort1.IsOpen)
            {
                btn_connect.Enabled = false;
                disconnect();
            }
            else
            {
                connect();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fillDevicesList(cb_ports);
            loadSettings();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
        }

        private void btn_cw_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (rb_Step.Checked)
                {
                    //cw
                    serialPort1.Write(new byte[] { 0x3, 0x1 }, 0, 2);
                    btn_cw.Enabled = false;
                    Thread.Sleep(100);
                }
                else if (rb_Continuous.Checked)
                {
                    if (stepper.Status == StepperStatus.TURNINGCW)
                    {
                        serialPort1.Write(new byte[] { 0xF }, 0, 1);
                    }
                    else if (stepper.Status == StepperStatus.IDLE)
                    {
                        //cw continuous
                        serialPort1.Write(new byte[] { 0x3, 0x2 }, 0, 2);
                        Thread.Sleep(100);
                        btn_cw.Text = "STOP";
                    }
                }
            }
            else
            {
                lbl_statusBar.Text = "Serial port is closed!";
            }
        }

        private void btn_ccw_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (rb_Step.Checked)
                {
                    //ccw step
                    byte[] cmdByte = { 0x4, 0x1 };
                    serialPort1.Write(cmdByte, 0, cmdByte.Length);
                    btn_ccw.Enabled = false;
                    Thread.Sleep(100);
                }
                else if (rb_Continuous.Checked)
                {
                    if (stepper.Status == StepperStatus.TURNINGCCW)
                    {
                        serialPort1.Write(new byte[] { 0xF }, 0, 1);
                    }
                    else if (stepper.Status == StepperStatus.IDLE)
                    {
                        //ccw continuous
                        byte[] cmdByte = { 0x4, 0x2 };
                        serialPort1.Write(cmdByte, 0, cmdByte.Length);
                        Thread.Sleep(100);
                        btn_ccw.Text = "STOP";
                    }
                }
            }
            else
            {
                lbl_statusBar.Text = "Serial port is closed!";
            }

        }

        private void btn_sprOk_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                btn_sprOk.Enabled = false;
                stepper.StepsPerRevolution = nud_spr.Text == string.Empty ? 0 : (int)(double.Parse(nud_spr.Text) / 1.8);
                byte[] cmdBytes = new byte[5];
                cmdBytes[0] = 0x2;
                byte[] intBytes = BitConverter.GetBytes(stepper.StepsPerRevolution);
                cmdBytes[1] = intBytes[3];
                cmdBytes[2] = intBytes[2];
                cmdBytes[3] = intBytes[1];
                cmdBytes[4] = intBytes[0];
                serialPort1.Write(cmdBytes, 0, cmdBytes.Length);
                Thread.Sleep(100);
            }
            else
            {
                lbl_statusBar.Text = "Serial port is closed!";
            }
        }

        private void btn_stepsOk_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                btn_stepsOk.Enabled = false;
                stepper.Steps = nud_steps.Text == string.Empty ? 0 : int.Parse(nud_steps.Value.ToString());
                byte[] cmdBytes = new byte[5];
                cmdBytes[0] = 0x1;
                byte[] intBytes = BitConverter.GetBytes(stepper.Steps);
                cmdBytes[1] = intBytes[3];
                cmdBytes[2] = intBytes[2];
                cmdBytes[3] = intBytes[1];
                cmdBytes[4] = intBytes[0];
                serialPort1.Write(cmdBytes, 0, cmdBytes.Length);
                Thread.Sleep(100);
            }
            else
            {
                lbl_statusBar.Text = "Serial port is closed!";
            }

        }

        private void txt_spr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_sprOk_Click(null, null);
            }
        }

        private void txt_steps_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_stepsOk_Click(null, null);
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            panel1.Focus();
        }
    }
}
