using UnityEngine;

public class LinearMovement : MonoBehaviour
{
    [SerializeField] private Vector3 _diretion;
    [SerializeField] private float _speed;

    public void Update()
    {
        transform.localPosition += _diretion * _speed * Time.deltaTime;
    }
}