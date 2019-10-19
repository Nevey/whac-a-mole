using System;
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
        }

        protected override void OnHide()
        {
            scoreController.HighscoreUpdatedEvent -= OnHighscoreUpdated;
        }

        private void OnHighscoreUpdated(int highscore)
        {
            highscoreText.SetText($"Highscore: {highscore}");
        }
    }
}