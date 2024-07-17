using System;
using System.Diagnostics;
using System.Drawing;
namespace TelCo.ColorCoder
{
    class Program
    {
        private static readonly Color[] colorMapMajor = { Color.White, Color.Red, Color.Black, Color.Yellow, Color.Violet };
        private static readonly Color[] colorMapMinor = { Color.Blue, Color.Orange, Color.Green, Color.Brown, Color.SlateGray };
        internal class ColorPair
        {
            internal Color majorColor, minorColor;
            public override string ToString() => $"MajorColor:{majorColor.Name}, MinorColor:{minorColor.Name}";
        }
        private static ColorPair GetColorFromPairNumber(int pairNumber)
        {
            if (pairNumber < 1 || pairNumber > colorMapMajor.Length * colorMapMinor.Length) { throw new ArgumentOutOfRangeException($"Argument PairNumber:{pairNumber} is outside the allowed range"); }
            int zeroBasedPairNumber = pairNumber - 1;
            return new ColorPair {majorColor = colorMapMajor[zeroBasedPairNumber / colorMapMinor.Length],minorColor = colorMapMinor[zeroBasedPairNumber % colorMapMinor.Length]};
        }
        private static int GetPairNumberFromColor(ColorPair pair)
        {
            int majorIndex = Array.IndexOf(colorMapMajor, pair.majorColor); int minorIndex = Array.IndexOf(colorMapMinor, pair.minorColor);
            if (majorIndex == -1 || minorIndex == -1) { throw new ArgumentException($"Unknown Colors: {pair}"); }
            return (majorIndex * colorMapMinor.Length) + (minorIndex + 1);
        }
        private static void Main(string[] args)
        {
            CalcPair(4, Color.White, Color.SlateGray);
            CalcPair(5,Color.White,Color.SlateGray);
            CalcPair(23,Color.Violet,Color.Green);
            ColorPair testPair2 = new ColorPair() { majorColor = Color.Yellow, minorColor = Color.Green };
            int pairNumber = Program.GetPairNumberFromColor(testPair2);
            Console.WriteLine("[In]Colors: {0}, [Out] PairNumber: {1}\n", testPair2, pairNumber);
            Debug.Assert(pairNumber == 18);
            testPair2 = new ColorPair() { majorColor = Color.Red, minorColor = Color.Blue };
            pairNumber = Program.GetPairNumberFromColor(testPair2);
            Console.WriteLine("[In]Colors: {0}, [Out] PairNumber: {1}", testPair2, pairNumber);
            Debug.Assert(pairNumber == 6);
        }
        private ColorPair CalcPair(int pairNumber,Color color1,Color color3)
        {
            ColorPair testPair1 = Program.GetColorFromPairNumber(pairNumber);
            Console.WriteLine("[In]Pair Number: {0},[Out] Colors: {1}\n", pairNumber, testPair1);
            Debug.Assert(testPair1.majorColor == color1); Debug.Assert(testPair1.minorColor == color3);
            return testPair1;
        }
    }
}
