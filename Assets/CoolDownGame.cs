using System;
using UnityEngine;
using System.Collections;
using TMPro;

public class CoolDownGame : MonoBehaviour
{
    public static event Action StartGame;
    public TextMeshProUGUI textMp;
    void Start()
    {
        StartCoroutine(WaitForGameStart());
    }

    IEnumerator WaitForGameStart()
    {
        textMp.text = "3.";
        yield return new WaitForSeconds(1f);
        textMp.text = "2..";
        yield return new WaitForSeconds(1f);
        textMp.text = "1...";
        yield return new WaitForSeconds(1f);
        textMp.text = "FUYEZ!";
        yield return new WaitForSeconds(1f);
        textMp.text = "";
        StartGame?.Invoke();
    }
}
