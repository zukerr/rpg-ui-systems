using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Choice/ModifyStatChoice")]
public class ModifyStatChoice : Choice
{
    public StatAtribute whichStatToChange;
    public float modifyValue;
    public Kryz.CharacterStats.StatModType type;
    public override void Consequences()
    {
        Player.Instance.character.GetStat(whichStatToChange).AddModifier(new Kryz.CharacterStats.StatModifier(modifyValue,type));
    }
}
