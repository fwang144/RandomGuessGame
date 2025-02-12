using System;

namespace Random.Services
{
    public class RandomService
    {
        public bool IsEasyRandom(int candidate)
        {

            return candidate <= 10;
            
        }

        public bool IsMediumRandom(int candidate)
        {

            return candidate <= 100;
            
        }

        public bool IsHardRandom(int candidate)
        {

            return candidate <= 1000;
            
        }
    }
}
