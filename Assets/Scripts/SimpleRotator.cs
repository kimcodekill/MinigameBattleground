using System;
using UnityEngine;

public class SimpleRotator : MonoBehaviour
{
    [SerializeField] private Vector3 rotationSpeed;

    private void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }

    public void SetRotationSpeed(Vector3 speed) => rotationSpeed = speed;
}
