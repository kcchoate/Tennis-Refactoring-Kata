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
                // the score is tied
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
                // we MIGHT have a winner
                var minusResult = _score1 - _score2;

                if (minusResult == 1)
                {
                    score = "Advantage player1";
                }
                else if (minusResult == -1)
                {
                    score = "Advantage player2";
                }
                else if (minusResult >= 2)
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
                // the score is NOT tied, and nobody has won yet
                switch (_score1)
                {
                    case 0:
                        score += "Love";
                        break;
                    case 1:
                        score += "Fifteen";
                        break;
                    case 2:
                        score += "Thirty";
                        break;
                    case 3:
                        score += "Forty";
                        break;
                }

                score += "-";

                switch (_score2)
                {
                    case 0:
                        score += "Love";
                        break;
                    case 1:
                        score += "Fifteen";
                        break;
                    case 2:
                        score += "Thirty";
                        break;
                    case 3:
                        score += "Forty";
                        break;
                }
            }

            return score;
        }
    }
}
