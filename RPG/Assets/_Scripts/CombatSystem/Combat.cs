using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Combat
{
    public const float DAMAGE_REDUCTION_VARIABLE = 100;

    public static void DealDamageOfType(Character target, ElementType type, float value)
    {
        float resistance = 0;
        float dmgMultiplier = 1;
        switch(type)
        {
            case ElementType.Fire:
                resistance = target.FireResist.Value;
                break;
            case ElementType.Nature:
                resistance = target.NatureResist.Value;
                break;
            case ElementType.Physical:
                resistance = target.Armor.Value;
                dmgMultiplier = DAMAGE_REDUCTION_VARIABLE / (DAMAGE_REDUCTION_VARIABLE + resistance);
                break;
            case ElementType.Water:
                resistance = target.WaterResist.Value;
                break;
            case ElementType.Wind:
                resistance = target.WindResist.Value;
                break;
        }
        if(type != ElementType.Physical)
        {
            dmgMultiplier = 1 - resistance;
        }

        float calculatedValue = value * dmgMultiplier;
        target.Health.Value -= calculatedValue;
    }
}
