using Num2Word.Service;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Num2Word.Tests
{
    public class Tests
    {
        private CoreService cs;

        public Tests()
        {
            cs = new CoreService();
        }

        [Test]
        [TestCase(123.45, "ONE HUNDRED AND TWENTY THREE DOLLARS AND FORTY-FIVE CENTS")]
        [TestCase(12.45, "TWELVE DOLLARS AND FORTY-FIVE CENTS")]
        [TestCase(1.45, "ONE DOLLAR AND FORTY-FIVE CENTS")]
        [TestCase(10, "TEN DOLLARS")]
        [TestCase(301.45, "THREE HUNDRED AND ONE DOLLARS AND FORTY-FIVE CENTS")]
        [TestCase(900.45, "NINE HUNDRED DOLLARS AND FORTY-FIVE CENTS")]
        [TestCase(0.45, "FORTY-FIVE CENTS")]
        public void Test_Convert(double Num, string Word)
        {
            string result = cs.Convert(Num);
            Assert.That(result.Equals(Word), $"Input: {Num}, Actual Result: {result}");
        }

        [TestCase(0)]
        [TestCase(-10)]
        [TestCase(1000)]
        [TestCase(1.345)]
        public void Test_NumOutOfRange(double Num)
        {
            Assert.Throws(typeof(Exception), () => { cs.Convert(Num); });
        }

        [Test]
        [TestCase(1.45, true)]
        [TestCase(1.4, true)]
        [TestCase(1.415, false)]
        public void Test_DoesNumHasTwoDecimalPlace(double Num, bool expectResult)
        {
            Assert.That(cs.DoesNumHasTwoDecimalPlace(Num) == expectResult);
        }

        [Test]
        [TestCase(12, " ", "TWELVE")]
        [TestCase(21, " ", "TWENTY ONE")]
        [TestCase(99, "-", "NINTY-NINE")]
        [TestCase(1, "-", "ONE")]
        [TestCase(0, "-", "")]
        public void Test_ConvertTensToWords(int tens, string concat, string expectResult)
        {
            Assert.That(cs.ConvertTensToWords(tens, concat).Equals(expectResult));
        }

        //public void Test_ConvertNumToWord()
        //{
        //    int num = 1;

        //    string strNum = num.ToString(); 
        //    string strNumPart = string.Empty;
        //    string[] strNumPartWord = new string[3];

        //    string result = string.Empty;

        //    //string strOnes = strNum.Substring(strNum.Length - 1, 1);

        //    for (int i = 0; i < strNum.Length; i++)
        //    {
        //        strNumPart = strNum.Substring((strNum.Length - 1 - i), 1);
        //        strNumPartWord[i] = cs.ReturnNumWord(int.Parse(strNumPart) * Convert.ToInt16(Math.Pow(10, i)));
        //        result += strNumPartWord;
        //    }

        //    if(!string.IsNullOrEmpty(strNumPartWord[2]))
        //    {
        //        result = 
        //    }
        //}
    }
}
