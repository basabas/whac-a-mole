using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace bas.whacamole
{
	public class MoleController : IDisposable
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
			for(int x = 0; x < settings.Layout.x; x++)
			{
				float xPos = (-(settings.Layout.x - 1) / 2f + x) * settings.SpaceBetweenMoles;
				for(int z = 0; z < settings.Layout.y; z++)
				{
					float zPos = (-(settings.Layout.y - 1) / 2f + z) * settings.SpaceBetweenMoles;
					IMole mole = CreateMole(settings.MolePrefab, new Vector3(xPos, 0, zPos));
					mole.OnHitAction = OnMoleHit;
					mole.Hide();
					_inactiveMoles.Add(mole);
				}
			}
		}

		private IMole CreateMole(GameObject molePrefab, Vector3 position)
		{
			IMole mole = UnityEngine.Object.Instantiate(molePrefab, position, Quaternion.identity).GetComponent<IMole>();
			if(mole == null)
			{
				throw new Exception("No IMole component found on gameobject");
			}
			return mole;
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

		public void OnMoleHit(IMole mole)
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
