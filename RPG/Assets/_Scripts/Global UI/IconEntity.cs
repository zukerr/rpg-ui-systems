using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconEntity : ScriptableObject
{
    public Sprite icon;
    public string entityName;
    [TextArea(3, 10)]
    public string description;
}
