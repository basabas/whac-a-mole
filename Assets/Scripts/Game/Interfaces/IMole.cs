using System;

namespace Bas.Whacamole.Game.Interfaces
{
	public interface IMole
	{
		Action<IMole> OnHitAction { get; set; }
		void Hide();
		void Dispose();
		void OnHit();
		void Show();
	}
}
