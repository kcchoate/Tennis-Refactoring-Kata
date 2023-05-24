namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int _score1;
        private int _score2;
        private string _player1Name;
        private string _player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
            {
                _score1++;
            }
            else
            {
                _score2++;
            }
        }

        public string GetScore()
        {
            if (IsTheGameTied())
            {
                return GetTieScoreDescription();
            }

            return IsInTheEndGamePhase()
                ? GetEndGamePhaseScoreDescription()
                : GetMidGameScoreDescription();
        }

        private string GetMidGameScoreDescription() =>
            $"{GetScoreDescription(_score1)}-{GetScoreDescription(_score2)}";

        private string GetEndGamePhaseScoreDescription()
        {
            if (IsPlayer1WinningBy1Point())
            {
                return "Advantage player1";
            }

            if (IsPlayer2WinningBy1Point())
            {
                return "Advantage player2";
            }

            return IsPlayer1WinningBy2Points()
                ? "Win for player1"
                : "Win for player2";
        }

        private string GetTieScoreDescription() =>
            _score1 switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce"
            };

        private bool IsInTheEndGamePhase() =>
            _score1 >= 4 || _score2 >= 4;

        private bool IsTheGameTied() =>
            _score1 == _score2;

        private bool IsPlayer1WinningBy2Points() =>
            _score1 >= _score2 + 2;

        private bool IsPlayer2WinningBy1Point() =>
            _score2 == _score1 + 1;

        private bool IsPlayer1WinningBy1Point() =>
            _score1 == _score2 + 1;

        private static string GetScoreDescription(int scoreNumber) =>
            scoreNumber switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                _ => "Forty",
            };
    }
}
