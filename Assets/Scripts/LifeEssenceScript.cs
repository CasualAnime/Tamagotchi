using UnityEngine;
using UnityEngine.UI;

public class LifeEssenceScript : MonoBehaviour
{
    public Slider slider;

    private void Awake()
    {
        GameManager.Instance?.RegisterLifeEssence(this);
    }

    public void SetValue(int value)
    {
        slider.value = value;
    }
}
