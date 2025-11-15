using UnityEngine;

public class PlayButton : MonoBehaviour
{
    [SerializeField] int intimacyIncrease = 1;

    void Awake()
    {
        GameManager.Instance?.RegisterPlayButton(this);
    }

    public void OnButtonClick()
    {
        GameManager.Instance.IncreaseIntimacyLevel(intimacyIncrease);
    }
}
