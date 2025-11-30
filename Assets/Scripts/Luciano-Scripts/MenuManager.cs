using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
public void PlayButton()
    {
           SceneManager.LoadScene("RulesScene");
    }

public void CreditsButton()
    {
               SceneManager.LoadScene("Credits");
    }

public void QuitButton()
    {
           Application.Quit();
    }   
}
