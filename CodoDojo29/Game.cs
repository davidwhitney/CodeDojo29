using System;
using System.Collections.Generic;

namespace CodoDojo29
{
    public class Game
    {
        private readonly IPlayer _player1;
        private readonly IPlayer _player2;

        public Game(IPlayer player1, IPlayer player2)
        {
            _player1 = player1;
            _player2 = player2;
        }

        public string PlayGame()
        {
            for (var i = 0; i != 3; i++)
            {
                PlayHand();
            }

            return string.Empty;
        }

        public SingleHandResult PlayHand()
        {
            var hand = _player1.GetHand();
            var hand2 = _player2.GetHand();

            if (hand == hand2)
            {
                return new SingleHandResult(0);
            }

            var winVsLose = new Dictionary<string, string>()
            {
                {"rock", "scissors"},
                {"scissors", "paper"},
                {"paper", "rock"},
            };

            var player1Beats = winVsLose[hand];
            return player1Beats == hand2 ? new SingleHandResult(1) : new SingleHandResult(2);
        }
    }

    public class SingleHandResult
    {
        public int WinningPlayer { get; set; }

        public SingleHandResult(int winningPlayer)
        {
            WinningPlayer = winningPlayer;
        }
    }
}