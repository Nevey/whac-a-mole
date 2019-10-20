using Game.DI;
using Game.Scoring;
using TMPro;
using UnityEngine;

namespace Game.UI
{
    public class HighscoreWidget : UIWidget
    {
        [Inject] private ScoreController scoreController;

        [SerializeField] private TextMeshProUGUI highscoreText;

        public override UIWidgets Widget => UIWidgets.Highscore;

        protected override void OnShow()
        {
            scoreController.HighscoreUpdatedEvent += OnHighscoreUpdated;
            SetHighscoreText(scoreController.HighScore.value);
        }

        protected override void OnHide()
        {
            scoreController.HighscoreUpdatedEvent -= OnHighscoreUpdated;
        }

        private void OnHighscoreUpdated(int highscore)
        {
            SetHighscoreText(highscore);
        }

        private void SetHighscoreText(int highscore)
        {
            highscoreText.SetText($"Highscore: {highscore}");
        }
    }
}