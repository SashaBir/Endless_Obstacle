using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class ScoreCounter : MonoBehaviour
{
    public event Action<int> OnScoreUpdated;
    public event Action<int> OnScoreGotten;

    private int _score = 0;

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Obstacle obstacle) == false)
            return;

        _score += obstacle.Score;

        OnScoreUpdated?.Invoke(_score);
        OnScoreGotten?.Invoke(obstacle.Score);

        Debug.Log($"Score: {_score}");
    }
}