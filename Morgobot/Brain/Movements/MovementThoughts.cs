using System.Linq;
using System.Reflection.Metadata;
using Morgobot.Brain.Grammar;

namespace Morgobot.Brain.Movements
{
    public class MovementThoughts : IThought
    {
        private readonly string[] _commands = { "вперед", "направо", "назад", "налево" };

        private Room _currentRoom=null;
        private int _beersFound = 0;

        public string Analyse(Phrase phrase)
        {
            if(_currentRoom == null)
            {
                CreateHome();
            }

            if(phrase.HasWord("где") && phrase.HasWord("ты"))
            {
                return _currentRoom.Description;
            }

            if (_currentRoom.TryToFindBeer(phrase.ToString()))
            {
                _beersFound++;
                return $"{_currentRoom.BeerFindMessage} Ура! Я нашел {_beersFound} из 7 пив!";
            }

            if (phrase.IsEmpty())
            {
                return null;
            }

            if (_commands.All(c => c != phrase.FirstWord.ToString()))
            {
                return null;
            }

            var direction = ConvertDirectionToEnum(phrase.FirstWord.ToString());
            if(_currentRoom.CanMove(direction))
            {
                _currentRoom = _currentRoom.Doors[direction];
                return _currentRoom.Description;
            }

            if(_currentRoom.HasMessage(direction))
            {
                return _currentRoom.NoWayMessages[direction];
            }
            else
            {
                return "Не могу!";
            }
        }

        private Direction ConvertDirectionToEnum(string message)
        {
            if (message.Contains(_commands[0]))
            {
                return Direction.Forward;
            }

            if (message.Contains(_commands[1]))
            {
                return Direction.Right;
            }

            if (message.Contains(_commands[2]))
            {
                return Direction.Backward;
            }

            if (message.Contains(_commands[3]))
            {
                return Direction.Left;
            }

            throw new System.Exception("Wrong direction");
        }

        private void CreateHome()
        {
            var zal = new Room("Зал")
            {
                Description = "Я в зале, тут тепло и кроватка.",
                WordsForBeer = new string[] { "посмотри", "под", "подушкой" },
                BeerFindMessage = "Поднимаю подушку и вижу под ней забытую бутылку пива, которую хотел выпить на ночь."
            };

            var koridor = new Room("Коридор")
            {
                Description = "Я в коридоре, ничего интересного. На полу лежит ковер.",
                WordsForBeer = new string[] { "посмотри", "под", "ковром" },
                BeerFindMessage = "Поднимаю ковер и вижу что что-то блеснуло. Это пиво!"
            };
            koridor.NoWayMessages[Direction.Backward] = "Не пойду, лифт не работает!";

            var kuhnya = new Room("Кухня")
            {
                Description = "Я на кухня, тут есть холодильник и комп.",
                WordsForBeer = new string[] { "посмотри", "в", "холодильнике" },
                BeerFindMessage = "Где ж еще ему быть."
            };

            var kladovka = new Room("Кладовка")
            {
                Description = "Я в кладовке, темно и уютно.",
                WordsForBeer = new string[] { "включи", "свет" },
                BeerFindMessage = "В темноте я вижу кучу пустых бутылок. Порывшись в ней я нахжу одну полную."
            };

            var vanna = new Room("Ванна")
            {
                Description = "Я в ванной, горячей воды нет.",
                WordsForBeer = new string[] { "посмотри", "в", "ванне" },
                BeerFindMessage = "Лежит, охлаждается."
            };

            var tualet = new Room("Туалет")
            {
                Description = "Я в туалете, не мешай!",
                WordsForBeer = new string[] { "посмотри", "в", "унитазе" },
                BeerFindMessage = "Лежит, охлаждается."
            };

            var balkon = new Room("Балкон")
            {
                Description = "Я на балконе, можно покурить.",
                WordsForBeer = new string[] { "посмотри", "в", "окно" },
                BeerFindMessage = "На ветке дерева висит на веревке еще одна бутылка. Как она туда попала? Подтягиваю её шваброй."
            };

            balkon.NoWayMessages[Direction.Forward] = "Не стОит.";

            zal.Doors[Direction.Backward] = koridor;
            koridor.Doors[Direction.Forward] = zal;

            koridor.Doors[Direction.Left] = kladovka;
            kladovka.Doors[Direction.Right] = koridor;

            koridor.Doors[Direction.Right] = vanna;
            vanna.Doors[Direction.Left] = koridor;

            vanna.Doors[Direction.Forward] = tualet;
            tualet.Doors[Direction.Backward] = vanna;

            tualet.Doors[Direction.Forward] = kuhnya;
            kuhnya.Doors[Direction.Backward] = tualet;

            kuhnya.Doors[Direction.Forward] = balkon;
            balkon.Doors[Direction.Backward] = kuhnya;

            _currentRoom = zal;
        }
    }
}
