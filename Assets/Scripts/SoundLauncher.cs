using UnityEngine;

public class SoundLauncher : MonoBehaviour
{
    public AudioClip clip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioManager.Instance.PlayMusic(clip);
        Time.timeScale = 1f;
    }

}
