using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace bas.whacamole
{
	[RequireComponent(typeof(Dropdown))]
	public class LevelSelector : MonoBehaviour
	{
		public WhacAMoleSettings CurrentSettings => _whacAMoleSettings[_currentIndex];

		[SerializeField] private List<WhacAMoleSettings> _whacAMoleSettings;
		[SerializeField] private Text _highScoreText;

		private int _currentIndex;

		private void OnEnable()
		{
			Dropdown dropdown = GetComponent<Dropdown>();
			dropdown.AddOptions(_whacAMoleSettings.Select(setting => setting.name).ToList());
			dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
			OnDropdownValueChanged(dropdown.value);
		}

		private void OnDropdownValueChanged(int value)
		{
			_currentIndex = value;
			GameStatistics gameStatistics = new GameStatistics(_whacAMoleSettings[value]);
			_highScoreText.text = $"Current Highscore - {gameStatistics.HighScore}";
		}
	}
}
