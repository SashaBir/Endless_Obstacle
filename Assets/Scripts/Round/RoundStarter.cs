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
        Debug.Log("Start Game");

        _spawner.StartSpawn();
    }
}
