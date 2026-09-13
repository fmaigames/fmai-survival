using System;
using System.IO;
using UnityEngine;

namespace FMAI.Survival.Save
{
    [Serializable]
    public class SaveData
    {
        public float health = 100f;
        public float hunger = 100f;
        public float[] playerPosition = new float[3];
    }

    public static class SaveSystem
    {
        private const string FileName = "fmai_survival_save.json";

        private static string Path => System.IO.Path.Combine(Application.persistentDataPath, FileName);

        public static void Save(Vector3 position, float health, float hunger)
        {
            var data = new SaveData
            {
                health = health,
                hunger = hunger,
                playerPosition = new[] { position.x, position.y, position.z }
            };
            File.WriteAllText(Path, JsonUtility.ToJson(data, true));
        }

        public static bool TryLoad(out SaveData data)
        {
            data = null;
            if (!File.Exists(Path)) return false;

            try
            {
                data = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path));
                return data != null && data.playerPosition != null && data.playerPosition.Length == 3;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
