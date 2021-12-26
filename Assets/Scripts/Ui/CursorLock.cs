using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLock : MonoBehaviour
{
    [SerializeField] private bool _cursorLocked = false;

    private void Start()
    {
        if (!_cursorLocked) return;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
