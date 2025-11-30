using UnityEngine;
using UnityEngine.UIElements;

public class FollowLine : MonoBehaviour
{
    [SerializeField] Transform anchor;
    void Update()
    {
        transform.position = anchor.position;
    }
}
