using System;
using UnityEngine;

[Serializable]
public struct Spawnpoint
{
    [field: SerializeField] public Transform[] Points { get; private set; }
}
