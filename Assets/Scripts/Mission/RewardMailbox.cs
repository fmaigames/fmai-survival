using System.Collections.Generic;
using UnityEngine;
using FMAI.Survival.Inventory;

namespace FMAI.Survival.Mission
{
    public class RewardMailbox : MonoBehaviour
    {
        [SerializeField] private List<string> storedRewards = new();

        public IReadOnlyList<string> StoredRewards => storedRewards;

        public void Store(string itemId, int amount = 1)
        {
            if (string.IsNullOrWhiteSpace(itemId) || amount <= 0) return;
            for (int i = 0; i < amount; i++) storedRewards.Add(itemId);
        }

        public int ClaimAll(InventorySystem inventory)
        {
            if (inventory == null) return 0;
            int claimed = 0;
            for (int i = storedRewards.Count - 1; i >= 0; i--)
            {
                if (!inventory.Add(storedRewards[i])) continue;
                storedRewards.RemoveAt(i);
                claimed++;
            }
            return claimed;
        }
    }
}
