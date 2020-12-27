using Bas.Whacamole.Game;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Bas.Whacamole.UI
{
	public class LevelSelector : Dropdown
	{
		public WhacAMoleSettings CurrentSettings => _whacAMoleSettings[value];

		[SerializeField] private List<WhacAMoleSettings> _whacAMoleSettings;
		[SerializeField] private Text _highScoreText;

#if UNITY_EDITOR
		protected override void OnValidate()
		{
			base.OnValidate();
			options = _whacAMoleSettings.Select(setting => new OptionData(setting.name)).ToList();
		}
#endif

		public override void OnSelect(BaseEventData eventData)
		{
			base.OnSelect(eventData);
			SetHighScore(new GameStatistics(CurrentSettings));
		}

		public void SetHighScore(GameStatistics gameStatistics)
		{
			_highScoreText.text = $"Current Highscore - {gameStatistics.HighScore}";
		}
	}
}
