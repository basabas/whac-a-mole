using System;
using UnityEngine;

namespace bas.whacamole
{
	public class Mole : MonoBehaviour, IMole
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
			_moleObject.transform.localPosition = Vector3.zero;
			_moleCollider.enabled = false;
		}

		public void Show()
		{
			_moleCollider.enabled = true;
			_moleObject.transform.localPosition = Vector3.up;
		}

		public void OnHit()
		{
			OnHitAction?.Invoke(this);
		}
	}
}
