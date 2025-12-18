using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HungerButton : MonoBehaviour
{
    [SerializeField] Button thisButton;
    [SerializeField] int feed = 5;
    [SerializeField] AudioManager audioManager;

    void Awake()
    {
        GameManager.Instance?.RegisterHungerButton(this);
    }

    public void OnButtonClick()
    {
       GameManager.Instance.IncreaseHungerLevel(feed); 
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
