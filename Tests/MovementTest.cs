using Microsoft.VisualStudio.TestTools.UnitTesting;
using Morgobot.Brain;
using Morgobot.Brain.Movements;

namespace Tests
{
    [TestClass]
    public class MovementTest
    {
        private Brain _brain;

        [TestInitialize]
        public void Init()
        {
            _brain = new Brain(new BasicThoughts(), new MovementThoughts(), new Huefication(new Grammar()));
        }

        [TestMethod]
        public void BeerGameTest()
        {
            Assert.AreEqual("Я в зале, тут тепло и кроватка.", _brain.Analyse("Где ты", 0));
            Assert.AreEqual("Поднимаю подушку и вижу под ней забытую бутылку пива, которую хотел выпить на ночь. Ура! Я нашел 1 из 7 пив!", _brain.Analyse("Посмотри под подушкой", 0));
            Assert.AreEqual("Я в коридоре, ничего интересного. На полу лежит ковер.", _brain.Analyse("Назад", 0));
            Assert.AreEqual("Поднимаю ковер и вижу что что-то блеснуло. Это пиво! Ура! Я нашел 2 из 7 пив!", _brain.Analyse("Посмотри под ковром", 0));
            Assert.AreEqual("Я в кладовке, темно и уютно.", _brain.Analyse("налево", 0));
            Assert.AreEqual("В темноте я вижу кучу пустых бутылок. Порывшись в ней я нахжу одну полную. Ура! Я нашел 3 из 7 пив!", _brain.Analyse("Включи свет", 0));
            Assert.AreEqual("Я в коридоре, ничего интересного. На полу лежит ковер.", _brain.Analyse("Направо", 0));
            Assert.AreEqual("Не пойду, лифт не работает!", _brain.Analyse("назад", 0));
            Assert.AreEqual("Я в ванной, горячей воды нет.", _brain.Analyse("направо", 0));
            Assert.AreEqual("Лежит, охлаждается. Ура! Я нашел 4 из 7 пив!", _brain.Analyse("Посмотри в ванне", 0));
            Assert.AreEqual("Я в туалете, не мешай!", _brain.Analyse("вперед", 0));
            Assert.AreEqual("Лежит, охлаждается. Ура! Я нашел 5 из 7 пив!", _brain.Analyse("Посмотри в унитазе", 0));
            Assert.AreEqual("Я на кухня, тут есть холодильник и комп.", _brain.Analyse("вперед", 0));
            Assert.AreEqual("Где ж еще ему быть. Ура! Я нашел 6 из 7 пив!", _brain.Analyse("Посмотри в холодильнике", 0));
            Assert.AreEqual("Я на балконе, можно покурить.", _brain.Analyse("вперед", 0));
            Assert.AreEqual("Не стОит.", _brain.Analyse("вперед", 0));
            Assert.AreEqual("На ветке дерева висит на веревке еще одна бутылка. Как она туда попала? Подтягиваю её шваброй. Ура! Я нашел 7 из 7 пив!", _brain.Analyse("Посмотри в окно", 0));
        }
    }
}
