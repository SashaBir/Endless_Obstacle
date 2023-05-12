using UnityEngine;

public class LinearRotator : MonoBehaviour
{
    [SerializeField] private Vector3 _diretion;
    [SerializeField] private float _speed;

    public void Update()
    {
        transform.localEulerAngles += _diretion * _speed * Time.deltaTime;
    }
}
