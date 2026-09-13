using System.Collections.Generic;
using UnityEngine;

namespace FMAI.Survival.Base
{
    public class StorageChest : MonoBehaviour
    {
        [SerializeField] private int capacity = 40;
        private readonly List<string> storedItems = new();

        public bool Store(string itemId)
        {
            if (string.IsNullOrWhiteSpace(itemId) || storedItems.Count >= capacity)
                return false;

            storedItems.Add(itemId);
            return true;
        }

        public bool Take(string itemId) => storedItems.Remove(itemId);
        public IReadOnlyList<string> Items => storedItems;
    }
}
