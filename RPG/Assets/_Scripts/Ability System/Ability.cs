using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Ability : IconEntity
{
    public abstract void Use(Character user, List<Character> other);
    public void Use(Character user, Character other)
    {
        Use(user, new List<Character>() { other });
    }
}
