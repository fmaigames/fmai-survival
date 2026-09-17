using UnityEngine;
using FMAI.Survival.Mission;
using FMAI.Survival.Player;
using FMAI.Survival.World;

namespace FMAI.Survival.Bootstrap
{
    public class PrototypeMissionBridge : MonoBehaviour
    {
        [SerializeField] private float shelterRadius = 4f;
        [SerializeField] private float helicopterRadius = 3f;

        private MissionManager missionManager;
        private ShelterZone shelter;
        private HelicopterInteraction helicopter;
        private HelicopterMission helicopterMission;
        private Transform player;
        private bool shelterObjectiveAdvanced;
        private bool extractionAttempted;

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player")?.transform;
            if (player == null) return;

            missionManager = gameObject.AddComponent<MissionManager>();
            missionManager.AddMission(new MissionDefinition
            {
                id = "mission.signal",
                title = "Follow the Signal",
                objectives = new System.Collections.Generic.List<MissionObjective>
                {
                    new MissionObjective
                    {
                        id = "reach_shelter",
                        description = "Reach the shelter",
                        required = 1
                    }
                },
                rewardItem = "resource.signal-core",
                rewardAmount = 1
            });

            GameObject shelterObject = GameObject.Find("Prototype_Shelter");
            if (shelterObject != null)
            {
                shelter = shelterObject.AddComponent<ShelterZone>();
            }

            GameObject helicopterObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            helicopterObject.name = "Prototype_Helicopter";
            helicopterObject.transform.position = new Vector3(8f, 1f, 8f);
            helicopter = helicopterObject.AddComponent<HelicopterInteraction>();
            helicopterMission = helicopterObject.AddComponent<HelicopterMission>();

            GameObject destination = new GameObject("Prototype_Helicopter_Destination");
            destination.transform.position = new Vector3(-8f, 1f, -8f);

            var destinationField = typeof(HelicopterMission).GetField("destination", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            destinationField?.SetValue(helicopterMission, destination.transform);
        }

        private void Update()
        {
            if (player == null || missionManager == null || shelter == null || helicopter == null) return;

            if (!shelterObjectiveAdvanced && shelter.IsInside(player.position))
            {
                shelterObjectiveAdvanced = missionManager.Advance("mission.signal", "reach_shelter");
                if (missionManager.IsComplete("mission.signal"))
                {
                    helicopterMission.Activate();
                    helicopter.SetMissionReady(true);
                }
            }

            if (!extractionAttempted && missionManager.IsComplete("mission.signal") && helicopter.CanExtract(player.position))
            {
                extractionAttempted = helicopter.TryExtract(player.position);
                if (extractionAttempted)
                    helicopterMission.TryLaunch(player);
            }
        }
    }
}
