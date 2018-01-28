using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    [SerializeField]
    GameObject informationPanel;

    [SerializeField]
    AudioSource sfxAudioManager;
    
    public void ActivateInstructions()
    {
        PlayClickSound();
        informationPanel.SetActive(true);
    }

    public void DeactivateInstructions()
    {
        PlayClickSound();
        informationPanel.SetActive(false);
    }

    public void PlayClickSound()
    {
        sfxAudioManager.Play();
    }
}
