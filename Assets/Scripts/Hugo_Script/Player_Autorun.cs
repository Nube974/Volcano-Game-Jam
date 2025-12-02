using UnityEngine;

public class Player_Autorun : MonoBehaviour
{
    // Update is called once per frame
    private Rigidbody2D rb;
    private float currentSpeed = 10;
    private float normalSpeed = 10;

    public bool hasWon = false;

    [SerializeField] PlayerSizeChange split;

    [SerializeField] PlayerCinematic cinematic;

    public void SetSpeed(float _speed){ currentSpeed = _speed;}
    public float GetNormalSpeed(){return normalSpeed;}

    private bool canMove = false;

    void Start()
    {
        CoolDownGame.StartGame += ReceiveStartSignal;
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (!hasWon && canMove) {
            if (split.direction == PlayerSizeChange.PlayerDirection.Horizontal)
            {
                rb.linearVelocityX = 1 * currentSpeed;
                rb.linearVelocityY = 0;
            } else if (split.direction == PlayerSizeChange.PlayerDirection.Vertical)
            {
                rb.linearVelocityY = 1 * currentSpeed;
                rb.linearVelocityX = 0;
            }
        }
    }

    private void ReceiveStartSignal()
    {
        canMove = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("VictoryZone")) 
        {
            hasWon = true;
            rb.linearVelocityX = 0;
            cinematic.activateCinematic = true;
        }
    }
}
