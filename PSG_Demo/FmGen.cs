// Author: MyName
// Copyright:   Copyright 2020 Keysight Technologies
//              You have a royalty-free right to use, modify, reproduce and distribute
//              the sample application files (and/or any modified version) in any way
//              you find useful, provided that you agree that Keysight Technologies has no
//              warranty, obligations or liability for any sample application files.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using OpenTap;

namespace PSG_Demo
{
    #region enum

    public enum EFMNoise { GAUSsian, UNIForm }
    public enum EFMramp {POSitive, NEGative }
    public enum EFMshape {SINE, TRIangle, SQUare, RAMP, NOISe, DUALsine, SWEPtsine }
    public enum EFMsource {INT1, INT2, EXT1, EXT2 }

    #endregion enum

    [Display("FM Generation", Group: "PSG_Demo", Description: "Insert a description here")]
    public class FmGen : TestStep
    {
        #region Settings
        [Display("Instrument", Group: "Instrument Setting", Description: "Reset Network Analyzer", Order: 1.1)]
        public E8257D MyPSG { get; set; }

        [Display("FMpath", "", "Input Parameters", 2)]
        public uint FMpath { get; set; } = 1u;

        [Unit("HZ")]
        [Display("Deviation", "", "Input Parameters", 2)]
        public double Deviation { get; set; } = 1000000D;

        [Display("IntPath", "", "Input Parameters", 2)]
        public uint IntPath { get; set; } = 1u;

        [Unit("HZ")]
        [Display("IntFreq", "", "Input Parameters", 2)]
        public double IntFreq { get; set; } = 2000D;

        [Display("FMNoise", "GAUSsian; UNIForm", "Input Parameters", 2)]
        public EFMNoise FMNoise { get; set; } = EFMNoise.UNIForm;

        [Display("FMramp", "POSitive; NEGative", "Input Parameters", 2)]
        public EFMramp FMramp { get; set; } = EFMramp.POSitive;

        [Display("FMshape", "SINE; TRIangle; SQUare; RAMP; NOISe; DUALsine; SWEPtsine", "Input Parameters", 2)]
        public EFMshape FMshape { get; set; } = EFMshape.DUALsine;

        [Display("FMsource", "INT1; INT2; EXT1; EXT2", "Input Parameters", 2)]
        public EFMsource FMsource { get; set; } = EFMsource.INT1;
        #endregion

        public FmGen()
        {
            // ToDo: Set default values for properties / settings.
        }

        public override void Run()
        {
            // ToDo: Add test case code.
            RunChildSteps(); //If the step supports child steps.

            MyPSG.FmGeneration(FMpath, Deviation, IntPath, IntFreq, FMNoise, FMramp, FMshape, FMsource);
        }
    }
}
