using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kryz.CharacterStats;

[CreateAssetMenu(fileName = "New PassiveTrait", menuName = "PassiveTrait/Example")]
public class ExampleP : PassiveTrait
{
    private float sameValue = 10f;

    public override void OnPotencyIncrease()
    {
        //CurrentPotency++;
        Debug.Log("Stat before increase: " + Player.Instance.character.GetStat(atribute).Value);
        if(mod != null)
        {
            Player.Instance.character.GetStat(atribute).RemoveModifier(mod);
        }
        mod = new StatModifier(sameValue * CurrentPotency, modifierType);
        Debug.Log("Current potency: " + CurrentPotency);
        Player.Instance.character.GetStat(atribute).AddModifier(mod);
        Debug.Log("Stat after increase: " + Player.Instance.character.GetStat(atribute).Value);
    }
}
