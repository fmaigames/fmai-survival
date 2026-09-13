using UnityEngine;
using FMAI.Survival.Player;

namespace FMAI.Survival.Social
{
    /// <summary>
    /// Safe player-to-player medical assistance foundation.
    /// The caller supplies the target PlayerStats; networking/consent UI can
    /// be layered on later without changing the healing rule.
    /// </summary>
    public class PlayerMedicalSupport : MonoBehaviour
    {
        [SerializeField] private float healAmount = 25f;
        [SerializeField] private float assistRange = 4f;

        public float HealAmount => healAmount;
        public float AssistRange => assistRange;

        public bool CanAssist(PlayerStats target)
        {
            if (target == null || target.IsDead) return false;
            return Vector3.Distance(transform.position, target.transform.position) <= assistRange;
        }

        public bool Assist(PlayerStats target)
        {
            if (!CanAssist(target)) return false;
            target.RestoreHealth(healAmount);
            return true;
        }
    }
}
