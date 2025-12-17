using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    [SerializeField] Button thisButton;
    [SerializeField] int intimacyIncrease = 1;

    void Awake()
    {
        GameManager.Instance?.RegisterPlayButton(this);
    }

    public void OnButtonClick()
    {
        GameManager.Instance.IncreaseIntimacyLevel(intimacyIncrease);
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
