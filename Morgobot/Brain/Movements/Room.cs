using System.Collections.Generic;
using System.Linq;

namespace Morgobot.Brain.Movements
{
    public class Room
    {
        public readonly string Name;
        public string Description;
        public bool HasBeer { get; private set; }
        public string BeerFindMessage { get; set; }

        public Dictionary<Direction, Room> Doors;
        public Dictionary<Direction,string> NoWayMessages;
        public string[] WordsForBeer;

        public Room(string name)
        {
            Name = name;
            Doors = new Dictionary<Direction, Room>();
            NoWayMessages = new Dictionary<Direction, string>();
            HasBeer = true;
        }

        public bool TryToFindBeer(string message)
        {
            if (HasBeer && WordsForBeer.All(w => message.Contains(w)))
            {
                HasBeer = false;
                return true;
            }

            return false;
        }

        public bool CanMove(Direction direction)
        {
            return Doors.ContainsKey(direction);
        }

        public bool HasMessage(Direction direction)
        {
            return NoWayMessages.ContainsKey(direction);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
