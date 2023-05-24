namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int _score1 = 0;
        private int _score2 = 0;
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
            var score = "";

            if (_score1 == _score2)
            {
                score = _score1 switch
                {
                    0 => "Love-All",
                    1 => "Fifteen-All",
                    2 => "Thirty-All",
                    _ => "Deuce"
                };
            }
            else if (_score1 >= 4 || _score2 >= 4)
            {
                if (IsPlayer1WinningBy1Point())
                {
                    score = "Advantage player1";
                }
                else if (IsPlayer2WinningBy1Point())
                {
                    score = "Advantage player2";
                }
                else if (IsPlayer1WinningBy2Points())
                {
                    score = "Win for player1";
                }
                else
                {
                    score = "Win for player2";
                }
            }
            else
            {
                score = GetScoreDescription(_score1);
                score += "-";
                score += GetScoreDescription(_score2);
            }

            return score;
        }

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
