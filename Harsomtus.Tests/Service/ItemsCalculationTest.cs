using Harsomtus.Helpers;
using NUnit.Framework;

namespace Harsomtus.Tests.Service
{
    [TestFixture]
    public class ItemsCalculationTest
    {
        /// <summary>
        /// Area size: 0x0
        /// Item size: 200x200
        /// Must be: 0
        /// </summary>
        [Test]
        public void Area_0x0_Item_200x200()
        {
            Assert.AreEqual(0, ItemsCalc.Calc(0, 0, 200, 200));
        }

        /// <summary>
        /// Area size: 200x200
        /// Item size: 200x200
        /// Must be: 1
        /// </summary>
        [Test]
        public void Area_200x200_Item_200x200()
        {
            Assert.AreEqual(1, ItemsCalc.Calc(200, 200, 200, 200));
        }

        /// <summary>
        /// Area size: 199x199
        /// Item size: 200x200
        /// Must be: 0
        /// </summary>
        [Test]
        public void Area_199x199_Item_200x200()
        {
            Assert.AreEqual(0, ItemsCalc.Calc(199, 199, 200, 200));
        }

        /// <summary>
        /// Area size: 1600x1600
        /// Item size: 200x200
        /// Must be: 0
        /// </summary>
        [Test]
        public void Area_1600x1600_Item_200x200()
        {
            Assert.AreEqual(64, ItemsCalc.Calc(1600, 1600, 200, 200));
        }
    }
}
