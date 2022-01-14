using System;
using System.Collections.Generic;
using System.Text;
using static Enigma_Machine.Library;

namespace Enigma_Machine
{
    public class Rotor
    {
        private char[] inputChars;
        private char[] outputChars;
        private int[] inputSignalConnections;
        private int[] outputSignalConnections;
        private int rotorPosition;
        private int notchPosition;
        private string abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private char _rotorNotch;
        private bool rotorIsMain;
        private ExecuteSimpleMethod rotateNextRotorFunc;


        public Rotor(string rotorEncriptionType, char rotorNotch)
        {
            inputChars = SetCharsToRotorArray( abc);
            outputChars = SetCharsToRotorArray(rotorEncriptionType);
            IniciateInputSignalArray();
            IniciateOutputSignalArray();
            rotorPosition = 0;
            notchPosition = 0;
            _rotorNotch = rotorNotch;
            rotorIsMain = false;
        }

        private void IniciateOutputSignalArray()
        {
            outputSignalConnections = new int[outputChars.Length];
            for (int i = 0; i < outputChars.Length; i++)
            {
                outputSignalConnections[i] = FindPlaceOfCharInArray(outputChars[i]);
            }
        }

        private int FindPlaceOfCharInArray(char v)
        {
            for (int i = 0; i < inputChars.Length; i++)
            {
                if(inputChars[i] == v)
                {
                    return i;
                }
            }
            return 0;
        }

        private void IniciateInputSignalArray()
        {
            inputSignalConnections = new int[inputChars.Length];
            for (int i = 0; i < inputChars.Length; i++)
            {
                inputSignalConnections[i] = i;
            }
        }

        private char[] SetCharsToRotorArray(string rowOfChars)
        {
            return rowOfChars.ToCharArray();
        }

        public void AddNextRotor(Rotor rot2)
        {
            rotateNextRotorFunc = rot2.SwitchRotorPosition;
        }

        public void SetRotorAsMain()
        {
            rotorIsMain = true;
        }

        public void SetRotorPosition(int position)
        {
            rotorPosition -= position;
            if(rotorPosition < 0)
            {
                rotorPosition += abc.Length;
            }
            notchPosition = position;
            if(notchPosition >= abc.Length)
            {
                notchPosition -= abc.Length;
            }
        }

        public void SwitchRotorPosition()
        {
            if(inputChars[notchPosition] == _rotorNotch && rotateNextRotorFunc != null)
            {
                rotateNextRotorFunc();
            }
            rotorPosition--;
            if (rotorPosition < 0)
            {
                rotorPosition = abc.Length - 1;
            }
            notchPosition++;
            if(notchPosition >= abc.Length)
            {
                notchPosition = 0;
            }
        }

        public int PassSignalFromEnter(int signal)
        {
            if (rotorIsMain)
            {
                SwitchRotorPosition(); 
            }
            int realSignal;
            realSignal = GetInputSignalWithRotorPlace(signal);
            realSignal = outputSignalConnections[realSignal];
            realSignal = GetOutputSignalWithRotorPlace(realSignal);
            return realSignal;
        }

        public int PassSignalFromBackward(int signal)
        {
            int realSignal = GetInputSignalWithRotorPlace(signal);
            realSignal = FindPlaceOfBackwardSignal(realSignal);
            realSignal = GetOutputSignalWithRotorPlace(realSignal);
            return realSignal;
        }

        private int GetOutputSignalWithRotorPlace(int realSignal)
        {
            int temp = realSignal + rotorPosition;
            if(temp > 25)
            {
                temp -= inputChars.Length;
            }

            return temp;
        }

        private int GetInputSignalWithRotorPlace(int signal)
        {
            int temp = signal - rotorPosition;
            if(temp < 0)
            {
                temp += inputChars.Length;
            }
            return temp;
        }


        private int FindPlaceOfBackwardSignal(int realSignal)
        {
            for (int i = 0; i < outputSignalConnections.Length; i++)
            {
                if(outputSignalConnections[i] == realSignal)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
