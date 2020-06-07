using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using OpenTap;

//Note this template assumes that you have a SCPI based instrument, and accordingly
//extends the ScpiInstrument base class.

//If you do NOT have a SCPI based instrument, you should modify this instance to extend
//the (less powerful) Instrument base class.

namespace PSG_Demo
{
    [Display("E8257D", Group: "PSG_Demo", Description: "Insert a description here")]
    public class E8257D : ScpiInstrument
    {
        #region Settings
        // ToDo: Add property here for each parameter the end user should be able to change
        #endregion

        public E8257D()
        {
            Name = "E8257D";
            // ToDo: Set default values for properties / settings.
        }

        /// <summary>
        /// Open procedure for the instrument.
        /// </summary>
        public override void Open()
        {

            base.Open();
            // TODO:  Open the connection to the instrument here

            //if (!IdnString.Contains("Instrument ID"))
            //{
            //    Log.Error("This instrument driver does not support the connected instrument.");
            //    throw new ArgumentException("Wrong instrument type.");
            // }

        }

        /// <summary>
        /// Close procedure for the instrument.
        /// </summary>
        public override void Close()
        {
            // TODO:  Shut down the connection to the instrument here.
            base.Close();
        }

        public void ResetInstrument()
        {
            ScpiCommand("*RST");
            ScpiCommand("SYSTem:PRESet");
            ScpiCommand("*RST");
            ScpiCommand("*CLS");
            ScpiCommand("OUTP OFF");
            ScpiCommand("*OPC?");
        }

        public void SetRfPowerOnOff(string State)
        {
            if (State == "On")
            {
                ScpiCommand("OUTP ON");
            }
            else
            {
                ScpiCommand("OUTP OFF");
            }
            string scpiToSend = "*OPC?";
            ScpiQuery<bool>(scpiToSend);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="NoOfPoints"></param>
        /// <param name="StartPower"></param>
        /// <param name="StopPower"></param>
        /// <param name="SweepTime"></param>
        /// <param name="Generation"></param>
        /// <param name="Amplitude"></param>
        /// <param name="DwellTime"></param>
        /// <param name="StopFreq"></param>
        /// <param name="StartFreq"></param>
        /// <param name="ModeOfFreq"></param>
        /// <param name="SweepMode"></param>
        /// <param name="ListType"></param>
        public void SweepConfig(int NoOfPoints, double SweepTime, string Generation, double Amplitude, double DwellTime, double StopFreq, double StartFreq, string ModeOfFreq, string SweepMode, string ListType)
        {
            ScpiCommand(":SOURce:FREQuency:MODE " + ModeOfFreq); //SWEep; LIST
            ScpiCommand(":SOURce:LIST:TYPE " + ListType); //LIST; STEP
            ScpiCommand(":SOURce:SWEep:MODE " + SweepMode); //"AUTO; MANual"
            ScpiCommand(":SOURce:FREQuency:STARt " + StartFreq);
            ScpiCommand(":SOURce:FREQuency:STOP " + StopFreq);
            ScpiCommand(":SOURce:SWEep:POINts " + NoOfPoints); //"2 to 65535 "
            ScpiCommand(":SOURce:SWEep:DWELl " + DwellTime); //resolution of 0.0001sec
            ScpiCommand(":SOURce:POWer:LEVel:IMMediate:AMPLitude " + Amplitude);
            ScpiCommand(":SOURce:SWEep:GENeration " + Generation); //"ANALog; STEPped"
            ScpiCommand(":SOURce:SWEep:TIME " + SweepTime); //"10 ms to 99 seconds "
            ScpiCommand(":OUTPut:STATe ON");
        }


        public void AmGeneration(int AMpath, int InternalPath, string AmType, double InternalFreq, double CarrierFreq, string Noise, string ShapeOfFunc, string ramp, string AMmode, string Polarity, string Source)
        {
            ScpiCommand(":SOURce: AM" + AMpath + ":TYPE " + AmType);
            ScpiCommand(":SOURce: AM" + AMpath + ":INTernal" + InternalPath + ":FREQuency " + InternalFreq);
            ScpiCommand(":SOURce: AM" + AMpath + ":INTernal" + InternalPath + ":FUNCtion: NOISe " + Noise);
            ScpiCommand(":SOURce: AM" + AMpath + ":INTernal" + InternalPath + ":FUNCtion: RAMP " + ramp);
            ScpiCommand(":SOURce: AM" + AMpath + ":INTernal" + InternalPath + ":FUNCtion: SHAPe " + ShapeOfFunc);
            ScpiCommand(":SOURce: AM" + AMpath + ":MODE " + AMmode);
            ScpiCommand(":SOURce: AM" + AMpath + ":POLarity " + Polarity);
            ScpiCommand(":SOURce: AM" + AMpath + ":SOURce " + Source);
            ScpiCommand(":SOURce: FREQuency:FIXed " + CarrierFreq);
            ScpiCommand(":SOURce: AM" + AMpath + ":STATe 1");
        }


        public void FmGeneration(uint FMpath, double Deviation, uint IntPath, double IntFreq, EFMNoise FMNoise,
            EFMramp FMramp, EFMshape FMshape, EFMsource FMsource)
        {
            ScpiCommand(":SOURce:FM{0}:DEViation {1}", FMpath, Deviation);
            ScpiCommand(":SOURce:FM{0}:INTernal{1}:FREQuency {2}", FMpath, IntPath, IntFreq);
            ScpiCommand(":SOURce:FM{0}:INTernal{1}:FUNCtion:NOISe {2}", FMpath, IntPath, FMNoise);
            ScpiCommand(":SOURce:FM{0}:INTernal{1}:FUNCtion:RAMP {2}", FMpath, IntPath, FMramp);
            ScpiCommand(":SOURce:FM{0}:INTernal{1}:FUNCtion:SHAPe {2}", FMpath, IntPath, FMshape);
            ScpiCommand(":SOURce:FM{0}:SOURce {1}", FMpath, FMsource);
            ScpiCommand(":SOURce:FM{0}:STATe 1", FMpath);
        }

        public void PmGeneration(uint PMpath, EPMbw PMbw, double Deviation, uint Intpath, double IntFreq,
            EPMNoise PMNoise, EPMRamp PMRamp, EPMShape PMShape, EInt2shape Int2shape, EPMSource PMSource)
        {
            ScpiCommand(":SOURce:PM{0}:BANDwidth {1}", PMpath, PMbw);
            ScpiCommand(":SOURce:PM{0}:DEViation {1}", PMpath, Deviation);
            ScpiCommand(":SOURce:PM{0}:INTernal{1}:FREQuency {2}", PMpath, Intpath, IntFreq);
            ScpiCommand(":SOURce:PM{0}:INTernal{1}:FUNCtion:NOISe {2}", PMpath, Intpath, PMNoise);
            ScpiCommand(":SOURce:PM{0}:INTernal{1}:FUNCtion:RAMP {2}", PMpath, Intpath, PMRamp);
            ScpiCommand(":SOURce:PM{0}:INTernal{1}:FUNCtion:SHAPe {2}", PMpath, Intpath, PMShape);
            ScpiCommand(":SOURce:PM{0}:INTernal2:FUNCtion:SHAPe {1}", PMpath, Int2shape);
            ScpiCommand(":SOURce:PM{0}:SOURce {1}", PMpath, PMSource);
            ScpiCommand(":SOURce:PM{0}:STATe 1", PMpath);
        }

        public void PulseGeneration(EPolarity Polarity, double Delay, double Freq, double Period, double PWidth, EIntSource IntSource, string Source)
        {
            ScpiCommand(":SOURce:PULM:EXTernal:POLarity {0}", Polarity);
            ScpiCommand(":SOURce:PULM:INTernal:DELay {0}", Delay);
            ScpiCommand(":SOURce:PULM:INTernal:FREQuency {0}", Freq);
            ScpiCommand(":SOURce:PULM:INTernal:PERiod {0}", Period);
            ScpiCommand(":SOURce:PULM:INTernal:PWIDth {0}", PWidth);
            ScpiCommand(":SOURce:PULM:SOURce {0}", Source);
            ScpiCommand(":SOURce:PULM:SOURce:INTernal {0}", IntSource);
            ScpiCommand(":SOURce:PULM:STATe 1");
        }

        public void CW_Generation(double Power, double CWfreq)
        {
            ScpiCommand(":SOURce:POWer:LEVel:IMMediate:AMPLitude {0}", Power);
            ScpiCommand(":SOURce:FREQuency:CW {0}", CWfreq);
        }
    }
}
