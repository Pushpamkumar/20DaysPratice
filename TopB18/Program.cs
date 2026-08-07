using System;

namespace IndirectRecursionExercise
{
    public class AlternatingChain
    {
        /// <summary>
        /// Evaluates whether a number can reach zero starting from a positive-step transition.
        /// Applies a -2 step transition to drive the value toward zero before delegating to IsNegativeChain.
        /// </summary>
        /// <param name="n">The current integer value in the sequence.</param>
        /// <returns>True if the chain reaches zero; otherwise, false.</returns>
        public static bool IsPositiveChain(int n)
        {
            // Base Case 1: Target Reached
            if (n == 0)
            {
                return true;
            }

            // Base Case 2: Out of Bounds / Divergence Prevention
            if (n < 0)
            {
                return false;
            }

            // Indirect recursive call: Apply -2 step and transition to negative step state
            return IsNegativeChain(n - 2);
        }

        /// <summary>
        /// Evaluates whether a number can reach zero starting from a negative-step transition.
        /// Applies a +1 step transition before delegating back to IsPositiveChain.
        /// </summary>
        /// <param name="n">The current integer value in the sequence.</param>
        /// <returns>True if the chain reaches zero; otherwise, false.</returns>
        public static bool IsNegativeChain(int n)
        {
            // Base Case 1: Target Reached
            if (n == 0)
            {
                return true;
            }

            // Base Case 2: Out of Bounds / Divergence Prevention
            if (n < 0)
            {
                return false;
            }

            // Indirect recursive call: Apply +1 step and transition to positive step state
            return IsPositiveChain(n + 1);
        }
    }
}