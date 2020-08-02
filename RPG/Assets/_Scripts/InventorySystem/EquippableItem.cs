using System.Collections.Generic;
using UnityEngine;

using Kryz.CharacterStats;
	public enum EquipmentType
	{
		Helmet,
		Chest,
		Gloves,
		Boots,
		Weapon1,
		Weapon2,
		Accessory1,
		Accessory2,
	}
	public enum StatAtribute
    {
		Str,
		Dex,
		Int,
		Vit,
		Armor,
		WindRes,
		WaterRes,
		FireRes,
		NatureRes
    }
[System.Serializable]
	public struct ItemInfo
    {
		public float value;
		public StatAtribute statAtribute;
		public StatModType modType;
    }
	[CreateAssetMenu]
	public class EquippableItem : Kryz.CharacterStats.Examples.Item
	{

		public List<ItemInfo> bonuses;
		[Space]
		public EquipmentType EquipmentType;

		public void Equip(Character c)
		{
			foreach(var item in bonuses)
            {
				if(item.value > 0)
                {
					c.GetStat(item.statAtribute).AddModifier(new StatModifier(item.value,item.modType,this));
                }
            }
		}

		public void Unequip(Character c)
		{
			foreach(var item in bonuses)
            {
					c.GetStat(item.statAtribute).RemoveAllModifiersFromSource(this);
            }
		}
	}

