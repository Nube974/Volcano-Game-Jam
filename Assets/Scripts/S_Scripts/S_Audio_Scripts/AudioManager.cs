using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("---------Audio Source --------")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("----------Audio Clips ---------")]
    // Music Clips
    public AudioClip homeMusic;
    public AudioClip levelMusic;
    public AudioClip creditsMusic;
    // SFX Clips
    public AudioClip buttonClickSFX;
    public AudioClip collectSFX;
    public AudioClip playerDieSFX;
    public AudioClip victorySFX;
    public AudioClip waveSFX;
    public AudioClip swooshSFX;
    public AudioClip runSFX;
    public AudioClip growSFX;
    public AudioClip shrinkSFX;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic(homeMusic);
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
