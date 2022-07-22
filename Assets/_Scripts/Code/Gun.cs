using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    public override void Hit()
    {
        Debug.Log("Shoot");
        base.Hit();
    }
}
