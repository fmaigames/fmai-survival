using FMAI.Survival.Inventory;
using UnityEngine;

namespace FMAI.Survival.Mission
{
    public static class MissionRewardSystem
    {
        public static bool Grant(MissionDefinition mission, InventorySystem inventory)
        {
            if (mission == null || inventory == null || mission.rewardAmount <= 0)
                return false;

            bool granted = true;
            for (int i = 0; i < mission.rewardAmount; i++)
                granted &= inventory.Add(mission.rewardItem);

            return granted;
        }
    }
}
