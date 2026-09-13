using UnityEngine;

namespace FMAI.Survival.World
{
    public enum MapRegionType
    {
        Desert,
        Ocean,
        Forest,
        City,
        Village,
        Mountain,
        Swamp,
        Farmland
    }

    [CreateAssetMenu(fileName = "MapRegion", menuName = "FMAI Survival/Map Region")]
    public class MapRegionDefinition : ScriptableObject
    {
        [SerializeField] private string regionId;
        [SerializeField] private string displayName;
        [SerializeField] private MapRegionType regionType;
        [SerializeField] private string description;
        [SerializeField] private float dangerLevel = 1f;

        public string RegionId => regionId;
        public string DisplayName => displayName;
        public MapRegionType RegionType => regionType;
        public string Description => description;
        public float DangerLevel => dangerLevel;
    }
}
