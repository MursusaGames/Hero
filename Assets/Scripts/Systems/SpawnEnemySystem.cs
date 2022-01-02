using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemySystem : MonoBehaviour
{
    public List<GameObject> enemys = new List<GameObject>(5);
    public List<Vector3> positions = new List<Vector3>(5);
    void Start()
    {
        InitSpawn(0);
        GameController.instance.changeArena += InitSpawn;
    }
    private void OnDisable()
    {
        GameController.instance.changeArena -= InitSpawn;
    }

    private void InitSpawn(int currentArena)
    {
        for (int i = 0; i < currentArena + 1; i++)
        {
            var enemy = Instantiate(enemys[i], positions[i], Quaternion.identity);
            GameController.instance.enemysInLevel.Add(enemy);
        }
    }
    
}
