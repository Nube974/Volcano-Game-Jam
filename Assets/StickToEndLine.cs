using UnityEngine;

public class StickToEndLine : MonoBehaviour
{
    [SerializeField] Transform endline;

    // Update is called once per frame
    void Update()
    {
        transform.position = endline.position;
    }
}
