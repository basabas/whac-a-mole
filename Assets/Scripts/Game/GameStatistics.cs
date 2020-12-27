using UnityEngine;

namespace Bas.Whacamole.Game
{
	public class GameStatistics
	{
		public int HighScore { get; private set; }

		private readonly string _highScoreName;

		public GameStatistics(WhacAMoleSettings whacAMoleSetting)
		{
			_highScoreName = $"HighScore_{whacAMoleSetting.name}";
			HighScore = PlayerPrefs.GetInt(_highScoreName);
		}

		public void SetNewScore(int score)
		{
			if(score > HighScore)
			{
				HighScore = score;
				PlayerPrefs.SetInt(_highScoreName, HighScore);
			}
		}
	}
}
