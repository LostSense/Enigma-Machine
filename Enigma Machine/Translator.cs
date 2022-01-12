using System;
using System.Collections.Generic;
using System.Text;

namespace Enigma_Machine
{
    class Translator
    {
        private Enigma machine;
        public void Run(string message)
        {
            IniciateEnigma();
            int[] signals = ConverMessageIntoSignals(message);
            int[] encryptedSignals = GetSignalsFromEnigma(signals);
            string codeMessage = ConverSignalsIntoMessage(encryptedSignals);
            Console.WriteLine(codeMessage);
        }

        private int[] ConverMessageIntoSignals(string message)
        {
            
            int[] signals = new int[message.Length];
            for (int i = 0; i < message.Length; i++)
            {
                signals[i] = GetSignalCode(message[i]);
            }
            return signals;
        }

        private int GetSignalCode(char v)
        {
            string abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] letters = abc.ToCharArray();
            for (int i = 0; i < letters.Length; i++)
            {
                if(v == letters[i])
                {
                    return i;
                }
            }
            return 0;
        }

        private int[] GetSignalsFromEnigma(int[] signals)
        {
            int[] encryptedSignals = new int[signals.Length];
            for (int i = 0; i < encryptedSignals.Length; i++)
            {
                encryptedSignals[i] = machine.GetSignal(signals[i]);
            }
            return encryptedSignals;
        }

        private string ConverSignalsIntoMessage(int[] encryptedSignals)
        {
            string message = "";
            for (int i = 0; i < encryptedSignals.Length; i++)
            {
                message += GetLetterFromSignal(encryptedSignals[i]);
            }
            return message;
        }

        private string GetLetterFromSignal(int v)
        {
            string abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] letters = abc.ToCharArray();
            return letters[v].ToString();
        }

        private void IniciateEnigma()//TEST METHOD
        {
            machine = new Enigma(3);
            machine.IniciateRotor(0, "EKMFLGDQVZNTOWYHXUSPAIBRCJ", 'E');
            machine.IniciateRotor(1, "EKMFLGDQVZNTOWYHXUSPAIBRCJ", 'E');
            machine.IniciateRotor(2, "EKMFLGDQVZNTOWYHXUSPAIBRCJ", 'E');
            machine.InsertRotorsIntoMachine();
            machine.IniciateReflector("YRUHQSLDPXNGOKMIEBFZCWVJAT");
            // | AE | BF | CM | DQ | HU | JN | LX | PR | SZ | VW |
            machine.IniciateClems("ABCDEFGHIJKLMNOPQRSTUVWXYZ");

            machine.SetRotorPosition(0, 0);
            machine.SetRotorPosition(1, 0);
            machine.SetRotorPosition(2, 0);
        }

        
    }
}
