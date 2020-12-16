namespace bas.whacamole
{
	public interface IScoreController : IOnMoleHitListener, IOnMoleMissListener
	{
		int Score { get; }
		float TimeBetweenMoleSpawn { get; }
	}
}
