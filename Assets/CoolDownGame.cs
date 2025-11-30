using System;
using UnityEngine;
using System.Collections;

public class CoolDownGame : MonoBehaviour
{
    public static event Action StartGame;
    void Start()
    {
        StartCoroutine(WaitForGameStart());
    }

    IEnumerator WaitForGameStart()
    {
        yield return new WaitForSeconds(3f);
        StartGame?.Invoke();
    }
}
