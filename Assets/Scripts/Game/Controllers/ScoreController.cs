using UnityEngine;

namespace bas.whacamole
{
	public class ScoreController : IScoreController
	{
		public int Score { get; private set; }
		public float TimeBetweenMoleSpawn { get; private set; } = 1;
		private float _speedIncrease = 0.01f;
		private GameUI _gameUI;

		public ScoreController(GameUI gameUI, float speedIncrease)
		{
			_gameUI = gameUI;
			_speedIncrease = speedIncrease;
		}

		public void OnMoleHit(IMole mole)
		{
			Score++;
			_gameUI.SetScore(Score);
			TimeBetweenMoleSpawn -= TimeBetweenMoleSpawn * _speedIncrease;
		}

		public void OnMoleMiss()
		{
			TimeBetweenMoleSpawn += TimeBetweenMoleSpawn * _speedIncrease * 3;
			Debug.Log("We have a miss " + TimeBetweenMoleSpawn);
		}
	}

	public interface IScoreController : IOnMoleHitListener, IOnMoleMissListener
	{
		int Score { get; }
		float TimeBetweenMoleSpawn { get; }
	}
}
