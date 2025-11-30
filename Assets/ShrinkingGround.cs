using UnityEngine;

public class ShrinkingGround : MonoBehaviour
{
    [SerializeField] float speedShrink;
    [SerializeField] Player_Autorun player;

    private bool canMove = false;

    void Start()
    {
        CoolDownGame.StartGame += ReceiveStartSignal;
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.hasWon && canMove)
            transform.localScale = new Vector3(transform.localScale.x - speedShrink * Time.deltaTime, transform.localScale.y, transform.localScale.z);
    }

    private void ReceiveStartSignal()
    {
        canMove = true;
    }
}
