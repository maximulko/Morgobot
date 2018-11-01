using Dagon.Grammar;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Morgobot.Brain;

namespace Tests
{
    [TestClass]
    public class HueficationTest
    {
        private Huefication _huefication;

        [TestInitialize]
        public void Init()
        {
            _huefication = new Huefication();
        }

        [TestMethod]
        public void HuefyTest()
        {
            Assert.AreEqual("Хуёжик!", _huefication.Analyse(new Phrase("Ножик")));
            Assert.AreEqual("Хуыква!", _huefication.Analyse(new Phrase("Тыква")));
            Assert.AreEqual("Хуебо!", _huefication.Analyse(new Phrase("Небо")));
            Assert.AreEqual("Хуяря!", _huefication.Analyse(new Phrase("Харя")));
            Assert.AreEqual("Хуяль!", _huefication.Analyse(new Phrase("Рояль")));
            Assert.AreEqual("Хуива!", _huefication.Analyse(new Phrase("Иди выпей пива")));
            Assert.AreEqual("Хуя!", _huefication.Analyse(new Phrase("Аааааааааааааа")));
        }

        [TestMethod]
        public void EmptyPhraseTest()
        {
            Assert.AreEqual(null, _huefication.Analyse(new Phrase("!!!!!")));
        }
    }
}
