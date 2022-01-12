using System;
using System.Collections.Generic;
using System.Text;

namespace Enigma_Machine
{
    class ClemsArray
    {
        private string _abc;
        private string _swapedLetters;
        private int[] inputSignals;
        private int[] outputSignals;

        public ClemsArray(string abc, string swapedLetters)
        {
            _abc = abc;
            _swapedLetters = swapedLetters;
            inputSignals = new int[abc.Length];
        }
    }
}
