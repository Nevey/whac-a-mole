using Game.DI;
using Game.Timers;
using TMPro;
using UnityEngine;

namespace Game.Scoring
{
    public class ScoreView : CardboardCoreBehaviour
    {
        [Inject] private TimerController timerController;

        [SerializeField] private TextMeshPro scoreText;
        [SerializeField] private float offset = 0.5f;
        [SerializeField] private float moveSpeed = 1f;
        [SerializeField] private float lifeSpan = 1f;

        private void Update()
        {
            Vector3 position = transform.position;
            position.y += moveSpeed * Time.deltaTime;
            transform.position = position;
        }

        public void Play(Score score, Vector3 position)
        {
            scoreText.SetText(score.value.ToString());

            Vector3 startPosition = position;
            startPosition.y += offset;
            transform.position = startPosition;

            timerController.StartTimer(this, lifeSpan, () =>
            {
                Destroy(gameObject);
            });
        }
    }
}