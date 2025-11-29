using UnityEngine.SceneManagement;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject[] panelsTutorial;
    public int currentPanelIndex = 0;   

    public void ShowNextPanel()
    {
        panelsTutorial[currentPanelIndex].SetActive(false);
        currentPanelIndex++;
        if (currentPanelIndex > panelsTutorial.Length - 1)
        {
            SceneManager.LoadScene("LevelDesignTest");
        }

        else
        {
            ShowPanel(currentPanelIndex);
        }
    }

    public void ShowPanel(int currentIndex)
    {
       panelsTutorial[currentIndex].SetActive(true);
    }
}
