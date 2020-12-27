using Bas.Whacamole.Game.Interfaces;
using UnityEngine;

namespace Bas.Whacamole.Game
{
	[CreateAssetMenu(fileName = "New WhacAMoleSettings", menuName = "Bas/New WhacAMoleSettings", order = 1)]
	public class WhacAMoleSettings : ScriptableObject
	{
		[Header("Prefab Settings")]
		[SerializeField] private GameObject _molePrefab;

		[Header("Layout Settings")]
		[SerializeField] private Vector2 _layout;
		[SerializeField] private float _spaceBetweenMoles;

		[Header("Game Settings")]
		[SerializeField] private float _startTime;
		[Tooltip("The time between moles spawn")]
		[SerializeField] private float _startInterval;
		[Tooltip("How much the interval decreases on hit")]
		[SerializeField] private float _intervalDecrease;
		[Tooltip("How much the interval increases on miss")]
		[SerializeField] private float _intervalIncrease;

		public GameObject MolePrefab => _molePrefab;
		public Vector2 Layout => _layout;
		public float SpaceBetweenMoles => _spaceBetweenMoles;
		public float StartInterval => _startInterval;
		public float IntervalDecrease => _intervalDecrease;
		public float IntervalIncrease => _intervalIncrease;
		public float StartTime => _startTime;

		private void OnValidate()
		{
			if(_molePrefab && (_molePrefab.GetComponent<IMole>() == null && _molePrefab.GetComponentInChildren<IMole>() == null))
			{
				Debug.LogError($"You need a prefab with {nameof(IMole)} interface implementation.");
				_molePrefab = null;
			}
		}
	}
}
