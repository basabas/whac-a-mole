﻿using Bas.Whacamole.Game.Interfaces;
using System;
using UnityEngine;

namespace Bas.Whacamole.Game.Moles
{
	public class Penguin : MonoBehaviour, IMole
	{
		[SerializeField] private GameObject _moleObject;
		[SerializeField] private Collider _moleCollider;

		public Action<IMole> OnHitAction { get; set; }

		public void Dispose()
		{
			Destroy(gameObject);
		}

		public void Hide()
		{
			_moleObject.transform.localPosition = -Vector3.up;
			_moleCollider.enabled = false;
		}

		public void Show()
		{
			_moleCollider.enabled = true;
			_moleObject.transform.localPosition = Vector3.zero;
		}

		public void OnHit()
		{
			OnHitAction?.Invoke(this);
		}
	}
}
