using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace bas.whacamole
{
	public class GameController : MonoBehaviour
	{
		[SerializeField] private List<WhacAMoleSettings> _whacAMoleSettings;

		[SerializeField] private GameUI _gameUI;
		[SerializeField] private GameObject _menuUI;
		[SerializeField] private Dropdown _levelDropdown;
		[SerializeField] private Text _highScoreText;

		private GameStatistics _gameStatistics;

		private void Awake()
		{
			_levelDropdown.AddOptions(_whacAMoleSettings.Select(setting => setting.name).ToList());
			_levelDropdown.onValueChanged.AddListener(OnDropdownValueChanged);
			OnDropdownValueChanged(_levelDropdown.value);
		}

		public async void StartGame()
		{
			_menuUI.SetActive(false);
			WhacAMoleGame game = new WhacAMoleGame(_whacAMoleSettings[_levelDropdown.value], _gameUI);

			int result = await game.PlayGame();

			Debug.Log($"Game Ended, score was {result}, best score is {_gameStatistics.HighScore}");

			_gameStatistics.AddNewScore(result);
			_highScoreText.text = $"Current Highscore - {_gameStatistics.HighScore}";
			_menuUI.SetActive(true);
		}

		private void OnDropdownValueChanged(int value)
		{
			_gameStatistics = new GameStatistics(_whacAMoleSettings[_levelDropdown.value]);
			_highScoreText.text = $"Current Highscore - {_gameStatistics.HighScore}";
		}

		public void StopGame()
		{
			//TODO: implementation for stopping the game during play
		}
	}
}
