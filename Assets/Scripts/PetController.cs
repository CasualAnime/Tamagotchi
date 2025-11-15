using UnityEngine;

public class PetController : MonoBehaviour
{
    // pet need variables
    public int intimacyLevel = 0, hunger = 100, lifeEssence = 100;
    public int decreaseHunger = 10, decreaseLifeEssence = 10;

    public bool starved = false, outOfEssence = false;

    // timer 
    private float timer = 0f;
    [SerializeField] float interval = 5f;

    private void Awake()
    {
        GameManager.Instance?.RegisterPet(this);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            // decrease hunger and lifeEssence constantly over a period of 10 seconds
            hunger -= decreaseHunger;
            lifeEssence -= decreaseLifeEssence;

            // reset timer; accounting for potential overshoot
            timer -= interval;
        }
    }

    public void IncreaseHungerLevel(int amount)
    {
        hunger += amount;
        Debug.Log("Increase hunger level by " + amount);
    }

    
    public void IncreaseIntimacyLevel(int amount)
    {
        intimacyLevel += amount;
        Debug.Log("Increase intimacy level by " + amount);
    }

    
    public void IncreaseLifeEssenceLevel(int amount)
    {
        lifeEssence += amount;
        Debug.Log("Increase life essence level by " + amount);
    }
}
