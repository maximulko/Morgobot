using Dagon.Grammar;

namespace Morgobot.Brain.ContextAnalysers
{
    public class SecretSantaAnalyzer : IContextAnalyzer
    {
        public int Order => 4;

        public string ContextName => "SecretSanta";

        public string[] ContextSwitchWords => new string[] { "секретный", "санта" };

        public BrainResponse Analyse(Phrase phrase)
        {
            return new BrainResponse
            {
                Text = "Привет из санты",
                ClenUpCurrentContext = true
            };
        }
    }
}
