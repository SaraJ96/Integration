using System;
using System.Collections.Generic;
using System.Text;

namespace FTN.Common
{
	
	public enum DMSType : short
	{		
		MASK_TYPE							= unchecked((short)0xFFFF),

        //konkretne klase
        TERMINAL                            = 0x0001,
        REGULATINGCTRL                      = 0x0002,
        STATICVARCOMP                       = 0x0003,
        CONTROL                             = 0x0004,       
        REACTIVECAPABILITYCURVE             = 0x0005,
        SHUNTCOMP                           = 0x0006,
        SYNCHRONOUSMACHINE                  = 0x0007

		
	}


    //NASLEDJIVANJE 32 bita, DMSTYPE za apstr 0 za konkretnu njen dms 16, OPIS ATRIB ide redni broj, pa tip podatka

    [Flags]
	public enum ModelCode : long
	{
		IDOBJ								         = 0x1000000000000000,
        IDOBJ_MRID                                   = 0x1000000000000107,
        IDOBJ_GID                                    = 0x1000000000000204,

        PSR									         = 0x1100000000000000,
		
        TERMINAL                                     = 0x1200000000010000,
        TERMINAL_REGULATINGCTRL                      = 0x1200000000010119,

        CONTROL                                      = 0x1300000000020000,
        CONTROL_REGULATINGCONDEQ                     = 0x1300000000020109,

        CURVE                                        = 0x1400000000000000,

        REACTIVECAPABILITYCURVE                      = 0x1410000000040000,
        REACTIVECAPABILITYCURVE_SYNCMACH             = 0x1410000000040119,

        EQUIPMENT							         = 0x1110000000000000,
		EQUIPMENT_AGGREGATE 				         = 0x1110000000000101,
		EQUIPMENT_NORMALLYINSERVICE			         = 0x1110000000000201,	
        
        REGULATINGCTRL                               = 0x1120000000030000,
        REGULATINGCTRL_DISCRETE                      = 0x1120000000030101,
        REGULATINGCTRL_MODE                          = 0x112000000003020a,
        REGULATINGCTRL_MONITOREDPHASE                = 0x112000000003030a,
        REGULATINGCTRL_TARGETRANGE                   = 0x1120000000030405,
        REGULATINGCTRL_TARGETVALUE                   = 0x1120000000030505,
        REGULATINGCTRL_TERMINAL                      = 0x1120000000030609,
        REGULATINGCTRL_REGULATINGCONDEQ              = 0x1120000000030719,

        CONDEQ								         = 0x1111000000000000,
		
        REGULATINGCONDEQ                             = 0x1111100000000000,
        REGULATINGCONDEQ_REGULATINGCTRL              = 0x1111100000000109,
        REGULATINGCONDEQ_CTRL                        = 0x1111100000000219,

        ROTATINGMACHINE                              = 0x1111110000000000,

        SHUNTCOMP                                    = 0x1111120000050000,

        STATICVARCOMP                                = 0x1111130000060000,

        SYNCHRONOUSMACHINE                           = 0x1111111000070000,
        SYNCHRONOUSMACHINE_REACTIVECAPABILITYCURVE   = 0x1111111000070109,


    }






    [Flags]
	public enum ModelCodeMask : long
	{
		MASK_TYPE			 = 0x00000000ffff0000,
		MASK_ATTRIBUTE_INDEX = 0x000000000000ff00,
		MASK_ATTRIBUTE_TYPE	 = 0x00000000000000ff,

		MASK_INHERITANCE_ONLY = unchecked((long)0xffffffff00000000),
		MASK_FIRSTNBL		  = unchecked((long)0xf000000000000000),
		MASK_DELFROMNBL8	  = unchecked((long)0xfffffff000000000),		
	}																		
}


