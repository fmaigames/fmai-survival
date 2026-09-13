using UnityEngine;
using FMAI.Survival.Player;

namespace FMAI.Survival.Combat
{
    public class ArmorSystem : MonoBehaviour
    {
        [SerializeField] private float armorDurability = 100f;
        [SerializeField] private float damageReduction = 0.35f;
        [SerializeField] private PlayerStats player;

        public float Durability => armorDurability;
        public bool HasArmor => armorDurability > 0f;

        public void Equip(float durability, float reduction)
        {
            armorDurability = Mathf.Max(0f, durability);
            damageReduction = Mathf.Clamp01(reduction);
        }

        public float AbsorbDamage(float incomingDamage)
        {
            if (!HasArmor) return incomingDamage;
            float reduced = incomingDamage * (1f - damageReduction);
            armorDurability = Mathf.Max(0f, armorDurability - incomingDamage);
            return reduced;
        }
    }
}
