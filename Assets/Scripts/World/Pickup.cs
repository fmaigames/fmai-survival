using FMAI.Survival.Inventory;
using UnityEngine;

namespace FMAI.Survival.World
{
    public class Pickup : MonoBehaviour
    {
        [SerializeField] private string itemId = "food.basic";

        public void SetItemId(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
                itemId = value;
        }

        private void OnTriggerEnter(Collider other)
        {
            var inventory = other.GetComponentInParent<InventorySystem>();
            if (inventory != null && inventory.Add(itemId))
                Destroy(gameObject);
        }
    }
}
