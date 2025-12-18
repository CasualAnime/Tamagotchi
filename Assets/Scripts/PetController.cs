using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PetController : MonoBehaviour
{
    [SerializeField] AudioManager audioManager;

    [SerializeField] const int max_value = 100, min_value = 0, max_intimacy_level = 10;

    // pet need variables
    public int intimacyLevel = 5, hunger = 50, lifeEssence = 50;
    public int decreaseHunger = 10, decreaseLifeEssence = 10, decreaseIntimacyLevel = 1;

    [SerializeField] Image petImage;
    [SerializeField] Sprite[] spriteList;

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
    private float timer = 0f, hungerTimer = 0f, essenceTimer = 0f, intimacyTimer = 0f;
    private float hungerDecreaseInterval, essenceDecreaseInterval, intimacyDecreaseInterval; 
    [SerializeField] float maxTimerInterval, minTimerInterval;

    private void Awake()
    {
        GameManager.Instance?.RegisterPet(this);
    }

    private void Start()
    {
        ChangeIntervals();
    }


    // Update is called once per frame
    void Update()
    {
        float interval = maxTimerInterval;
        timer += Time.deltaTime;
        if (timer >= interval) 
        {
            ChangeIntervals();

            timer -= interval;
        }

        HungerTimer();
        LifeEssenceTimer();
        IntimacyTimer();

        UpdateState();
    }

    private void ChangeIntervals()
    {
        hungerDecreaseInterval = Random.Range(minTimerInterval, maxTimerInterval);
        essenceDecreaseInterval = Random.Range(minTimerInterval, maxTimerInterval);
        intimacyDecreaseInterval = Random.Range(minTimerInterval, maxTimerInterval);
    }

    private void IntimacyTimer()
    {
        intimacyTimer += Time.deltaTime;

        if (intimacyTimer >= intimacyDecreaseInterval)
        {
            DecreaseIntimacy();

            intimacyTimer -= intimacyDecreaseInterval;
        }
    }

    private void LifeEssenceTimer()
    {
        essenceTimer += Time.deltaTime;

        if (essenceTimer >= essenceDecreaseInterval)
        {
            DecreaseLifeEssence();

            essenceTimer -= essenceDecreaseInterval;
        }
    }

    private void HungerTimer()
    {
        hungerTimer += Time.deltaTime;

        if (hungerTimer >= hungerDecreaseInterval)
        {
            // decrease hunger constantly
            DecreaseHunger();

            // reset timer; accounting for potential overshoot
            hungerTimer -= hungerDecreaseInterval;
        }
    }

    private void DecreaseHunger()
    {
        hunger -= decreaseHunger;
        if (hunger < min_value)
        {
            hunger = min_value;
            audioManager.PlayMoodChangeSound();
        }
    }

    private void DecreaseLifeEssence()
    {
        lifeEssence -= decreaseLifeEssence;
        if (lifeEssence < min_value) 
        {
            lifeEssence = min_value;
            audioManager.PlayMoodChangeSound();
        }
    }

    private void DecreaseIntimacy()
    {
        intimacyLevel -= decreaseIntimacyLevel;
        if (intimacyLevel < min_value) 
        {
            intimacyLevel = min_value;
            audioManager.PlayMoodChangeSound();
        }
    }

    public void IncreaseHungerLevel(int amount)
    {
        hunger += amount;
        Debug.Log("Increase hunger level by " + amount);
        
        if (hunger >= max_value) 
        {
            hunger = max_value;
            audioManager.PlayMoodChangeSound();
        }
    }

    
    public void IncreaseIntimacyLevel(int amount)
    {
        intimacyLevel += amount;
        Debug.Log("Increase intimacy level by " + amount);

        if (intimacyLevel >= max_intimacy_level) 
        {
            intimacyLevel = max_intimacy_level;
            audioManager.PlayMoodChangeSound();
        }
    }

    
    public void IncreaseLifeEssenceLevel(int amount)
    {
        lifeEssence += amount;
        Debug.Log("Increase life essence level by " + amount);

        if (lifeEssence >= max_value) 
        {
            lifeEssence = max_value;
            audioManager.PlayMoodChangeSound();
        }
    }

    private void UpdateState()
    {
        switch (state)
        {
            case DisplayPetState.Hungry:
                petImage.sprite = spriteList[3];
                break;
            case DisplayPetState.Angry:
                //petImage.sprite = petSpriteList[1];
                petImage.sprite = spriteList[1];
                break;
            case DisplayPetState.Full:
                petImage.sprite = spriteList[4];
                break;
            case DisplayPetState.Happy:
                petImage.sprite = spriteList[2];
                break;
            case DisplayPetState.MPFull:
                petImage.sprite = spriteList[6];
                break;
            case DisplayPetState.Normal:
                //petImage.sprite = petSpriteList[0];
                petImage.sprite = spriteList[0];
                break;
            case DisplayPetState.Drained:
                petImage.sprite = spriteList[5];
                break;
        }

    }

}
