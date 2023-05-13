using System;
using UnityEngine;

public class ScoreTextSpawner : MonoBehaviour
{
    [SerializeField] private ScoreText _prefab;
    [SerializeField] private Transform _container;
    [SerializeField] private Transform _spawnpoint;
    [SerializeField] private ScoreCounter _counter;
    [SerializeField] private float _radius;

    public event Action<ScoreText, int> OnSpawned;

    private void OnEnable()
    {
        _counter.OnScoreGotten += OnSpawn;
    }

    private void OnDisable()
    {
        _counter.OnScoreGotten -= OnSpawn;
    }

    private void OnSpawn(int score)
    {
        var position = GetPosition();
        var scoreText = Spawn(position);

        OnSpawned?.Invoke(scoreText, score);
    }

    private Vector3 GetPosition()
    {
        Vector3 position = _spawnpoint.position;
        return new()
        {
            x = position.x + UnityEngine.Random.Range(-_radius, _radius),
            y = position.y + UnityEngine.Random.Range(-_radius, _radius),
        };
    }

    private ScoreText Spawn(Vector3 position)
    {
        return Instantiate(_prefab, position, Quaternion.identity, _container);
    }
}
