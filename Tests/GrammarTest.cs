using Microsoft.VisualStudio.TestTools.UnitTesting;
using Morgobot.Brain;

namespace Tests
{
    [TestClass]
    public class GrammarTest
    {
        private Grammar _grammar;

        [TestInitialize]
        public void Init()
        {
            _grammar = new Grammar();
        }

        [TestMethod]
        public void SplitByWordsTest()
        {
            CollectionAssert.AreEqual(new string[] {"первое", "второе", "третье", "четвертое", "пятое", "шестое"}, _grammar.SplitByWords("первое   второе,третье, четвертое!пятое;шестое"));
        }
    }
}
