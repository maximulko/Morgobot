using Dagon.Grammar;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Morgobot.Test.Grammar
{
    [TestClass]
    public class WordTest
    {
        private Word _word;

        [TestInitialize]
        public void Init()
        {
            _word = new Word("первое");
        }

        [TestMethod]
        public void FindFirstVowelTest()
        {
            Assert.AreEqual(1, _word.FindFirstVowelIndex());
        }

        [TestMethod]
        public void IsVowelTest()
        {
            Assert.AreEqual(false, _word.IsVowel(2));
            Assert.AreEqual(true, _word.IsVowel(4));
        }

        [TestMethod]
        public void LengthTest()
        {
            Assert.AreEqual(6, _word.Length);
        }

        [TestMethod]
        public void SubstringTest()
        {
            Assert.AreEqual("ерв", _word.Substring(1,3));
        }

        [TestMethod]
        public void HasEnglishLettersTrueTest()
        {
            var sut = new Word("Приветa");
            sut.HasEnglisLetters().Should().BeTrue();
        }

        [TestMethod]
        public void HasEnglishLettersFalseTest()
        {
            var sut = new Word("Привет");
            sut.HasEnglisLetters().Should().BeFalse();
        }
    }
}
