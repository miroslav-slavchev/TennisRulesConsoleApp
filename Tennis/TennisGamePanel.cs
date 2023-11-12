using Tennis.Strategies.Match;
using Tennis.Utils;

namespace Tennis
{
    public class TennisGamePanel
    {
        public ResultManager ResultManager { get; private set; }

        public TennisGamePanel(Player player1, Player player2, WinMatchStrategy winMatchStrategy)
        {
            ResultManager = new ResultManager(player1, player2, winMatchStrategy);
        }

        public void StartTennisGame()
        {
            PrintLegend();

            bool endGame;
            do
            {
                int playerIndex = EnterScoringPlayer();
                ResultManager.SetScoreToPlayer(playerIndex);
                Console.WriteLine();
                endGame = ResultManager.MatchEnded;
            } while (endGame == false);
        }

        private static void PrintLegend()
        {
            Logger.PrintLineMessage("Start of the tennis Match.");
            Logger.PrintLineMessage("=============================================================");
            Logger.PrintLineYellowTextMessage("Yellow messages: Set related info.");
            Logger.PrintLineGreenTextMessage("Green messages: Game related info.");
            Logger.PrintLineCyanTextMessage("Cyan messages: Win Point/Game/Set/Match info.");
            Logger.PrintLineHighLightedMessage("Highlighted messages: Current results info.");
            Logger.PrintLineMessage("White messages: Enter Player info.");
            Logger.PrintLineRedTextMessage("Red messages: Entered invalid player index.");
            PrintEnterValidPlayerIndexMessage();
            Logger.PrintLineMessage("=============================================================");
        }

        private static void PrintEnterValidPlayerIndexMessage() => Logger.PrintLineRedTextMessage("Please enter a player index. Valid Player inputs are 1 and 2.");

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
            Logger.PrintMessage("Enter Scoring Player:");
            return Console.ReadLine();
        }
    }
}
