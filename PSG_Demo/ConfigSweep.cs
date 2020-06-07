using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using OpenTap;

namespace PSG_Demo
{
    [Display("Configure Sweep", Group: "PSG_Demo", Description: "Insert a description here")]
    public class ConfigSweep : TestStep
    {
        #region Settings
        [Display("Instrument", Group: "Instrument Setting", Description: "Reset Network Analyzer", Order: 1.1)]
        public E8257D MyPSG { get; set; }

        [Display("Points", Group: "Inputs", Description: "No of Sweep Points", Order: 1.1)]
        public int NoOfPoints { get; set; }
        [Display("Sweep Time", Group: "Inputs", Description: "", Order: 1.1)]
        public double SweepTime { get; set; }
        [Display("Sweep Generation", Group: "Inputs", Description: "", Order: 1.1)]
        public string Generation { get; set; }
        [Display("Aplitude", Group: "Inputs", Description: "", Order: 1.1)]
        public double Amplitude { get; set; }
        [Display("Dwell Time", Group: "Inputs", Description: "", Order: 1.1)]
        public double DwellTime { get; set; }
        [Display("Start Frequency", Group: "Inputs", Description: "", Order: 1.1)]
        public double StartFreq { get; set; }
        [Display("Stop Frequency", Group: "Inputs", Description: "", Order: 1.1)]
        public double StopFreq { get; set; }
        [Display("Mode of Frequency", Group: "Inputs", Description: "", Order: 1.1)]
        public string ModeOfFreq { get; set; }
        [Display("Sweep Mode", Group: "Inputs", Description: "", Order: 1.1)]
        public string SweepMode { get; set; }
        [Display("List Type", Group: "Inputs", Description: "", Order: 1.1)]
        public string ListType { get; set; }

        #endregion

        public ConfigSweep()
        {
            // ToDo: Set default values for properties / settings.
        }

        public override void Run()
        {
            // ToDo: Add test case code.
            RunChildSteps(); //If the step supports child steps.

            MyPSG.SweepConfig(NoOfPoints, SweepTime, Generation, Amplitude, DwellTime, StopFreq, StartFreq, ModeOfFreq, SweepMode, ListType);
            // If no verdict is used, the verdict will default to NotSet.
            // You can change the verdict using UpgradeVerdict() as shown below.
            // UpgradeVerdict(Verdict.Pass);
        }
    }
}
