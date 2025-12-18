using UnityEngine;
using UnityEngine.UI;

public class LifeEssenceButton : MonoBehaviour
{
    [SerializeField] Button thisButton;
    [SerializeField] int lifeEssence = 5;
    [SerializeField] AudioManager audioManager;

    void Awake()
    {
        GameManager.Instance?.RegisterLifeEssenceButton(this);
    }

    public void OnButtonClick()
    {
        GameManager.Instance.IncreaseLifeEssenceLevel(lifeEssence);
        audioManager.PlayButtonSound();
    }

    public void TurnOff()
    {
        thisButton.interactable = false;
    }

    public void TurnOn()
    {
        thisButton.interactable = true;
    }
}
