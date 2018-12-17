using Dagon.Grammar;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Morgobot.Brain;

namespace Morgobot.Test.Brain
{
    [TestClass]
    public class BasicAnalyzerTest
    {
        private BasicAnalyzer _basicThoughts;

        [TestInitialize]
        public void Init()
        {
            _basicThoughts = new BasicAnalyzer();
        }

        [TestMethod]
        public void StartTest()
        {
            Assert.AreEqual("Вечер в хату, часик в радость!", _basicThoughts.Analyse(new Phrase("start"), 0));
        }

        [TestMethod]
        public void GuseTest()
        {
            Assert.AreEqual("Сам ты гусь!", _basicThoughts.Analyse(new Phrase("Привет гусь!"), 0));
        }

        [TestMethod]
        public void FartTest()
        {
            Assert.AreEqual("\u2601", _basicThoughts.Analyse(new Phrase("пукни"), 0));
        }

        [TestMethod]
        public void ThanksTest()
        {
            Assert.AreEqual("Пожалуйста", _basicThoughts.Analyse(new Phrase("спасибо"), 0));
        }

        [TestMethod]
        public void HelloTest()
        {
            Assert.AreEqual("Привет, козлик!", _basicThoughts.Analyse(new Phrase("привет"), 0));
        }

        [TestMethod]
        public void ThreeHundredTest()
        {
            Assert.AreEqual("Отсоси у тракториста!!! У ха ха ха ха!!!!", _basicThoughts.Analyse(new Phrase("300"), 0));
            Assert.AreEqual("Отсоси у тракториста!!! У ха ха ха ха!!!!", _basicThoughts.Analyse(new Phrase("триста"), 0));
        }

        [TestMethod]
        public void HorseTest()
        {
            Assert.AreEqual("Не брал я твоего коня!!!", _basicThoughts.Analyse(new Phrase("верни коня!"), 0));
        }

        [TestMethod]
        public void BeerTest()
        {
            Assert.AreEqual("Пошли!", _basicThoughts.Analyse(new Phrase("пошли пить пиво!"), 0));
            Assert.AreEqual("Давай!", _basicThoughts.Analyse(new Phrase("давай пить водку!"), 0));
            Assert.AreEqual(null, _basicThoughts.Analyse(new Phrase("давай не пить водку!"), 0));
        }

        [TestMethod]
        public void YesNoTest()
        {
            Assert.AreEqual("Пизда!", _basicThoughts.Analyse(new Phrase("ты дурак, да?"), 0));
            Assert.AreEqual("Пидора ответ!", _basicThoughts.Analyse(new Phrase("никак нет!"), 0));
        }

        [TestMethod]
        public void EmptyPhraseTest()
        {
            Assert.AreEqual(null, _basicThoughts.Analyse(new Phrase("!!!!!"), 0));
        }
    }
}
