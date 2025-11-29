using UnityEngine;

public class InkController: MonoBehaviour
{
    public PlayerInk playerInk;
    public int damage = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerInk.ObtainInk(damage);
        }
    }
}
