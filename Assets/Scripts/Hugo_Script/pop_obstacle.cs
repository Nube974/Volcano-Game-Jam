using UnityEngine;

public class pop_obstacle : MonoBehaviour
{
    [SerializeField] HorizontalBullet obstacle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FullPlayer"))
        {
            obstacle.IsActivated();
        }
    }
}
