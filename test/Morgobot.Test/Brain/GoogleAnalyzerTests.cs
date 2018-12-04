using Dagon.Grammar;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Morgobot.Brain;

namespace Morgobot.Test.Brain
{
    [TestClass]
    public class GoogleAnalyzerTests
    {
        private GoogleAnalyzer _sut;

        [TestInitialize]
        public void Init()
        {
            _sut = new GoogleAnalyzer();
        }

        [TestMethod]
        public void AnalyzeTest()
        {
            var reply = _sut.Analyse(new Phrase("загугли монах"));
            reply.Should().Be("https://ru.wikipedia.org/wiki/Монах");
        }
    }
}
