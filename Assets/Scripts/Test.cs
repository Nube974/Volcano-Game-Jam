using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    public Transform player;

    public void OnChangeScaleUp(InputAction.CallbackContext ctx)
    {
        var scale = player.transform.localScale;
        scale = new Vector3(0, Shrink(), 0);
        if (ctx.performed)
        {
        }
    }
    void Shrink()
    {
        Vector3 theScale = transform.localScale;
        theScale.y *= 1;
        transform.localScale = theScale;
    }
}
        
