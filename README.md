# StepperControl
Stepper Motor Control &amp; Test Application

This application consist of two distinct part which one is Windows and other is Arduino. First part of the project is a Windows application. The application is written in C# as Windows Forms. Serial Port library is used to communicate with the arduino which controls the stepper electronically. Actually, it controls the Arduino board by sending following hex based commands over UART:

* 0x1: set speed. following 4 bytes of this byte are amount of speed (as integer)
* 0x2: steps per revolution. following 4 bytes of this byte are amount of revolution
* 0x3: turn clockwise direction. 0x1 Step by step, 0x2 Continuous, 0xF Stop turning.
* 0x4: turn counter clockwise direction. 0x1 Step by step, 0x2 Continuous, 0xF Stop turning.

And, then the Arduino board controls the stepper motor connected its gpio pins according to those commands.
Second part of the project is Arduino code that is firmware of the Arduino board. It listen uart port for a new command. If it is available then it compare the incoming byte to the above command values. If there is a match it execute related code part. Speed and steps per revolution values stored internal EEPROM, as well. 
