using UnityEngine;
using UnityEngine.UI;

namespace Bas.Whacamole.UI
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
			CancelInvoke(nameof(UpdateTime));
		}

		public void SetScore(int score)
		{
			_scoreText.text = $"Score - {score}";
		}

		public void StartTimer(float time)
		{
			_timeInMs = time;
			InvokeRepeating(nameof(UpdateTime), 0, 1);
		}

		private void UpdateTime()
		{
			_timeText.text = $"Time left - {Mathf.RoundToInt(_timeInMs)}";
			_timeInMs -= 1;
		}
	}
}
