using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerSplit : MonoBehaviour
{
    [SerializeField] GameObject[] bodyParts;

    private Vector3 middleSplit = new Vector3(1f,0.4f,1f);
    private Vector3 otherSplit = new Vector3(1f,0.6f,1f);
    private Vector3 normalMode = Vector3.one;
    private Coroutine ReturnToNormalcy;

    [SerializeField] private float change = 1f;

    private bool isSplit = false;
    private bool isTopChange = false;
    private bool isBottomChange = false;

    public enum PlayerDirection
    {
        Horizontal,
        Vertical
    }

    public PlayerDirection direction = PlayerDirection.Horizontal;


    public enum Body_type
    {
        top,
        bottom
    }

    public void SwitchSide()
    {
        if (direction == PlayerDirection.Vertical)
            direction = PlayerDirection.Horizontal;
        else if (direction == PlayerDirection.Horizontal)
            direction = PlayerDirection.Vertical;
    }

    public void OnMiddleSplit(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (ReturnToNormalcy != null) {
                StopCoroutine(ReturnToNormalcy);
                ForceNormalcy();
            }

            bodyParts[(int)Body_type.top].transform.localScale = middleSplit; 
            bodyParts[(int)Body_type.bottom].transform.localScale = middleSplit;
            isSplit = true;
        }

        if (context.canceled)
        {
            ReturnToNormalcy = StartCoroutine(WaitForNormal());
        }

    }

    public void OnTopShrink(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (ReturnToNormalcy != null) {
                StopCoroutine(ReturnToNormalcy);
                ForceNormalcy();
            }

            bodyParts[(int)Body_type.top].transform.localScale = otherSplit; 
            bodyParts[(int)Body_type.bottom].transform.localScale = otherSplit;

            if (direction == PlayerDirection.Horizontal) 
            {
            bodyParts[(int)Body_type.bottom].transform.position = new Vector3
            (bodyParts[(int)Body_type.bottom].transform.position.x,
            bodyParts[(int)Body_type.bottom].transform.position.y + change,
            bodyParts[(int)Body_type.bottom].transform.position.z);
            } else if (direction == PlayerDirection.Vertical)
            {
            bodyParts[(int)Body_type.bottom].transform.position = new Vector3
            (bodyParts[(int)Body_type.bottom].transform.position.x - change,
            bodyParts[(int)Body_type.bottom].transform.position.y,
            bodyParts[(int)Body_type.bottom].transform.position.z);
            }
            
            isBottomChange = true;
        }

        if (context.canceled)
        {
            ReturnToNormalcy = StartCoroutine(WaitForNormal());
        }
    }

    public void OnBottomShrink(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (ReturnToNormalcy != null) {
                StopCoroutine(ReturnToNormalcy);
                ForceNormalcy();
            }

            bodyParts[(int)Body_type.top].transform.localScale = otherSplit; 
            bodyParts[(int)Body_type.bottom].transform.localScale = otherSplit;

            if (direction == PlayerDirection.Horizontal) 
            {
                bodyParts[(int)Body_type.top].transform.position = new Vector3
                (bodyParts[(int)Body_type.top].transform.position.x,
                bodyParts[(int)Body_type.top].transform.position.y - change,
                bodyParts[(int)Body_type.top].transform.position.z);
            } else if (direction == PlayerDirection.Vertical)
            {
                bodyParts[(int)Body_type.top].transform.position = new Vector3
                (bodyParts[(int)Body_type.top].transform.position.x + change,
                bodyParts[(int)Body_type.top].transform.position.y,
                bodyParts[(int)Body_type.top].transform.position.z);
            }
            isTopChange = true;
        }

        if (context.canceled)
        {
            ReturnToNormalcy = StartCoroutine(WaitForNormal());
        }
    }

    private void FixPos()
    {
        if (isSplit)
        {
            isSplit = false;
            return;
        } else
        {
            if (isTopChange)
            {   
                if (direction == PlayerDirection.Horizontal)
                {
                bodyParts[(int)Body_type.top].transform.position = new Vector3
                (bodyParts[(int)Body_type.top].transform.position.x,
                bodyParts[(int)Body_type.top].transform.position.y + change,
                bodyParts[(int)Body_type.top].transform.position.z);
                } else if (direction == PlayerDirection.Vertical)
                {
                bodyParts[(int)Body_type.top].transform.position = new Vector3
                (bodyParts[(int)Body_type.top].transform.position.x - change,
                bodyParts[(int)Body_type.top].transform.position.y,
                bodyParts[(int)Body_type.top].transform.position.z);
                }
                isTopChange = false;
            } else if (isBottomChange)
            {
                if (direction == PlayerDirection.Horizontal)
                {
                bodyParts[(int)Body_type.bottom].transform.position = new Vector3
                (bodyParts[(int)Body_type.bottom].transform.position.x,
                bodyParts[(int)Body_type.bottom].transform.position.y - change,
                bodyParts[(int)Body_type.bottom].transform.position.z);
                } else if (direction == PlayerDirection.Vertical)
                {
                bodyParts[(int)Body_type.bottom].transform.position = new Vector3
                (bodyParts[(int)Body_type.bottom].transform.position.x + change,
                bodyParts[(int)Body_type.bottom].transform.position.y,
                bodyParts[(int)Body_type.bottom].transform.position.z);
                }
                isBottomChange = false;
            }
        }
    }

    IEnumerator WaitForNormal()
    {
        yield return new WaitForSeconds(0.5f);
        ForceNormalcy();
    }

    private void ForceNormalcy()
    {
        bodyParts[(int)Body_type.top].transform.localScale = normalMode; 
        bodyParts[(int)Body_type.bottom].transform.localScale = normalMode;
        FixPos();
    }
}
