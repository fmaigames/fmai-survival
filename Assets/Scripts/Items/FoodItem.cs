using UnityEngine;

namespace FMAI.Survival.Items
{
    [CreateAssetMenu(menuName = "FMAI Survival/Items/Food Item")]
    public class FoodItem : ScriptableObject
    {
        [SerializeField] private string itemId = "food";
        [SerializeField] private float hungerRestored = 20f;

        public string ItemId => itemId;
        public float HungerRestored => hungerRestored;
    }
}
