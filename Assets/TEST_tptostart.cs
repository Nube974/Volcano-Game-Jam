using Unity.VisualScripting;
using UnityEngine;

public class TEST_tptostart : MonoBehaviour
{
    [SerializeField] Transform playerStartPos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent.position = playerStartPos.position;
        }
    }
}
