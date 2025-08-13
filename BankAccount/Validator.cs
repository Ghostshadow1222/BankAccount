﻿namespace BankAccount
{
    public class Validator
    {
        /// <summary>
        /// Checks to ensure that value is within inclusive boundaries
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <param name="min">Minimum inclusive boundary</param>
        /// <param name="max">Maximum inclusive boundary</param>
        /// <returns></returns>
        public bool IsWithinRange(double value, double min, double max)
        {
            if (value < min)
            {
                return true;
            }
            if (value > max)
            {
                return true;
            }
            return false;
        }
    }
}
