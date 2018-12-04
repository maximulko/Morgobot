using Microsoft.VisualStudio.TestTools.UnitTesting;
using Morgobot.Brain;
using Moq;
using Morgobot.Brain.Movements;
using System.Collections.Generic;

namespace Morgobot.Tests.Brain
{
    [TestClass]
    public class BrainTest
    {
        private Morgobot.Brain.Brain _brain;
        private Mock<BasicAnalyzer> _basicThoughtsMock;
        private Mock<MovementAnalyzer> _movementThoughtsMock;
        private Mock<Huefication> _hueficationMock;
        private Mock<ServiceMessageAnalysis> _serviceMessageAnalysis;

        [TestInitialize]
        public void Init()
        {
            _basicThoughtsMock = new Mock<BasicAnalyzer>();
            _movementThoughtsMock = new Mock<MovementAnalyzer>();
            _hueficationMock = new Mock<Huefication>();
            _serviceMessageAnalysis = new Mock<ServiceMessageAnalysis>();

            _brain = new Morgobot.Brain.Brain(new List<IAnalyzer>{ _basicThoughtsMock.Object, _movementThoughtsMock.Object, _hueficationMock.Object }, _serviceMessageAnalysis.Object);
        }

        [TestMethod]
        public void YoTest()
        {
            /*_brain.Analyse(Update.FromString(
                "{ " +
                    "'Message' : { " +
                        "'Test': 'вперёд', " +
                        "'message_id':'123', " +
                        "'date':'2018-11-01', " +
                        "'MessageType': 'TextMessage' " +
                    "}," +
                    "'Type': 'MessageUpdate'" +
                "}"));*/
            //_movementThoughtsMock.Verify(x => x.Analyse());
        }
    }
}
