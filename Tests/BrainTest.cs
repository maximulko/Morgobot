using Microsoft.VisualStudio.TestTools.UnitTesting;
using Morgobot.Brain;

namespace Tests
{
    [TestClass]
    public class BrainTest
    {
        private Brain _brain;

        [TestInitialize]
        public void Init()
        {
            _brain = new Brain(new BasicThoughts(), new MovementThoughts());
        }

        [TestMethod]
        public void BasicThoughtsTest()
        {
            Assert.AreEqual("Иди нахуй!", _brain.Analyse("Абырвалг"));
        }

        [TestMethod]
        public void MovementThoughtsTest()
        {
            Assert.AreEqual("Ок", _brain.Analyse("налево"));
        }
    }
}
