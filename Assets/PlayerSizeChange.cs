using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class PlayerSizeChange : MonoBehaviour
{
    [SerializeField] GameObject body;

    private Vector3 bigMode = new Vector3(4f,4f,1f);
    private Vector3 ultimateMode = new Vector3(7f, 7f,1f);
    private Vector3 smallMode = new Vector3(1f,1f,1f);
    private Vector3 normalMode = new Vector3(2f,2f,1f);
    private Coroutine UltimateModeAction;

    [SerializeField] SpriteRenderer sprite;

    [SerializeField] PlayerInk ultimateJauge;

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
        if (context.started && !isUltimateState)
        {
             body.transform.localScale = bigMode;
        }
    }

    public void OnNormalMode(InputAction.CallbackContext context)
    {
        if (context.started && !isUltimateState)
        {
            body.transform.localScale = normalMode;
        }
    }

    public void OnShrinkMode(InputAction.CallbackContext context)
    {
        if (context.started && !isUltimateState)
        {
            body.transform.localScale = smallMode;

        }
    }

    public void OnUltimateMode(InputAction.CallbackContext context)
    {
        if (context.started && !isUltimateState && ultimateJauge.CanUltimate())
        {
            body.transform.localScale = ultimateMode;
            ultimateJauge.UseInk(3);
            StartCoroutine(WaitForUltimateAction());
        }
    }

    IEnumerator WaitForUltimateAction()
    {
        isUltimateState = true;
        yield return new WaitForSeconds(5f);
        isUltimateState = false;
        body.transform.localScale = normalMode;
    }

}
