namespace Game.Whacking
{
    public interface IWhackable
    {
        /// <summary>
        /// Whack and get a Score in return
        /// </summary>
        /// <returns>Score</returns>
        Scoring.Score Hit();
    }
}