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
            Assert.AreEqual("Хуёжик!", _huefication.Analyse("Ножик"));
            Assert.AreEqual("Хуыква!", _huefication.Analyse("Тыква"));
            Assert.AreEqual("Хуебо!", _huefication.Analyse("Небо"));
            Assert.AreEqual("Хуяря!", _huefication.Analyse("Харя"));
            Assert.AreEqual("Хуяль!", _huefication.Analyse("Рояль"));
            Assert.AreEqual("Хуива!", _huefication.Analyse("Иди выпей пива"));
            Assert.AreEqual("Хуя!", _huefication.Analyse("Аааааааааааааа"));
        }
    }
}
