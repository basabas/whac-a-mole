using UnityEngine;

namespace bas.whacamole
{
	public class GameController : MonoBehaviour
	{
		[SerializeField] private LevelSelector _levelSelector;
		[SerializeField] private GameUI _gameUI;
		[SerializeField] private GameObject _menuUI;

		public async void StartGame()
		{
			_menuUI.SetActive(false);
			WhacAMoleSettings settings = _levelSelector.CurrentSettings;
			WhacAMoleGame game = new WhacAMoleGame(settings, _gameUI);

			int result = await game.PlayGame();

			GameStatistics gameStatistics = new GameStatistics(settings);
			if(result > gameStatistics.HighScore)
			{
				Debug.Log($"Game Ended, score was {result}. Gratz for getting the new high score.");
				gameStatistics.AddNewScore(result);
			}
			else
			{
				Debug.Log($"Game Ended, score was {result}.");
			}

			_menuUI.SetActive(true);
		}
	}
}
