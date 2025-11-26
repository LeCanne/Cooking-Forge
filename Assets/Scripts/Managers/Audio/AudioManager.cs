using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [Header("Music")]
    public AudioSource musicMenu;
    public AudioSource musicLevel;
    public AudioSource musicShop;
    public bool isMenu;

    [Header("SFX")]
    public AudioSource sfxButton;
    public AudioSource sfxMoney;

    [Header("Mixer")]
    public AudioMixer mixer;
    public float volume;
    public Slider musicSlider, sfxSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayMenu();
    }

    private void Update()
    {
        SetMusicVolume(musicSlider.value);
        SetSFXVolume(sfxSlider.value);
    }

    // Pour les musiques jouées par les autres script. CHARLES
    #region Music
    // Jouée automatiquement
    public void PlayMenu()
    {
        musicMenu.Play();
        musicLevel.Stop();
        musicShop.Stop();
    }

    // Jouée après le shop. CHARLES
    public void PlayLevel()
    {
        musicLevel.Play();
        musicShop.Stop();
    }

    // Jouée aprèss un niveau ou après l'écran de démarage. CHARLES
    public void PlayShop()
    {
        musicShop.Play();
        musicLevel.Stop();
        musicMenu.Stop();
    }
    #endregion

    // Pour les SFX et Jingle joués par les autres script. CHARLES
    #region SFX/Jingle
    public void PlayButton()
    {
        musicMenu.Play();
    }

    public void PlayMoney()
    {
        musicLevel.Play();
    }

    public void PlayDay()
    {
        musicShop.Play();
    }
    #endregion

    // Pour les paramètres audio. CHARLES
    // Il faudra donner les valeurs des paramètres. CHARLES
    // A savoir que le volume normal est de 0 dB, la plus basse est de -80 dB tandis que le maximum est de 20 dB (il faut faire attention cela peut saturer). CHARLES
    // Pour l'instant, j'ai mis dans les slides -50 à 10. CHARLES
    #region Mixer
    public void SetMusicVolume(float volume)
    {
        mixer.SetFloat("MusicVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        mixer.SetFloat("SFXVolume", volume);
    }
    #endregion
}
