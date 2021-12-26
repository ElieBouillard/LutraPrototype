using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Color _damagedColor = new Color();

    private Color _originalColor = new Color();
    private Material _mat = null;

    private void Start()
    {
        _mat = this.gameObject.GetComponentInChildren<Renderer>().material;
        _originalColor = _mat.color;
    }

    [ContextMenu("TakeDamage")]
    public void Damaged()
    {
        _mat.color = _damagedColor;
        Invoke(nameof(ResetMat),0.1f);
    }

    private void ResetMat()
    {
        _mat.color = _originalColor;
    }
}
