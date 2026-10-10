using UnityEngine;
using FMAI.Survival.Inventory;
using FMAI.Survival.Mission;
using FMAI.Survival.Player;
using FMAI.Survival.World;

namespace FMAI.Survival.Bootstrap
{
    public class PrototypeMissionBridge : MonoBehaviour
    {
        private MissionManager missionManager;
        private ShelterZone shelter;
        private HelicopterInteraction helicopter;
        private HelicopterMission helicopterMission;
        private Transform player;
        private InventorySystem inventory;
        private bool shelterObjectiveAdvanced;
        private bool extractionAttempted;
        private bool rewardGranted;

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player")?.transform;
            if (player == null) return;

            inventory = player.GetComponent<InventorySystem>();

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
            helicopterMission.SetDestination(destination.transform);
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

            if (missionManager.IsComplete("mission.signal") && !rewardGranted)
            {
                // Retry on later frames if the inventory is temporarily full or unavailable.
                if (inventory != null && inventory.Add("resource.signal-core"))
                    rewardGranted = true;
            }

            if (!extractionAttempted &&
                missionManager.IsComplete("mission.signal") &&
                helicopter.CanExtract(player.position))
            {
                if (helicopterMission.TryLaunch(player))
                {
                    if (helicopter.TryCompleteExtraction())
                    {
                        extractionAttempted = true;
                    }
                }
            }
        }
    }
}