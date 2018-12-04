using Dagon.Grammar;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class PhraseTest
    {
        private Phrase _phrase;

        [TestInitialize]
        public void Init()
        {
            _phrase = new Phrase("первое   второе,третье, четвертое!пятое;шестое");
        }

        [TestMethod]
        public void HasWordTest()
        {
            Assert.AreEqual(true, _phrase.HasWord("первое"));
            Assert.AreEqual(true, _phrase.HasWord("второе"));
            Assert.AreEqual(true, _phrase.HasWord("третье"));
            Assert.AreEqual(true, _phrase.HasWord("четвертое"));
            Assert.AreEqual(true, _phrase.HasWord("пятое"));
            Assert.AreEqual(true, _phrase.HasWord("шестое"));
            Assert.AreEqual(false, _phrase.HasWord("седьмое"));
        }

        [TestMethod]
        public void HasAnyWordTest()
        {
            Assert.AreEqual(true, _phrase.HasAnyWord("первое", "второе"));
            Assert.AreEqual(false, _phrase.HasAnyWord("седьмое"));
            Assert.AreEqual(true, _phrase.HasAnyWord("седьмое", "четвертое"));
        }

        [TestMethod]
        public void ChatInvitationTest()
        {
            var phrase = new Phrase("https://t.me/joinchat/AAAAAEN6lWHMXNbNfeE1Sw");
            var lastWord = phrase.LastWord;
        }

        [TestMethod]
        public void IsFirstWordEqualsTrueTest()
        {
            var phrase = new Phrase("загугли дич");
            phrase.IsFirstWordEquals("загугли").Should().BeTrue();
        }

        [TestMethod]
        public void IsFirstWordEqualsFalseTest()
        {
            var phrase = new Phrase("загугли дич");
            phrase.IsFirstWordEquals("дич").Should().BeFalse();
        }

        [TestMethod]
        public void RemoveFirstWordTest()
        {
            var phrase = new Phrase("загугли дич");
            phrase.RemoveFirstWord().ToString().Should().Be("дич");
        }
    }
}
