﻿using UnityEngine;

namespace bas.whacamole
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
		[Tooltip("How much the interval increases/decreases on hit/miss")]
		[SerializeField] private float _speedIncrease;

		public GameObject MolePrefab => _molePrefab;
		public Vector2 Layout => _layout;
		public float SpaceBetweenMoles => _spaceBetweenMoles;
		public float StartInterval => _startInterval;
		public float SpeedIncrease => _speedIncrease;
		public float StartTime => _startTime;
	}
}