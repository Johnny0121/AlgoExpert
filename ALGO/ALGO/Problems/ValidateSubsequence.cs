using System;
using System.Collections.Generic;
using System.Text;

namespace ALGO.Problems
{
    // Problem: https://gyazo.com/2117a2d70b74bb53415328b14343b21d
    public class ValidateSubsequence : IProblem
    {
        private List<int> Array;
        private List<int> Sequence;

        public ValidateSubsequence()
        {
            Array = new List<int>() { 5, 1, 22, 25, 6, -1, 8, 10 };
            Sequence = new List<int>() { 22, 25, 6 };
        }

        public void Run()
        {
            Console.WriteLine($"For Loop Method: {ForLoopMethod(Array, Sequence)}");
            Console.WriteLine($"While Loop Method: {WhileLoopMethod(Array, Sequence)}");
        }

        public bool ForLoopMethod(List<int> array, List<int> sequence)
        {
            for (int i = 0; i < array.Count; i++)
            {
                if (sequence.Count > 0 && array[i] == sequence[0])
                {
                    sequence.RemoveAt(0);
                }
            }

            if (sequence.Count > 0)
            {
                return false;
            }

            return true;
        }

        public bool WhileLoopMethod(List<int> array, List<int> sequence) {
            int arrayPointer = 0;
            int sequencePointer = 0;

            while (arrayPointer < array.Count && sequencePointer < sequence.Count)
            {
                if (array[arrayPointer] == sequence[sequencePointer])
                {
                    sequencePointer++;
                }

                arrayPointer++;
            }

            return sequencePointer == sequence.Count;
        }
    }
}
