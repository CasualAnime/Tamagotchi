using UnityEngine;

public class LifeEssenceButton : MonoBehaviour
{
    [SerializeField] int lifeEssence = 5;

    void Awake()
    {
        GameManager.Instance?.RegisterLifeEssenceButton(this);
    }

    public void OnButtonClick()
    {
        GameManager.Instance.IncreaseLifeEssenceLevel(lifeEssence);
    }
}
