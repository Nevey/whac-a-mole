using UnityEngine;

namespace Game.Whacking
{
    /// <summary>
    /// Add to any object to make it whackable.
    /// </summary>
    public interface IWhackable
    {
        /// <summary>
        /// Whack and get a Score in return
        /// </summary>
        /// <returns>Score</returns>
        Scoring.Score Hit();

        /// <summary>
        /// Position, depending on implementation this could be different per object
        /// </summary>
        /// <value></value>
        Vector3 Position { get; }
    }
}