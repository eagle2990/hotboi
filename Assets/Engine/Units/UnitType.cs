using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class UnitType : ScriptableObject
{
    public List<UnitType> InjuredBy = new List<UnitType>();
    public List<UnitType> AdvantageOver = new List<UnitType>();

    public bool HasAdvantageOver(UnitType type)
    {
        return AdvantageOver.Contains(type);
    }

    public bool IsInjuredBy(UnitType type)
    {
        return InjuredBy.Contains(type);
    }
}