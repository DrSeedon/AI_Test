using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Attribute
{
    Poison,
    Upgrade,
    Resurrection,
    Size
}

public interface IObject
{
    public void GiveAttribute(Attribute attribute);
}