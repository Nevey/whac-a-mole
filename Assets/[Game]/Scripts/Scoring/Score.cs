namespace Game.Scoring
{
    /// <summary>
    /// Simple Score object. Has a readonly value.
    /// </summary>
    public class Score
    {
        public readonly int value;

        public Score(int value)
        {
            this.value = value;
        }
    }
}