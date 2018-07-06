using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EvosTest
{
    static class ExtFunk
    {
        /// <summary>
        /// Memoize function
        /// </summary>
        public static Func<A, R> Memoize<A, R>(this Func<A, R> f)
        {
            var map = new Dictionary<A, R>();

             Func<A, R> func = (x) =>
             {
            
                 if (map.TryGetValue(x, out R value))
                 {
                     return value;
                 }
                 value = f(x);
                 map.Add(x, value);
                 return value;
             };
             return func;
        }
    }

    public class Tribonacci
    {
        Func<BigInteger, BigInteger> fib = null;
        Func<int, BigInteger> fibMemoize = null;

        public Tribonacci()
        {
            fib = n => n > 2 ? fib(n - 1) + fib(n - 2) + fib(n - 3) : 1;

            fibMemoize = n => n > 2 ? fibMemoize(n - 1) + fibMemoize(n - 2) + fibMemoize(n - 3) : 1;
            fibMemoize = fibMemoize.Memoize();
        }

        /// <summary>
        /// Get value using recursive
        /// </summary>
        /// <param name="index">Position of element. Start from 0</param>
        /// <returns></returns>
        public BigInteger GetValueRecursive(int index)
        {
            if (index < 0)
            {
                throw new ArgumentException($"Input value must be greater than or equal to 0. Input value: {index}");
            }
            return fib(index);
        }

        /// <summary>
        /// Get value using recursive with Memoization
        /// </summary>
        /// <param name="index">Position of element. Start from 0</param>
        /// <returns></returns>
        public BigInteger GetValueRecursiveMemoize(int index)
        {
            if (index < 0)
            {
                throw new ArgumentException($"Input value be greater than or equal to 0. Input value: {index}");
            }
            return fibMemoize(index);
        }

        /// <summary>
        /// Get value using recursive with Memoization
        /// </summary>
        /// <param name="index">Position of element. Start from 0</param>
        /// <returns></returns>
        public BigInteger GetValueLoop(int index)
        {
            if (index < 0)
            {
                throw new ArgumentException($"Input value be greater than or equal to 0. Input value: {index}");
            }
            BigInteger value_1 = 1;
            BigInteger value_2 = 1;
            BigInteger value_3 = 1;
            BigInteger res = 1;
            for (int i = 2; i < index; i++)
            {
                res = value_1 + value_2 + value_3;
                value_1 = value_2;
                value_2 = value_3;
                value_3 = res;
            }
            return res;
        }

        /// <summary>
        /// Get a sequence of numbers
        /// </summary>
        /// <param name="indexStart">Index of the first number of the sequence</param>
        /// <param name="indexEnd"> Index of the last number of the sequence</param>
        /// <returns></returns>
        public IEnumerable<BigInteger> GetRange(int indexStart, int indexEnd)
        {
            if (indexStart > indexEnd)
            {
                throw new ArgumentException($"Error. {nameof(indexStart)} > {nameof(indexEnd)}");
            }
            if (indexStart < 0)
            {
                throw new ArgumentException($"Error. {nameof(indexStart)} must be greater than or equal to 0");
            }
            List<BigInteger> range = new List<BigInteger>();
            for (int i = indexStart; i <= indexEnd; i++)
            {
                range.Add(GetValueRecursiveMemoize(i));
            }
            return range;
        }

    }
}
