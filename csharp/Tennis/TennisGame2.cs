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
                return GetTieScoreDescription();
            }

            return IsMidGame()
                ? GetMidGameScoreDescription()
                : GetEndGamePhaseScoreDescription();
        }

        private string GetScoreDescription(int score) =>
            score switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                _ => "Forty",
            };

        private bool ArePlayersTied() => _p1Point == _p2Point;
        private string GetTieScoreDescription() =>
            _p1Point > 2
                ? "Deuce"
                : $"{_p1Description}-All";

        private bool IsMidGame() => !IsGameWinnableForPlayer1() && !IsGameWinnableForPlayer2();
        private string GetMidGameScoreDescription() => _p1Description + "-" + _p2Description;
        private bool IsGameWinnableForPlayer1() => _p1Point >= 4;
        private bool IsGameWinnableForPlayer2() => _p2Point >= 4;
        private bool HasPlayerOneWon() => (_p1Point - _p2Point) >= 2 && IsGameWinnableForPlayer1();
        private bool HasPlayerTwoWon() => (_p2Point - _p1Point) >= 2 && IsGameWinnableForPlayer2();

        private string GetEndGamePhaseScoreDescription()
        {
            if (HasPlayerOneWon())
            {
                return "Win for player1";
            }

            if (HasPlayerTwoWon())
            {
                return "Win for player2";
            }

            return _p1Point > _p2Point
                ? "Advantage player1"
                : "Advantage player2";
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
