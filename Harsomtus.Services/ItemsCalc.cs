using System;

namespace Harsomtus.Services
{
    public static class ItemsCalc
    {
        /// <summary>
        /// Calculating items that can be placed on area
        /// </summary>
        /// <param name="aWidth">Area width</param>
        /// <param name="aHeight">Area height</param>
        /// <param name="iWidth">Item width</param>
        /// <param name="iHeight">Item height</param>
        /// <returns>Items count rounded down</returns>
        public static int Calc(double aWidth, double aHeight, double iWidth, double iHeight)
        {
            return (int)(Math.Floor(aWidth / iWidth) * Math.Floor(aHeight / iHeight));
        }
    }
}
