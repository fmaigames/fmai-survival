using UnityEngine;

namespace FMAI.Survival.Economy
{
    public class WalletSystem : MonoBehaviour
    {
        [SerializeField] private int startingCoins = 100;
        public int Coins { get; private set; }

        private void Awake() => Coins = Mathf.Max(0, startingCoins);

        public bool AddCoins(int amount)
        {
            if (amount <= 0) return false;
            Coins += amount;
            return true;
        }

        public bool TrySpend(int amount)
        {
            if (amount <= 0 || Coins < amount) return false;
            Coins -= amount;
            return true;
        }
    }
}
