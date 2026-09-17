using UnityEngine;

namespace FMAI.Survival.Inventory
{
    [CreateAssetMenu(menuName = "FMAI Survival/Item Data", fileName = "ItemData")]
    public class ItemData : ScriptableObject
    {
        [SerializeField] private string itemId;
        [SerializeField] private string displayName;
        [SerializeField] private int maxStack = 1;

        public string ItemId => itemId;
        public string DisplayName => displayName;
        public int MaxStack => Mathf.Max(1, maxStack);
    }
}
