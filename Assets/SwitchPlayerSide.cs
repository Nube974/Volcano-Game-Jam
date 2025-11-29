using UnityEngine;

public class SwitchPlayerSide : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FullPlayer"))
        {
            collision.GetComponent<PlayerSplit>().SwitchSide();
        }
    }
}
