using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kryz.CharacterStats;
[CreateAssetMenu(fileName ="New Stats",menuName ="BaseStats")]
public class BaseStats : ScriptableObject
{
    public float Strength;
    public float Dexterity;
    public float Intelligence;
    public float Vitality;

    public float Armor;
    public float FireResist;
    public float WaterResist;
    public float WindResist;
    public float NatureResist;
}
