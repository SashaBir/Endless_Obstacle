using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    [field: SerializeField] public int Score { get; private set; }

    public abstract void Launch();
}
