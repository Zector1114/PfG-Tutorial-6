using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private List<WeaponBase> _myWeapons;
    [SerializeField] private int ammoBoxNum;
    [SerializeField] private float speed;
    private Vector3 moveDirection;
    private bool weaponShootToggle;
    private int weapNum = 1;

    [field: SerializeField] public EProjectileType BulletType { get; private set; }

    private void Start()
    {
        InputManager.Init(this);
        InputManager.EnableInGame();
    }

    private void Update()
    {
        transform.position += speed * Time.deltaTime * moveDirection;
    }

    public void SetMovementDirection(Vector3 currentDirection)
    {
        moveDirection = currentDirection;
    }

    public void Shoot()
    {
        weaponShootToggle = !weaponShootToggle;
        if (weaponShootToggle)
        {
            _myWeapons[weapNum - 1].SetBulletType(BulletType);
            _myWeapons[weapNum - 1].StartShooting();
        }
        else _myWeapons[weapNum - 1].StopShooting();
    }

    public void WeaponSwap(int swapNum)
    {
        weapNum = swapNum;

        _myWeapons[weapNum - 1].AmmoUIUpdate();
    }

    public void BulletSwap(int bulNum)
    {
        switch (bulNum)
        {
            case 0:
                ToggleState(EProjectileType.Water);
                break;
            case 1:
                ToggleState(EProjectileType.Fire);
                break;
            case 2:
                ToggleState(EProjectileType.Lightning);
                break;
            case 3:
                ToggleState(EProjectileType.Earth);
                break;
        }
    }

    public void ToggleState(EProjectileType toTog)
    {
        if ((int)(BulletType & toTog) > 0)
        {
            BulletType &= ~toTog;
        }
        else
        {
            BulletType |= toTog;
        }
    }

    public void CallReload()
    {
        _myWeapons[weapNum - 1].Reload();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collided!");

        if (collision.gameObject.CompareTag("AmmoCrate"))
        {
            Debug.Log("Ammo!");
            _myWeapons[weapNum - 1].AmmoCollect(ammoBoxNum);
            Destroy(collision.gameObject);
        }
    }
}
