using UnityEngine;

namespace FMAI.Survival.Social
{
    public class TownHallHub : MonoBehaviour
    {
        [SerializeField] private Transform townHallSpawn;
        [SerializeField] private GameObject festivalArea;
        [SerializeField] private GameObject enjoymentPark;

        public bool IsFestivalOpen { get; private set; }
        public bool IsParkOpen { get; private set; }

        public void OpenFestival()
        {
            IsFestivalOpen = true;
            if (festivalArea != null) festivalArea.SetActive(true);
        }

        public void CloseFestival()
        {
            IsFestivalOpen = false;
            if (festivalArea != null) festivalArea.SetActive(false);
        }

        public void OpenEnjoymentPark()
        {
            IsParkOpen = true;
            if (enjoymentPark != null) enjoymentPark.SetActive(true);
        }

        public void CloseEnjoymentPark()
        {
            IsParkOpen = false;
            if (enjoymentPark != null) enjoymentPark.SetActive(false);
        }

        public bool TryEnter(Transform player)
        {
            if (player == null || townHallSpawn == null) return false;
            player.SetPositionAndRotation(townHallSpawn.position, townHallSpawn.rotation);
            return true;
        }
    }
}
