using Game.DI;
using Game.Scoring;
using TMPro;
using UnityEngine;

namespace Game.UI
{
    public class ScoreWidget : UIWidget
    {
        [Inject] private ScoreController scoreController;

        [SerializeField] private TextMeshProUGUI scoreText;

        public override UIWidgets Widget => UIWidgets.Score;

        protected override void OnShow()
        {
            scoreController.ScoreUpdatedEvent += OnScoreUpdated;
            SetScoreText(scoreController.TotalScore.value);
        }

        protected override void OnHide()
        {
            scoreController.ScoreUpdatedEvent -= OnScoreUpdated;
        }

        private void OnScoreUpdated(int totalScore)
        {
            SetScoreText(totalScore);
        }

        private void SetScoreText(int totalScore)
        {
            scoreText.SetText($"Score: {totalScore}");
        }
    }
}