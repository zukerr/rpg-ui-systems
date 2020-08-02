using Kryz.CharacterStats;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    private const int BASESTAT_MULT=25;
    private CharacterStat healthBaseStat;
    public event Action<float> OnHpChanged;
    private float value;
    public float Value
    {
        get
        {
            return value;
        }
        set
        {
            
            float maxHp=healthBaseStat.Value*BASESTAT_MULT;
            if(value > maxHp)
            {
                this.value = maxHp;

            }
            else
            {
                this.value = value;
            }
            
            
            OnHpChanged?.Invoke(this.value);
            
        }
    }
    public Health(CharacterStat healthBaseStat)
    {
        this.healthBaseStat = healthBaseStat;
        value = healthBaseStat.Value*BASESTAT_MULT;
    }
}
