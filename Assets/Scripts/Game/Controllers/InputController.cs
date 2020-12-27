using Bas.Whacamole.Game.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

namespace Bas.Whacamole.Game.Controllers
{
	public class InputController
	{
		private readonly Camera _camera;
		private readonly IOnMoleMissListener _moleMissListener;

		public InputController(IOnMoleMissListener moleMissListener)
		{
			_camera = Camera.main;
			_moleMissListener = moleMissListener;
			Object.FindObjectOfType<PlayerInput>().onActionTriggered += OnFireActionCallBack;
		}

		public void OnFireActionCallBack(CallbackContext context)
		{
			if(context.phase == InputActionPhase.Started)
			{
				Ray ray = _camera.ScreenPointToRay(Pointer.current.position.ReadValue());

				if(Physics.Raycast(ray, out RaycastHit hitInfo) && hitInfo.collider.TryGetComponent(out IMole mole))
				{
					mole.OnHit();
				}
				else
				{
					_moleMissListener.OnMoleMiss();
				}
			}
		}

		public void Dispose()
		{
			Object.FindObjectOfType<PlayerInput>().onActionTriggered -= OnFireActionCallBack;
		}
	}
}
