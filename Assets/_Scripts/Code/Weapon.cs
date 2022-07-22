using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IObject
{
    public int Attack = 10;
    public Human Human;
    
    public bool isPosion = false;
    public bool isResurrection = false;

    public virtual void Hit()
    {
        if (isPosion)
            Attack *= 2;
        if (isResurrection)
            Attack = Mathf.Abs(Attack);
        
        Human.ChangeLife(-Attack);
    }

    private void Awake()
    {
        GlobalEventManager.OnHumanKilled.AddListener(Huray);
    }

    public void Huray()
    {
        Debug.Log("huray");
    }

    public void GiveAttribute(Attribute attribute)
    {
        switch (attribute)
        {
            case Attribute.Poison:
                isPosion = true;
                break;
            case Attribute.Upgrade:
                Attack += 10;
                break;
            case Attribute.Resurrection:
                isResurrection = true;
                break;
            default:
                break;
        }
    }
}
