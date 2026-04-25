using System;
using UnityEngine;

[RequireComponent(typeof(Cube))]
public class CollisionDetector : MonoBehaviour
{
    public event Action CollisionWithFloor;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out Floor floor))
        {
            CollisionWithFloor?.Invoke();
        }
    }
}