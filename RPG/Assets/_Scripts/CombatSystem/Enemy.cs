using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy:MonoBehaviour
{
    [SerializeField]BaseStats stats;
    public Character character;
    public BasicAttackAbility basicAttack;
    private void Start()
    {
        character = new Character(stats);
         basicAttack = new BasicAttackBA();
    }
}
