using DG.Tweening;
using UnityEngine;

public class LinearHitter : MonoBehaviour
{
    [SerializeField] private Transform _source;
    [SerializeField] private Transform _forwardPoint;
    [SerializeField] private Transform _backPoint;
    [SerializeField] private float _forwardDuration;
    [SerializeField] private float _backDuration;

    [Header("Debug")]
    [SerializeField] private Ease _ease;

    private void Start()
    {
        Launch();
    }

    public void Launch()
    {
        _source
            .DOLocalMove(_backPoint.localPosition, _backDuration)
            .SetEase(_ease)
            .OnComplete(() =>
            {
                _source
                    .DOLocalMove(_forwardPoint.localPosition, _forwardDuration)
                    .SetEase(_ease)
                    .OnComplete(Launch);
            });
    }
}
