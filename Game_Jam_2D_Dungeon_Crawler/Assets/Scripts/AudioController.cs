
using UnityEngine;
using UnityEngine.Audio;


public class AudioController : MonoBehaviour
{
    // reference to the audio mixer component
    public AudioMixer audioMixer;




    void Start()
    {
        // if the master volume value has already been saved
        if (PlayerPrefs.HasKey("Master Volume"))
        {
            // get the master volume value and set it
            audioMixer.SetFloat("Master Volume", PlayerPrefs.GetFloat("Master Volume"));
        }

        // if the music volume value has already been saved
        if (PlayerPrefs.HasKey("Music Volume"))
        {
            // get the music volume value and set it
            audioMixer.SetFloat("Music Volume", PlayerPrefs.GetFloat("Music Volume"));
        }

        // if the sfx volume value has already been saved
        if (PlayerPrefs.HasKey("SFX Volume"))
        {
            // get the sfx volume value and set it
            audioMixer.SetFloat("SFX Volume", PlayerPrefs.GetFloat("SFX Volume"));
        }
    }


} // end of class
