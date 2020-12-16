using System.Diagnostics;
using System.Threading.Tasks;
using UnityEngine;

namespace bas.whacamole
{
	public class WhacAMoleGame
	{
		private readonly GameUI _gameUI;

		private readonly IScoreController _scoreController;
		private readonly InputController _inputController;
		private readonly MoleController _moleController;

		private readonly float _startTime;

		public WhacAMoleGame(WhacAMoleSettings whacAMoleSetting, GameUI gameUI)
		{
			_gameUI = gameUI;
			_startTime = whacAMoleSetting.StartTime;
			_scoreController = new ScoreController(gameUI, whacAMoleSetting);
			_inputController = new InputController(_scoreController);
			_moleController = new MoleController(whacAMoleSetting, _scoreController);
		}

		public async Task<int> PlayGame()
		{
			_gameUI.Show();
			_gameUI.SetStartTime(_startTime);
			Stopwatch stopwatch = Stopwatch.StartNew();

			while(stopwatch.ElapsedMilliseconds < _startTime * 1000 && Application.isPlaying)
			{
				_moleController.ShowMole();
				await Task.Delay(Mathf.RoundToInt(_scoreController.TimeBetweenMoleSpawn * 1000));
			}

			_inputController.Dispose();
			_moleController.Dispose();
			_gameUI.Hide();
			return _scoreController.Score;
		}
	}
}
