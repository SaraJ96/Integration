using System;

namespace FTN.Common
{	
	public enum PhaseCode : short
	{
		Unknown = 0x0,
		N = 0x1,
		C = 0x2,
		CN = 0x3,
		B = 0x4,
		BN = 0x5,
		BC = 0x6,
		BCN = 0x7,
		A = 0x8,
		AN = 0x9,
		AC = 0xA,
		ACN = 0xB,
		AB = 0xC,
		ABN = 0xD,
		ABC = 0xE,
		ABCN = 0xF
	}
   

    
    public enum RegulatingControlModeKind : short 
    {
        Voltage = 0,
        ActivePower = 1,
        ReactivePower = 2,
        CurrentFlow = 3,
        Fixed = 4, 
        Admittance = 5,
        TimeScheduled = 6,
        Temperature = 7,
        PowerFactor = 8

    }
}
