using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedAudio : MonoBehaviour
{
    public static SavedAudio instance;
    public float musicVolume;
    public float effectsVolume;
    public GameObject settings;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
    }

    private void Start()
    {
        //settings.GetComponent<Settings>().SetMusicVolume();
        //settings.GetComponent<Settings>().SetEffectsVolume();
    }
    public void FindEffetsObjects()
    {
        settings.GetComponent<Settings>().effectsObjects.RemoveAll(AudioSource => AudioSource == null);
        settings.GetComponent<Settings>().effectsObjects.TrimExcess();
        foreach (AudioSource source in settings.GetComponent<Settings>().allSoundObjects)
        {
            if (source != settings.GetComponent<Settings>().musicSource && !settings.GetComponent<Settings>().effectsObjects.Contains(source))
            {
                settings.GetComponent<Settings>().effectsObjects.Add(source);
            }
        }
    }


}
