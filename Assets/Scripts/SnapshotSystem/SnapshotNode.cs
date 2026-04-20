using UnityEngine;
using System.Collections.Generic;

public class SnapshotNode
{
    public int Turn;

    public Vector3 playerPosition;
    public Vector3 playerRotation;
    public List<Vector3> EnemiesPos;
    public int str;
    public int dtx;
    public int spd;

    public SnapshotNode(Player player, int turn, SpawnEnemy spawner)
    {
        Turn = turn;

        playerPosition = player.transform.position;
        playerRotation = player.transform.rotation.eulerAngles;
        str = player.str;
        dtx = player.dtx;
        spd = player.spd;
        
        foreach (var enemy in spawner.enemies)
        {
            EnemiesPos.Add(enemy.transform.position);
        }
    }
}
