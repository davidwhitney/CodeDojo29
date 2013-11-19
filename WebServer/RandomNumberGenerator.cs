using System;

namespace WebServer
{
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        private static readonly Random Random = new Random();

        public int GenerateRandomNumberBetweenZeroAndTwo()
        {
            return Random.Next(0, 3);
        }
    }
}