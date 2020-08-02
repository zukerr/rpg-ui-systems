using Kryz.CharacterStats.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Singleton
    private static Player _instance;
    public static Player Instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject o = new GameObject("Player");
                Player p = o.AddComponent<Player>();
                _instance = p;  
            }
             return _instance;
        }
    }
    
    #endregion
    [SerializeField] BaseStats stats;
    public Character character;
    public BasicAttackAbility basicAttack;
    public ActiveAbility activeAbility = null;
    public Inventory inventory;
    public PlayerAbilityPoints abilityPoints;
    public Expirience expirience;
    public void Awake()
    {
        _instance = this;
         character = new Character(stats);
        basicAttack = (BasicAttackAbility)ScriptableObject.CreateInstance("BasicAttackBA");
        abilityPoints = new PlayerAbilityPoints();
        expirience = new Expirience();  
    }
  


}
