using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPoisonAttribute : WeaponBaseState
{
    public override void EnterState(WeaponStateManager weapon)
    {
        Debug.Log("WeaponPoisonAttribute");
        Priority = 5;
    }

    public override void UpdateState(WeaponStateManager weapon)
    {
        
    }

    public override void Hit(WeaponStateManager weapon)
    {
         weapon.attack *= 2;
    }
}
