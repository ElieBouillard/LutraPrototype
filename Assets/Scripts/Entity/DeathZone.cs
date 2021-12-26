using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{

    [SerializeField] private Transform _respawnTr = null;
    private GameObject _player = null;

    private void Start()
    {
        _player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        _player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        _player.transform.position = _respawnTr.position;
    }
}
