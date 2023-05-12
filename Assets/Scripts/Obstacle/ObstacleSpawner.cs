using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private Transform[] _spawnpoints;
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
            CalculateParamsToSpawn(out GameObject prefab, out Vector3 spawpoint);
            Spawn(prefab, spawpoint);

            await UniTask.Delay(_delay.ToDelayMillisecond(), cancellationToken: token);
        }
        while (token.IsCancellationRequested == false);
    }

    private void CalculateParamsToSpawn(out GameObject prefab, out Vector3 spawpoint)
    {
        int indexSpawnpoint = _counter % _spawnpoints.Length;
        int indexPrefab = Random.Range(0, _prefabs.Length);

        prefab = _prefabs[indexPrefab];
        spawpoint = _spawnpoints[indexSpawnpoint].position;

        _counter++;
    }

    private void Spawn(GameObject prefab, Vector3 spawnpoint)
    {
        Instantiate(prefab, spawnpoint, Quaternion.identity, _container);
    }
}