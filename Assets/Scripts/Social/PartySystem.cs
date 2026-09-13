using System.Collections.Generic;
using UnityEngine;

namespace FMAI.Survival.Social
{
    public class PartySystem : MonoBehaviour
    {
        [SerializeField] private int maxMembers = 4;
        private readonly List<string> members = new();

        public IReadOnlyList<string> Members => members;
        public bool IsFull => members.Count >= maxMembers;

        public bool CreateOrJoin(string playerId)
        {
            if (string.IsNullOrWhiteSpace(playerId) || members.Contains(playerId) || IsFull)
                return false;
            members.Add(playerId);
            return true;
        }

        public bool Leave(string playerId)
        {
            return !string.IsNullOrWhiteSpace(playerId) && members.Remove(playerId);
        }

        public void ClearParty() => members.Clear();
    }
}
