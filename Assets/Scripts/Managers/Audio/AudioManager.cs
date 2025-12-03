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
    public AudioSource sfxPlay; 
    public AudioSource sfxPlayDay;
    public AudioSource sfxMoney;
    public AudioSource sfxBuy;
    public AudioSource sfxButton;

    public AudioSource sfxMaterialsChoice;
    public AudioSource sfxMaterialsGet;
    public AudioSource sfxBook;

    public AudioSource sfxFournaise;
    public AudioSource[] sfxHammer;
    public AudioSource sfxGrab;
    public AudioSource sfxPolish;

    [Header("Mixer")]
    public AudioMixer mixer;
    public float volumeMusic, volumeSFX;
    public Slider musicSlider, sfxSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            LoadVolume();
        }
        else
        {
            musicSlider.value = 0.5f;
            sfxSlider.value = 0.5f;
        }
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
    // Jingle joué par le bouton "Play". CHARLES
    public void GetPlaySound()
    {
        sfxPlayDay.Play();
    }

    // Jingle joué par les boutons " Play Day XX" et "Start Day". CHARLES
    public void GetPlayDaySound()
    {
        sfxPlayDay.Play();
    }

    // SFX joué quand le client nous donne de l'argent ou quand on achète/upgrade dans le shop. CHARLES
    public void GetMoneySound()
    {
        sfxMoney.Play();
    }

    // SFX joué quand le client nous donne de l'argent ou quand on achète/upgrade dans le shop. CHARLES
    public void GetBuySound()
    {
        musicLevel.Play();
    }

    #endregion

    // Pour les paramètres audio. CHARLES
    // Il faudra donner les valeurs des paramètres. CHARLES
    // A savoir que le volume normal est de 0 dB, la plus basse est de -80 dB tandis que le maximum est de 20 dB (il faut faire attention cela peut saturer). CHARLES
    // Pour répondre à ce problème, j'ai utiliser un logarithme pour mieux gérer le volume du son. CHARLES
    // On va aussi sauvegarder les stats des sliders. CHARLES
    #region Mixer
    public void SetMusicVolume(float volume)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        mixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    // Charger les données sauvegardées au Sliders. CHARLES
    public void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    }
    #endregion
}
