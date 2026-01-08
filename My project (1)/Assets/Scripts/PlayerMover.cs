using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        TryMove();
    }

    private void TryMove()
    {
        var horizontal = Input.GetAxis("Horizontal") * Time.fixedDeltaTime;
        var vertical = Input.GetAxis("Vertical") * Time.fixedDeltaTime;
        var movingVector = (transform.right * horizontal + transform.forward * vertical) * _speed;
        Move(movingVector);
    }

    private void Move(Vector3 movingVector)
    {
        _rigidbody.velocity = new Vector3(movingVector.x, _rigidbody.velocity.y, movingVector.z);
    }
}
