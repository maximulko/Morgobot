using Dagon.Grammar;
using System;
using System.Collections.Generic;
using System.Linq;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Morgobot.Brain
{
    public class Brain
    {
        private readonly List<IAnalyzer> _analyzers;
        private readonly ServiceMessageAnalysis _serviceMessageAnalysis;

        public Brain(IEnumerable<IAnalyzer> analizers, ServiceMessageAnalysis serviceMessageAnalysis)
        {
            _analyzers = analizers.OrderBy(x=>x.Order).ToList();

            if (!_analyzers.Any())
            {
                throw new ArgumentException("No analyzers found");
            }

            _serviceMessageAnalysis = serviceMessageAnalysis;
        }

        public string Analyse(string message, MessageType type)
        {
            if (type != MessageType.Text)
            {
                return _serviceMessageAnalysis.Analyse(message, type);
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
                return "Holodilnik!";
            }

            foreach(var analyzer in _analyzers)
            {
                var response = analyzer.Analyse(phrase);

                if(response != null)
                {
                    return response;
                }
            }

            return "Иди нахуй!";
        }
    }
}
