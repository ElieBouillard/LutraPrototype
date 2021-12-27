using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadParameters : MonoBehaviour
{
    [SerializeField] private CMF.CameraController _cameraController = null;

    public void LoadMouseSensitivity()
    {
        _cameraController.cameraSpeed = PlayerPrefs.GetFloat("MouseSensitivity");
    }
}
