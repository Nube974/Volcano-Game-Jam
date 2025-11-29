using UnityEngine;

public class HorizontalBullet : MonoBehaviour
{
    [SerializeField] float dmg = 1;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent.transform.parent.GetComponent<LifeController>().SpeedChange(dmg);
        }
    }
}
