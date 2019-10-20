using System;
using Game.DI;
using Game.Whacking;
using UnityEngine;

namespace Game.Scoring
{
    /// <summary>
    /// Handles everything score related over current play session.
    /// </summary>
    [Injectable(Singleton = true)]
    public class ScoreController : MonoBehaviour
    {
        private const string HIGHSCORE_KEY = "Whac-a-Mole.HighScore";

        [SerializeField] private ScoreView scoreViewPrefab;

        private Score totalScore;
        private Score highScore;

        public Score TotalScore => totalScore;
        public Score HighScore => highScore;
        public bool NewHighscoreSet { get; private set; }

        public event Action<int> ScoreUpdatedEvent;
        public event Action<int> HighscoreUpdatedEvent;

        private void Awake()
        {
            highScore = new Score(PlayerPrefs.GetInt(HIGHSCORE_KEY, 0));
        }

        private void ShowScore(Score score, IWhackable whackable)
        {
            ScoreView scoreView = Instantiate(scoreViewPrefab);
            scoreView.Play(score, whackable.Position);
        }

        public void AddScore(Score score, IWhackable whackable)
        {
            totalScore = new Score(totalScore.value + score.value);
            ShowScore(score, whackable);

            ScoreUpdatedEvent?.Invoke(totalScore.value);
        }

        public void ResetScore()
        {
            totalScore = new Score(0);
            ScoreUpdatedEvent?.Invoke(totalScore.value);
            NewHighscoreSet = false;
        }

        public void CheckForHighscore()
        {
            if (totalScore.value > highScore.value)
            {
                highScore = new Score(totalScore.value);
                PlayerPrefs.SetInt(HIGHSCORE_KEY, highScore.value);

                NewHighscoreSet = true;

                HighscoreUpdatedEvent?.Invoke(highScore.value);
            }
        }
    }
}