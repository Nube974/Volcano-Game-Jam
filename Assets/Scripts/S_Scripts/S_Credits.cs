using UnityEngine;

public class S_Credits : MonoBehaviour
{
    public float scrollSpeed = 400f;

    public RectTransform rectTransform;

    public AudioManager audioManager;

    private void Awake() 
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>(); 
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        // S_MusicManager.Instance.PlayMusic("Credits");
        rectTransform = GetComponent<RectTransform>();
        audioManager.PlayMusic(audioManager.creditsMusic);

    }
    
    private void Update()
    {
        rectTransform.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;
    }

}
