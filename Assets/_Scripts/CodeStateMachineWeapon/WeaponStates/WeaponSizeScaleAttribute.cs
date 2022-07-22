using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSizeScaleAttribute : WeaponBaseState
{
    public override void EnterState(WeaponStateManager weapon)
    {
        //StartCoroutine(Timer(weapon.gameObject));
        Debug.Log("WeaponSizeScaleAttribute");
    }

    public override void UpdateState(WeaponStateManager weapon)
    {
        
    }

    public override void Hit(WeaponStateManager weapon)
    {
        
    }

    IEnumerator Timer(GameObject obj)
    {
        while (true)
        {
            obj.transform.localScale *= 1.01f;
            yield return new WaitForSeconds(1f);
        }
    }
}
