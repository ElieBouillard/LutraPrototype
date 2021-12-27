using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitClassic : EnemyHit
{
    public override void GetHit(float classicDamage, float headshotDamage)
    {
        _enemy.TakeDamage(false, classicDamage);
    }
}
