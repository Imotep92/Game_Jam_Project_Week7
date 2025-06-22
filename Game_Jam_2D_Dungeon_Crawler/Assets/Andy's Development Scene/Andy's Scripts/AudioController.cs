
using UnityEngine;
using UnityEngine.Audio;


public class AudioController : MonoBehaviour
{
    // make audio controller script accessible from other scripts
    public static AudioController audioControllerScript;


    // reference to the audio mixer component
    public AudioMixer audioMixer;

    // reference to audio source components
    public AudioSource titleScreen;

    public AudioSource gameMusic;

    public AudioSource bossScreen;

    public AudioSource optionsScreen;

    public AudioSource gameOverScreen;

    public AudioSource victoryScreen;

    // reference to sfx array
    public AudioSource[] sfx;




    private void Awake()
    {
        audioControllerScript = this;
    }



    void Start()
    {
        GetAudioMixerSettings();
    }


    private void GetAudioMixerSettings()
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


    // play music
    public void PlayTitleMusic()
    {
        StopAllMusic();

        titleScreen.Play();
    }


    public void PlayLevelMusic()
    {
        StopAllMusic();

        gameMusic.Play();
    }


    public void PlayGameOverMusic()
    {
        StopAllMusic();

        gameOverScreen.Play();
    }


    public void PlayBossMusic()
    {
        StopAllMusic();

        bossScreen.Play();
    }


    public void PlayVictoryMusic()
    {
        StopAllMusic();
       
        victoryScreen.Play();
    }


    private void StopAllMusic()
    {
        titleScreen.Stop();

        gameMusic.Stop();

        gameOverScreen.Stop();

        bossScreen.Stop();

        victoryScreen.Stop();
    }


    // play sfx
    public void PlaySFX(int sfxToPlay)
    {
        // stop playing the currently selected sfx
        sfx[sfxToPlay].Stop();

        // start playing the sfx
        sfx[sfxToPlay].Play();
    }



} // end of class
