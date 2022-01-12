using System;
using System.Collections.Generic;
using System.Text;

namespace Enigma_Machine
{
    public class Enigma
    {
        private Rotor[] rotors;
        private Rotor reflector;
        private ClemsArray clems;
        public Enigma(int rotorAmount)
        {
            rotors = new Rotor[rotorAmount];
        }

        public void IniciateRotor(int rotorNum, string rotorType, char notch)
        {
            try
            {
                rotors[rotorNum] = new Rotor(rotorType, notch);
            }
            catch (Exception)
            {
                //this should be handled
            }
        }

        public void IniciateReflector(string reflectorType)
        {
            reflector = new Rotor(reflectorType, 'A');
        }

        public void IniciateClems(params string[] clemsType)
        {
            clems = new ClemsArray("ABCDEFGHIJKLMNOPQRSTUVWXYZ",clemsType);
        }

        public void SetRotorPosition(int rotorNum, int position)
        {
            rotors[rotorNum].SetRotorPosition(position);
        }

        public void InsertRotorsIntoMachine()
        {
            rotors[0].SetRotorAsMain();
            for (int i = 1; i < rotors.Length; i++)
            {
                rotors[i - 1].AddNextRotor(rotors[i]);
            }
        }

        public int GetSignal(int signal)
        {
            return StartEncryption(signal);
        }

        private int StartEncryption(int signal)
        {
            int a = signal;
            a = RunForwardThroughtClems(a);
            a = RunForwardThroughtRotors(a);
            a = RunForwardThroughtReflector(a);
            a = RunBackwardThroughtRotors(a);
            a = RunBackwardThroughtClems(a);
            return a;
        }

        private int RunForwardThroughtRotors(int code)
        {
            int operatingSingnal = code;
            for (int i = 0; i < rotors.Length; i++)
            {
                operatingSingnal = rotors[i].PassSignalFromEnter(operatingSingnal);
            }
            return operatingSingnal;
        }

        private int RunForwardThroughtReflector(int code)
        {
            return reflector.PassSignalFromEnter(code);
        }


        private int RunBackwardThroughtRotors(int code)
        {
            int operatingSingnal = code;
            for (int i = rotors.Length - 1; i >= 0; i--)
            {
                operatingSingnal = rotors[i].PassSignalFromBackward(operatingSingnal);
            }
            return operatingSingnal;
        }

        private int RunForwardThroughtClems(int code)
        {
            return clems._clems.PassSignalFromEnter(code);
        }

        private int RunBackwardThroughtClems(int code)
        {
            return clems._clems.PassSignalFromBackward(code);
        }

    }
}
