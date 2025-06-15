using DG.Tweening;
using UnityEngine;

public class UsableGaugeViewStart : GaugeView
{
    private int preValue;
    private Tween currentTween;

    protected override void SetGaugeValue(float value)
    {
        int newValue = (int)value;
        if (newValue == preValue) return;
        currentTween?.Kill();
        bool upward = newValue > preValue;
        currentTween = targetImage
            .DOFillAmount(newValue / maxValue, upward ? 0.5f : 1f)
            .SetEase(upward ? Ease.OutBack : Ease.Linear)
            .OnComplete(() => Debug.Log("Transition Completed to: " + newValue));
        preValue = newValue;
    }
}