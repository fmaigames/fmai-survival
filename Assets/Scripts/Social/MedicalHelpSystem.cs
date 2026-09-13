using System;
using UnityEngine;
using FMAI.Survival.Player;

namespace FMAI.Survival.Social
{
    /// <summary>
    /// Safe player-to-player support foundation. Network authority and UI are
    /// intentionally left to the multiplayer layer.
    /// </summary>
    public class MedicalHelpSystem : MonoBehaviour
    {
        [SerializeField] private float helpRange = 4f;
        [SerializeField] private float healAmount = 25f;

        public float HelpRange => helpRange;
        public float HealAmount => healAmount;

        public bool CanHelp(Transform helper, PlayerStats target)
        {
            if (helper == null || target == null || target.IsDead)
                return false;
            return Vector3.Distance(helper.position, target.transform.position) <= helpRange;
        }

        public bool GiveMedicalHelp(Transform helper, PlayerStats target)
        {
            if (!CanHelp(helper, target))
                return false;

            float before = target.Health;
            target.RestoreHealth(healAmount);
            return target.Health > before;
        }

        public bool ReviveSupport(PlayerStats target, float reviveHealth = 20f)
        {
            if (target == null || !target.IsDead || reviveHealth <= 0f)
                return false;

            // Revival authority belongs to the multiplayer/game-state layer.
            // This foundation only exposes the safe health restoration contract.
            return false;
        }
    }
}
