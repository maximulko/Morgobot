using Morgobot.Brain.Grammar;

namespace Morgobot.Brain
{
    interface IThought
    {
        string Analyse(Phrase phrase);
    }
}
