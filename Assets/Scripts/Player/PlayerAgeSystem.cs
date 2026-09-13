using UnityEngine;

namespace FMAI.Survival.Player
{
    public class PlayerAgeSystem : MonoBehaviour
    {
        [SerializeField] private int startingAge = 18;
        [SerializeField] private int maxAge = 80;
        [SerializeField] private float daysPerAge = 30f;
        private float ageProgress;

        public int Age { get; private set; }

        private void Awake() => Age = Mathf.Clamp(startingAge, 1, maxAge);

        private void Update()
        {
            if (Age >= maxAge || daysPerAge <= 0f) return;
            ageProgress += Time.deltaTime / 86400f;
            if (ageProgress >= daysPerAge)
            {
                ageProgress = 0f;
                Age++;
            }
        }
    }
}
