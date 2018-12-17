﻿using Dagon.Grammar;

namespace Morgobot.Brain
{
    public class SecretSantaAnalyzer : IContextAnalyzer
    {
        public int Order => 4;

        public string ContextName => "SecretSanta";

        public string[] ContextSwitchWords => new string[] { "секретный", "санта" };

        public string Analyse(Phrase phrase)
        {
            return "Привети из санты";
        }
    }
}