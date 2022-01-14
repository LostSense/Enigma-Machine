using System;
using System.Collections.Generic;
using System.Text;

namespace Enigma_Machine
{
    class ClemsArray
    {
        //rotor class got very good place at all elements in my logic. So i will use it as good part of code.
        //Bad example if your programm are long supported. Never do that. Make separated object Clems
        public Rotor _clems;
        private string _swapedLetters;
        private char[] _swapedLettersArray;

        public ClemsArray(string abc,params string[] swapedLetters)
        {
            GenerateStringOfSwapedLetters(abc, swapedLetters);
            IniciateClems();
        }

        private void IniciateClems()
        {
            _clems = new Rotor(_swapedLetters, 'A');
        }

        private void GenerateStringOfSwapedLetters(string abc, string[] swapedLetters)
        {
            _swapedLettersArray = abc.ToCharArray();
            if (swapedLetters.Length > 0)
            {
                for (int i = 0; i < swapedLetters.Length; i++)
                {
                    SwapLetters(swapedLetters[i]);
                }
                for (int i = 0; i < _swapedLettersArray.Length; i++)
                {
                    _swapedLetters += _swapedLettersArray[i];
                } 
            }
            else
            {
                _swapedLetters = abc;
            }
        }

        private void SwapLetters(string v)
        {
            char firstLetter = v[0];
            char secondLetter = v[1];
            int firstPlace = FindPlaceOfLetter(firstLetter);
            int secondPlace = FindPlaceOfLetter(secondLetter);
            _swapedLettersArray[firstPlace] = secondLetter;
            _swapedLettersArray[secondPlace] = firstLetter;
        }

        private int FindPlaceOfLetter(char v)
        {
            int place = 0;
            for (int i = 0; i < _swapedLettersArray.Length; i++)
            {
                if(_swapedLettersArray[i] == v)
                {
                    place = i;
                    break;
                }
            }
            return place;
        }
    }
}
