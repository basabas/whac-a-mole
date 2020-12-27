using Bas.Whacamole.Game.Interfaces;
using Bas.Whacamole.UI;

namespace Bas.Whacamole.Game.Controllers
{
	public class ScoreController : IScoreController
	{
		public int Score { get; private set; }
		public float TimeBetweenMoleSpawn { get; private set; } = 1;

		private readonly float _intervalIncrease;
		private readonly float _intervalDecrease;
		private readonly GameUI _gameUI;

		public ScoreController(GameUI gameUI, WhacAMoleSettings whacAMoleSettings)
		{
			_gameUI = gameUI;
			_intervalIncrease = whacAMoleSettings.IntervalIncrease;
			_intervalDecrease = whacAMoleSettings.IntervalDecrease;
		}

		public void OnMoleHit(IMole mole)
		{
			Score++;
			_gameUI.SetScore(Score);
			TimeBetweenMoleSpawn += TimeBetweenMoleSpawn * _intervalDecrease;
		}

		public void OnMoleMiss()
		{
			TimeBetweenMoleSpawn += TimeBetweenMoleSpawn * _intervalIncrease;
		}
	}
}
