using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleRottenState : AppleBaseState
{
    float destroyCountdown = 5f;
    public override void EnterState(AppleStateManager apple)
    {
        Debug.Log("Enter AppleRottenState");
    }

    public override void UpdateState(AppleStateManager apple)
    {
        if (destroyCountdown > 0)
        {
            destroyCountdown -= Time.deltaTime;
        }
        else
        {
            Object.Destroy(apple.gameObject);
        }
    }
}
