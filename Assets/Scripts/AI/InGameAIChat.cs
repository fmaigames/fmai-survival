using UnityEngine;

namespace FMAI.Survival.AI
{
    public class InGameAIChat : MonoBehaviour
    {
        [SerializeField] private InGameAIHelper helper;

        private void Awake()
        {
            if (helper == null) helper = GetComponent<InGameAIHelper>();
        }

        public string Ask(string question)
        {
            if (string.IsNullOrWhiteSpace(question)) return "AI Help: Ask me about health, hunger, enemies, loot, crafting, or survival.";

            string q = question.ToLowerInvariant();
            if (q.Contains("health") || q.Contains("heal") || q.Contains("medicine"))
                return "AI Help: Check your health first, then use available medicine or food and avoid unnecessary fights.";
            if (q.Contains("food") || q.Contains("hungry") || q.Contains("hunger"))
                return "AI Help: Eat food when hunger is low and keep a reserve before leaving your shelter.";
            if (q.Contains("enemy") || q.Contains("zombie") || q.Contains("fight"))
                return "AI Help: Keep distance, watch your health, and use your weapon only when the fight is worth the risk.";
            if (q.Contains("loot") || q.Contains("item") || q.Contains("resource"))
                return "AI Help: Search nearby containers and collect useful crafting materials before travelling farther.";
            if (q.Contains("craft") || q.Contains("build"))
                return "AI Help: Gather wood, scrap, cloth, herbs, and other required materials, then craft from a safe area.";
            if (q.Contains("mission") || q.Contains("where") || q.Contains("next"))
                return helper != null ? helper.GetHint() : "AI Help: Follow your current mission and prepare supplies before travelling.";

            return helper != null ? helper.GetHint() : "AI Help: I can help with survival, combat, food, loot, crafting, and missions.";
        }
    }
}
