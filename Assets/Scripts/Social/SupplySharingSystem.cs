using UnityEngine;
using FMAI.Survival.Inventory;

namespace FMAI.Survival.Social
{
    /// <summary>
    /// Safe cooperative item-sharing foundation. Networking, identity and
    /// server authority remain responsibilities of the multiplayer layer.
    /// </summary>
    public class SupplySharingSystem : MonoBehaviour
    {
        [SerializeField] private float shareRange = 4f;

        public float ShareRange => shareRange;

        public bool CanShare(Transform giver, Transform receiver)
        {
            if (giver == null || receiver == null)
                return false;

            return Vector3.Distance(giver.position, receiver.position) <= shareRange;
        }

        public bool TransferOneItem(
            Transform giverTransform,
            InventorySystem giver,
            Transform receiverTransform,
            InventorySystem receiver,
            string itemId)
        {
            if (!CanShare(giverTransform, receiverTransform) ||
                giver == null || receiver == null ||
                string.IsNullOrWhiteSpace(itemId))
                return false;

            if (!giver.Has(itemId))
                return false;

            // Add first so a full receiver inventory never causes item loss.
            if (!receiver.Add(itemId))
                return false;

            if (!giver.Remove(itemId))
            {
                // Roll back if the source removal unexpectedly fails.
                receiver.Remove(itemId);
                return false;
            }

            return true;
        }
    }
}
