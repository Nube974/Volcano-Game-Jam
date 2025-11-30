using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInk : MonoBehaviour
{
    public Slider slider;

    public int ink;
    public int minInk = 0;
    public int maxInk = 3;
    
    private void Start()
    {
        SetMinMaxInk(minInk, maxInk);
    }

    //

    public void SetMinMaxInk(int minInk, int maxInk)
    {
        slider.minValue = minInk;
        slider.maxValue = maxInk;
        SetInk(ink);
    }
    public void SetInk(int ink)
    {
        slider.value = ink;
    }
    
    //

    public void ObtainInk(int amount)
    {
        ink += amount;
        //Debug.Log($"You have this much ink: {ink}");
        SetInk(ink);
        if (ink > maxInk)
        {
            ink = maxInk;
            SetInk(ink);
            //Debug.Log($"You have this much ink: {ink}");
        }
    }
    public void UseInk(int amount)
    {
        ink -= amount;
        //Debug.Log($"You have this much ink: {ink}");
        slider.value = ink;
        SetInk(ink);
        if (ink < minInk)
        {
            ink = minInk;
            SetInk(ink);
            //Debug.Log($"You have this much ink: {ink}");
        }
    }

    //

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ink")
        {
            ObtainInk(1);
        }
    }
    public void OnUseInk(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            UseInk(1);
            //Debug.Log($"You have used ink!");
        }
    }

    //

    public bool CanUltimate()
    {
        if (ink == maxInk)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //
    // CheatCode
    public void CheatInk(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            ObtainInk(3);
        }
    }
}
