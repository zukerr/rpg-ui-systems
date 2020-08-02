using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Choice/TakeItem")]
public class TakeItemChoice : Choice
{
    public Kryz.CharacterStats.Examples.Item item;
    public override void Consequences()
    {
        Player.Instance.inventory.AddItem(item);
    }
}
