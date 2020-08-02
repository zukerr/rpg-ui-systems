using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Choice : ScriptableObject
{
    public string text;

    public Occurance succesor;
    public abstract void Consequences();
}
