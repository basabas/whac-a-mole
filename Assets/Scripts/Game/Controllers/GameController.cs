using Bas.Whacamole.UI;
using UnityEngine;

namespace Bas.Whacamole.Game.Controllers
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
			Debug.Log($"Game Ended, score was {result}");
			if(result > gameStatistics.HighScore)
			{
				Debug.Log("Gratz for getting the new high score.");
				gameStatistics.SetNewScore(result);
				_levelSelector.SetHighScore(gameStatistics);
			}

			_menuUI.SetActive(true);
		}
	}
}
