using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("--Audio Source--")]
    [SerializeField] AudioSource Music;
    [SerializeField] AudioSource SFX;

    [Header("--Audio Clip--")]
    public AudioClip mainMenu;
    public AudioClip inGame;
    public AudioClip ending;
    public AudioClip pause;
    public AudioClip jump;
    public AudioClip buttonClick;
    public AudioClip collect;
    public AudioClip death;
    public AudioClip popupMenu;
    public AudioClip sliderClick;

    public static AudioManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Music.clip = mainMenu;
        //Music.clip = inGame;
        Music.Play();
        SceneManager.activeSceneChanged += SceneChanged;
    }

    private void SceneChanged(Scene current, Scene next)
    {
        switch (next.name)
        {
            case "Menu":
                ChangeBGM(mainMenu);
                break;

            case "Level1":
                ChangeBGM(inGame);
                break;

            case "Level2":
                ChangeBGM(inGame);
                break;

            case "Ending":
                ChangeBGM(ending);
                break;
        }
    }

    public void ChangeBGM(AudioClip music)
    {
        if (Music.clip.name == music.name) return;
        Music.Stop();
        Music.clip = music;
        Music.Play();
    }
    public void PlaySFX(string clip)
    {
        AudioClip audioClip;

        switch (clip)
        {
            case "Jump":
                audioClip = jump;
                break;

            case "ButtonClick":
                audioClip = buttonClick;
                break;

            case "Collect":
                audioClip = collect;
                break;

            case "Death":
                audioClip = death;
                break;

            case "PopupMenu":
                audioClip = popupMenu;
                break;

            case "SliderClick":
                audioClip = sliderClick;
                break;

            default:
                Debug.LogError("SFX is invalid");
                return;
        }

        SFX.PlayOneShot(audioClip);
    }
}