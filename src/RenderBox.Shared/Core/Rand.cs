﻿using System;

namespace RenderBox.Core
{
    public static class Rand
    {
        private static Random _random = new Random(RandomizeSeed());

        public static void InitState(int seed)
        {
            _random = null;
            _random = new Random(seed);
        }

        public static int Int(int min, int max) => _random.Next(min, max);
        public static int Int() => Int(int.MinValue, int.MaxValue);

        public static double Double(double min, double max) => MathHelpres.Lerp(min, max, Double());
        public static double Double() => (double)Next() / int.MaxValue;  //random.NextDouble();

        public static float Float() => (float)Next() / int.MaxValue; //random.NextFloat();

        public static long Long(long min, long max) => MathHelpres.Lerp(min, max, Double());
        public static long Long() => Long(long.MinValue, long.MaxValue);

        public static int RandomizeSeed() => Guid.NewGuid().GetHashCode();
        public static void Reset() => _random = new Random(RandomizeSeed());

        private static int 
            x = RandomizeSeed(), 
            y = RandomizeSeed(), 
            z = RandomizeSeed(), 
            w = RandomizeSeed();

        private static int Next()
        {
            int t = x ^ (x << 11);
            x = y;
            y = z;
            z = w;
            return (w = (w ^ (w >> 19)) ^ (t ^ (t >> 8)));
        }
    }

    public static class RandomExtensions
    {
        public static float NextFloat(this Random random) => (float)random.NextDouble();
    }
}

