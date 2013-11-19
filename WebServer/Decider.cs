using System.Collections.Generic;

namespace WebServer
{
    public class Decider : IPickRockPaperOrScissors
    {
        private readonly IRandomNumberGenerator _randomNumberGenerator;
        public List<string> ValidDecisions { get; private set; }

        public Decider(IRandomNumberGenerator randomNumberGenerator)
        {
            _randomNumberGenerator = randomNumberGenerator;
            ValidDecisions = new List<string> { "rock", "paper", "scissors" };
        }

        public string MakeDecision()
        {
            var randomValue = _randomNumberGenerator.GenerateRandomNumberBetweenZeroAndTwo();
            return ValidDecisions[randomValue];
        }
    }
}