using UnityEngine;

public class ShrinkingGround : MonoBehaviour
{
    [SerializeField] float speedShrink;
    [SerializeField] Player_Autorun player;
    // Update is called once per frame
    void Update()
    {
        if (!player.hasWon)
            transform.localScale = new Vector3(transform.localScale.x - speedShrink * Time.deltaTime, transform.localScale.y, transform.localScale.z);
    }
}
