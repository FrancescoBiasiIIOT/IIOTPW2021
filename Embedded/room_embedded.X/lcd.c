#include "lcd.h"
#include <xc.h>
#include <sys/attribs.h>

#define FunctionSet8Bit_CMD 0x3C //8bit mode, 2 lines, 5x8 font
#define FunctionSet4Bit_CMD 0x2C //4bit mode, 2 lines, 5x8 font
#define SetDisplay_CMD 0x0C //Display ON, cursor off, cursor blinking off
#define EntryModeSet_CMD 0x06 //Write left to right, entire display shift off
#define Clear_CMD 0x01
#define ShiftCursorLeft_CMD 0x10
#define ShiftCursorRight_CMD 0x14
#define ShiftDisplayLeft_CMD 0x18
#define ShiftDisplayRight_CMD 0x1C
#define GoToRow1_CMD 0x80
#define GoToRow2_CMD 0xC0
#define GoToRow3_CMD 0x90
#define GoToRow4_CMD 0xD0

char goTmrLcd = 0;

void initLcd(){
    TRISD = 0x00;
    TRISB = 0x00;
    PORTD = 0;
    PORTB = 0;
    initLcdTimer();
    
    //Reset lcd circuit
    sleepLcd(500);
    
    //Imposto 4 bit
    sendConfigSinglePulse(FunctionSet8Bit_CMD>>4);
    sendConfigSinglePulse(FunctionSet8Bit_CMD>>4);
    sendConfigSinglePulse(FunctionSet8Bit_CMD>>4);
    sendConfigSinglePulse(FunctionSet4Bit_CMD>>4);
    
    //Imposto il resto
    sendConfig(FunctionSet4Bit_CMD);
    
    //Imposto display on e cursore off
    sendConfig(SetDisplay_CMD);
    
    //Imposto direzione
    sendConfig(EntryModeSet_CMD);
    
    //Clear
    sendConfig(Clear_CMD);
}

void sendCommand(char rs, char rw, char db7, char db6, char db5, char db4){
    PORTD = 0;
    PORTB = 0;
    PORTDbits.RD4 = rs;
    PORTDbits.RD5 = rw;
    PORTDbits.RD6 = db7;
    PORTDbits.RD7 = db6;
    PORTDbits.RD8 = db5;
    PORTDbits.RD11 = db4;
    pulseE();
    if(rs == 1)
        sleepLcd(1);
    else
        sleepLcd(50);
    
    return;
}

void sendByte(char a, char b, char c, char d, char e, char f, char g, char h){
    sendCommand(1,0,a,b,c,d);
    sendCommand(1,0,e,f,g,h);
}

void sendConfig(char databits){
    sendCommand(0, 0, databits>>7&1, databits>>6&1, databits>>5&1, databits>>4&1);
    sendCommand(0, 0, databits>>3&1, databits>>2&1, databits>>1&1, databits&1);
}

void sendConfigSinglePulse(char databits){
    sendCommand(0, 0, databits>>3&1, databits>>2&1, databits>>1&1, databits&1);
}

void sendLetter(char databits){
    sendCommand(1, 0, databits>>7&1, databits>>6&1, databits>>5&1, databits>>4&1);
    sendCommand(1, 0, databits>>3&1, databits>>2&1, databits>>1&1, databits&1);
}

void goToRow(char n){
    switch(n){
        case 1: sendConfig(GoToRow1_CMD);
                break;
        case 2: sendConfig(GoToRow2_CMD);
                break;
        case 3: sendConfig(GoToRow3_CMD);
                break;
        case 4: sendConfig(GoToRow4_CMD);
                break;
        default: break;
    }
}

void clearLcd(){
    sendConfig(Clear_CMD);
}

void printString(char *str){
    char i = 0;
    while (str[i] != '\n') {
        sendLetter(str[i]);
        i++;
    }
}

void pulseE(){
    sleepLcd(10);
    PORTBbits.RB14 = 0;
    sleepLcd(10);
    PORTBbits.RB14 = 1;
    sleepLcd(10);
    PORTBbits.RB14 = 0;
    
    return;
}

void initLcdTimer(){
    T2CONbits.TON = 0;
    T2CONbits.TCKPS = 1; //Prescaler
    PR2 = 500;
    TMR2 = 0;

    IPC2bits.T2IP = 7;
    IPC2bits.T2IS = 1;
    IFS0bits.T2IF = 0;
    IEC0bits.T2IE = 1;

    INTCONSET = _INTCON_MVEC_MASK;  

    __builtin_enable_interrupts(); //Interruttore generale di tutti gli interrupt
}

void sleepLcd(int dms){ //Decimi di millisecondo
    TMR2 = 0;
    T2CONbits.TON = 1;
    int count = 0;
    while(count < dms)
        if(goTmrLcd){
            count++;
            goTmrLcd = 0;
        }
    T2CONbits.TON = 0;
}

void __ISR(_TIMER_2_VECTOR, IPL7SRS) T2Interrupt(void){
    goTmrLcd = 1;
    IFS0bits.T2IF = 0;
}