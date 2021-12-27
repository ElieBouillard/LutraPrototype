using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitHeadshot : EnemyHit
{
    public override void GetHit(float classicDamage, float headshotDamage)
    {
        _enemy.TakeDamage(true, headshotDamage);
    }
}
