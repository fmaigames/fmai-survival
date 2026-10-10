using UnityEngine;
using FMAI.Survival.Inventory;
using FMAI.Survival.Mission;
using FMAI.Survival.World;

namespace FMAI.Survival.Bootstrap
{
    public class PrototypeMissionBridge : MonoBehaviour
    {
        private const string MissionId = "mission.signal";
        private const string ObjectiveId = "reach_shelter";

        private MissionManager missionManager;
        private ShelterZone shelter;
        private HelicopterInteraction helicopter;
        private HelicopterMission helicopterMission;
        private Transform player;
        private InventorySystem inventory;
        private bool shelterObjectiveAdvanced;
        private bool extractionRequested;
        private bool extractionAttempted;
        private bool rewardGranted;

        private GUIStyle panelStyle;
        private GUIStyle headingStyle;
        private GUIStyle bodyStyle;
        private GUIStyle buttonStyle;

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player")?.transform;
            if (player == null) return;

            inventory = player.GetComponent<InventorySystem>();

            missionManager = gameObject.AddComponent<MissionManager>();
            missionManager.AddMission(new MissionDefinition
            {
                id = MissionId,
                title = "Follow the Signal",
                objectives = new System.Collections.Generic.List<MissionObjective>
                {
                    new MissionObjective
                    {
                        id = ObjectiveId,
                        description = "Reach the shelter",
                        required = 1
                    }
                },
                rewardItem = "resource.signal-core",
                rewardAmount = 1
            });

            GameObject shelterObject = GameObject.Find("Prototype_Shelter");
            if (shelterObject != null)
                shelter = shelterObject.AddComponent<ShelterZone>();

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
            if (player == null || missionManager == null || shelter == null || helicopter == null)
                return;

            if (!shelterObjectiveAdvanced && shelter.IsInside(player.position))
            {
                shelterObjectiveAdvanced = missionManager.Advance(MissionId, ObjectiveId);
                if (missionManager.IsComplete(MissionId))
                {
                    helicopterMission.Activate();
                    helicopter.SetMissionReady(true);
                }
            }

            if (missionManager.IsComplete(MissionId) && !rewardGranted)
            {
                // Retry on later frames if the inventory is temporarily full or unavailable.
                if (inventory != null && inventory.Add("resource.signal-core"))
                    rewardGranted = true;
            }

            // Extraction is explicit: entering the helicopter radius alone never teleports the player.
            if (extractionRequested)
            {
                extractionRequested = false;
                if (!extractionAttempted &&
                    missionManager.IsComplete(MissionId) &&
                    helicopter.CanExtract(player.position) &&
                    helicopterMission.TryLaunch(player) &&
                    helicopter.TryCompleteExtraction())
                {
                    extractionAttempted = true;
                }
            }
        }

        private void OnGUI()
        {
            if (player == null || missionManager == null) return;
            EnsureGuiStyles();

            float scale = Mathf.Clamp(Screen.width / 390f, 0.8f, 1.25f);
            float margin = 12f * scale;
            float panelWidth = Mathf.Min(Screen.width - margin * 2f, 340f * scale);
            bool canExtract = !extractionAttempted &&
                              missionManager.IsComplete(MissionId) &&
                              helicopter != null &&
                              helicopter.CanExtract(player.position);
            float panelHeight = (canExtract ? 154f : 112f) * scale;
            Rect panel = new Rect(margin, margin, panelWidth, panelHeight);

            GUI.Box(panel, GUIContent.none, panelStyle);
            GUI.Label(
                new Rect(panel.x + 12f * scale, panel.y + 8f * scale, panel.width - 24f * scale, 24f * scale),
                "FMAI SURVIVAL  /  MISSION",
                headingStyle
            );

            string status;
            if (extractionAttempted)
                status = "EXTRACTION COMPLETE";
            else if (missionManager.IsComplete(MissionId))
                status = canExtract
                    ? "Helicopter in range"
                    : "Objective complete — reach helicopter";
            else
                status = "Objective: Reach the shelter";

            GUI.Label(
                new Rect(panel.x + 12f * scale, panel.y + 35f * scale, panel.width - 24f * scale, 25f * scale),
                status,
                bodyStyle
            );

            string rewardStatus = rewardGranted
                ? "Signal Core: collected"
                : missionManager.IsComplete(MissionId)
                    ? "Signal Core: waiting for inventory space"
                    : "Reward: Signal Core";
            GUI.Label(
                new Rect(panel.x + 12f * scale, panel.y + 62f * scale, panel.width - 24f * scale, 25f * scale),
                rewardStatus,
                bodyStyle
            );

            if (canExtract)
            {
                Rect buttonRect = new Rect(
                    panel.x + 12f * scale,
                    panel.y + 88f * scale,
                    panel.width - 24f * scale,
                    32f * scale
                );
                if (GUI.Button(buttonRect, "EXTRACT", buttonStyle))
                    extractionRequested = true;
            }
        }

        private void EnsureGuiStyles()
        {
            if (panelStyle != null) return;

            panelStyle = new GUIStyle(GUI.skin.box)
            {
                alignment = TextAnchor.UpperLeft,
                normal = { background = MakeSolidTexture(new Color(0.035f, 0.055f, 0.10f, 0.92f)) }
            };

            headingStyle = new GUIStyle(GUI.skin.label)
            {
                fontSize = 14,
                fontStyle = FontStyle.Bold,
                normal = { textColor = new Color(0.2f, 0.9f, 1f) }
            };

            bodyStyle = new GUIStyle(GUI.skin.label)
            {
                fontSize = 13,
                wordWrap = true,
                normal = { textColor = Color.white }
            };

            buttonStyle = new GUIStyle(GUI.skin.button)
            {
                fontSize = 14,
                fontStyle = FontStyle.Bold
            };
        }

        private Texture2D MakeSolidTexture(Color color)
        {
            Texture2D texture = new Texture2D(1, 1);
            texture.SetPixel(0, 0, color);
            texture.Apply();
            return texture;
        }
    }
}