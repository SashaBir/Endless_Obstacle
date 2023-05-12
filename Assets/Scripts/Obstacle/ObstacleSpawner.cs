using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private Spawnpoint[] _spawnpoints;
    [SerializeField] private Transform _container;
    [SerializeField] private float _delay;

    private CancellationTokenSource _tokenSource;
    private int _counter = 0;

    private void OnDisable()
    {
        _tokenSource?.Cancel();
        _tokenSource?.Dispose();
    }

    public void StartSpawn()
    {
        _tokenSource = new();
        ProcessSpawn(_tokenSource.Token).Forget();
    }

    public void StopSpawn()
    {
        _tokenSource?.Cancel();
        _counter = 0;
    }

    private async UniTask ProcessSpawn(CancellationToken token)
    {
        do
        {
            var spawnpoint = GetSpawnpoint();
            foreach (var point in spawnpoint.Points)
            {
                var prefab = GetPrefab();
                Spawn(prefab, point.position);
            }

            await UniTask.Delay(_delay.ToDelayMillisecond(), cancellationToken: token);
        }
        while (token.IsCancellationRequested == false);
    }

    private void Spawn(GameObject prefab, Vector3 spawnpoint)
    {
        Instantiate(prefab, spawnpoint, Quaternion.identity, _container);
    }

    private Spawnpoint GetSpawnpoint()
    {
        int indexSpawnpoint = _counter % _spawnpoints.Length;
        var spawpoint = _spawnpoints[indexSpawnpoint];

        _counter++;

        return spawpoint;
    }

    private GameObject GetPrefab()
    {
        int indexPrefab = Random.Range(0, _prefabs.Length);
        return _prefabs[indexPrefab];
    }
}