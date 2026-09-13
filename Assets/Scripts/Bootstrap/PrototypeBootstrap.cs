using UnityEngine;
using FMAI.Survival.Player;
using FMAI.Survival.Inventory;

namespace FMAI.Survival.Bootstrap
{
    public class PrototypeBootstrap : MonoBehaviour
    {
        [SerializeField] private bool buildOnStart = true;

        private void Start()
        {
            if (!buildOnStart) return;

            CreateEnvironment();
            CreatePlayer();
            CreateCamera();
            CreateLight();
        }

        private void CreateEnvironment()
        {
            GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
            ground.name = "Prototype_Ground";
            ground.transform.localScale = Vector3.one * 10f;

            GameObject shelter = GameObject.CreatePrimitive(PrimitiveType.Cube);
            shelter.name = "Prototype_Shelter";
            shelter.transform.position = new Vector3(4f, 1f, 4f);
            shelter.transform.localScale = new Vector3(4f, 2f, 4f);
        }

        private void CreatePlayer()
        {
            GameObject player = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            player.name = "Player";
            player.transform.position = new Vector3(0f, 1f, 0f);

            CharacterController controller = player.AddComponent<CharacterController>();
            controller.height = 2f;
            controller.radius = 0.35f;

            player.AddComponent<PlayerStats>();
            player.AddComponent<InventorySystem>();
        }

        private void CreateCamera()
        {
            GameObject cameraObject = new GameObject("Main Camera");
            Camera camera = cameraObject.AddComponent<Camera>();
            camera.tag = "MainCamera";
            camera.transform.position = new Vector3(0f, 6f, -8f);
            camera.transform.rotation = Quaternion.Euler(25f, 0f, 0f);
        }

        private void CreateLight()
        {
            GameObject lightObject = new GameObject("Prototype Sun");
            Light light = lightObject.AddComponent<Light>();
            light.type = LightType.Directional;
            light.transform.rotation = Quaternion.Euler(50f, -30f, 0f);
        }
    }
}
