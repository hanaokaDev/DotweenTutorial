public class RealGaugeViewStart : GaugeView
{
    protected override void SetGaugeValue(float value)
    {
        targetImage.fillAmount = value / maxValue;
    }
}