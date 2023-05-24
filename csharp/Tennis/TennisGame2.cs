namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int _p1Point;
        private int _p2Point;

        private string _p1Description => GetScoreDescription(_p1Point);
        private string _p2Description => GetScoreDescription(_p2Point);

        private string _player1Name;
        private string _player2Name;

        public TennisGame2(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;
        }

        public string GetScore()
        {
            if (ArePlayersTied())
            {
                return _p1Point > 2
                    ? "Deuce"
                    : $"{_p1Description}-All";
            }

            if (IsMidGame())
            {
                return GetMidGameScoreDescription();
            }

            if (IsGameWinnableForPlayer1() && _p2Point >= 0 && (_p1Point - _p2Point) >= 2)
            {
                return "Win for player1";
            }
            if (IsGameWinnableForPlayer2() && _p1Point >= 0 && (_p2Point - _p1Point) >= 2)
            {
                return "Win for player2";
            }

            return _p1Point > _p2Point
                ? "Advantage player1"
                : "Advantage player2";
        }

        private bool IsMidGame() => !IsGameWinnableForPlayer1() && !IsGameWinnableForPlayer2();

        private string GetMidGameScoreDescription() => _p1Description + "-" + _p2Description;

        private bool IsGameWinnableForPlayer1() => _p1Point >= 4;
        private bool IsGameWinnableForPlayer2() => _p2Point >= 4;

        private bool ArePlayersTied() => _p1Point == _p2Point;

        public string GetScoreDescription(int score) =>
            score switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                _ => "Forty",
            };

        public void SetP1Score(int number)
        {
            for (int i = 0; i < number; i++)
            {
                IncrementP1Score();
            }
        }

        public void SetP2Score(int number)
        {
            for (var i = 0; i < number; i++)
            {
                IncrementP2Score();
            }
        }

        private void IncrementP1Score()
        {
            _p1Point++;
        }

        private void IncrementP2Score()
        {
            _p2Point++;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                IncrementP1Score();
            else
                IncrementP2Score();
        }

    }
}
