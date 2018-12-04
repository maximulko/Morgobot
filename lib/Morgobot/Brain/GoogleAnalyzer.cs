using System;
using Dagon.Grammar;

namespace Morgobot.Brain
{
    public class GoogleAnalyzer : IAnalyzer
    {
        public int Order => 3;

        public string Analyse(Phrase phrase)
        {
            if (!phrase.IsFirstWordEquals("загугли"))
                return null;

            return "Сам загугли!";
        }
    }
}
