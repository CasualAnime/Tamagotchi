using UnityEngine;
using System;
using System.Collections;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }


    public PetController Pet;
    public HungerScript Hunger;
    public LifeEssenceScript LifeEssence;
    public IntimacyScript Intimacy;
    public HungerButton HungerButton;
    public LifeEssenceButton LifeEssenceButton;
    public PlayButton PlayButton;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        // if this gameobject exists, destroy it because we only want one GameManger object
        // to exist
        // tldr; destroys copies
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // update slider for each bar
        UpdateBar();
        CheckStats();
    }

    private void UpdateBar()
    {
        Debug.Log(Pet.hunger);
        Hunger.SetValue(Pet.hunger);

        Debug.Log(Pet.lifeEssence);
        LifeEssence.SetValue(Pet.lifeEssence);

        Debug.Log(Pet.intimacyLevel);
        Intimacy.SetValue(Pet.intimacyLevel);
    }

    private void CheckStats()
    {
        if (Pet.hunger <= 25)
            Pet.state = PetController.DisplayPetState.Hungry;
        else if (Pet.lifeEssence <= 25)
            Pet.state = PetController.DisplayPetState.Drained;
        else if (Pet.intimacyLevel <= 3)
            Pet.state = PetController.DisplayPetState.Angry;
        else if (Pet.hunger == 100)
            Pet.state = PetController.DisplayPetState.Full;
        else if (Pet.lifeEssence == 100)
            Pet.state = PetController.DisplayPetState.MPFull;
        else if (Pet.intimacyLevel > 6)
            Pet.state = PetController.DisplayPetState.Happy;
        else
            Pet.state = PetController.DisplayPetState.Normal;
    }

    public void IncreaseHungerLevel(int increase)
    {
        Pet.IncreaseHungerLevel(increase);
        Debug.Log("Increasing hunger");
    }

    public void IncreaseIntimacyLevel(int increase)
    {
        Pet.IncreaseIntimacyLevel(increase);
        Debug.Log("Increasing intimacy");
    }

    public void IncreaseLifeEssenceLevel(int increase)
    {
        Pet.IncreaseLifeEssenceLevel(increase);
        Debug.Log("Increasing life essence");
    }


    // Creates a reference of the Hunger script 
    public void RegisterHunger(HungerScript hunger)
    {
        Hunger = hunger;
    }

    public void RegisterLifeEssence(LifeEssenceScript life)
    {
        LifeEssence = life;
    }

    public void RegisterIntimacy(IntimacyScript intimacy)
    {
        Intimacy = intimacy;
    }

    public void RegisterPet(PetController pet)
    {
        Pet = pet;
    }

    public void RegisterHungerButton(HungerButton button)
    {
        HungerButton = button;
    }

    public void RegisterLifeEssenceButton(LifeEssenceButton button)
    {
        LifeEssenceButton = button;
    }

    public void RegisterPlayButton(PlayButton button)
    {
        PlayButton = button;
    }
}
