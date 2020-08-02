using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ActiveAbility", menuName = "Ability/ActiveAbility/Cleave")]
public class CleaveA : ActiveAbility
{
    float dmgValue = 20;

    protected override void ActiveAbilityBody(Character user, List<Character> other)
    {
        dmgValue += user.Strength.Value;
        foreach (Character c in other)
        {
            Combat.DealDamageOfType(c, ElementType.Physical, dmgValue);
        }
    }
    protected override void CooldownSetup()
    {
        Cooldown = 3;
    }
}
