using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : WeaponBase
{
    [SerializeField] private BulletStats stats;
    [SerializeField] private BulletStats stats2;
    [SerializeField] private Rigidbody myBullet;
    [SerializeField] private Rigidbody myBullet2;
    [SerializeField] private float force = 50;
    [SerializeField] private bool spread;
    [SerializeField] private bool lob;
    
    protected override void Attack(float percent)
    {
        Ray camRay = InputManager.GetCameraRay();
        Rigidbody rb = Instantiate(percent > 0.5f ? myBullet2 : myBullet, camRay.origin, transform.rotation);
        
        if (lob)
        {
            rb.AddForce((Mathf.Max(percent, 0.1f) * force * camRay.direction) * 0.3f, ForceMode.Impulse);
            rb.AddForce(Mathf.Max(percent, 0.1f) * force * Vector3.up, ForceMode.Impulse);
            Destroy(rb.gameObject, t: 10);
        }
        else
        {
            rb.AddForce(Mathf.Max(percent, 0.1f) * force * camRay.direction, ForceMode.Impulse);
            Destroy(rb.gameObject, t: 5);
        }

        if (spread)
        {
            Rigidbody rb2 = Instantiate(percent > 0.5f ? myBullet2 : myBullet, camRay.origin, transform.rotation);
            rb2.AddForce(Mathf.Max(percent, 0.1f) * force * camRay.direction, ForceMode.Impulse);
            rb2.AddForce(Mathf.Max(percent, 0.1f) * force * 0.1f * Vector3.left, ForceMode.Impulse);
            Destroy(rb2.gameObject, t: 5);
            Rigidbody rb3 = Instantiate(percent > 0.5f ? myBullet2 : myBullet, camRay.origin, transform.rotation);
            rb3.AddForce(Mathf.Max(percent, 0.1f) * force * camRay.direction, ForceMode.Impulse);
            rb3.AddForce(Mathf.Max(percent, 0.1f) * force * 0.1f * Vector3.right, ForceMode.Impulse);
            Destroy(rb3.gameObject, t: 5);
        }
    }

    public override void SetBulletType(EProjectileType bulType)
    {
        stats.SetBulletType(bulType);
        stats2.SetBulletType(bulType);
    }
}
