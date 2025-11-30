using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

public GameObject Options_Panel;

    public void PlayButton()
    {
           SceneManager.LoadScene("RulesScene");
    }

public void CreditsButton()
    {
               SceneManager.LoadScene("Credits");
    }

public void BackButton()
    {
           SceneManager.LoadScene("MainMenu");
    }

public void ParametersButton()
    {            
        Options_Panel.SetActive(true);
    }
    public void QuitButton()
    {
           Application.Quit();
    }   
}
