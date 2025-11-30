using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

public GameObject Options_Panel;
    public GameObject VictoryPanel;
    public GameObject DefeatPanel;
    public GameObject PausePanel;

    public void PlayButton()
    {
        SceneManager.LoadScene("RulesScene");

    }

    public void CreditsButton()
    {
        SceneManager.LoadScene("Credits");
    }

    public void RetryButton()
    {
        SceneManager.LoadScene("LevelDesignTest");
    }


    public void BackButton()
    {
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
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
    }

    public void LaunchScene(string sceneName)
    {
        StartCoroutine(launchScene(sceneName));
    }
}
