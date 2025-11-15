using Unity.VisualScripting;
using UnityEngine;

public class HungerButton : MonoBehaviour
{
    [SerializeField] int feed = 5;

    void Awake()
    {
        GameManager.Instance?.RegisterHungerButton(this);
    }

    public void OnButtonClick()
    {
       GameManager.Instance.IncreaseHungerLevel(feed); 
    }
}
