using System;
using System.Collections.Generic;
using UnityEngine;
using FMAI.Survival.Inventory;

namespace FMAI.Survival.Market
{
    [Serializable]
    public class MarketListing
    {
        public string itemId;
        public int buyPrice;
        public int sellPrice;

        public MarketListing(string id, int buy, int sell)
        {
            itemId = id;
            buyPrice = buy;
            sellPrice = sell;
        }
    }

    public class MarketSystem : MonoBehaviour
    {
        [SerializeField] private InventorySystem inventory;
        [SerializeField] private int startingCoins = 100;

        private readonly List<MarketListing> listings = new()
        {
            new MarketListing("food.raw_meat", 12, 6),
            new MarketListing("item.hide", 30, 15),
            new MarketListing("item.fur", 40, 20),
            new MarketListing("item.wood", 8, 4),
            new MarketListing("item.scrap", 10, 5),
            new MarketListing("item.herb", 14, 7),
            new MarketListing("item.cloth", 16, 8)
        };

        public int Coins { get; private set; }
        public IReadOnlyList<MarketListing> Listings => listings;

        private void Awake()
        {
            Coins = Mathf.Max(0, startingCoins);
        }

        public bool Buy(string itemId)
        {
            MarketListing listing = Find(itemId);
            if (inventory == null || listing == null || Coins < listing.buyPrice) return false;
            if (!inventory.Add(itemId)) return false;

            Coins -= listing.buyPrice;
            return true;
        }

        public bool Sell(string itemId)
        {
            MarketListing listing = Find(itemId);
            if (inventory == null || listing == null || !inventory.Has(itemId)) return false;
            if (!inventory.Remove(itemId)) return false;

            Coins += listing.sellPrice;
            return true;
        }

        private MarketListing Find(string itemId)
        {
            return listings.Find(x => x.itemId == itemId);
        }
    }
}
