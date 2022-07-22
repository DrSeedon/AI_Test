using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgradeAttribute : WeaponBaseState
{
    public override void EnterState(WeaponStateManager weapon)
    {
        Debug.Log("WeaponUpgradeAttribute");
        isStacking = true;
    }

    public override void UpdateState(WeaponStateManager weapon)
    {
        
    }

    public override void Hit(WeaponStateManager weapon)
    {
        weapon.attack += 10;
    }
}
