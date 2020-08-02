using Kryz.CharacterStats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public Health Health { get; private set; }

    public CharacterStat Strength { get; private set;}
    public CharacterStat Dexterity { get; private set; }
    public CharacterStat Intelligence { get; private set; }
    public CharacterStat Vitality { get; private set; }

    public CharacterStat Armor { get; private set; }
    public CharacterStat FireResist { get; private set; }
    public CharacterStat WaterResist { get; private set; }
    public CharacterStat WindResist { get; private set; }
    public CharacterStat NatureResist { get; private set; }

    public Character(BaseStats baseStats)
    {
        Strength = new CharacterStat(baseStats.Strength);
        Dexterity = new CharacterStat(baseStats.Dexterity);
        Intelligence = new CharacterStat(baseStats.Intelligence);
        Vitality = new CharacterStat(baseStats.Vitality);

        Armor = new CharacterStat(baseStats.Armor);
        FireResist = new CharacterStat(baseStats.FireResist);
        WaterResist = new CharacterStat(baseStats.WaterResist);
        WindResist = new CharacterStat(baseStats.WindResist);
        NatureResist = new CharacterStat(baseStats.NatureResist);

        Health = new Health(Vitality);
    }
    public CharacterStat GetStat(StatAtribute statAribute)
    {
        switch (statAribute)
        {
            case StatAtribute.Str:
                return Strength;
            case StatAtribute.Dex:
                return Dexterity;
            case StatAtribute.Int:
                return Intelligence;
            case StatAtribute.Vit:
                return Vitality;
            case StatAtribute.Armor:
                return Armor;
            case StatAtribute.FireRes:
                return FireResist;
            case StatAtribute.NatureRes:
                return NatureResist;
            case StatAtribute.WaterRes:
                return WaterResist;
            case StatAtribute.WindRes:
                return WindResist;
            default:
                return null;
        }
    }
}
