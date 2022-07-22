using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBaseState
{
    public bool isStacking = false;
    public int Priority = 0;
    public abstract void EnterState(WeaponStateManager weapon);
    public abstract void UpdateState(WeaponStateManager weapon);
    public abstract void Hit(WeaponStateManager weapon);
}
