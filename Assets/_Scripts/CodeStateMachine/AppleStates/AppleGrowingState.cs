using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleGrowingState : AppleBaseState
{
    private Vector3 startingSize = new Vector3(.1f, .1f, 0.1f);
    private Vector3 growScalar = new Vector3(.1f, .1f, 0.1f);
    public override void EnterState(AppleStateManager apple)
    {
        Debug.Log("Enter AppleGrowingState");
        apple.transform.localScale = startingSize;
    }

    public override void UpdateState(AppleStateManager apple)
    {
        if (apple.transform.localScale.x < 1)
        {
            apple.transform.localScale += growScalar * Time.deltaTime;
        }
        else
        {
            apple.SwitchState(apple.WholeState);
        }
    }
}
