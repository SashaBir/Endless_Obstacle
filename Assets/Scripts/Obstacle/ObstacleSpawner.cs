using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private Spawnpoint[] _spawnpoints;
    [SerializeField] private Transform _container;
    [SerializeField] private float _delay;

    public event Action<GameObject> OnSpawned;

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

    private async UniTaskVoid ProcessSpawn(CancellationToken token)
    {
        do
        {
            var spawnpoint = GetSpawnpoint();
            foreach (var point in spawnpoint.Points)
            {
                var prefab = GetPrefab();
                var obstacle = Spawn(prefab, point.position);

                OnSpawned.Invoke(obstacle);
            }

            await UniTask.Delay(_delay.ToDelayMillisecond(), cancellationToken: token);
        }
        while (token.IsCancellationRequested == false);
    }

    private GameObject Spawn(GameObject prefab, Vector3 spawnpoint)
    {
        return Instantiate(prefab, spawnpoint, Quaternion.identity, _container);
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
        int indexPrefab = UnityEngine.Random.Range(0, _prefabs.Length);
        return _prefabs[indexPrefab];
    }
}
