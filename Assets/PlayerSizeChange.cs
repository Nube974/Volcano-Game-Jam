using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerSizeChange : MonoBehaviour
{
    [SerializeField] GameObject body;

    private Vector3 bigMode = new Vector3(4f,4f,1f);
    private Vector3 ultimateMode = new Vector3(6f, 6f,1f);
    private Vector3 smallMode = new Vector3(1f,1f,1f);
    private Vector3 normalMode = new Vector3(2f,2f,1f);
    private Coroutine UltimateModeAction;

    private bool isUltimateState = false;

    public enum PlayerDirection
    {
        Horizontal,
        Vertical
    }

    public PlayerDirection direction = PlayerDirection.Horizontal;

    public void SwitchSide()
    {
        if (direction == PlayerDirection.Vertical)
            direction = PlayerDirection.Horizontal;
        else if (direction == PlayerDirection.Horizontal)
            direction = PlayerDirection.Vertical;
    }


    public void OnBigMode(InputAction.CallbackContext context)
    {
        if (context.started || !isUltimateState)
        {
             body.transform.localScale = bigMode;
        }
    }

    public void OnNormalMode(InputAction.CallbackContext context)
    {
        if (context.started || !isUltimateState)
        {
            body.transform.localScale = normalMode;
        }
    }

    public void OnShrinkMode(InputAction.CallbackContext context)
    {
        if (context.started || !isUltimateState)
        {
            body.transform.localScale = smallMode;

        }
    }

    public void OnUltimateMode(InputAction.CallbackContext context)
    {
        if (context.started && !isUltimateState)
        {
            body.transform.localScale = ultimateMode;
            StartCoroutine(WaitForUltimateAction());
        }
    }

    IEnumerator WaitForUltimateAction()
    {
        isUltimateState = true;
        yield return new WaitForSeconds(4f);
        isUltimateState = false;
    }

}
