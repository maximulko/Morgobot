using Dagon.Grammar;
using Morgobot.Brain.ContextAnalysers;
using System;
using System.Collections.Generic;
using System.Linq;
using Telegram.Bot.Types.Enums;

namespace Morgobot.Brain
{
    public class Brain
    {
        private readonly List<IAnalyzer> _analyzers;
        private readonly IEnumerable<IContextAnalyzer> _contextAnalyzers;
        private readonly ServiceMessageAnalysis _serviceMessageAnalysis;

        public Brain(
            IEnumerable<IAnalyzer> analizers,
            IEnumerable<IContextAnalyzer> contextAnalyzers,
            ServiceMessageAnalysis serviceMessageAnalysis)
        {
            _analyzers = analizers.OrderBy(x=>x.Order).ToList();

            if (!_analyzers.Any())
            {
                throw new ArgumentException("No analyzers found");
            }

            _contextAnalyzers = contextAnalyzers ?? throw new ArgumentNullException(nameof(contextAnalyzers));

            _serviceMessageAnalysis = serviceMessageAnalysis;
        }

        public BrainResponse Analyse(string message, long chatId, MessageType type = MessageType.Text, string contextName = null)
        {
            if (type != MessageType.Text)
            {
                return new BrainResponse(_serviceMessageAnalysis.Analyse(message, type));
            }

            if (message == null)
            {
                return null;
            }

            message = message.ToLower();

            if (message.StartsWith("/"))
            {
                message = message.Substring(1, message.Length - 1);
            }

            message = message.Replace('ё', 'е');

            var phrase = new Phrase(message);

            if (phrase.HasEnglisLetters())
            {
                return new BrainResponse("Holodilnik!");
            }

            if (!string.IsNullOrWhiteSpace(contextName))
            {
                var currentContextAnalyser = _contextAnalyzers.FirstOrDefault(x => x.ContextName == contextName);

                if(currentContextAnalyser != null)
                {
                    return currentContextAnalyser.Analyse(phrase, chatId);
                }
            }

            foreach(var analyzer in _analyzers)
            {
                var response = analyzer.Analyse(phrase, chatId);

                if(response != null)
                {
                    return new BrainResponse(response);
                }
            }

            return new BrainResponse("Иди нахуй!");
        }
    }
}
