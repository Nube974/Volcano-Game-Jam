using UnityEngine;
using System.Collections;

public class LifeController : MonoBehaviour
{


    public float speedHurt = 5f;
    private bool isInvincible = false;

    private float iFrameTimer = 0.5f;

    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Player_Autorun playerRun;


    public void SpeedChange(float dmg)
    {
        speedHurt = dmg;

        if (!isInvincible)
        {
            if (dmg > 0)
                StartCoroutine(PlayerHurt());
            isInvincible = true;
            StartCoroutine(WaitForIFrame());
        }
    }

    IEnumerator PlayerHurt()
    {
        FlashBody(false);
        yield return new WaitForSeconds(iFrameTimer / 3);
        FlashBody(true); 
        yield return new WaitForSeconds(iFrameTimer / 3);
        FlashBody(false);
        yield return new WaitForSeconds(iFrameTimer / 3);
        FlashBody(true);

    }

    private void FlashBody(bool bo)
    {
        sprite.enabled = bo;
    }

    IEnumerator WaitForIFrame()
    {
        isInvincible = true;
        playerRun.SetSpeed(speedHurt);
        yield return new WaitForSeconds(iFrameTimer);
        playerRun.SetSpeed(playerRun.GetNormalSpeed());
        isInvincible = false;
    }
    
}
