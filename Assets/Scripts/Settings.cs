using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [Header("Audio")]
    public GameObject audioSettings;
    public Slider music;
    public Slider effects;
    [Header("Graphics")]
    public Dropdown resolutionSelecter;
    public bool fullscreen;

    [HideInInspector]
    public AudioSource[] allSoundObjects;
    public AudioSource musicSource;
    [HideInInspector]
    public List<AudioSource> effectsObjects = new List<AudioSource>();
    private void Awake()
    {
        audioSettings = GameObject.Find("AudioSettings");
        audioSettings.GetComponent<SavedAudio>().settings = gameObject;

    }

    private void Start()
    {
        music.value = audioSettings.GetComponent<SavedAudio>().musicVolume;
        effects.value = audioSettings.GetComponent<SavedAudio>().effectsVolume;

        musicSource = GameObject.FindGameObjectWithTag("MusicSource").GetComponent<AudioSource>();
        allSoundObjects = GameObject.FindObjectsOfType<AudioSource>();

        SavedAudio.instance.FindEffetsObjects();

        SetEffectsVolume();
        SetMusicVolume();
    }



    public void SetMusicVolume()
    {
        print(musicSource.name);
        audioSettings.GetComponent<SavedAudio>().musicVolume = music.value;
        musicSource.volume = audioSettings.GetComponent<SavedAudio>().musicVolume / 100;
    }
    public void SetEffectsVolume()
    {
        if (effectsObjects != null)
        {
            foreach (AudioSource source in effectsObjects)
            {
                source.volume = effects.value / 100;
            }
        }
        else
        {
            print("No effects in this scene");
        }

        audioSettings.GetComponent<SavedAudio>().effectsVolume = effects.value;
    }


    public void ToggleFullscreen(bool localFullscreen)
    {
        Screen.fullScreen = localFullscreen;
        fullscreen = localFullscreen;
    }

    public void SetResolution()
    {
        string resString = resolutionSelecter.captionText.gameObject.GetComponent<Text>().text;
        string width = "", height = "";
        bool widthCalculated = false;
        Debug.Log(resString);
        for(int i = 0; i <resString.Length; i++)
        {
            char c = resString[i];
            if (widthCalculated == false)
            {
                width += c.ToString();
            }
            else
            {
                height += c.ToString();
            }
            if (c.ToString() == "x")
            {
                widthCalculated = true;
                width = width.Remove(width.Length - 1);
            }
        }
        int widthInt;
        int.TryParse(width, out widthInt);
        int heightInt;
        int.TryParse(height, out heightInt);

        Screen.SetResolution(widthInt, heightInt, fullscreen);
        Debug.Log("Resolution set to " + width + " x " + height);
    }
}
