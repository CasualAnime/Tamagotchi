using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] AudioSource[] buttonAudioClips;
    [SerializeField] AudioSource moodChange;

    public HungerButton hungerButton;
    public LifeEssenceButton lifeEssenceButton;
    public PlayButton playButton;

    [SerializeField] float pitchMin, pitchMax;

    public void PlayButtonSound()
    {
        int clips = Random.Range(0, 1);
        AudioSource clipToPlay = buttonAudioClips[clips];
        clipToPlay.pitch = Random.Range(pitchMin, pitchMax);
        clipToPlay.Play();
    }

    public void PlayMoodChangeSound()
    {
        moodChange.pitch = Random.Range(1, pitchMax);
        moodChange.Play();
    }


}
