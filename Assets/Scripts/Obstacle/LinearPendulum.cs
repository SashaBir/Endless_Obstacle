using DG.Tweening;
using UnityEngine;

public class LinearPendulum : MonoBehaviour
{
    [SerializeField] private Transform _source;
    [SerializeField] private Vector3 _forwardEulerAngles;
    [SerializeField] private Vector3 _backEulerAngles;
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
            .DOLocalRotate(_backEulerAngles, _backDuration)
            .SetEase(_ease)
            .OnComplete(() =>
            {
                _source
                    .DOLocalRotate(_forwardEulerAngles, _forwardDuration)
                    .SetEase(_ease)
                    .OnComplete(Launch);
            });
    }
}