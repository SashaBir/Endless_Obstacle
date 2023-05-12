using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class HitRecipient : MonoBehaviour
{
    [SerializeField] private Rigidbody _recipient;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out HitDistributor distributor) == true)
            Hit(collision.contacts[0].normal, distributor.Distance);
    }

    private void Hit(Vector3 normal, float distance)
    {
        _recipient.AddForce(normal * PhysicsExpansion.CalculateForceNoMass(distance), ForceMode.Impulse);
    }
}