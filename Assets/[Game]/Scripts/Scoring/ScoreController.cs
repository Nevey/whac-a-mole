using UnityEngine;

namespace Game.Scoring
{
    public class ScoreController : MonoBehaviour
    {
        private const string HIGHSCORE_KEY = "Whac-a-Mole.HighScore";

        [SerializeField] private ScoreView scoreView;

        private int currentScore;
        private int highScore;

        private void Awake()
        {
            highScore = PlayerPrefs.GetInt(HIGHSCORE_KEY, 0);
        }

        private void CheckForHighscore()
        {
            if (currentScore > highScore)
            {
                highScore = currentScore;
                PlayerPrefs.SetInt(HIGHSCORE_KEY, highScore);
            }
        }

        private void ShowScore(Score score)
        {
            // TODO: Show score, spawn ScoreView prefab
        }

        public void AddScore(Score score)
        {
            currentScore += score.value;
            ShowScore(score);

            // TODO: Do this at the end of the game instead
            CheckForHighscore();

            Debug.Log($"Current Score {currentScore}");
        }

        public void ResetScore()
        {
            currentScore = 0;
        }
    }
}