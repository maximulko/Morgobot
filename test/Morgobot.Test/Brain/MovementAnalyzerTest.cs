using Dagon.Grammar;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Morgobot.Brain.Movements;

namespace Morgobot.Test.Brain
{
    [TestClass]
    public class MovementAnalyzerTest
    {
        private MovementAnalyzer _movementThoughts;

        [TestInitialize]
        public void Init()
        {
            _movementThoughts = new MovementAnalyzer();
        }

        [TestMethod]
        public void BeerGameTest()
        {
            Assert.AreEqual("Я в зале, тут тепло и кроватка.", _movementThoughts.Analyse(new Phrase("где ты"), 0));
            Assert.AreEqual("Поднимаю подушку и вижу под ней забытую бутылку пива, которую хотел выпить на ночь. Ура! Я нашел 1 из 7 пив!", _movementThoughts.Analyse(new Phrase("посмотри под подушкой"), 0));
            Assert.AreEqual("Я в коридоре, ничего интересного. На полу лежит ковер.", _movementThoughts.Analyse(new Phrase("назад"), 0));
            Assert.AreEqual("Поднимаю ковер и вижу что что-то блеснуло. Это пиво! Ура! Я нашел 2 из 7 пив!", _movementThoughts.Analyse(new Phrase("посмотри под ковром"), 0));
            Assert.AreEqual("Я в кладовке, темно и уютно.", _movementThoughts.Analyse(new Phrase("налево"), 0));
            Assert.AreEqual("В темноте я вижу кучу пустых бутылок. Порывшись в ней я нахжу одну полную. Ура! Я нашел 3 из 7 пив!", _movementThoughts.Analyse(new Phrase("включи свет"), 0));
            Assert.AreEqual("Я в коридоре, ничего интересного. На полу лежит ковер.", _movementThoughts.Analyse(new Phrase("направо"), 0));
            Assert.AreEqual("Не пойду, лифт не работает!", _movementThoughts.Analyse(new Phrase("назад"), 0));
            Assert.AreEqual("Я в ванной, горячей воды нет.", _movementThoughts.Analyse(new Phrase("направо"), 0));
            Assert.AreEqual("Лежит, охлаждается. Ура! Я нашел 4 из 7 пив!", _movementThoughts.Analyse(new Phrase("посмотри в ванне"), 0));
            Assert.AreEqual("Я в туалете, не мешай!", _movementThoughts.Analyse(new Phrase("вперед"), 0));
            Assert.AreEqual("Лежит, охлаждается. Ура! Я нашел 5 из 7 пив!", _movementThoughts.Analyse(new Phrase("посмотри в унитазе"), 0));
            Assert.AreEqual("Я на кухне, тут есть холодильник и комп.", _movementThoughts.Analyse(new Phrase("вперед"), 0));
            Assert.AreEqual("Где ж еще ему быть. Ура! Я нашел 6 из 7 пив!", _movementThoughts.Analyse(new Phrase("посмотри в холодильнике"), 0));
            Assert.AreEqual("Я на балконе, можно покурить.", _movementThoughts.Analyse(new Phrase("вперед"), 0));
            Assert.AreEqual("Не стОит.", _movementThoughts.Analyse(new Phrase("вперед"), 0));
            Assert.AreEqual("На ветке дерева висит на веревке еще одна бутылка. Как она туда попала? Подтягиваю её шваброй. Ура! Я нашел 7 из 7 пив!", _movementThoughts.Analyse(new Phrase("посмотри в окно"), 0));
        }

        [TestMethod]
        public void EmptyPhraseTest()
        {
            Assert.AreEqual(null, _movementThoughts.Analyse(new Phrase("!!!!!"), 0));
        }
    }
}
