using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
    public Player player;
    public List<Enemy> enemies;
    
    public void Battle()
    {
        Battle battle = new Battle(player,enemies);
        battle.StartBattle();
    }
    private void Start()
    {
       Invoke("Battle",1f);
    }
}
