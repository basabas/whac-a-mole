namespace Bas.Whacamole.Game.Interfaces
{
	public interface IScoreController : IOnMoleHitListener, IOnMoleMissListener
	{
		int Score { get; }
		float TimeBetweenMoleSpawn { get; }
	}
}
