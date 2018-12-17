using Dagon.Grammar;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Morgobot.Test.Grammar
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
            _phrase.HasWord("первое").Should().BeTrue();
            _phrase.HasWord("второе").Should().BeTrue();
            _phrase.HasWord("третье").Should().BeTrue();
            _phrase.HasWord("четвертое").Should().BeTrue();
            _phrase.HasWord("пятое").Should().BeTrue();
            _phrase.HasWord("шестое").Should().BeTrue();
            _phrase.HasWord("седьмое").Should().BeFalse();
        }

        [TestMethod]
        public void HasAnyWordTest()
        {
            _phrase.HasAnyWord("первое", "второе").Should().BeTrue();
            _phrase.HasAnyWord("седьмое").Should().BeFalse();
            _phrase.HasAnyWord("седьмое", "четвертое").Should().BeTrue();
        }

        [TestMethod]
        public void HasAllWordTest()
        {
            _phrase.HasAllWords("первое", "второе").Should().BeTrue();
            _phrase.HasAllWords("седьмое").Should().BeFalse();
            _phrase.HasAllWords("седьмое", "четвертое").Should().BeFalse();

            new Phrase("скажи контекст").HasAllWords("скажи", "контекст").Should().BeTrue();
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
