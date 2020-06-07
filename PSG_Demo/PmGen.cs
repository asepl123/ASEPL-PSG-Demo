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

    public enum EPMbw { NORMal, HIGH }
    public enum EPMNoise { GAUSsian, UNIForm }
    public enum EPMRamp { POSitive, NEGative }
    public enum EPMShape { SINE, TRIangle, SQUare, RAMP, NOISe, DUALsine, SWEPtsine }
    public enum EInt2shape { SINE, TRIangle, SQUare, RAMP, NOISe }
    public enum EPMSource { INT1, INT2, EXT1, EXT2 }

    #endregion enum

    [Display("PM Generation", Group: "PSG_Demo", Description: "Insert a description here")]
    public class PmGen : TestStep
    {
        #region Settings
        [Display("Instrument", Group: "Instrument Setting", Description: "Reset Network Analyzer", Order: 1.1)]
        public E8257D MyPSG { get; set; }

        [DisplayAttribute("PMpath", "", "Input Parameters", 2)]
        public uint PMpath { get; set; } = 1u;

        [DisplayAttribute("PMbw", "NORMal; HIGH", "Input Parameters", 2)]
        public EPMbw PMbw { get; set; } = EPMbw.NORMal;

        [Unit("RAD")]
        [DisplayAttribute("Deviation", "", "Input Parameters", 2)]
        public double Deviation { get; set; } = 25D;

        [DisplayAttribute("Intpath", "", "Input Parameters", 2)]
        public uint Intpath { get; set; } = 1u;

        [Unit("HZ")]
        [DisplayAttribute("IntFreq", "", "Input Parameters", 2)]
        public double IntFreq { get; set; } = 40D;

        [DisplayAttribute("PMNoise", "GAUSsian; UNIForm", "Input Parameters", 2)]
        public EPMNoise PMNoise { get; set; } = EPMNoise.UNIForm;

        [DisplayAttribute("PMRamp", "POSitive; NEGative ", "Input Parameters", 2)]
        public EPMRamp PMRamp { get; set; } = EPMRamp.POSitive;

        [DisplayAttribute("PMShape", "SINE; TRIangle; SQUare; RAMP; \r\nNOISe; DUALsine; SWEPtsine", "Input Parameters", 2)]
        public EPMShape PMShape { get; set; } = EPMShape.SINE;

        [DisplayAttribute("Int2shape", "SINE; TRIangle; SQUare; RAMP; NOISe", "Input Parameters", 2)]
        public EInt2shape Int2shape { get; set; } = EInt2shape.SINE;

        [DisplayAttribute("PMSource", "INT1; INT2; EXT1; EXT2", "Input Parameters", 2)]
        public EPMSource PMSource { get; set; } = EPMSource.INT1;
        #endregion

        public PmGen()
        {
            // ToDo: Set default values for properties / settings.
        }

        public override void Run()
        {
            // ToDo: Add test case code.
            RunChildSteps(); //If the step supports child steps.

            MyPSG.PmGeneration(PMpath, PMbw, Deviation, Intpath, IntFreq, PMNoise, PMRamp, PMShape, Int2shape, PMSource);
        }
    }
}
