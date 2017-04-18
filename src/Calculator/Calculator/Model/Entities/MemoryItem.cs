using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model.Entities
{
    internal class MemoryItem
    {
        private double memory;

        public double Memory => memory;

        public MemoryItem()
        {
            memory = 0;
        }

        public void AddMemory(double value)
        {
            memory += value;
        }

        public void SubMemory(double value)
        {
            memory -= value;
        }

        public void SaveToMemory(double value)
        {
            memory = value;
        }
    }
}
