using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource sfxSource;
    public AudioSource musicSource;
    public AudioClip sfxHit;
    public AudioClip sfxSplash;
    public AudioClip sfxButtonClick;
    public AudioClip sfxWin;
    public AudioClip uiMusic;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { Destroy(gameObject); }
    }

    void Start()
    {
        if (uiMusic != null)
        {
            musicSource.clip = uiMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void PlayUIMusic(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
