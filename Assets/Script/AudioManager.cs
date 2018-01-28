using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    AudioClip dieSound;
    [SerializeField]
    AudioClip ornamentPickUpSFX;
    [SerializeField]
    AudioClip presentPickUpSFX;
    [SerializeField]
    AudioClip buttonSFX;
    [SerializeField]
    AudioSource Audio;

    public static AudioManager audInstance;


	// Use this for initialization
	void Start ()
    {
        Audio = GetComponent<AudioSource>();
        audInstance = this; 
	}

    public void PlayDeathSound()
    {
        Audio.clip = dieSound;
        Audio.Play();
    }

    public void PlayOrnamentSound()
    {
        Audio.clip = ornamentPickUpSFX;
        Audio.Play();
    }

    public void PlayPresentSound()
    {
        Audio.clip = presentPickUpSFX;
        Audio.Play();
    }

    public void PlayClickSound()
    {
        Audio.clip = buttonSFX;
        Audio.Play();
    }
	
}
