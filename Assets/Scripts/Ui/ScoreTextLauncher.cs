using UnityEngine;

public class ScoreTextLauncher : MonoBehaviour
{
    [SerializeField] private ScoreTextSpawner _spawner;
    [SerializeField] private Transform _target;

    private void OnEnable()
    {
        _spawner.OnSpawned += OnLaunch;
    }

    private void OnDisable()
    {
        _spawner.OnSpawned -= OnLaunch;
    }

    public void OnLaunch(ScoreText scoreText, int score)
    {
        scoreText.Launch(_target, score);
    }
}
