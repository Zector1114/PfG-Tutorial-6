using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Flags]
public enum EProjectileType
{
    Water = 1,
    Fire = 2,
    Lightning = 4,
    Earth = 8
}

public class BulletStats : MonoBehaviour
{
    [SerializeField] private ParticleSystem waterSys;
    [SerializeField] private ParticleSystem fireSys;
    [SerializeField] private ParticleSystem lightningSys;
    [SerializeField] private ParticleSystem earthSys;

    [field: SerializeField] public float Damage { get; private set; }
    [field: SerializeField] public float Speed { get; private set; }
    [field: SerializeField] public float Scale { get; private set; }

    [field: SerializeField] public EProjectileType BulletType { get; private set; }

    public void SetBulletType(EProjectileType bulNum)
    {
        BulletType = bulNum;
    }

    public void OnCollisionEnter(Collision collision)
    {
        string output = "Types: ";

        if ((int)(BulletType & EProjectileType.Water) > 0)
        {
            output += "Water ";
            Instantiate(waterSys, collision.GetContact(0).point, Quaternion.FromToRotation(Vector3.forward, collision.GetContact(0).normal));
        }
        if ((int)(BulletType & EProjectileType.Fire) > 0)
        {
            output += "Fire ";
            Instantiate(fireSys, collision.GetContact(0).point, Quaternion.FromToRotation(Vector3.forward, collision.GetContact(0).normal));
        }
        if ((int)(BulletType & EProjectileType.Lightning) > 0)
        {
            output += "Lightning ";
            Instantiate(lightningSys, collision.GetContact(0).point, Quaternion.FromToRotation(Vector3.forward, collision.GetContact(0).normal));
        }
        if ((int)(BulletType & EProjectileType.Earth) > 0)
        {
            output += "Earth ";
            Instantiate(earthSys, collision.GetContact(0).point, Quaternion.FromToRotation(Vector3.forward, collision.GetContact(0).normal));
        }

        Debug.Log(output);
    }
}
