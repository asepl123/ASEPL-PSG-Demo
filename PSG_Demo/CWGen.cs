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
    [Display("CW Generation", Group: "PSG_Demo", Description: "Insert a description here")]
    public class CWGen : TestStep
    {
        #region Settings

        [Display("Instrument", Group: "Instrument Setting", Description: "Reset Network Analyzer", Order: 1.1)]
        public E8257D MyPSG { get; set; }

        [Unit("DBM")]
        [DisplayAttribute("Power", "", "Input Parameters", 2)]
        public double Power { get; set; } = 0D;

        [Unit("HZ")]
        [DisplayAttribute("CWfreq", "", "Input Parameters", 2)]
        public double CWfreq { get; set; } = 1000000000D;

        #endregion

        public CWGen()
        {
            // ToDo: Set default values for properties / settings.
        }

        public override void Run()
        {
            // ToDo: Add test case code.
            RunChildSteps(); //If the step supports child steps.

            MyPSG.CW_Generation(Power, CWfreq);
        }
    }
}
