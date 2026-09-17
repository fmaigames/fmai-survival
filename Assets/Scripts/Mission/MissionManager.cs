using System;
using System.Collections.Generic;
using UnityEngine;

namespace FMAI.Survival.Mission
{
    [Serializable]
    public class MissionObjective
    {
        public string id;
        public string description;
        public int required = 1;
        [NonSerialized] public int progress;

        public bool Complete => progress >= required;
        public void AddProgress(int amount = 1) => progress = Mathf.Clamp(progress + amount, 0, required);
    }

    [Serializable]
    public class MissionDefinition
    {
        public string id = "mission.signal";
        public string title = "Follow the Signal";
        public List<MissionObjective> objectives = new();
        public string rewardItem = "resource.signal-core";
        public int rewardAmount = 1;
    }

    public class MissionManager : MonoBehaviour
    {
        [SerializeField] private List<MissionDefinition> missions = new();
        private readonly HashSet<string> completed = new();

        public IReadOnlyList<MissionDefinition> Missions => missions;

        public void AddMission(MissionDefinition mission)
        {
            if (mission == null || string.IsNullOrWhiteSpace(mission.id)) return;
            if (missions.Exists(m => m.id == mission.id)) return;
            missions.Add(mission);
        }

        public bool Advance(string missionId, string objectiveId, int amount = 1)
        {
            var mission = missions.Find(m => m.id == missionId);
            if (mission == null || completed.Contains(missionId)) return false;

            var objective = mission.objectives.Find(o => o.id == objectiveId);
            if (objective == null) return false;

            objective.AddProgress(amount);
            if (mission.objectives.TrueForAll(o => o.Complete))
                completed.Add(missionId);
            return true;
        }

        public bool IsComplete(string missionId) => completed.Contains(missionId);
    }
}
