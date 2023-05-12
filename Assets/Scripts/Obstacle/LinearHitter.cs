using DG.Tweening;
using UnityEngine;

public class LinearHitter : MonoBehaviour
{
    [SerializeField] private Transform _source;
    [SerializeField] private Transform _forwardPoint;
    [SerializeField] private Transform _backPoint;
    [SerializeField] private float _forwardDuration;
    [SerializeField] private float _backDuration;

    private void Start()
    {
        Hit();
    }

    public void Hit()
    {
        _source
            .DOLocalMove(_backPoint.localPosition, _backDuration)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                _source
                    .DOLocalMove(_forwardPoint.localPosition, _forwardDuration)
                    .SetEase(Ease.Linear)
                    .OnComplete(Hit);
            });
    }
}