using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class RoundFinalizer : MonoBehaviour
{
    [SerializeField] private Collider _playerLoseTrigger;
    [SerializeField] private ObstacleSpawner _spawner;

    private CompositeDisposable _disposable;

    private void OnEnable()
    {
        _disposable = new();

        _playerLoseTrigger
            .OnTriggerExitAsObservable()
            .Subscribe(collision => 
            {
                if (collision.transform.GetComponent<Player>() == true)
                    OnFinalize();
            })
            .AddTo(_disposable);
    }

    private void OnDisable()
    {
        _disposable?.Dispose();
    }

    private void OnFinalize()
    {
        Debug.Log("Finalize Game");

        _spawner.StopSpawn();
    }
}