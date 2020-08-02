using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BasicAttackAbility", menuName = "Ability/BasicAttackAbility/Windslash")]
public class WindslashBA : BasicAttackAbility
{
    private float damageValue = 0;

    public WindslashBA()
    {
        elementType = ElementType.Wind;
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
