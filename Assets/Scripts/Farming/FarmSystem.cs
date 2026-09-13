using System.Collections.Generic;
using UnityEngine;

namespace FMAI.Survival.Farming
{
    public class FarmSystem : MonoBehaviour
    {
        [System.Serializable]
        public class CropPlot
        {
            public Transform plot;
            public GameObject plantedPrefab;
            public float growSeconds = 60f;
            [HideInInspector] public float plantedAt = -1f;
            [HideInInspector] public bool ready;
        }

        [SerializeField] private List<CropPlot> plots = new();

        public bool Plant(int index, GameObject cropPrefab)
        {
            if (index < 0 || index >= plots.Count || cropPrefab == null)
                return false;

            CropPlot plot = plots[index];
            if (plot.plot == null || plot.plantedAt >= 0f)
                return false;

            plot.plantedPrefab = Instantiate(cropPrefab, plot.plot.position, plot.plot.rotation, plot.plot);
            plot.plantedAt = Time.time;
            plot.ready = false;
            return true;
        }

        public bool Harvest(int index)
        {
            if (index < 0 || index >= plots.Count)
                return false;

            CropPlot plot = plots[index];
            if (plot.plantedAt < 0f || !plot.ready)
                return false;

            if (plot.plantedPrefab != null)
                Destroy(plot.plantedPrefab);

            plot.plantedPrefab = null;
            plot.plantedAt = -1f;
            plot.ready = false;
            return true;
        }

        private void Update()
        {
            foreach (CropPlot plot in plots)
            {
                if (plot.plantedAt >= 0f && !plot.ready && Time.time - plot.plantedAt >= plot.growSeconds)
                    plot.ready = true;
            }
        }
    }
}
