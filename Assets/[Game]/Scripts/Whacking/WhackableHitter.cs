using Game.DI;
using Game.Input;
using Game.Scoring;
using UnityEngine;

namespace Game.Whacking
{
    public class WhackableHitter : CardboardCoreBehaviour
    {
        [Inject] private MouseInput mouseInput;
        [Inject] private ScoreController scoreController;

        protected override void Awake()
        {
            base.Awake();
            mouseInput.TapEvent += OnTap;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            mouseInput.TapEvent -= OnTap;
        }

        private void OnTap(Vector2 screenPosition)
        {
            IWhackable whackable = GetWhackable(screenPosition);

            if (whackable == null)
            {
                return;
            }

            Score score = whackable.Hit();
            scoreController.AddScore(score, whackable);
        }

        private IWhackable GetWhackable(Vector2 screenPosition)
        {
            Ray ray = Camera.main.ScreenPointToRay(screenPosition);

            Debug.DrawRay(ray.origin, ray.direction * 50f, Color.green, 2f);

            if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit hit, 50f))
            {
                // Could be null, that's fine
                return hit.transform.GetComponent<IWhackable>();
            }

            return null;
        }
    }
}