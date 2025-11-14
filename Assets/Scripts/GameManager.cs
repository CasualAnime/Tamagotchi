using UnityEngine;
using System;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }


    public PetController Pet;
    public HungerScript Hunger;
    public LifeEssenceScript LifeEssence;
    public IntimacyScript Intimacy;


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
}
