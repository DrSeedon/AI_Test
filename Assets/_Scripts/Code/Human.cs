using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Human : MonoBehaviour, IObject
{
    public int Life = 100;
    public bool isLife = true;

    public UnityEvent OnDies;
    
        
    
    public void ChangeLife(int value)
    {
        if (!isLife) return;
        Life += value;
        isLife = Life > 0;
        if (!isLife)
        {
            GlobalEventManager.SendHumanKilled();
            OnDies.Invoke();
        }
    }

    public void GiveAttribute(Attribute attribute)
    {
        switch (attribute)
        {
            case Attribute.Poison:
                ChangeLife(-100);
                break;
            case Attribute.Upgrade:
                ChangeLife(100);
                break;
            case Attribute.Resurrection:
                if (!isLife)
                {
                    isLife = true;
                    Life = 100;
                }
                break;
            default:
                break;
        }
    }

}
