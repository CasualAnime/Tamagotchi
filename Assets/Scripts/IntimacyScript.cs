using UnityEngine;
using UnityEngine.UI;

public class IntimacyScript : MonoBehaviour
{
    public Slider slider;

    private void Awake()
    {
        GameManager.Instance?.RegisterIntimacy(this); // short hand notation of if (GameManager.Instance != null) -> pass this script into the RegisterHunger function
    }

    public void SetValue(int value)
    {
        slider.value = value;
    }
}
