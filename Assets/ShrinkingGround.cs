using UnityEngine;

public class ShrinkingGround : MonoBehaviour
{
    [SerializeField] float speedShrink;
    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x - speedShrink * Time.deltaTime, transform.localScale.y, transform.localScale.z);
    }
}
