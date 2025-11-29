using UnityEngine;

public class AddInk : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FullPlayer"))
        {
            collision.GetComponent<PlayerInk>().ObtainInk(1);
            Destroy(gameObject);
        }
    }
}
