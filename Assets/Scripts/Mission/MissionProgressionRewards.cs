using UnityEngine;
using FMAI.Survival.Economy;
using FMAI.Survival.Inventory;

namespace FMAI.Survival.Mission
{
    public class MissionProgressionRewards : MonoBehaviour
    {
        [SerializeField] private WalletSystem wallet;
        [SerializeField] private InventorySystem inventory;
        [SerializeField] private RewardMailbox mailbox;
        [SerializeField] private int xp;

        public int XP => xp;

        public void Grant(int rewardCoins, int rewardXp, string rewardItem, int rewardAmount = 1)
        {
            if (wallet != null && rewardCoins > 0) wallet.AddCoins(rewardCoins);
            if (rewardXp > 0) xp += rewardXp;
            if (string.IsNullOrWhiteSpace(rewardItem) || rewardAmount <= 0) return;

            for (int i = 0; i < rewardAmount; i++)
            {
                if (inventory != null && inventory.Add(rewardItem)) continue;
                if (mailbox != null) mailbox.Store(rewardItem);
            }
        }
    }
}
