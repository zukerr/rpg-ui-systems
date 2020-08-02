using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Card : ScriptableObject
{
    public Sprite icon;
    public string cardName;
    [Multiline]
    public string description;
}
