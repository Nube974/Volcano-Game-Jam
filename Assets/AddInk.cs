using UnityEngine;

public class AddInk : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.shrinkSFX);
            collision.transform.parent.transform.parent.GetComponent<PlayerInk>().ObtainInk(1);
            Destroy(gameObject);
        }
    }
}
