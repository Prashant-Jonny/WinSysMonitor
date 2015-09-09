using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Speech.Synthesis;

namespace Jarvis
{
    class Program
    {
        /// <summary>
        /// Här händer allt det magiska!!!
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Detta kommer välkomna användaren med standardrösten.
            SpeechSynthesizer synth = new SpeechSynthesizer();
            //synth.Speak("Welcome, Simon. You are now using, Jarvis one point zero.");

            #region Performance Counters
            //Det här tar och skriver ut det nuvarande "Cpu load" i procent.
            PerformanceCounter perfCpuCount = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");

            //Det här tar och skriver ut det tillgängliga minnet på datorn.
            PerformanceCounter perfMemCount = new PerformanceCounter("Memory", "Available MBytes");

            //Skriver ut hur länge system har varit igång.
            PerformanceCounter perfUpTimeCount = new PerformanceCounter("System", "System Up Time");
            #endregion

            // Infinate while-loop
            while(true)
            {
                //Hämta de nuvarande performace värdena.
                int currentCpuPercentage = (int)perfCpuCount.NextValue();
                int currentAvailableMemory = (int)perfMemCount.NextValue();
                int currentSystemUptime = (int)perfUpTimeCount.NextValue();

                //Varje sekund printar programmet ut "Cpu load" i procent.
                Console.WriteLine("CPU Load        : {0}%", currentCpuPercentage);
                Console.WriteLine("Available Memory: {0}", currentAvailableMemory);
                Console.WriteLine("System Uptime   : {0}Minutes", currentSystemUptime);

                //Pratar med användaren med hjälp av text till röst om vad de nuvarande värdena är.
                string cpuLoadVocalMessage = string.Format("The current CPU Load is {0}%", currentCpuPercentage);
                string memAvailableVocalMessage = string.Format("You have {0} megabytes of available memory", currentAvailableMemory);
                string upTimeVocalMessage = string.Format("The system has been avtive for {0} minutes", currentSystemUptime);
                
                synth.Speak(cpuLoadVocalMessage);
                synth.Speak(memAvailableVocalMessage);
                synth.Speak(upTimeVocalMessage);

                Thread.Sleep(1000);

            } //Slutet av "loopen"
        }
    }
}
