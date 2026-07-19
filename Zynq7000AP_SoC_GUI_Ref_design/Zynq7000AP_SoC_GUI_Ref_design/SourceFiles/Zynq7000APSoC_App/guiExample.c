/*
 * Copyright (c) 2009-2012 Xilinx, Inc.  All rights reserved.
 *
 * Xilinx, Inc.
 * XILINX IS PROVIDING THIS DESIGN, CODE, OR INFORMATION "AS IS" AS A
 * COURTESY TO YOU.  BY PROVIDING THIS DESIGN, CODE, OR INFORMATION AS
 * ONE POSSIBLE   IMPLEMENTATION OF THIS FEATURE, APPLICATION OR
 * STANDARD, XILINX IS MAKING NO REPRESENTATION THAT THIS IMPLEMENTATION
 * IS FREE FROM ANY CLAIMS OF INFRINGEMENT, AND YOU ARE RESPONSIBLE
 * FOR OBTAINING ANY RIGHTS YOU MAY REQUIRE FOR YOUR IMPLEMENTATION.
 * XILINX EXPRESSLY DISCLAIMS ANY WARRANTY WHATSOEVER WITH RESPECT TO
 * THE ADEQUACY OF THE IMPLEMENTATION, INCLUDING BUT NOT LIMITED TO
 * ANY WARRANTIES OR REPRESENTATIONS THAT THIS IMPLEMENTATION IS FREE
 * FROM CLAIMS OF INFRINGEMENT, IMPLIED WARRANTIES OF MERCHANTABILITY
 * AND FITNESS FOR A PARTICULAR PURPOSE.
 *
 */

#include <stdio.h>
#include "platform.h"
#include "xparameters.h"
#include "xil_types.h"
#include "xuartps_hw.h"

//void print(char *str);
void strrev(char *p)
{
  char *q = p;
  while(q && *q) ++q;
  for(--q; p < q; ++p, --q)
    *p = *p ^ *q,
    *q = *p ^ *q,
    *p = *p ^ *q;
}

int main()
{
    u8 inputString[200];
    u8 *inputStrPtr = inputString;

	init_platform();
	xil_printf("GUI Example design\n\r");
	xil_printf("Receives the input string from GUI and sends back the reversed string\n\r");
    while(1)
    {
       inputStrPtr = inputString;
       do
       {
    	   *inputStrPtr = XUartPs_RecvByte(STDOUT_BASEADDRESS);
    	   if (*inputStrPtr == '\r')
    	   {
    		   break;
    	   }
    	   inputStrPtr++;
       }while(1);
       *inputStrPtr = '\0';
       strrev((char *)inputString);
       print((char *)inputString);

    }

    return 0;
}
