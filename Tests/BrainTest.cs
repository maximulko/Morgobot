using Microsoft.VisualStudio.TestTools.UnitTesting;
using Morgobot.Brain;
using Moq;
using Morgobot.Brain.Movements;

namespace Tests
{
    [TestClass]
    public class BrainTest
    {
        private Brain _brain;
        private Mock<BasicThoughts> _basicThoughtsMock;
        private Mock<MovementThoughts> _movementThoughtsMock;
        private Mock<Huefication> _hueficationMock;

        [TestInitialize]
        public void Init()
        {
            _basicThoughtsMock = new Mock<BasicThoughts>();
            //_basicThoughtsMock.Setup(bt => bt.Analyse(It.IsAny<Phrase>())).Returns("Пожалуйста");


            _movementThoughtsMock = new Mock<MovementThoughts>();
            _hueficationMock = new Mock<Huefication>();

            _brain = new Brain(_basicThoughtsMock.Object, _movementThoughtsMock.Object, _hueficationMock.Object);
        }

        [TestMethod]
        public void BasicThoughtsTest()
        {
            //_brain.Analyse("спасибо", 0);
            //_basicThoughtsMock.Verify(bt=>bt.Analyse(It.IsAny<Phrase>()));
        }
    }
}
