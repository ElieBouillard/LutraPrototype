using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 50f;
    private Rigidbody _rigidBody = null;

    [HideInInspector] public Vector3 dir = new Vector3();

    private void Start()
    {
        _rigidBody = this.gameObject.GetComponent<Rigidbody>();
        transform.forward = dir;
        _rigidBody.velocity = dir * _bulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
