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
    [Display("AM Generation", Group: "PSG_Demo", Description: "Insert a description here")]
    public class AmGen : TestStep
    {
        #region Settings
        [Display("Instrument", Group: "Instrument Setting", Description: "Reset Network Analyzer", Order: 1.1)]
        public E8257D MyPSG { get; set; }

        [Display("AM Path", Group: "Input", Description: "1, 2", Order: 2.1)]
        public int AMpath { get; set; }
        [Display("Internal Path", Group: "Input", Description: "1, 2", Order: 2.1)]
        public int InternalPath { get; set; }
        [Display("Type of AM", Group: "Input", Description: "LINear; EXPonential", Order: 2.1)]
        public string AmType { get; set; }
        [Display("Internal Freq", Group: "Input", Description: "", Order: 2.1)]
        public double InternalFreq { get; set; }
        [Display("Carrier Freq", Group: "Input", Description: "", Order: 2.1)]
        public double CarrierFreq { get; set; }
        [Display("Noise", Group: "Input", Description: "GAUSsian; UNIForm ", Order: 2.1)]
        public string Noise { get; set; }
        [Display("Shape of Func", Group: "Input", Description: "SINE; TRIangle; SQUare; RAMP; NOISe; DUALsine; SWEPtsine", Order: 2.1)]
        public string ShapeOfFunc { get; set; }
        [Display("Ramp", Group: "Input", Description: "POSitive; NEGative ", Order: 2.1)]
        public string Ramp { get; set; }
        [Display("Mode of AM", Group: "Input", Description: "DEEP; NORMal", Order: 2.1)]
        public string AMmode { get; set; }
        [Display("Polarity of AM", Group: "Input", Description: "NORMal; INVerted", Order: 2.1)]
        public string Polarity { get; set; }
        [Display("Source of AM", Group: "Input", Description: "INT1; INT2; EXT1; EXT2", Order: 2.1)]
        public string Source { get; set; }

        #endregion

        public AmGen()
        {
            // ToDo: Set default values for properties / settings.
        }

        public override void Run()
        {
            // ToDo: Add test case code.
            RunChildSteps(); //If the step supports child steps.

            MyPSG.AmGeneration(AMpath, InternalPath, AmType, InternalFreq, CarrierFreq, Noise, ShapeOfFunc, Ramp, AMmode, Polarity, Source);
        }
    }
}
