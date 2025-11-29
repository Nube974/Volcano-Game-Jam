using UnityEditor.UIElements;
using UnityEngine;

public class PlayerInk : MonoBehaviour
{
    public int ink;
    public int maxInk = 1;

    private void Start()
    {
        ink = maxInk; // Set current ink to full
    }

    public void TakeDamage(int amount)
    {
        // amount = ink; // If we want a one shot but have more HP
        ink -= amount;

        if (ink <= 0)
        {
            Destroy(gameObject); // Temporary event
        }
    }
}
