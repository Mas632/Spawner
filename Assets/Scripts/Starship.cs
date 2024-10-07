using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Starship : MonoBehaviour
{
    [SerializeField] private float _forceValue;

    private Rigidbody _rigidbody;
    private Vector3 _forceDirection;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _forceDirection = transform.forward;
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(_forceDirection * _forceValue);
    }

    public void ChangeForceDirection(Vector3 newForceDirection)
    {
        _forceDirection = newForceDirection;
        transform.forward = newForceDirection;
    }
}
