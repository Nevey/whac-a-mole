using Game.DI;
using UnityEngine;

namespace Game.Scoring
{
    [Injectable(Singleton = true)]
    public class ScoreController : MonoBehaviour
    {
        private const string HIGHSCORE_KEY = "Whac-a-Mole.HighScore";

        [SerializeField] private ScoreView scoreViewPrefab;

        private Score totalScore;
        private Score highScore;

        private void Awake()
        {
            ResetScore();
            highScore = new Score(PlayerPrefs.GetInt(HIGHSCORE_KEY, 0));
        }

        private void CheckForHighscore()
        {
            if (totalScore.value > highScore.value)
            {
                highScore = new Score(totalScore.value);
                PlayerPrefs.SetInt(HIGHSCORE_KEY, highScore.value);
            }
        }

        private void ShowScore(Score score)
        {
            // TODO: Show score, spawn ScoreView prefab
        }

        public void AddScore(Score score)
        {
            totalScore = new Score(totalScore.value + score.value);
            ShowScore(score);

            // TODO: Do this at the end of the game instead
            CheckForHighscore();
        }

        public void ResetScore()
        {
            totalScore = new Score(0);
        }
    }
}