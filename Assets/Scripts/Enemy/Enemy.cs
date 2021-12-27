using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _startLife = 100f;

    private float _currLife = 0f;
    private Animator _animator = null;

    public event Action Die;

    private void Start()
    {
        Setup();
    }

    private void Setup()
    {
        _animator = this.gameObject.GetComponent<Animator>();
        _currLife = _startLife;
    }

    public void TakeDamage(bool isHeadshot, float damage)
    {

        _currLife -= damage;

        if(_currLife <= 0f) 
        {
            Die?.Invoke();

            if (isHeadshot)
            {
                HeadshotDeath();
            }
            else
            {
                ClassicDeath();
            }
        }
        else
        {
            GetHitAnim();
        }
    }

    private void GetHitAnim()
    {
        _animator.SetTrigger("Hit");
    }

    private void HeadshotDeath()
    {
        _animator.SetTrigger("HeadshotDeath");
    }

    private void ClassicDeath()
    {
        _animator.SetTrigger("ClassicDeath");
    }
}
