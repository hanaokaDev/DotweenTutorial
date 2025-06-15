using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class GaugeView : MonoBehaviour
{
    protected Image targetImage;
    protected float maxValue = 10.0f;
    
    private void Start()
    {
        targetImage = GetComponent<Image>();
        GaugeManager.Instance.OnGaugeValueChange += SetGaugeValue;
    }

    protected abstract void SetGaugeValue(float value);
}