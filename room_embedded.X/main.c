#define PinguinoID 0x0B
#define GatewayID 0x64
#define PinguinoName "S1\n"

// DEVCFG3
#pragma config USERID = 0xFFFF          // Enter Hexadecimal value (Enter Hexadecimal value)

// DEVCFG2
#pragma config FPLLIDIV = DIV_2         // PLL Input Divider (2x Divider)
#pragma config FPLLMUL = MUL_20         // PLL Multiplier (20x Multiplier)
#pragma config UPLLIDIV = DIV_12        // USB PLL Input Divider (12x Divider)
#pragma config UPLLEN = OFF             // USB PLL Enable (Disabled and Bypassed)
#pragma config FPLLODIV = DIV_1         // System PLL Output Clock Divider (PLL Divide by 1)

// DEVCFG1
#pragma config FNOSC = PRIPLL           // Oscillator Selection Bits (Primary Osc w/PLL (XT+,HS+,EC+PLL))
#pragma config FSOSCEN = ON             // Secondary Oscillator Enable (Enabled)
#pragma config IESO = ON                // Internal/External Switch Over (Enabled)
#pragma config POSCMOD = HS             // Primary Oscillator Configuration (HS osc mode)
#pragma config OSCIOFNC = ON            // CLKO Output Signal Active on the OSCO Pin (Enabled)
#pragma config FPBDIV = DIV_8           // Peripheral Clock Divisor (Pb_Clk is Sys_Clk/8)
#pragma config FCKSM = CSDCMD           // Clock Switching and Monitor Selection (Clock Switch Disable, FSCM Disabled)
#pragma config WDTPS = PS1048576        // Watchdog Timer Postscaler (1:1048576)
#pragma config FWDTEN = OFF             // Watchdog Timer Enable (WDT Disabled (SWDTEN Bit Controls))

// DEVCFG0
#pragma config DEBUG = OFF              // Background Debugger Enable (Debugger is disabled)
#pragma config ICESEL = ICS_PGx2        // ICE/ICD Comm Channel Select (ICE EMUC2/EMUD2 pins shared with PGC2/PGD2)
#pragma config PWP = OFF                // Program Flash Write Protect (Disable)
#pragma config BWP = OFF                // Boot Flash Write Protect bit (Protection Disabled)
#pragma config CP = OFF                 // Code Protect (Protection Disabled)

#include <xc.h>
#include <sys/attribs.h>
#include "lcd.h"

////Variabili protocollo UART////
/*0 = non sto ricevendo, il prossimo pacchetto dovrebbe contenere un id
  1 = ho ricevuto l'id, il prossimo pacchetto dovrebbe contenere il tipo di messaggio
  2 = il prossimo pacchetto va messo da parte*/
char protocolStep = 0;
char readID = 0;
char msgType = 0;
unsigned char msgContent[35];
char notForMe = 0; //CALL AN AMBULANCE!!
int i = 0, j;
char uartJobNow = 0;
char processMsgFlag = 0;

////Variabili gestione display////
unsigned char timeLeftNum = 0; //Secondi rimanenti alla fine della lezione
unsigned char timeLeftStr[4];
char tmr3Count = 0;
char updateTimeFlag = 0;

////Variabili pulsante////
char btn, btn_old;
int n;

void initUART(void);
void processMsg();
void checkBtn();

int main(void)
{
    AD1PCFG = 0xFFFF;
    TRISBbits.TRISB1 = 1;
    OSCCONbits.PBDIV = 0;
    
    initLcd();
    initUART();
    initClassTimer();
    
    printString(PinguinoName);
    printString(" - AULA LIBERA\n");
    
    while(1){
        if(processMsgFlag){
            processMsgFlag = 0;
            processMsg();
        }
        if(updateTimeFlag){
            updateTime();
        }
        checkBtn();
    }
}

void updateTime() {
    if (timeLeftNum <= 1) {
        T3CONbits.TON = 0;
        TMR3 = 0;
        updateTimeFlag = 0;
        tmr3Count = 0;
        clearLcd();
        goToRow(1);
        printString(PinguinoName);
        printString(" - AULA LIBERA\n");
    } else {
        updateTimeFlag = 0;
        tmr3Count = 0;
        timeLeftNum--;
        convertDuration();
        goToRow(1);
        goToRow(4);
        printString(timeLeftStr);
        printString("m rimanenti  \n");
    }
    
    return;
}

void convertDuration() {
    if (timeLeftNum > 99) {
        timeLeftStr[0] = timeLeftNum / 100 + 48;
        timeLeftStr[1] = timeLeftNum / 10 % 10 + 48;
        timeLeftStr[2] = timeLeftNum % 10 + 48;
        timeLeftStr[3] = '\n';
    } else if (timeLeftNum > 9) {
        timeLeftStr[0] = timeLeftNum / 10 % 10 + 48;
        timeLeftStr[1] = timeLeftNum % 10 + 48;
        timeLeftStr[2] = '\n';
    } else {
        timeLeftStr[0] = timeLeftNum % 10 + 48;
        timeLeftStr[1] = '\n';
    }
    
    return;
}

void checkBtn() {
    btn = PORTBbits.RB1;
    if ((btn == 1) && (btn_old == 0)) {
        for (n = 0; n < 5000; n++);
        btn = PORTBbits.RB1;
        if ((btn == 1) && (btn_old == 0)) {
            while (uartJobNow != 0) {}
            uartJobNow = 1; //Sto inviando
            //Vedere protocollo - pulsante premuto
            U1TXREG = GatewayID; // Id destinatario
            U1TXREG = 0x02;
            U1TXREG = PinguinoID;
            U1TXREG = 0x0D;
            uartJobNow = 0; //Ho smesso di inviare
        }
    }

    btn_old = btn;
}

void initUART(){
    //UART sending config
    U1MODEbits.BRGH = 0;
    U1BRG = 63;
    U1MODEbits.PDSEL = 0;
    U1MODEbits.STSEL = 0;
    U1STAbits.UTXEN = 1;
    
    //UART reception config
    IPC6bits.U1IP = 7;
    IPC6bits.U1IS = 3;
    IFS0bits.U1RXIF = 0;
    U1STAbits.URXISEL = 0;
    IEC0bits.U1RXIE = 1;
    INTCONSET = _INTCON_MVEC_MASK;
    __builtin_enable_interrupts();
    U1STAbits.URXEN = 1;
    
    //UART1  module on
    U1MODEbits.ON = 1;
}

void resetProtocolSteps(){
    //Resetta variabili
    protocolStep = 0; //Contatore che mi dice che tipo di info sto per ricevere
    i = 0; //Contatore di quanti pacchetti ho ricevuto (dopo i primi due)
}

void fillDisplay(){
    clearLcd();
    int i, j;
    char teacher[17] = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
         topic[17] = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
    
    //Estrazione nome insegnante
    for(i=0; i<17; i++){
        teacher[i] = msgContent[i];
        if(msgContent[i] == '\n')
            break;
    }

    //Estrazione nome del corso
    for(j=i+1; j<i+18; j++){
        topic[j-(i+1)] = msgContent[j];
        if(msgContent[j] == '\n')
            break;
    }
    
    //Estrazione durata della lezione (minuti)
    timeLeftNum = msgContent[j+1];
    convertDuration(); //Sposta valore dalla globale timeLeftNum (char) alla globale timeLeftStr (array di char)
    
    goToRow(1);
    printString(PinguinoName);
    goToRow(2);
    printString(teacher);
    goToRow(3);
    printString(topic);
    goToRow(4);
    printString( timeLeftStr );
    printString("m rimanenti\n");
    
    //Avvia timer
    TMR3 = 0;
    tmr3Count = 0;
    T3CONbits.TON = 1;
}

void processMsg(){
    resetProtocolSteps();
    
    switch(msgType){
        case 0: fillDisplay();
                break;
        case 1:
                break;
        case 2:
                break;
        case 3:
                break;
        default: break;
    }
}

void initClassTimer(){
    T3CONbits.TON = 0;
    T3CONbits.TCKPS = 7; //Prescaler
    PR3 = 2000;
    TMR3 = 0;

    IPC3bits.T3IP = 7;
    IPC3bits.T3IS = 2;
    IFS0bits.T3IF = 0;
    IEC0bits.T3IE = 1;

    INTCONSET = _INTCON_MVEC_MASK;  

    __builtin_enable_interrupts(); //Interruttore generale di tutti gli interrupt
}

void processPackage(){
    //Come da doc, segnalo tramite questa variabile che sto ricevendo
    uartJobNow = 2;
    if(IFS0bits.U1RXIF){
        //Salvo il byte ricevuto
        char a = U1RXREG;
        
        switch(protocolStep){
            //Questo è il primo pacchetto che ricevo, quindi contiene l'id del destinatario
            case 0: readID = a;
                    if(readID != PinguinoID)
                        notForMe = 1;
                    break;
            //Questo è il secondo pacchetto che ricevo, quindi conterrà il tipo di messaggio
            case 1: msgType = a;
                    break;
            //Questo è il terzo (o successivo) pacchetto che ricevo, quindi fa parte del "body" del messagio.
            //Lo salvo in un array che analizzerò dopo.
            default: msgContent[i] = a;
                     i++;
                    
        }
        protocolStep++; 
        
        if( a == '\r' ){
            while(a=='\r')
                a = U1RXREG;
            //Se questa condizione è vera, vuol dire che ho ricevuto l'ultimo pacchetto.
            uartJobNow = 0; //Segnalo che ho smesso di ricevere
            if(notForMe)
                resetProtocolSteps();
            else{
                processMsgFlag = 1;
            }
        }
        
        IFS0bits.U1RXIF = 0;
    }
}

void __ISR(_UART_1_VECTOR, IPL7SRS) U1RXInterrupt(void){
    if(uartJobNow == 0 || uartJobNow == 2){
        //Pacchetto esterno
        processPackage();
    }
    else{
        //Pacchetto inviato da questa stessa scheda, da controllare
        //if(U1RXREG != U1TXREG)
            //Collisione!!
            //return;
    }
    IFS0bits.U1RXIF = 0;
}

void classTimerInterrupt(){ //Decimi di millisecondo
    if(tmr3Count < 10)
        tmr3Count++;
    else{ //È passato un minuto
        updateTimeFlag = 1;
    }
    
    return;
}

void __ISR(_TIMER_3_VECTOR, IPL7SRS) T3Interrupt(void){
    classTimerInterrupt();
    IFS0bits.T3IF = 0;
}
