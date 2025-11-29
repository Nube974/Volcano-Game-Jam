using UnityEngine;

public class HorizontalBullet : MonoBehaviour
{
    [SerializeField] float dmg = 1;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent.GetComponent<LifeController>().HPChange(dmg);
        }
    }
}
