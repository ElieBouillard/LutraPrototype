using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    [HideInInspector] public Enemy _enemy = null;
    [HideInInspector] public Collider _collider = null;

    private void Start()
    {
        _enemy = this.gameObject.GetComponentInParent<Enemy>();
        _collider = this.gameObject.GetComponent<Collider>();

        _enemy.Die += DesactiveCollider;
    }

    public virtual void GetHit(float classicDamage, float headshotDamage)
    {

    }

    private void DesactiveCollider()
    {
        _collider.enabled = false;
    }
}
