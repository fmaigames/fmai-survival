using UnityEngine;
using FMAI.Survival.Player;

namespace FMAI.Survival.Social
{
    /// <summary>
    /// Local request state for cooperative medical assistance.
    /// Multiplayer/session authority can mirror this state later.
    /// </summary>
    public class MedicalHelpRequest : MonoBehaviour
    {
        [SerializeField] private MedicalHelpSystem medicalHelp;
        [SerializeField] private PlayerStats target;

        public bool IsRequested { get; private set; }
        public bool IsAccepted { get; private set; }

        public PlayerStats Target => target;

        public void RequestHelp(PlayerStats player)
        {
            target = player;
            IsRequested = target != null && target.IsDead == false;
            IsAccepted = false;
        }

        public void Accept(Transform helper)
        {
            if (!IsRequested || medicalHelp == null || target == null)
                return;

            IsAccepted = medicalHelp.GiveMedicalHelp(helper, target);
            if (IsAccepted)
                IsRequested = false;
        }

        public void Decline()
        {
            IsRequested = false;
            IsAccepted = false;
        }

        public void Clear()
        {
            target = null;
            IsRequested = false;
            IsAccepted = false;
        }
    }
}
