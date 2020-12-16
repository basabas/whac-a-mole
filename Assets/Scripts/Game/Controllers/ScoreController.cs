namespace bas.whacamole
{
	public class ScoreController : IScoreController
	{
		public int Score { get; private set; }
		public float TimeBetweenMoleSpawn { get; private set; } = 1;

		private float _intervalIncrease;
		private float _intervalDecrease;
		private GameUI _gameUI;

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
