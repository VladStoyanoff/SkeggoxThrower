using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    [Header("Singleton")]
    static MusicManager instance;

    [Header("Scripts")]
    public AudioClip crashSound;
    public AudioSource playerAudio;

    [Header("UI")]
    [SerializeField] Slider volumeSlider;

    void Start()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }
}
