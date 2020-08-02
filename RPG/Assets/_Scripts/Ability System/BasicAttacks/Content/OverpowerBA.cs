using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BasicAttackAbility", menuName = "Ability/BasicAttackAbility/Overpower")]
public class OverpowerBA : BasicAttackAbility
{
    private float damageValue = 0;

    public OverpowerBA()
    {
        elementType = ElementType.Physical;
    }

    protected override void DealDamage(Character user, List<Character> other)
    {
        CalculateDamage();
        foreach (Character c in other)
        {
            Combat.DealDamageOfType(c, elementType, damageValue);
        }
    }

    private void CalculateDamage()
    {
        //turbo obliczenia
        damageValue = 25f;
    }
}
