using System;
using System.Collections.Generic;
using UnityEngine;

namespace FMAI.Survival.Social
{
    public enum ChildActivity
    {
        Home,
        Education,
        Gardening,
        Chores,
        TownFestival,
        Conversation
    }

    [Serializable]
    public class ChildNPC
    {
        public string childId;
        public string displayName;
        public ChildActivity activity;
        public bool atHome;
    }

    /// <summary>
    /// Safe family-child NPC foundation. Children enter the family through
    /// gameplay progression only; there is no conception or sexual simulation.
    /// Children are non-combatants and cannot receive combat assignments.
    /// </summary>
    public class ChildNPCSystem : MonoBehaviour
    {
        [SerializeField] private List<ChildNPC> children = new List<ChildNPC>();

        public IReadOnlyList<ChildNPC> Children => children;

        public bool AddChild(string childId, string displayName)
        {
            if (string.IsNullOrWhiteSpace(childId))
                return false;

            for (int i = 0; i < children.Count; i++)
            {
                if (string.Equals(children[i].childId, childId, StringComparison.Ordinal))
                    return false;
            }

            children.Add(new ChildNPC
            {
                childId = childId.Trim(),
                displayName = displayName?.Trim() ?? string.Empty,
                activity = ChildActivity.Home,
                atHome = true
            });
            return true;
        }

        public bool SetActivity(string childId, ChildActivity activity)
        {
            if (activity == ChildActivity.Conversation || activity == ChildActivity.Education ||
                activity == ChildActivity.Gardening || activity == ChildActivity.Chores ||
                activity == ChildActivity.Home || activity == ChildActivity.TownFestival)
            {
                var child = Find(childId);
                if (child == null)
                    return false;

                child.activity = activity;
                child.atHome = activity == ChildActivity.Home || activity == ChildActivity.Gardening || activity == ChildActivity.Chores;
                return true;
            }

            return false;
        }

        public ChildNPC Find(string childId)
        {
            for (int i = 0; i < children.Count; i++)
            {
                if (string.Equals(children[i].childId, childId, StringComparison.Ordinal))
                    return children[i];
            }
            return null;
        }
    }
}
