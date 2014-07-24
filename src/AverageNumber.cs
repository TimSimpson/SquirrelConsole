
using System;
using System.Collections.Generic;
using System.Text;

namespace DebugConsole
{
    public class AverageNumber
    {
        int count;
        int[] numbers;
        int index;
        int sum;

        public AverageNumber(int size)
        {
            count = size;
            index = 0;
            numbers = new int[size];
            sum = 0;
            for (int i = 0; i < count; i ++)
            {
                numbers[i] = 0;
            }
        }

        public void Add(int value)
        {
            numbers[index] = value;
            index ++;
            if (index >= count)
            {
                index = 0;
            }
            sum -= numbers[index];
            sum += value;
        }

        public int Average()
        {
            return sum / count;// ((double)sum / (double)count);
        }
    }
}
