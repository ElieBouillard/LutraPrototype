using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunOrientation : MonoBehaviour
{
    [SerializeField] private GameObject _cameraTarget = null;

    private void Update()
    {
        transform.rotation = _cameraTarget.transform.rotation;
    }
}
