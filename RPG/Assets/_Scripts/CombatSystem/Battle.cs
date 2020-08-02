using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle
{
    private Player player;
    private List<Enemy> enemies;
    int counter;
    private List<string> logs;
    public Battle(Player player, List<Enemy> enemies)
    {
        this.player=player;
        this.enemies=enemies;
        logs = new List<string>();
    }

    public void StartBattle()
    {
        counter =0;
        do
        {
            NextRound();
            float dif = enemies[0].character.Health.Value;
            player.basicAttack.Use(player.character,enemies[0].character);
            dif-=enemies[0].character.Health.Value;
            logs.Add($"Player dealt {dif} damage enemy hp:{enemies[0].character.Health.Value}");
            RemoveIfDead(enemies[0]);
            foreach (var item in enemies)
            {
                dif = player.character.Health.Value;
                item.basicAttack.Use(item.character,player.character);
                dif-=player.character.Health.Value;
                logs.Add($"Enemy dealt {dif} damage Player hp:{player.character.Health.Value}");
            }
        }while(ContinueBattle());
        foreach (var item in logs)
        {
            Debug.Log(item);
        }
    }
    private bool ContinueBattle()=> player.character.Health.Value>0&&enemies.Count>0;
    private void NextRound()
    {
        counter++;
        logs.Add("Round"+counter);
    }
    private void RemoveIfDead(Enemy enemy)
    {
        if (enemy.character.Health.Value <= 0)
        {
            enemies.Remove(enemy);
        }
    }
    
}
