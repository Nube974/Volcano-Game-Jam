using UnityEngine;
using System.Collections;

public class LifeController : MonoBehaviour
{
    public float maxHp = 3;
    public float currentHp = 3;

    public float speedHurt = 5f;
    private bool isInvincible = false;

    private float iFrameTimer = 0.5f;

    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Player_Autorun playerRun;

    public void Start()
    {
        currentHp = maxHp;
    }

    public void HPChange(float dmg)
    {
        if (!isInvincible)
        {
            //currentHp -= dmg;
           
            if (currentHp <= 0)
            {
                PlayerDeath();
                return;
            }

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

    private void PlayerDeath()
    {
        currentHp = maxHp;
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
