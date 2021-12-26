using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedDisplay : MonoBehaviour
{
    private Rigidbody _rigidbody = null;
    private TMP_Text _speedText = null;

    private void Start()
    {
        _rigidbody = GameObject.Find("Player").GetComponent<Rigidbody>();
        _speedText = this.gameObject.GetComponent<TMP_Text>();
    }

    private void Update()
    {
        _speedText.text = $"Speed: {_rigidbody.velocity.magnitude}";
    }
}
