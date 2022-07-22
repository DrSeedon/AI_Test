using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponStateManager : MonoBehaviour, IObject
{
    public int DefaultAttack = 10;
    internal int attack; 
    public Human Human;

    private List<WeaponBaseState> currentStates = new List<WeaponBaseState>();
    [SerializeField] private List<string> currentStatesString = new List<string>();

    public WeaponPoisonAttribute PoisonAttribute = new WeaponPoisonAttribute();
    public WeaponResurrectionAttribute ResurrectionAttribute = new WeaponResurrectionAttribute();
    public WeaponUpgradeAttribute UpgradeAttribute = new WeaponUpgradeAttribute();
    public WeaponSizeScaleAttribute SizeScaleAttribute = new WeaponSizeScaleAttribute();
    
    public virtual void Hit()
    {
        attack = DefaultAttack;
        foreach (var states in currentStates)
        {
            states.Hit(this);
        }

        Human.ChangeLife(-attack);
        Debug.Log("hit: " + -attack);
    }

    private void Update()
    {
        foreach (var states in currentStates)
        {
            states.UpdateState(this);
        }
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
                AddAttribute(PoisonAttribute);
                break;
            case Attribute.Upgrade:
                AddAttribute(UpgradeAttribute);
                break;
            case Attribute.Resurrection:
                AddAttribute(ResurrectionAttribute);
                break;
            case Attribute.Size:
                AddAttribute(SizeScaleAttribute);
                break;
        }
    }

    private void AddAttribute(WeaponBaseState attribute)
    {
        if (currentStates.Contains(attribute) && !attribute.isStacking)
            return;
        
        currentStates.Add(attribute);
        attribute.EnterState(this);
        
        OrganizeAttribute();
    }

    private void OrganizeAttribute()
    {
        currentStates = currentStates.OrderBy(o => o.Priority).ToList();

        currentStatesString.Clear();
        foreach (var state in currentStates)
        {
            currentStatesString.Add(state.ToString());
        }
    }
}
