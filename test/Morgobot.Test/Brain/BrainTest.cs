using Microsoft.VisualStudio.TestTools.UnitTesting;
using Morgobot.Brain;
using Morgobot.Brain.Movements;
using System.Collections.Generic;
using FluentAssertions;

namespace Morgobot.Test.Brain
{
    [TestClass]
    public class BrainTest
    {
        private Morgobot.Brain.Brain _sut;

        [TestInitialize]
        public void Init()
        {

            _sut = new Morgobot.Brain.Brain(
            new List<IAnalyzer>
            {
                new BasicAnalyzer(),
                new GoogleAnalyzer(),
                new Huefication(),
                new MovementAnalyzer()
            },
            new ServiceMessageAnalysis());
        }

        [TestMethod]
        public void GoogleTest()
        {
            var result = _sut.Analyse("Загугли монах", 0);
            result.Should().Be("https://ru.wikipedia.org/wiki/Монах");
        }
    }
}
