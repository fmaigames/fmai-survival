using System;
using UnityEngine;

namespace FMAI.Survival.Social
{
    [Serializable]
    public struct MarriageRecord
    {
        public string familyId;
        public string partnerPlayerId;
        public string partnerDisplayName;
        public bool confirmed;
    }

    /// <summary>
    /// Safe social relationship foundation. Marriage is represented only as
    /// a confirmed family/social relationship; no sexual simulation is included.
    /// </summary>
    public class MarriageSystem : MonoBehaviour
    {
        [SerializeField] private MarriageRecord marriage;

        public bool IsMarried => marriage.confirmed;
        public MarriageRecord CurrentMarriage => marriage;

        public bool ConfirmMarriage(string familyId, string partnerPlayerId, string partnerDisplayName)
        {
            if (string.IsNullOrWhiteSpace(familyId) || string.IsNullOrWhiteSpace(partnerPlayerId) || marriage.confirmed)
                return false;

            marriage = new MarriageRecord
            {
                familyId = familyId.Trim(),
                partnerPlayerId = partnerPlayerId.Trim(),
                partnerDisplayName = partnerDisplayName?.Trim() ?? string.Empty,
                confirmed = true
            };
            return true;
        }

        public void EndMarriage()
        {
            marriage = default;
        }
    }
}
