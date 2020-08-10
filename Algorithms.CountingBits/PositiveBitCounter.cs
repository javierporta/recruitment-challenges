// <copyright file="PositiveBitCounter.cs" company="Payvision">
// Copyright (c) Payvision. All rights reserved.
// </copyright>

namespace Algorithms.CountingBits
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    public class PositiveBitCounter
    {
        public IEnumerable<int> Count(int input)
        {
            //Analyze edge ases
            if (input < 0)
            {
                throw new ArgumentException();
            } else if(input == 0)
            {
                return new List<int> { 0 };
            }

            var binary = Convert.ToString(input, 2);
            var reversedBinaryArray = ReverseStringToArray(binary);

            var countOfOnes = 0;
            var result = new List<int>();
            //NOte: As performance is important, I prefered to use my own loop instead of trusting linq methods
            for (int index = 0; index < reversedBinaryArray.Length; index++)
            {
                if(reversedBinaryArray[index] == '1') //comparing only chars (faster than comapring strings)
                {
                    result.Add(index);
                    countOfOnes++;
                }
            }

            //Add count at the beginning of the list
            result.Insert(0, countOfOnes);

            return  result;
        }

        private char[] ReverseStringToArray(string s)
        {
            char[] array = new char[s.Length];
            int forward = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                array[forward++] = s[i];
            }
            return array;
        }

    }
}
