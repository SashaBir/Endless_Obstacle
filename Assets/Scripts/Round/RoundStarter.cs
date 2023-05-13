using System;
using UnityEngine;

public class RoundStarter : MonoBehaviour
{
    [SerializeField] private ObstacleSpawner _spawner;

    private void Start()
    {
        StartRound();
    }

    public void StartRound() 
    {
        _spawner.StartSpawn();
    }
}
