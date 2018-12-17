using Microsoft.VisualStudio.TestTools.UnitTesting;
using Morgobot.Brain;
using Morgobot.Brain.Movements;
using System.Collections.Generic;
using FluentAssertions;
using Morgobot.Web.Brain;
using Morgobot.Web.Infrastructure;
using Morgobot.Test.Mocks;
using Morgobot.Brain.ContextAnalysers;

namespace Morgobot.Test.Brain
{
    [TestClass]
    public class BrainTest
    {
        private Morgobot.Brain.Brain _sut;

        [TestInitialize]
        public void Init()
        {
            var contextAnalysers = new List<IContextAnalyzer>
            {
                new SecretSantaAnalyzer()
            };

            var  analizers = new List<IAnalyzer>
            {
                new BasicAnalyzer(),
                new GoogleAnalyzer(),
                new Huefication(),
                new MovementAnalyzer(),
                new ContextSwitchAnalyzer(contextAnalysers, new PerChatCache(new MemoryCacheMock()))
            };

            _sut = new Morgobot.Brain.Brain(
                analizers,
                contextAnalysers,
                new ServiceMessageAnalysis()
            );
        }

        [TestMethod]
        public void ContextSwitchTest()
        {
            var r1 = _sut.Analyse("секретный санта", 0);
            r1.Text.Should().Be("Привет из санты");
            var result = _sut.Analyse("скажи контекст", 0);
            result.Text.Should().Be("Нет контекста");
        }

        [TestMethod]
        public void GoogleTest()
        {
            var result = _sut.Analyse("Загугли монах", 0);
            result.Text.Should().Be("https://uk.wikipedia.org/wiki/Чернець");
        }
    }
}
