using UnityEngine;
using UnityEngine.UI;

namespace bas.whacamole
{
	public class GameUI : MonoBehaviour
	{
		[SerializeField] private Text _scoreText;
		[SerializeField] private Text _timeText;

		private float _timeInMs;

		public void Show()
		{
			gameObject.SetActive(true);
		}

		public void Hide()
		{
			gameObject.SetActive(false);
		}

		internal void SetScore(int score)
		{
			_scoreText.text = $"Score - {score}";
		}

		internal void SetStartTime(float time)
		{
			_timeInMs = time;
		}

		private void Update()
		{
			_timeInMs -= Time.deltaTime;
			_timeText.text = $"Time left - {Mathf.RoundToInt(_timeInMs)}";
		}
	}
}
