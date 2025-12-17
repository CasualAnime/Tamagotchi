using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HungerButton : MonoBehaviour
{
    [SerializeField] Button thisButton;
    [SerializeField] int feed = 5;


    void Awake()
    {
        GameManager.Instance?.RegisterHungerButton(this);
    }

    public void OnButtonClick()
    {
       GameManager.Instance.IncreaseHungerLevel(feed); 
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
