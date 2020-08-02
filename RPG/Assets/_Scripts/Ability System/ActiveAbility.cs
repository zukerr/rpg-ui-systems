using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActiveAbility : Ability
{
    public int Cooldown { get; protected set; }
    public int TurnsUntilReady { get; set; }
    public bool Ready { get; set; } = false;

    public override void Use(Character user, List<Character> other)
    {
        if(TurnsUntilReady == 0)
        {
            ActiveAbilityBody(user, other);
            TurnsUntilReady = Cooldown;
        }
        else
        {
            TurnsUntilReady--;
        }
    }
    protected abstract void CooldownSetup();
    protected virtual void Setup()
    {
        CooldownSetup();
        TurnsUntilReady = Cooldown;
    }
    protected abstract void ActiveAbilityBody(Character user, List<Character> other);
}
