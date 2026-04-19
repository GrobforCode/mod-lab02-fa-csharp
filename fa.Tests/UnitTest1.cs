using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using fans;
namespace NET
    {
    [TestClass]
    public class UnitTest1
    {
        // Тесты для FA1 (ровно один '0' и хотя бы одна '1')
        [TestMethod]
        public void FA1_Test1_Valid()  // 0111
        {
            String s = "0111";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }

        [TestMethod]
        public void FA1_Test2_TwoZeros()  // 01011
        {
            String s = "01011";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }

        [TestMethod]
        public void FA1_Test3_ThreeZeros()  // 110101011
        {
            String s = "110101011";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }

        [TestMethod]
        public void FA1_Test4_Valid2()  // 1110111
        {
            String s = "1110111";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }

        [TestMethod]
        public void FA1_Test5_ValidMinimal()  // 10
        {
            String s = "10";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }

        [TestMethod]
        public void FA1_Test6_OnlyOne()  // 1 (нет нуля)
        {
            String s = "1";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }

        [TestMethod]
        public void FA1_Test7_OnlyZero()  // 0 (нет единиц)
        {
            String s = "0";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }

        [TestMethod]
        public void FA1_Test8_EmptyString()  // пустая строка
        {
            String s = "";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }

        [TestMethod]
        public void FA1_Test9_InvalidSymbol()  // недопустимый символ '2'
        {
            String s = "1012";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsNull(result);
        }

        // Тесты для FA2 (нечетное число 0 и нечетное число 1)
        [TestMethod]
        public void FA2_Test1_False()  // 0101 (чёт/чёт)
        {
            String s = "0101";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }

        [TestMethod]
        public void FA2_Test2_False2()  // 00110011 (чёт/чёт)
        {
            String s = "00110011";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }

        [TestMethod]
        public void FA2_Test3_True()  // 0001 (нечет/нечет)
        {
            String s = "0001";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }

        [TestMethod]
        public void FA2_Test4_True2()  // 111000 (нечет/нечет)
        {
            String s = "111000";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }

        [TestMethod]
        public void FA2_Test5_EmptyString()  // пустая (чёт/чёт) -> false
        {
            String s = "";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }

        [TestMethod]
        public void FA2_Test6_SingleZero()  // "0" (нечет/чёт) -> false
        {
            String s = "0";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }

        [TestMethod]
        public void FA2_Test7_SingleOne()  // "1" (чёт/нечет) -> false
        {
            String s = "1";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }

        [TestMethod]
        public void FA2_Test8_InvalidSymbol()  // "0102"
        {
            String s = "0102";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.IsNull(result);
        }

        // Тесты для FA3 (содержит "11")
        [TestMethod]
        public void FA3_Test1_True()  // 00110011
        {
            String s = "00110011";
            FA3 fa = new FA3();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }

        [TestMethod]
        public void FA3_Test2_False()  // 0101
        {
            String s = "0101";
            FA3 fa = new FA3();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }

        [TestMethod]
        public void FA3_Test3_MinimalTrue()  // "11"
        {
            String s = "11";
            FA3 fa = new FA3();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }

        [TestMethod]
        public void FA3_Test4_NoConsecutiveOnes()  // "1010"
        {
            String s = "1010";
            FA3 fa = new FA3();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }

        [TestMethod]
        public void FA3_Test5_EmptyString()  // ""
        {
            String s = "";
            FA3 fa = new FA3();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }

        [TestMethod]
        public void FA3_Test6_InvalidSymbol()  // "11a"
        {
            String s = "11a";
            FA3 fa = new FA3();
            bool? result = fa.Run(s);
            Assert.IsNull(result);
        }
    }
}
