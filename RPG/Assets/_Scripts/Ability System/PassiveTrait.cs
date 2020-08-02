using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kryz.CharacterStats;

public abstract class PassiveTrait : IconEntity
{
    public int maxPotency;
    public int CurrentPotency { get; set; } = 0;
    public StatAtribute atribute;
    public StatModType modifierType;
    protected StatModifier mod = null;
    public PNodeStatus Status { get; set; } = PNodeStatus.Locked;

    public abstract void OnPotencyIncrease();
    public void OnReset()
    {
        if (mod != null)
        {
            Player.Instance.character.GetStat(atribute).RemoveModifier(mod);
        }
    }
}
