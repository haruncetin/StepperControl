using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRobotControl
{
    public enum StepperStatus
    {
        IDLE = 0,
        TURNINGCW = 1,
        TURNINGCCW = 2
    }

    public class Stepper
    {
        private string _name;
        private int _steps;
        private int _spr;
        private double _apr = 1.8;
        private StepperStatus _status = StepperStatus.IDLE;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Steps
        {
            get { return _steps; }
            set { _steps = value; }
        }

        public int StepsPerRevolution
        {
            get { return _spr; }
            set { _spr = value; }
        }

        public double RotationAnglePerSteps
        {
            get { return _apr; }
            set { _apr = value; }
        }

        public double RotationAngle
        {
            get { return _apr * _spr; }
            set { _spr = (int)(value / _apr); }
        }

        public StepperStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public Stepper(string name = "Stepper")
        {
            Name = name;
            Steps = 60;
            StepsPerRevolution = 200;
        }

        public Stepper(string name, int steps = 60, int steps_per_revolution = 200, double angle_per_steps = 1.8)
        {
            Name = name;
            Steps = steps;
            StepsPerRevolution = steps_per_revolution;
            RotationAnglePerSteps = angle_per_steps;
        }
    }
}
