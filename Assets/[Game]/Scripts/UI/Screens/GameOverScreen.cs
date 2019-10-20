using Game.Application;
using Game.DI;
using Game.Input;
using Game.Scoring;
using TMPro;
using UnityEngine;

namespace Game.UI
{
    public class GameOverScreen : UIScreen
    {
        [Inject] private ApplicationStateMachine applicationStateMachine;
        [Inject] private MouseInput mouseInput;
        [Inject] private ScoreController scoreController;

        [SerializeField] private TextMeshProUGUI timeIsUpText;
        [SerializeField] private TextMeshProUGUI finalScoreText;
        [SerializeField] private TextMeshProUGUI newRecordText;
        [SerializeField] private TextMeshProUGUI tapToContinueText;
        [SerializeField] private Blinker tapToContinueBlinker;

        public override UIScreens Screen => UIScreens.GameOver;

        protected override void OnShow()
        {
            timeIsUpText.gameObject.SetActive(false);
            finalScoreText.gameObject.SetActive(false);
            newRecordText.gameObject.SetActive(false);
            tapToContinueText.gameObject.SetActive(false);

            StartFlow();
        }

        protected override void OnHide()
        {
            mouseInput.TapEvent -= OnTap;
        }

        private void StartFlow()
        {
            float delay = 1f;
            Invoke(nameof(ShowTimeUpText), delay);

            delay += 1f;
            Invoke(nameof(ShowFinalScoreText), delay);

            if (scoreController.NewHighscoreSet)
            {
                delay += 1f;
                Invoke(nameof(ShowNewRecordText), delay);
            }

            delay += 1f;
            Invoke(nameof(ShowTapToContinueText), delay);
        }

        private void ShowTimeUpText()
        {
            timeIsUpText.gameObject.SetActive(true);
        }

        private void ShowFinalScoreText()
        {
            finalScoreText.gameObject.SetActive(true);
            finalScoreText.SetText($"You scored {scoreController.TotalScore.value} points!");
        }

        private void ShowNewRecordText()
        {
            newRecordText.gameObject.SetActive(true);
        }

        private void ShowTapToContinueText()
        {
            tapToContinueText.gameObject.SetActive(true);
            tapToContinueBlinker.StartBlinking();

            mouseInput.TapEvent += OnTap;
        }

        private void OnTap(Vector2 obj)
        {
            tapToContinueBlinker.StopBlinking();
            applicationStateMachine.ToState<MenuState>();
        }
    }
}