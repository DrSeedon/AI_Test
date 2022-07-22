using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleWholeState : AppleBaseState
{
    private float rottenCountdown = 10f;
    public override void EnterState(AppleStateManager apple)
    {
        Debug.Log("Enter AppleWholeState");
        apple.GetComponent<Rigidbody>().useGravity = true;
    }

    public override void UpdateState(AppleStateManager apple)
    {
        if (rottenCountdown >= 0)
        {
            rottenCountdown -= Time.deltaTime;
        }
        else
        {
            apple.SwitchState(apple.RottenState);
        }
    }
}
