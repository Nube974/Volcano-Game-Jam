using UnityEditor.UIElements;
using UnityEngine;

public class PlayerInk : MonoBehaviour
{
    public int ink;
    public int maxInk = 3;

    private void Start()
    {
        ink = maxInk; // Set current ink to full
    }
    public void ObtainInk(int amount)
    {
        ink += amount;
        if (amount > maxInk)
        {
            ink -= amount;
        }
    }
}
