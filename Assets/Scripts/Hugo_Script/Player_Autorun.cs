using UnityEngine;

public class Player_Autorun : MonoBehaviour
{
    // Update is called once per frame
    private Rigidbody2D rb;
    private float currentSpeed = 10;
    private float normalSpeed = 10;

    [SerializeField] PlayerSplit split;

    public void SetSpeed(float _speed){ currentSpeed = _speed;}
    public float GetNormalSpeed(){return normalSpeed;}

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (split.direction == PlayerSplit.PlayerDirection.Horizontal)
        {
            rb.linearVelocityX = 1 * currentSpeed;
            rb.linearVelocityY = 0;
        } else if (split.direction == PlayerSplit.PlayerDirection.Vertical)
        {
            rb.linearVelocityY = 1 * currentSpeed;
            rb.linearVelocityX = 0;
        }
    }
}
