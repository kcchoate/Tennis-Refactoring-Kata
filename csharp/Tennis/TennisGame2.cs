namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int _p1Point;
        private int _p2Point;

        private string _p1Res = "";
        private string _p2Res = "";
        private string _player1Name;
        private string _player2Name;

        public TennisGame2(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _p1Point = 0;
            _player2Name = player2Name;
        }

        public string GetScore()
        {
            var score = "";
            if (_p1Point == _p2Point && _p1Point < 3)
            {
                if (_p1Point == 0)
                    score = "Love";
                if (_p1Point == 1)
                    score = "Fifteen";
                if (_p1Point == 2)
                    score = "Thirty";
                score += "-All";
            }
            if (_p1Point == _p2Point && _p1Point > 2)
                score = "Deuce";

            if (_p1Point > 0 && _p2Point == 0)
            {
                if (_p1Point == 1)
                    _p1Res = "Fifteen";
                if (_p1Point == 2)
                    _p1Res = "Thirty";
                if (_p1Point == 3)
                    _p1Res = "Forty";

                _p2Res = "Love";
                score = _p1Res + "-" + _p2Res;
            }
            if (_p2Point > 0 && _p1Point == 0)
            {
                if (_p2Point == 1)
                    _p2Res = "Fifteen";
                if (_p2Point == 2)
                    _p2Res = "Thirty";
                if (_p2Point == 3)
                    _p2Res = "Forty";

                _p1Res = "Love";
                score = _p1Res + "-" + _p2Res;
            }

            if (_p1Point > _p2Point && _p1Point < 4)
            {
                if (_p1Point == 2)
                    _p1Res = "Thirty";
                if (_p1Point == 3)
                    _p1Res = "Forty";
                if (_p2Point == 1)
                    _p2Res = "Fifteen";
                if (_p2Point == 2)
                    _p2Res = "Thirty";
                score = _p1Res + "-" + _p2Res;
            }
            if (_p2Point > _p1Point && _p2Point < 4)
            {
                if (_p2Point == 2)
                    _p2Res = "Thirty";
                if (_p2Point == 3)
                    _p2Res = "Forty";
                if (_p1Point == 1)
                    _p1Res = "Fifteen";
                if (_p1Point == 2)
                    _p1Res = "Thirty";
                score = _p1Res + "-" + _p2Res;
            }

            if (_p1Point > _p2Point && _p2Point >= 3)
            {
                score = "Advantage player1";
            }

            if (_p2Point > _p1Point && _p1Point >= 3)
            {
                score = "Advantage player2";
            }

            if (_p1Point >= 4 && _p2Point >= 0 && (_p1Point - _p2Point) >= 2)
            {
                score = "Win for player1";
            }
            if (_p2Point >= 4 && _p1Point >= 0 && (_p2Point - _p1Point) >= 2)
            {
                score = "Win for player2";
            }
            return score;
        }

        public void SetP1Score(int number)
        {
            for (int i = 0; i < number; i++)
            {
                P1Score();
            }
        }

        public void SetP2Score(int number)
        {
            for (var i = 0; i < number; i++)
            {
                P2Score();
            }
        }

        private void P1Score()
        {
            _p1Point++;
        }

        private void P2Score()
        {
            _p2Point++;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                P1Score();
            else
                P2Score();
        }

    }
}
