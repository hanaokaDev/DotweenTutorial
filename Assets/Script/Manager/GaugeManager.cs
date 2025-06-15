using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GaugeManager : MonoBehaviour
{
    public static GaugeManager Instance { get; private set; }
    public UnityAction<float> OnGaugeValueChange;
    private float gaugeValue = 0.0f;
    
    private readonly float skillCost = 2.0f;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        gaugeValue = Mathf.Clamp(gaugeValue + Time.deltaTime, 0.0f, 10.0f);
        
        if(Keyboard.current.spaceKey.wasPressedThisFrame && gaugeValue > skillCost)
        {
            gaugeValue -= skillCost;
        }
        OnGaugeValueChange?.Invoke(gaugeValue);
    }
}
