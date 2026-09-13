using UnityEngine;

namespace FMAI.Survival.Social
{
    public class FestivalEventController : MonoBehaviour
    {
        [SerializeField] private TownHallHub townHall;
        [SerializeField] private float eventDurationSeconds = 300f;
        private float remaining;

        public bool IsActive => remaining > 0f;
        public float RemainingSeconds => remaining;

        public void StartEvent()
        {
            remaining = Mathf.Max(1f, eventDurationSeconds);
            if (townHall != null) townHall.OpenFestival();
        }

        public void StopEvent()
        {
            remaining = 0f;
            if (townHall != null) townHall.CloseFestival();
        }

        private void Update()
        {
            if (remaining <= 0f) return;
            remaining -= Time.deltaTime;
            if (remaining <= 0f) StopEvent();
        }
    }
}
