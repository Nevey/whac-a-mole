using Game.Input;
using Game.Scoring;
using UnityEngine;

namespace Game.Whacking
{
    public class WhackableHitter : MonoBehaviour
    {
        [SerializeField] private MouseInput mouseInput;
        [SerializeField] private ScoreController scoreController;

        private void Awake()
        {
            mouseInput.TapEvent += OnTap;
        }

        private void OnDestroy()
        {
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
            scoreController.AddScore(score);
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