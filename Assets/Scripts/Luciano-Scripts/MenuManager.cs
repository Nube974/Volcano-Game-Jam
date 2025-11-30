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

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.started && !playerLife.isDead)
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
