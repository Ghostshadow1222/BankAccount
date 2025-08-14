namespace BankAccount
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
        /// <exception cref="ArgumentException">Thrown when min is greater than max</exception>"
        public bool IsWithinRange(double value, double min, double max)
        {
            if (min > max)
            {
                throw new ArgumentException("Min cannot be greater than max.");
            }

            if (value >= min && value <= max)
            {
                return true;
            }
            return false;
        }
    }
}
