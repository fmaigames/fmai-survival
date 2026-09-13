using System;
using UnityEngine;

namespace FMAI.Survival.Social
{
    public enum SocialHelpRequestStatus
    {
        Pending,
        Accepted,
        Declined,
        Completed,
        Expired
    }

    /// <summary>
    /// Local request lifecycle for cooperative player assistance.
    /// Multiplayer transport and server authority are intentionally separate.
    /// </summary>
    [Serializable]
    public class SocialHelpRequest
    {
        [SerializeField] private string requestId;
        [SerializeField] private string requesterId;
        [SerializeField] private string helperId;
        [SerializeField] private SocialHelpRequestStatus status = SocialHelpRequestStatus.Pending;
        [SerializeField] private float createdAt;
        [SerializeField] private float timeoutSeconds = 30f;

        public string RequestId => requestId;
        public string RequesterId => requesterId;
        public string HelperId => helperId;
        public SocialHelpRequestStatus Status => status;
        public float CreatedAt => createdAt;
        public float TimeoutSeconds => timeoutSeconds;

        public SocialHelpRequest(string requesterId, float timeoutSeconds = 30f)
        {
            requestId = Guid.NewGuid().ToString("N");
            this.requesterId = requesterId ?? string.Empty;
            this.timeoutSeconds = Mathf.Max(1f, timeoutSeconds);
            createdAt = Time.time;
            status = SocialHelpRequestStatus.Pending;
        }

        public bool Accept(string helperId)
        {
            if (status != SocialHelpRequestStatus.Pending || string.IsNullOrWhiteSpace(helperId))
                return false;

            this.helperId = helperId;
            status = SocialHelpRequestStatus.Accepted;
            return true;
        }

        public bool Decline()
        {
            if (status != SocialHelpRequestStatus.Pending)
                return false;

            status = SocialHelpRequestStatus.Declined;
            return true;
        }

        public bool Complete()
        {
            if (status != SocialHelpRequestStatus.Accepted)
                return false;

            status = SocialHelpRequestStatus.Completed;
            return true;
        }

        public bool Expire()
        {
            if (status != SocialHelpRequestStatus.Pending)
                return false;

            status = SocialHelpRequestStatus.Expired;
            return true;
        }

        public bool IsExpired(float now)
        {
            return status == SocialHelpRequestStatus.Pending && now - createdAt >= timeoutSeconds;
        }
    }
}
