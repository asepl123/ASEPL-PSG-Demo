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
    public enum EPolarity { NORMal, INVerted }
    public enum EIntSource { SQUare, FRUN, TRIGgered, DOUBlet, GATEd }
    #endregion enum


    [Display("Pulse Generation", Group: "PSG_Demo", Description: "Insert a description here")]
    public class PulseGen : TestStep
    {
        #region Settings
        [Display("Instrument", Group: "Instrument Setting", Description: "Reset Network Analyzer", Order: 1.1)]
        public E8257D MyPSG { get; set; }


        [Display("polarity", "NORMal; INVerted", "Input Parameters", 2)]
        public EPolarity Polarity { get; set; } = EPolarity.NORMal;

        [Unit("SEC")]
        [Display("Delay", "", "Input Parameters", 2)]
        public double Delay { get; set; } = 2E-07D;

        [Unit("Hz")]
        [Display("Freq", "", "Input Parameters", 2)]
        public double Freq { get; set; } = 1000000D;

        [Unit("SEC")]
        [Display("Period", "", "Input Parameters", 2)]
        public double Period { get; set; } = 0.5D;

        [Unit("SEC")]
        [Display("PWidth", "", "Input Parameters", 2)]
        public double PWidth { get; set; } = 0.1D;

        [Display("IntSource", "SQUare; FRUN; TRIGgered; DOUBlet; GATEd", "Input Parameters", 2)]
        public EIntSource IntSource { get; set; } = EIntSource.SQUare;

        //  INTernal; EXTernal; SCALar
        private String Source = "INTernal";
        #endregion

        public PulseGen()
        {
            // ToDo: Set default values for properties / settings.
        }

        public override void Run()
        {
            // ToDo: Add test case code.
            RunChildSteps(); //If the step supports child steps.

            MyPSG.PulseGeneration(Polarity, Delay, Freq, Period, PWidth, IntSource, Source);

            // If no verdict is used, the verdict will default to NotSet.
            // You can change the verdict using UpgradeVerdict() as shown below.
            // UpgradeVerdict(Verdict.Pass);
        }
    }
}
