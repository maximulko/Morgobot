using System.Linq;

namespace Morgobot.Brain.Movements
{
    public class MovementThoughts : IThought
    {
        private string[] Commands = { "вперед", "направо", "назад", "налево" };

        private Room _currentRoom=null;
        private int beersFound = 0;

        public string Analyse(string message)
        {
            if(_currentRoom == null)
            {
                CreateHome();
            }

            if(message.Contains("где") && message.Contains("ты"))
            {
                return _currentRoom.Description;
            }

            if (_currentRoom.TryToFindBeer(message))
            {
                beersFound++;
                return $"Ура! Я нашел {beersFound} из 7 пив!";
            }

            if (!Commands.Any(c => message.StartsWith(c)))
            {
                return null;
            }

            var direction = ConvertDirectionToEnum(message);
            if(_currentRoom.Doors[direction] != null)
            {
                _currentRoom = _currentRoom.Doors[direction];
                return _currentRoom.Description;
            }

            if(_currentRoom.NoWayMessages[direction] != null)
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
            if (message.Contains(Commands[0]))
            {
                return Direction.Forward;
            }

            if (message.Contains(Commands[1]))
            {
                return Direction.Right;
            }

            if (message.Contains(Commands[2]))
            {
                return Direction.Backward;
            }

            if (message.Contains(Commands[3]))
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
                WordsForBeer = new string[] { "посмотри", "под", "подушкой" }
            };

            var koridor = new Room("Коридор")
            {
                Description = "Я в коридоре, ничего интересного. На полу лежит ковер.",
                WordsForBeer = new string[] { "посмотри", "под", "ковром" }
            };
            koridor.NoWayMessages[Direction.Backward] = "Не пойду, лифт не работает!";

            var kuhnya = new Room("Кухня")
            {
                Description = "Я на кухня, тут есть холодильник и комп.",
                WordsForBeer = new string[] { "посмотри", "в", "холодильнике" }
            };

            var kladovka = new Room("Кладовка")
            {
                Description = "Я в кладовке, темно и уютно.",
                WordsForBeer = new string[] { "включи", "свет" }
            };

            var vanna = new Room("Ванна")
            {
                Description = "Я в ванной, горячей воды нет.",
                WordsForBeer = new string[] { "посмотри", "в", "ванне" }
            };

            var tualet = new Room("Туалет")
            {
                Description = "Я в туалете, не мешай!",
                WordsForBeer = new string[] { "посмотри", "в", "унитазе" }
            };

            var balkon = new Room("Балкон")
            {
                Description = "Я на балконе, можно покурить",
                WordsForBeer = new string[] { "посмотри", "в", "окно" }
            };

            balkon.NoWayMessages[Direction.Forward] = "Не стОит";

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
