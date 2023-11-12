using Tennis.Strategies.Match;

namespace Tennis
{
    public class TennisGame
    {
        public Player Player1 { get; private set; }

        public Player Player2 { get; private set; }

        public ResultManager ResultManager { get; private set; }

        public TennisGame(Player player1, Player player2, WinMatchStrategy winMatchStrategy)
        {
            Player1 = player1;
            Player2 = player2;
            ResultManager = new ResultManager(player1, player2, winMatchStrategy);
        }

        public void StartTennisGame()
        {
            Console.WriteLine("Start of the tennis Match.");
            PrintEnterValidPlayerIndexMessage();

            bool endGame;
            do
            {
                Console.Write("Enter Scoring Player:");
                int playerIndex = EnterScoringPlayer();
                ResultManager.SetScoreToPlayer(playerIndex);
                Console.WriteLine();
                endGame = ResultManager.MatchEnded;
            } while (endGame == false);
        }

        private static void PrintEnterValidPlayerIndexMessage()
        {
            Console.WriteLine("Please enter a player index. Valid Player inputs are 1 and 2.");
        }

        public int EnterScoringPlayer()
        {
            const int retryLimit = 100;
            int count = 0;
            bool validPlayerNumber;
            do
            {
                validPlayerNumber = TryGetNumber(out int playerIndex);
                if (validPlayerNumber == false)
                {
                    PrintEnterValidPlayerIndexMessage();
                    count++;
                }
                else
                {
                    return playerIndex;
                }
            } while (validPlayerNumber == false || count < retryLimit);

            throw new Exception("Reached retry limit.");
        }

        public bool TryGetNumber(out int number)
        {
            string? playerIndexInput = EnterPlayer();
            bool parsableNumber = int.TryParse(playerIndexInput, out int playerIndex);
            bool validNumber = parsableNumber && (playerIndex == 1 || playerIndex == 2);
            number = playerIndex;
            return validNumber;
        }

        // Move Enter into a separate method for better encapsulation.
        private static string? EnterPlayer()
        {
            return Console.ReadLine();
        }
    }
}
