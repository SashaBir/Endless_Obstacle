using DG.Tweening;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _fadeDuration;
    [SerializeField] private Ease _fadeEase;
    [SerializeField] private float _movementDuration;
    [SerializeField] private Ease _movementEase;

    public void Launch(Transform target, int score)
    {
        SetText(score);
        Move(target);
        FadeText();
    }

    private void SetText(int score)
    {
        _text.text = $"+{score}";
    }

    private void Move(Transform target)
    {
        transform
            .DOMove(target.position, _movementDuration)
            .SetEase(_movementEase);
    }

    private void FadeText()
    {
        _text
            .DOFade(0, _fadeDuration)
            .SetEase(_fadeEase);
    }
}