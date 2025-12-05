using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [Header("Music")]
    public AudioSource musicMenu;
    public AudioSource musicLevelIntro, musicLevelLoop;
    public AudioSource musicShop;
    public AudioSource musicEnding;

    [Header("SFX")]
    public SFX sfx;

    [System.Serializable]
    public class SFX
    {
        [Header("UI")]
        public AudioSource sfxPlay;
        public AudioSource sfxPlayDay;
        public AudioSource sfxBuy;
        public AudioSource sfxButton;
        public AudioSource sfxButtonBook;

        [Header("Level")]
        public AudioSource[] sfxAmbiance;
        public AudioSource sfxLevelBells;
        public AudioSource sfxCoq;
        public AudioSource sfxOwls;
        public AudioSource sfxMaterialsChoice;
        public AudioSource sfxMaterialsGet;
        public AudioSource sfxBook;
        public AudioSource sfxMoney;

        [Header("Forge")]
        public AudioSource sfxFournaise;
        public AudioSource[] sfxHammer;
        public AudioSource sfxPolish;
        public AudioSource sfxGrab;
        public AudioSource[] sfxResult;

        [Header("Shop")]
        public AudioSource sfxShopBells;
    }

    private bool isPlay;

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
        musicLevelIntro.Stop();
        musicLevelLoop.Stop();
        musicShop.Stop();
        musicEnding.Stop();
    }

    // Jouée après le shop. CHARLES
    public void PlayLevel()
    {
        musicLevelIntro.Play();
        musicShop.Stop();

        StartCoroutine(GetLevelLoop());
    }

    public IEnumerator GetLevelLoop()
    {
        yield return new WaitForSeconds(1f);
        musicLevelLoop.Play();
    }

    // Jouée après un niveau ou après l'écran de démarage. CHARLES
    public void PlayShop()
    {
        musicShop.Play();
        musicLevelIntro.Stop();
        musicLevelLoop.Stop();
        musicMenu.Stop();
    }

    // Jouée à la fin du jeu. CHARLES
    public void PlayEnding()
    {
        musicShop.Stop();
        musicLevelIntro.Stop();
        musicLevelLoop.Stop();
        musicMenu.Stop();
        musicEnding.Play();
    }
    #endregion


    // Pour les SFX et Jingle joués par les autres script. CHARLES
    #region SFX/Jingle

    #region UI
    // Jingle joué par le bouton "Play". CHARLES
    public void GetPlaySound()
    {
        sfx.sfxPlayDay.Play();
    }

    // Jingle joué par les boutons " Play Day XX" et "Start Day". CHARLES
    public void GetPlayDaySound()
    {
        sfx.sfxPlayDay.Play();
    }

    // Jingle joué quand on achète/upgrade dans le shop (avec le son de l'argent). CHARLES
    public void GetBuySound()
    {
        sfx.sfxBuy.Play();
        sfx.sfxMoney.Play();
    }

    // SFX quand on appuie sur les boutons "Setting", "Upgrades", "Blueprints", "Resume", "Restart Day" et "To Main Menu" (en gros tout les boutons un peu basiques). CHARLES
    public void GetButtonSound()
    {
        sfx.sfxButton.Play();
    }

    // Jingle joué quand on achète/upgrade dans le shop. CHARLES
    public void GetButtonBookSound()
    {
        sfx.sfxButtonBook.Play();
    }
    #endregion

    #region Level
    // Ambiance du matin jouée dès qu'on apparaît dans l'écran du niveau. CHARLES
    public void GetAmbianceMorningSound()
    {
        sfx.sfxAmbiance[0].Play();
        sfx.sfxAmbiance[1].Play();

        sfx.sfxLevelBells.Play();
        sfx.sfxCoq.Play();

        StartCoroutine(GetLerpMorning());
    }
    // Lerp du volume du matin
    public IEnumerator GetLerpMorning()
    {
        float time = 0;
        
        while (time > 4)
        {
            sfx.sfxAmbiance[0].volume = Mathf.Lerp(0, 1, 4/time);
            sfx.sfxAmbiance[1].volume = Mathf.Lerp(0, 1, 4/time);
            time += Time.deltaTime;
        }

        yield return null;
    }

    // Ambiance du midi jouée après avoir fini la commission du matin ou avoir rejeter cette commission. CHARLES
    public void GetAmbianceEveningSound()
    {
        sfx.sfxAmbiance[2].Play();
        sfx.sfxAmbiance[0].Stop();

        sfx.sfxLevelBells.Stop();
        sfx.sfxCoq.Stop();

        StartCoroutine(GetLerpEvening());
        StopCoroutine(GetLerpMorning());
    }
    // Lerp du volume midi
    public IEnumerator GetLerpEvening()
    {
        float time = 0;

        while (time > 4)
        {
            sfx.sfxAmbiance[2].volume = Mathf.Lerp(0, 1, 4 / time);
            time += Time.deltaTime;
        }

        yield return null;
    }

    // Ambiance du soir jouée après avoir fini la commission du midi ou avoir rejeter cette commission. CHARLES
    public void GetAmbianceNightSound()
    {
        sfx.sfxAmbiance[3].Play();
        sfx.sfxAmbiance[2].Stop();

        StartCoroutine(GetLerpNight());
        StopCoroutine(GetLerpEvening());
    }
    // Lerp du volume du soir
    public IEnumerator GetLerpNight()
    {
        float time = 0;

        while (time > 4)
        {
            sfx.sfxAmbiance[3].volume = Mathf.Lerp(0, 1, 4 / time);
            time += Time.deltaTime;
        }

        yield return null;
    }

    // SFX joué quand on choisi dans le livre des recettes. CHARLES
    public void GetOwlsSound()
    {
        sfx.sfxMaterialsChoice.Play();
    }

    // SFX joué quand on choisi dans le livre des recettes. CHARLES
    public void GetMaterialsChoiceSound()
    {
        sfx.sfxMaterialsChoice.Play();
    }

    // SFX joué quand on reçoit les matériaux gratuits. CHARLES
    public void GetMaterialsFreeSound()
    {
        sfx.sfxMaterialsGet.Play();
    }

    // SFX joué quand on ouvre le livre des recettes. CHARLES
    public void GetMBookSound()
    {
        sfx.sfxBook.Play();
    }

    // SFX joué quand le client nous donne de l'argent ou quand on achète/upgrade dans le shop. CHARLES
    public void GetMoneySound()
    {
        sfx.sfxMoney.Play();
    }
    #endregion

    #region Forge
    // SFX joué en loop jusqu'à qu'on finit l'étape 1. CHARLES
    public void GetFournaiseSound()
    {
        isPlay = !isPlay;

        if (isPlay)
            sfx.sfxFournaise.Play();
        else
            sfx.sfxFournaise.Stop();
    }

    // SFX joué quand on touche l'écran pour frapper le métal dans l'étape 2. CHARLES
    public void GetHammerSound()
    {
        int nbHammer = Random.Range(0,4);
        sfx.sfxHammer[nbHammer].Play();
    }

    // SFX joué dans l'étape 3 en loop quand on appuie sur l'écran pour polir la lame et qui s'arrête quand on relache le doigt. CHARLES
    public void GetPolishSound()
    {
        isPlay = !isPlay;

        if (isPlay)
            sfx.sfxPolish.Play();
        else
            sfx.sfxPolish.Stop();
    }

    // SFX joué dans l'étape 4 quand on drag'n'drop les différentes parties de l'outil/arme. CHARLES
    public void GetGrabSound()
    {
        sfx.sfxGrab.Play();
    }

    // Jingle joué dans l'étape 4 quand on a tout assemblé. CHARLES
    public void GetResultSound(float quality)
    {
        if (quality < 0.5f)
            sfx.sfxResult[0].Play();
        else if (quality < 0.75f && quality >= 0.5f)
            sfx.sfxResult[1].Stop();
        else if (quality > 0.75f)
            sfx.sfxResult[2].Play();
    }
    #endregion

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
