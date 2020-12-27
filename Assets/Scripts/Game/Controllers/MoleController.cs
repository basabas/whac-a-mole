using Bas.Whacamole.Game.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Bas.Whacamole.Game.Controllers
{
	public class MoleController : System.IDisposable
	{
		private readonly List<IMole> _inactiveMoles = new List<IMole>();
		private readonly List<IMole> _activeMoles = new List<IMole>();

		private readonly IOnMoleHitListener _moleHitListener;

		public MoleController(WhacAMoleSettings settings, IOnMoleHitListener moleHitListener)
		{
			_moleHitListener = moleHitListener;
			CreateMoles(settings);
		}

		private void CreateMoles(WhacAMoleSettings settings)
		{
			Vector2 halfLayout = (settings.Layout - Vector2.one) / 2f;
			for(int x = 0; x < settings.Layout.x; x++)
			{
				float xPos = (x - halfLayout.x) * settings.SpaceBetweenMoles;
				for(int z = 0; z < settings.Layout.y; z++)
				{
					float zPos = (z - halfLayout.y) * settings.SpaceBetweenMoles;
					IMole mole = Object.Instantiate(settings.MolePrefab, new Vector3(xPos, 0, zPos), Quaternion.identity).GetComponent<IMole>();
					mole.OnHitAction = OnMoleHit;
					mole.Hide();
					_inactiveMoles.Add(mole);
				}
			}
		}

		public void ShowMole()
		{
			if(_inactiveMoles.Count > 0)
			{
				int index = Random.Range(0, _inactiveMoles.Count);
				IMole mole = _inactiveMoles[index];
				mole.Show();
				_inactiveMoles.RemoveAt(index);
				_activeMoles.Add(mole);
			}
		}

		private void OnMoleHit(IMole mole)
		{
			if(_activeMoles.Contains(mole))
			{
				_moleHitListener.OnMoleHit(mole);
				mole.Hide();
				_activeMoles.Remove(mole);
				_inactiveMoles.Add(mole);
			}
		}

		public void Dispose()
		{
			_inactiveMoles.ForEach(mole => mole.Dispose());
			_activeMoles.ForEach(mole => mole.Dispose());
		}
	}
}
