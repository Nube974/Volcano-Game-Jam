using System;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Autorun : MonoBehaviour
{
    // Update is called once per frame
    public static event Action LaunchEnding;
    private Rigidbody2D rb;
    private float currentSpeed = 10;
    private float normalSpeed = 10;

    public bool hasWon = false;

    [SerializeField] PlayerSizeChange split;

    public void SetSpeed(float _speed){ currentSpeed = _speed;}
    public float GetNormalSpeed(){return normalSpeed;}

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (!hasWon) {
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("VictoryZone")) 
        {
            hasWon = true;
            rb.linearVelocityX = 0;
            LaunchEnding?.Invoke();
        }
    }
}
