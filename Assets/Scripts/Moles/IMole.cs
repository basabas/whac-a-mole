using System;

namespace bas.whacamole
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
