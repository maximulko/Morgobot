using Microsoft.VisualStudio.TestTools.UnitTesting;
using Morgobot.Brain;
using Morgobot.Brain.Movements;
using System.Collections.Generic;
using FluentAssertions;
using Morgobot.Web.Brain;
using Morgobot.Web.Infrastructure;
using Morgobot.Test.Mocks;
using Morgobot.Brain.ContextAnalysers;
using Morgobot.Infrastructure;
using Telegram.Bot.Types.Enums;

namespace Morgobot.Test.Brain
{
    [TestClass]
    public class BrainTest
    {
        private Morgobot.Brain.Brain _sut;

        [TestInitialize]
        public void Init()
        {
            IPerChatCache perChatCache = new PerChatCache(new MemoryCacheMock());

            var contextAnalysers = new List<IContextAnalyzer>
            {
                new SecretSantaAnalyzer(perChatCache)
            };

            var  analizers = new List<IAnalyzer>
            {
                new BasicAnalyzer(),
                new GoogleAnalyzer(),
                new Huefication(),
                new MovementAnalyzer(),
                new ContextSwitchAnalyzer(contextAnalysers, perChatCache)
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
            var response = _sut.Analyse("секретный санта", 0);
            response.Text.Should().Be("Скажи кто ты");
            response.ClenUpCurrentContext.Should().BeFalse();

            response = _sut.Analyse("Антон", 0, MessageType.Text, "SecretSanta");
            response.Text.Should().Be("Скажи кого ты любишь");
            response.ClenUpCurrentContext.Should().BeFalse();

            response = _sut.Analyse("Света", 0, MessageType.Text, "SecretSanta");
            response.Text.Should().Be("Скажи свой вишлист");
            response.ClenUpCurrentContext.Should().BeFalse();

            response = _sut.Analyse("настолки", 0, MessageType.Text, "SecretSanta");
            response.Text.Should().Be("Спасибо!");
            response.ClenUpCurrentContext.Should().BeTrue();
        }

        [TestMethod]
        public void GoogleTest()
        {
            var result = _sut.Analyse("Загугли монах", 0);
            result.Text.Should().Be("https://uk.wikipedia.org/wiki/Чернець");
        }
    }
}
