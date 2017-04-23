using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model.Entities
{
    /// <summary>
    /// MemoryItem class for work with memory functions
    /// </summary>
    internal class MemoryItem
    {
        private double memory;

        /// <summary>
        /// Getter for saved value
        /// </summary>
        public double Memory => memory;

        /// <summary>
        /// Constructor for create new MemoryItem object
        /// </summary>
        public MemoryItem()
        {
            memory = 0;
        }

        /// <summary>
        /// Addition value to memory
        /// </summary>
        /// <param name="value">value to add</param>
        public void AddMemory(double value)
        {
            memory += value;
        }

        /// <summary>
        /// Substract value from memory
        /// </summary>
        /// <param name="value">value to substraction</param>
        public void SubMemory(double value)
        {
            memory -= value;
        }

        /// <summary>
        /// Save new value to memory
        /// </summary>
        /// <param name="value">Value to save</param>
        public void SaveToMemory(double value)
        {
            memory = value;
        }
    }
}
