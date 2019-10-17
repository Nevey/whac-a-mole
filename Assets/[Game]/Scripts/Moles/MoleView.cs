using System;
using DG.Tweening;
using UnityEngine;

namespace Game.Moles
{
    // TODO: Create abstract view class or view interface
    public class MoleView : MonoBehaviour
    {
        private Tween moveTween;

        public void Show(Action callback)
        {
            Vector3 targetPosition = transform.localPosition;
            Vector3 startPosition = targetPosition;
            startPosition.y -= 1f;
            transform.localPosition = startPosition;

            moveTween?.Kill();
            moveTween = transform.DOLocalMove(targetPosition, 0.5f)
                .SetEase(Ease.OutElastic)
                .OnComplete(() => callback?.Invoke());
        }

        public void Hide(Action callback)
        {
            Vector3 startPosition = transform.localPosition;
            Vector3 targetPosition = startPosition;
            targetPosition.y -= 1f;

            moveTween?.Kill();
            moveTween = transform.DOLocalMove(targetPosition, 0.2f)
                .SetEase(Ease.InBack)
                .OnComplete(() => callback?.Invoke());
        }
    }
}