using Dagon.Grammar;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Morgobot.Brain;

namespace Morgobot.Test.Brain
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
            Assert.AreEqual("Хуёжик!", _huefication.Analyse(new Phrase("Ножик"), 0));
            Assert.AreEqual("Хуыква!", _huefication.Analyse(new Phrase("Тыква"), 0));
            Assert.AreEqual("Хуебо!", _huefication.Analyse(new Phrase("Небо"), 0));
            Assert.AreEqual("Хуяря!", _huefication.Analyse(new Phrase("Харя"), 0));
            Assert.AreEqual("Хуяль!", _huefication.Analyse(new Phrase("Рояль"), 0));
            Assert.AreEqual("Хуива!", _huefication.Analyse(new Phrase("Иди выпей пива"), 0));
            Assert.AreEqual("Хуя!", _huefication.Analyse(new Phrase("Аааааааааааааа"), 0));
        }

        [TestMethod]
        public void EmptyPhraseTest()
        {
            Assert.AreEqual(null, _huefication.Analyse(new Phrase("!!!!!"), 0));
        }
    }
}
