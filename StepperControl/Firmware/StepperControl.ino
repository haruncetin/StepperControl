/*
 * Harun CETIN (hcetin01@hotmail.com)
 */
#include <Stepper.h>
#include <EEPROM.h>

// EEPROM Address Config
#define ADDR_STATUS 0
#define ADDR_SPR 1
#define ADDR_STEPS 5

uint32_t spr = 200;  // Steps per revolution 200 * 1.8 = 360
uint32_t steps = 50; // RPM
byte cmdByte = 0;
byte paramByte = 0;

// initialize the stepper library
Stepper myStepper(spr, 6, 7, 8, 9);

void setup() {
  // Read config from internal EEPROM
  spr = EEPROM.read(ADDR_SPR);
  steps = EEPROM.read(ADDR_STEPS);
  
  myStepper.setSpeed(steps);
  Serial.begin(9600); // initialize the serial port
}

void loop() {
  /*
   * command 0x1 = set speed. following 4 bytes of this byte are amount of speed
   * command 0x2 = steps per revolution. following 4 bytes of this byte are amount of revolution
   * command 0x3 = turn clockwise direction. 0x1 Step by step, 0x2 Continuous, 0xF Stop turning.
   * command 0x4 = turn counter clockwise direction. 0x1 Step by step, 0x2 Continuous, 0xF Stop turning.
   */
  if (Serial.available() > 0) {
    cmdByte = Serial.read();
    if(cmdByte == 0x1){
      if (Serial.available() > 0) {
        // Byte to int conversion
        paramByte = Serial.read();
        steps = (uint32_t) paramByte << 24;
        paramByte = Serial.read();
        steps |=  (uint32_t) paramByte << 16;
        paramByte = Serial.read();
        steps |= (uint32_t) paramByte << 8;
        paramByte = Serial.read();
        steps |= (uint32_t) paramByte;
        delay(100);
        Serial.print("STEPS:");
        Serial.println(steps);
        // Write steps config to internal EEPROM
        EEPROM.write(ADDR_STEPS, steps);
        if(EEPROM.read(ADDR_STEPS) == steps){
          Serial.println("EEWRITEOK");
        }else{
          Serial.println("EEWRITEFAIL");          
        }
      }else{
        delay(100);
        Serial.print("STEPS:");
        Serial.println(steps);
      }
    }
    if(cmdByte == 0x2){
      if (Serial.available() > 0) {
        // Byte to int conversion
        paramByte = Serial.read();
        spr = (uint32_t) paramByte << 24;
        paramByte = Serial.read();
        spr |=  (uint32_t) paramByte << 16;
        paramByte = Serial.read();
        spr |= (uint32_t)paramByte << 8;
        paramByte = Serial.read();
        spr |= (uint32_t) paramByte; 
        delay(100);
        Serial.print("SPR:");
        Serial.println(spr);        
        // Write spr config to internal EEPROM
        EEPROM.write(ADDR_SPR, spr);
        if(EEPROM.read(ADDR_SPR) == spr){
          Serial.println("EEWRITEOK");
        }else{
          Serial.println("EEWRITEFAIL");          
        }
      }else{
        delay(100);
        Serial.print("SPR:");
        Serial.println(spr);
      }
    }
    if(cmdByte == 0x3){
      cmdByte = Serial.read();
      Serial.println("TURNINGCW");
      if(cmdByte == 0x1){
        myStepper.setSpeed(steps);
        myStepper.step(spr);
      }else if(cmdByte == 0x2){
        while(!(Serial.available()>0 && Serial.read()==0xF)){
          myStepper.setSpeed(steps);
          myStepper.step(spr);
        }
      }
      Serial.println("TURNINGCWOK");        
    }
    if(cmdByte == 0x4){
      cmdByte = Serial.read();
      Serial.println("TURNINGCCW");
      if(cmdByte == 0x1){
        myStepper.setSpeed(steps);
        myStepper.step(-spr);
      }else if(cmdByte == 0x2){
        while(!(Serial.available()>0 && Serial.read()==0xF)){
          myStepper.setSpeed(steps);
          myStepper.step(-spr);
        }
      }
      Serial.println("TURNINGCCWOK");
    }
  }
  myStepper.setSpeed(0);
  myStepper.step(0);
}

