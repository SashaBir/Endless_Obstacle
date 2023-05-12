using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class HitDistributor : MonoBehaviour
{
    [field: SerializeField] public float Distance { get; private set; }
}