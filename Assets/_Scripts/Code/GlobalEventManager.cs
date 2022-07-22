using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager
{
    public static UnityEvent OnHumanKilled = new UnityEvent();
    public static void SendHumanKilled()
    {
        OnHumanKilled.Invoke();
    }
}
