using UnityEngine;

namespace FMAI.Survival.Farming
{
    [CreateAssetMenu(menuName = "FMAI Survival/Farming/Crop Definition", fileName = "CropDefinition")]
    public class CropDefinition : ScriptableObject
    {
        public string cropId = "crop.wheat";
        public float growSeconds = 60f;
        public int harvestYield = 2;
        public string harvestedItem = "food.wheat";
    }
}
