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
    [Display("Reset E8257D", Group: "PSG_Demo", Description: "Insert a description here")]
    public class Reset8257D : TestStep
    {
        #region Settings

        [Display("Instrument", Group: "Instrument Setting", Description: "Reset Network Analyzer", Order: 1.1)]
        public E8257D MyPSG { get; set; }
        #endregion

        public Reset8257D()
        {
            // ToDo: Set default values for properties / settings.
        }

        public override void Run()
        {
            // ToDo: Add test case code.
            RunChildSteps(); //If the step supports child steps.
            MyPSG.ResetInstrument();
            Log.Info("PSG is successfully Reset");
        }
    }
}
