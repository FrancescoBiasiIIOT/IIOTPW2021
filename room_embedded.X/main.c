#define PinguinoID 0x0B

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

/*0 = non sto ricevendo, il prossimo pacchetto dovrebbe contenere un id
  1 = ho ricevuto l'id, il prossimo pacchetto dovrebbe contenere il tipo di messaggio
  2 = il prossimo pacchetto va messo da parte*/
char protocolStep = 0;
char readID = 0;
char msgType = 0;
char msgContent[33];
char notForMe = 0;
char i = 0, j;

void initUART(void);

int main(void)
{
    initUART();
    
    int i;
    while(1){
        //U1TXREG = 0x56;
        for(i=0; i<100000; i++);
    }
}

void initUART(){
        //UART sending config
    U1MODEbits.BRGH = 0;
    U1BRG = 63;
    U1MODEbits.PDSEL = 0;
    U1MODEbits.STSEL = 0;
    U1STAbits.UTXEN = 1;
    
    //UART reception config
    IPC6bits.U1IP = 2;
    IFS0bits.U1RXIF = 0;
    U1STAbits.URXISEL = 0;
    IEC0bits.U1RXIE = 1;
    INTCONSET = _INTCON_MVEC_MASK;
    __builtin_enable_interrupts();
    U1STAbits.URXEN = 1;
    
    //UART1  module on
    U1MODEbits.ON = 1;
}

void __ISR(_UART_1_VECTOR, IPL2AUTO) U1RXInterrupt(void){
    if(IFS0bits.U1RXIF){
        char a = U1RXREG;
        switch(protocolStep){
            case 0: readID = a;
                    if(readID != PinguinoID)
                        notForMe = 1;
                    break;
            case 1: msgType = a;
                    break;
            default: msgContent[i] = a;
                     i++;
        }
        protocolStep++;
        if(i>32){
            protocolStep = 0;
            i = 0;
        }
        IFS0bits.U1RXIF = 0;
    }
}