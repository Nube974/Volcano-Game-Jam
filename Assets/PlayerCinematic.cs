using UnityEngine;
using System.Collections;
using System;
using TMPro;
using UnityEditor.Callbacks;

public class PlayerCinematic : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] GameObject victoryPanel;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private TextMeshProUGUI textMP;

    [SerializeField] GameObject EraserFinal;
    private String godDialog1;
    private String godDialog2;
    private String godDialog3;

    private bool movingPlayerToSpot;
    
    void Start()
    {
        Player_Autorun.LaunchEnding += Ending;
        godDialog1 = "Oh, et puis zut!";
        godDialog2 = "Je n'ai pas le temps de perdre avec toi!";
        godDialog2 = "Tu as gagné, je dois aller à l'école!";
    }

    void Update()
    {
        if (movingPlayerToSpot)
        {
            rb.linearVelocityX = 1;
        }
    }

    private void Ending()
    {
        StartCoroutine(WaitForGod());
    }

    IEnumerator WaitForGod()
    {
        movingPlayerToSpot = true;
        yield return new WaitForSeconds(4f);
        movingPlayerToSpot = false;
        rb.linearVelocityX = 0;
        anim.SetBool("isIdle", true);
        yield return new WaitForSeconds(2f);
        sprite.flipX = true;
        yield return new WaitForSeconds(2f);
        EraserFinal.SetActive(true);
        yield return new WaitForSeconds(2f);
        textMP.text = godDialog1;
        yield return new WaitForSeconds(2f);
        textMP.text = godDialog2;
        yield return new WaitForSeconds(2f);
        textMP.text = godDialog3;
        yield return new WaitForSeconds(2f);
        textMP.text = "";
        victoryPanel.SetActive(true);
    }
}
