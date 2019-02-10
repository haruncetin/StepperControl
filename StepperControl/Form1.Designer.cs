namespace MyRobotControl
{
    partial class frm_main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ts_statusLed = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_statusBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nud_steps = new System.Windows.Forms.NumericUpDown();
            this.nud_spr = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_stepsOk = new System.Windows.Forms.Button();
            this.btn_sprOk = new System.Windows.Forms.Button();
            this.rb_Step = new System.Windows.Forms.RadioButton();
            this.btn_cw = new System.Windows.Forms.Button();
            this.rb_Continuous = new System.Windows.Forms.RadioButton();
            this.btn_ccw = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbx_rts = new System.Windows.Forms.CheckBox();
            this.rb_dataBits_8 = new System.Windows.Forms.RadioButton();
            this.rb_dataBits_7 = new System.Windows.Forms.RadioButton();
            this.cb_parity = new System.Windows.Forms.ComboBox();
            this.cb_baud = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_ports = new System.Windows.Forms.ComboBox();
            this.btn_connect = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_steps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_spr)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_statusLed,
            this.lbl_statusBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 184);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(483, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ts_statusLed
            // 
            this.ts_statusLed.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ts_statusLed.Image = global::MyRobotControl.Properties.Resources.status_grey;
            this.ts_statusLed.Name = "ts_statusLed";
            this.ts_statusLed.RightToLeftAutoMirrorImage = true;
            this.ts_statusLed.Size = new System.Drawing.Size(16, 17);
            this.ts_statusLed.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // lbl_statusBar
            // 
            this.lbl_statusBar.Name = "lbl_statusBar";
            this.lbl_statusBar.Size = new System.Drawing.Size(39, 17);
            this.lbl_statusBar.Text = "Ready";
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Tips From Author";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(483, 184);
            this.panel1.TabIndex = 0;
            this.panel1.TabStop = true;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nud_steps);
            this.groupBox2.Controls.Add(this.nud_spr);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btn_stepsOk);
            this.groupBox2.Controls.Add(this.btn_sprOk);
            this.groupBox2.Controls.Add(this.rb_Step);
            this.groupBox2.Controls.Add(this.btn_cw);
            this.groupBox2.Controls.Add(this.rb_Continuous);
            this.groupBox2.Controls.Add(this.btn_ccw);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(278, 158);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Commands";
            // 
            // nud_steps
            // 
            this.nud_steps.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nud_steps.Font = new System.Drawing.Font("Quartz MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_steps.ForeColor = System.Drawing.Color.Red;
            this.nud_steps.Location = new System.Drawing.Point(9, 99);
            this.nud_steps.Name = "nud_steps";
            this.nud_steps.ReadOnly = true;
            this.nud_steps.Size = new System.Drawing.Size(76, 29);
            this.nud_steps.TabIndex = 11;
            // 
            // nud_spr
            // 
            this.nud_spr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nud_spr.DecimalPlaces = 1;
            this.nud_spr.Font = new System.Drawing.Font("Quartz MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_spr.ForeColor = System.Drawing.Color.Red;
            this.nud_spr.Increment = new decimal(new int[] {
            18,
            0,
            0,
            65536});
            this.nud_spr.Location = new System.Drawing.Point(9, 38);
            this.nud_spr.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nud_spr.Name = "nud_spr";
            this.nud_spr.ReadOnly = true;
            this.nud_spr.Size = new System.Drawing.Size(76, 29);
            this.nud_spr.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Rotation";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Steps per Revolution";
            // 
            // btn_stepsOk
            // 
            this.btn_stepsOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_stepsOk.Location = new System.Drawing.Point(91, 99);
            this.btn_stepsOk.Name = "btn_stepsOk";
            this.btn_stepsOk.Size = new System.Drawing.Size(33, 29);
            this.btn_stepsOk.TabIndex = 10;
            this.btn_stepsOk.TabStop = false;
            this.btn_stepsOk.Text = "OK";
            this.btn_stepsOk.UseVisualStyleBackColor = true;
            this.btn_stepsOk.Click += new System.EventHandler(this.btn_stepsOk_Click);
            // 
            // btn_sprOk
            // 
            this.btn_sprOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_sprOk.Location = new System.Drawing.Point(91, 38);
            this.btn_sprOk.Name = "btn_sprOk";
            this.btn_sprOk.Size = new System.Drawing.Size(33, 29);
            this.btn_sprOk.TabIndex = 10;
            this.btn_sprOk.TabStop = false;
            this.btn_sprOk.Text = "OK";
            this.btn_sprOk.UseVisualStyleBackColor = true;
            this.btn_sprOk.Click += new System.EventHandler(this.btn_sprOk_Click);
            // 
            // rb_Step
            // 
            this.rb_Step.AutoSize = true;
            this.rb_Step.Checked = true;
            this.rb_Step.Location = new System.Drawing.Point(152, 78);
            this.rb_Step.Name = "rb_Step";
            this.rb_Step.Size = new System.Drawing.Size(47, 17);
            this.rb_Step.TabIndex = 8;
            this.rb_Step.TabStop = true;
            this.rb_Step.Text = "Step";
            this.rb_Step.UseVisualStyleBackColor = true;
            // 
            // btn_cw
            // 
            this.btn_cw.Location = new System.Drawing.Point(207, 38);
            this.btn_cw.Name = "btn_cw";
            this.btn_cw.Size = new System.Drawing.Size(49, 34);
            this.btn_cw.TabIndex = 2;
            this.btn_cw.Text = "CW";
            this.btn_cw.UseVisualStyleBackColor = true;
            this.btn_cw.Click += new System.EventHandler(this.btn_cw_Click);
            // 
            // rb_Continuous
            // 
            this.rb_Continuous.AutoSize = true;
            this.rb_Continuous.Location = new System.Drawing.Point(152, 100);
            this.rb_Continuous.Name = "rb_Continuous";
            this.rb_Continuous.Size = new System.Drawing.Size(78, 17);
            this.rb_Continuous.TabIndex = 8;
            this.rb_Continuous.Text = "Continuous";
            this.rb_Continuous.UseVisualStyleBackColor = true;
            // 
            // btn_ccw
            // 
            this.btn_ccw.Location = new System.Drawing.Point(152, 38);
            this.btn_ccw.Name = "btn_ccw";
            this.btn_ccw.Size = new System.Drawing.Size(49, 34);
            this.btn_ccw.TabIndex = 3;
            this.btn_ccw.Text = "CCW";
            this.btn_ccw.UseVisualStyleBackColor = true;
            this.btn_ccw.Click += new System.EventHandler(this.btn_ccw_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Steps";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbx_rts);
            this.groupBox1.Controls.Add(this.rb_dataBits_8);
            this.groupBox1.Controls.Add(this.rb_dataBits_7);
            this.groupBox1.Controls.Add(this.cb_parity);
            this.groupBox1.Controls.Add(this.cb_baud);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cb_ports);
            this.groupBox1.Controls.Add(this.btn_connect);
            this.groupBox1.Location = new System.Drawing.Point(296, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(175, 158);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Port Settings";
            // 
            // cbx_rts
            // 
            this.cbx_rts.AutoSize = true;
            this.cbx_rts.Location = new System.Drawing.Point(9, 130);
            this.cbx_rts.Name = "cbx_rts";
            this.cbx_rts.Size = new System.Drawing.Size(48, 17);
            this.cbx_rts.TabIndex = 5;
            this.cbx_rts.Text = "RTS";
            this.cbx_rts.UseVisualStyleBackColor = true;
            // 
            // rb_dataBits_8
            // 
            this.rb_dataBits_8.AutoSize = true;
            this.rb_dataBits_8.Location = new System.Drawing.Point(138, 100);
            this.rb_dataBits_8.Name = "rb_dataBits_8";
            this.rb_dataBits_8.Size = new System.Drawing.Size(31, 17);
            this.rb_dataBits_8.TabIndex = 4;
            this.rb_dataBits_8.TabStop = true;
            this.rb_dataBits_8.Text = "8";
            this.rb_dataBits_8.UseVisualStyleBackColor = true;
            // 
            // rb_dataBits_7
            // 
            this.rb_dataBits_7.AutoSize = true;
            this.rb_dataBits_7.Location = new System.Drawing.Point(101, 100);
            this.rb_dataBits_7.Name = "rb_dataBits_7";
            this.rb_dataBits_7.Size = new System.Drawing.Size(31, 17);
            this.rb_dataBits_7.TabIndex = 4;
            this.rb_dataBits_7.TabStop = true;
            this.rb_dataBits_7.Text = "7";
            this.rb_dataBits_7.UseVisualStyleBackColor = true;
            // 
            // cb_parity
            // 
            this.cb_parity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_parity.FormattingEnabled = true;
            this.cb_parity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.cb_parity.Location = new System.Drawing.Point(84, 73);
            this.cb_parity.Name = "cb_parity";
            this.cb_parity.Size = new System.Drawing.Size(85, 21);
            this.cb_parity.TabIndex = 3;
            // 
            // cb_baud
            // 
            this.cb_baud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_baud.FormattingEnabled = true;
            this.cb_baud.Items.AddRange(new object[] {
            "115200",
            "57600",
            "38400",
            "19200",
            "9600",
            "4800",
            "2400",
            "1200",
            "300"});
            this.cb_baud.Location = new System.Drawing.Point(84, 47);
            this.cb_baud.Name = "cb_baud";
            this.cb_baud.Size = new System.Drawing.Size(85, 21);
            this.cb_baud.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Data Bits";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Parity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Baud Rate";
            // 
            // cb_ports
            // 
            this.cb_ports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ports.FormattingEnabled = true;
            this.cb_ports.Location = new System.Drawing.Point(84, 19);
            this.cb_ports.Name = "cb_ports";
            this.cb_ports.Size = new System.Drawing.Size(85, 21);
            this.cb_ports.TabIndex = 0;
            // 
            // btn_connect
            // 
            this.btn_connect.Font = new System.Drawing.Font("Agency FB", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_connect.Location = new System.Drawing.Point(84, 124);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(85, 28);
            this.btn_connect.TabIndex = 1;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Ports";
            // 
            // frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 206);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_main";
            this.Text = "Stepper Motor Control v0.1a";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_steps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_spr)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbl_statusBar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_stepsOk;
        private System.Windows.Forms.Button btn_sprOk;
        private System.Windows.Forms.RadioButton rb_Step;
        private System.Windows.Forms.Button btn_cw;
        private System.Windows.Forms.RadioButton rb_Continuous;
        private System.Windows.Forms.Button btn_ccw;
        private System.Windows.Forms.ComboBox cb_ports;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripStatusLabel ts_statusLed;
        private System.Windows.Forms.NumericUpDown nud_spr;
        private System.Windows.Forms.NumericUpDown nud_steps;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_baud;
        private System.Windows.Forms.ComboBox cb_parity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rb_dataBits_8;
        private System.Windows.Forms.RadioButton rb_dataBits_7;
        private System.Windows.Forms.CheckBox cbx_rts;
        private System.Windows.Forms.Label label7;
    }
}

