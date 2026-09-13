using UnityEngine;

namespace FMAI.Survival.Base
{
    public class HomeDecorationSystem : MonoBehaviour
    {
        [SerializeField] private Transform decorationRoot;

        public GameObject PlaceDecoration(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            if (prefab == null) return null;
            return Instantiate(prefab, position, rotation, decorationRoot);
        }

        public void RemoveDecoration(GameObject decoration)
        {
            if (decoration != null)
                Destroy(decoration);
        }
    }
}
