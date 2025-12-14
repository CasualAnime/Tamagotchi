using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PetController : MonoBehaviour
{
    // pet need variables
    public int intimacyLevel = 0, hunger = 100, lifeEssence = 100;
    public int decreaseHunger = 10, decreaseLifeEssence = 10;

    [SerializeField] Image petImage;
    [SerializeField] Sprite normalPet, angryPet;

    public enum DisplayPetState
    {
        Hungry, 
        Drained, 
        Angry, 
        Normal, 
        Happy, 
        Full, 
        MPFull
    }
    public DisplayPetState state;


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

        UpdateState();
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

    private void UpdateState()
    {
        switch (state)
        {
            case DisplayPetState.Hungry:

                break;
            case DisplayPetState.Angry:
                //petImage.sprite = petSpriteList[1];
                petImage.sprite = angryPet;
                break;
            case DisplayPetState.Full:

                break;
            case DisplayPetState.Happy:

                break;
            case DisplayPetState.MPFull:

                break;
            case DisplayPetState.Normal:
                //petImage.sprite = petSpriteList[0];
                petImage.sprite = normalPet;
                break;
            case DisplayPetState.Drained:

                break;
        }
    }

}
