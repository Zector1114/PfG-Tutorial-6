using UnityEngine;

namespace ScriptableObjects
{
    public enum EProjectileType
    {
        Water = 1,
        Poison = 2,
        Fire = 4,
        Lightning = 8,
        Earth = 16
    }

    [CreateAssetMenu(menuName = "BulletStats", fileName = "BulletSO", order = 1)]
    public class BulletSO : ScriptableObject
    {
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float Scale { get; private set; }

        [field: SerializeField] public EProjectileType BulletType { get; private set; }
    }
}