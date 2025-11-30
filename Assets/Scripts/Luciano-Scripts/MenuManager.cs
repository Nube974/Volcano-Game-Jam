using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{

public GameObject Options_Panel;
    public GameObject VictoryPanel;
    public GameObject DefeatPanel;
    public GameObject PausePanel;

    [SerializeField] LifeController playerLife;

    public void PlayButton()
    {
        Debug.Log("here");
        SceneManager.LoadScene("RulesScene");

    }

    public void CreditsButton()
    {
        AudioManager.Instance.PlayMusic(AudioManager.Instance.creditsMusic);
        SceneManager.LoadScene("Credits");
    }

    public void RetryButton()
    {
        SceneManager.LoadScene("LevelDesignTest");
    }


    public void BackButton()
    {
        AudioManager.Instance.PlayMusic(AudioManager.Instance.homeMusic);
        SceneManager.LoadScene("MainMenu");
        // Déscativer le panneau des options lorsqu'on revient au menu principal
        Options_Panel.SetActive(false);
        VictoryPanel.SetActive(false);
        DefeatPanel.SetActive(false);
        PausePanel.SetActive(false);    
    }

    public void ProgressAgain()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void ParametersButton()
    {            
        Options_Panel.SetActive(true);
    }
    public void QuitButton()
    {
           Application.Quit();
    }   

    IEnumerator launchScene(string sceneName)
    {
        AudioManager.Instance.PlayMusic(AudioManager.Instance.levelMusic);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
    }

    public void LaunchScene(string sceneName)
    {
        StartCoroutine(launchScene(sceneName));
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.started && !playerLife.isDead)
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
