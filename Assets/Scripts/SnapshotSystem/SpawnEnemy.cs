using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;

public class SpawnEnemy : MonoBehaviour
{
    public Enemy EnemyPrefab;
    public int Range = 2;
    public Transform spawnPoint; 

  public List<Enemy> enemies = new List<Enemy>();
  private void OnEnable()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.OnPassTurn += MoveEnemies;
            GameManager.instance.OnPassTurn += CreateEnemy;
        }
    }

    private void OnDisable()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.OnPassTurn -= MoveEnemies;
            GameManager.instance.OnPassTurn -= CreateEnemy;
        }
    }

    private void MoveEnemies()
    {
        GameManager.instance.EnablePlayerTurn = false;

        foreach (var enemy in enemies)
        {
            enemy.MoveToTarget();
        }

        Invoke(nameof(EnableTurn) , 1); 
    }
    [Button]
    private void CreateEnemy()
    {
        Vector3Int ramdomPos = new Vector3Int(UnityEngine.Random.Range(-Range, 10),1, UnityEngine.Random.Range(-Range, 10));
        Enemy enemy = Instantiate(EnemyPrefab);
        enemy.Set(GameManager.instance.transform, ramdomPos);
    }
    
    public void ClearEnemies()
    {
         foreach (var enemy in enemies)
         {
             Destroy(enemy);
         }
         enemies.Clear();
    }
    public void LoadEnimes(List<Vector3> EnemiesPos)
    {
        if (EnemyPrefab == null)
        {
            Debug.LogError("EnemyPrefab no está asignado en SpawnEnemy.");
            return;
        }

        if (GameManager.instance == null || GameManager.instance.player == null)
        {
            Debug.LogError("GameManager.instance o GameManager.instance.player es null. Asegúrate de que el GameManager y el jugador estén inicializados.");
            return;
        }

        foreach (var pos in EnemiesPos)
        {
            Enemy enemy = Instantiate(EnemyPrefab);
            enemy.Set(GameManager.instance.player.transform, pos); // Asignar al jugador como objetivo
            enemies.Add(enemy);
        }
    }


    void EnableTurn()
    {
          GameManager.instance.EnablePlayerTurn = true;
    }
   
}

