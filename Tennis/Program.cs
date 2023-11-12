using Tennis;
using Tennis.Strategies.Match;


TennisGame game = new(new Player() { Name = "Player 1" }, new Player() { Name = "Player 2" }, new BestOfThreeWinMatchStrategy());
game.StartTennisGame();
