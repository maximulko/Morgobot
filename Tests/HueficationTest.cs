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
        public void Test()
        {
            Assert.AreEqual("Хуёжик", _huefication.Huefy("Ножик"));
            Assert.AreEqual("Хуыква", _huefication.Huefy("Тыква"));
            Assert.AreEqual("Хуебо", _huefication.Huefy("Небо"));
            Assert.AreEqual("Хуяря", _huefication.Huefy("Харя"));

            Assert.AreEqual("Хуива", _huefication.HuefyPhrase("Иди выпей пива"));
        }
    }
}
