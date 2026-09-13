using UnityEngine;
using FMAI.Survival.Player;

namespace FMAI.Survival.Drone
{
    public class MedicalDrone : MonoBehaviour
    {
        [SerializeField] private PlayerStats player;
        [SerializeField] private float healAmount = 20f;
        [SerializeField] private float cooldown = 15f;
        private float nextHealTime;

        public bool TryHeal()
        {
            if (player == null || Time.time < nextHealTime || player.IsDead) return false;
            player.Heal(healAmount);
            nextHealTime = Time.time + cooldown;
            return true;
        }

        public void SetPlayer(PlayerStats target)
        {
            player = target;
        }
    }
}
