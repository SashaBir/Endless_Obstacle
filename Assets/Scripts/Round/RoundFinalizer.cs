using UnityEngine;

public class RoundFinalizer : MonoBehaviour
{
    [SerializeField] private Collider _playerLoseTrigger;
    [SerializeField] private ObstacleSpawner _spawner;

    private void OnEnable()
    {
       // _playerLoseTrigger.
    }

    private void OnDisable()
    {
        //_trigger.OnLost -= OnFinalize;
    }

    private void OnFinalize()
    {
        _spawner.StopSpawn();
    }
}