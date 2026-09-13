using System.Collections.Generic;
using UnityEngine;

namespace FMAI.Survival.Inventory
{
    public class InventorySystem : MonoBehaviour
    {
        [SerializeField] private int capacity = 24;
        private readonly List<string> items = new();

        public IReadOnlyList<string> Items => items;

        public bool Add(string itemId)
        {
            if (items.Count >= capacity || string.IsNullOrWhiteSpace(itemId))
                return false;

            items.Add(itemId);
            return true;
        }

        public bool Remove(string itemId) => items.Remove(itemId);
        public bool Has(string itemId) => items.Contains(itemId);
        public int Count => items.Count;
        public int CountItem(string itemId)
        {
            int count = 0;
            foreach (string item in items)
                if (item == itemId) count++;
            return count;
        }
    }
}
