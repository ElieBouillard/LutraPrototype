using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float _shootRange = 50f;
    [SerializeField] private LayerMask _shootableLayer = new LayerMask();

    [Space(20)]
    [Header("References")]
    [SerializeField] private Camera _mainCamera = null;
    [SerializeField] private Transform _muzzleFlashPos = null;
    [SerializeField] private GameObject _muzzleFlashFx = null;
    [SerializeField] private GameObject _bulletFx = null;
    [SerializeField] private GameObject _impactFx = null;
    [SerializeField] private GameObject _hitmarkerUi = null;
    [SerializeField] private CMF.CameraController _cameraController = null;

    [Header("AudioSources")]
    [SerializeField] private AudioSource _glockSound = null;
    [SerializeField] private AudioSource _hitSound = null;
    [SerializeField] private AudioSource _deadSound = null;


    private RaycastHit _hit = new RaycastHit();

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryShoot();
        }

        if (Input.GetMouseButtonDown(1))
        {
            _cameraController.SetFOV(45f);
        }

        if (Input.GetMouseButtonUp(1))
        {
            _cameraController.SetFOV(90f);
        }
    }

    private void TryShoot()
    {
        Ray ray = new Ray(_mainCamera.transform.position, _mainCamera.transform.forward);
        if (Physics.Raycast(ray, out _hit, _shootRange, _shootableLayer))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject muzzleFlashInstancce = Instantiate(_muzzleFlashFx, _muzzleFlashPos);

        GameObject bulletInstance = Instantiate(_bulletFx, _muzzleFlashPos.position, Quaternion.identity);
        bulletInstance.GetComponent<Bullet>().dir = (_hit.point - _muzzleFlashPos.position).normalized;

        GameObject impactInstance = Instantiate(_impactFx, _hit.point, Quaternion.identity);
        impactInstance.transform.forward = _hit.normal;

        Destroy(muzzleFlashInstancce, 1f);
        Destroy(bulletInstance, 1f);
        Destroy(impactInstance, 1f);

        _glockSound.Play();

        if(_hit.collider.gameObject.TryGetComponent<Target>(out Target target))
        {
            target.Damaged();
            _hitmarkerUi.SetActive(true);
            Invoke(nameof(ResetHitmarker), 0.1f);
            _hitSound.Play();
        }

        _cameraController.ShootCameraRecoil();
    }

    private void ResetHitmarker()
    {
        _hitmarkerUi.SetActive(false);
    }
}
