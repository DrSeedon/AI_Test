using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponResurrectionAttribute : WeaponBaseState
{
    public override void EnterState(WeaponStateManager weapon)
    {
        Debug.Log("WeaponResurrectionAttribute");
        Priority = 10;
    }

    public override void UpdateState(WeaponStateManager weapon)
    {
        
    }

    public override void Hit(WeaponStateManager weapon)
    {
        weapon.attack = -weapon.attack;
    }
}
