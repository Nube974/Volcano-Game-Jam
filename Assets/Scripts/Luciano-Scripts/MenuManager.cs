using Unity.VisualScripting;
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
        // Déscativer le panneau des options lorsqu'on revient au menu principal
        Options_Panel.SetActive(false);
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
