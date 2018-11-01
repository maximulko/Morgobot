using Microsoft.VisualStudio.TestTools.UnitTesting;
using Morgobot.Brain;
using Morgobot.Brain.Grammar;

namespace Tests
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
            Assert.AreEqual("Вечер в хату, часик в радость!", _basicThoughts.Analyse(new Phrase("start")));
        }

        [TestMethod]
        public void GuseTest()
        {
            Assert.AreEqual("Сам ты гусь!", _basicThoughts.Analyse(new Phrase("Привет гусь!")));
        }

        [TestMethod]
        public void FartTest()
        {
            Assert.AreEqual("\u2601", _basicThoughts.Analyse(new Phrase("пукни")));
        }

        [TestMethod]
        public void ThanksTest()
        {
            Assert.AreEqual("Пожалуйста", _basicThoughts.Analyse(new Phrase("спасибо")));
        }

        [TestMethod]
        public void HelloTest()
        {
            Assert.AreEqual("Привет, козлик!", _basicThoughts.Analyse(new Phrase("привет")));
        }

        [TestMethod]
        public void ThreeHundredTest()
        {
            Assert.AreEqual("Отсоси у тракториста!!! У ха ха ха ха!!!!", _basicThoughts.Analyse(new Phrase("300")));
            Assert.AreEqual("Отсоси у тракториста!!! У ха ха ха ха!!!!", _basicThoughts.Analyse(new Phrase("триста")));
        }

        [TestMethod]
        public void HorseTest()
        {
            Assert.AreEqual("Не брал я твоего коня!!!", _basicThoughts.Analyse(new Phrase("верни коня!")));
        }

        [TestMethod]
        public void BeerTest()
        {
            Assert.AreEqual("Пошли!", _basicThoughts.Analyse(new Phrase("пошли пить пиво!")));
            Assert.AreEqual("Давай!", _basicThoughts.Analyse(new Phrase("давай пить водку!")));
            Assert.AreEqual(null, _basicThoughts.Analyse(new Phrase("давай не пить водку!")));
        }

        [TestMethod]
        public void YesNoTest()
        {
            Assert.AreEqual("Пизда!", _basicThoughts.Analyse(new Phrase("ты дурак, да?")));
            Assert.AreEqual("Пидора ответ!", _basicThoughts.Analyse(new Phrase("никак нет!")));
        }

        [TestMethod]
        public void EmptyPhraseTest()
        {
            Assert.AreEqual(null, _basicThoughts.Analyse(new Phrase("!!!!!")));
        }
    }
}
