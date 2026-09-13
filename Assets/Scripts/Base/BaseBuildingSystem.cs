using UnityEngine;

namespace FMAI.Survival.Base
{
    public class BaseBuildingSystem : MonoBehaviour
    {
        [SerializeField] private GameObject[] buildPrefabs;
        [SerializeField] private float buildDistance = 4f;
        [SerializeField] private LayerMask placementMask = ~0;

        public bool TryPlace(int prefabIndex, Camera camera)
        {
            if (camera == null || prefabIndex < 0 || prefabIndex >= buildPrefabs.Length)
                return false;

            Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (!Physics.Raycast(ray, out RaycastHit hit, buildDistance, placementMask))
                return false;

            GameObject prefab = buildPrefabs[prefabIndex];
            if (prefab == null) return false;

            Instantiate(prefab, hit.point, Quaternion.identity);
            return true;
        }
    }
}
