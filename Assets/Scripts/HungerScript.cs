using UnityEngine;
using UnityEngine.UI;

public class HungerScript : MonoBehaviour
{

    public Slider slider;

    private void Awake()
    {
        GameManager.Instance?.RegisterHunger(this); // short hand notation of if (GameManager.Instance != null) -> pass this script into the RegisterHunger function
    }

    public void SetValue(int value)
    {
        slider.value = value;
    }
}
