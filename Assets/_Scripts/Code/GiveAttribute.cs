using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GiveAttribute : MonoBehaviour
{
    public Attribute attributes;
    public GameObject obj;
    public Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(delegate { Give(obj, attributes); });
    }

    public void Give(GameObject obj, Attribute attribute)
    {
        var objec = obj.GetComponent<IObject>();
        objec.GiveAttribute(attributes);
    }
    

}
