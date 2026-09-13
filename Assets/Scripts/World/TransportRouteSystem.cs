using System;
using System.Collections.Generic;
using UnityEngine;

namespace FMAI.Survival.World
{
    [Serializable]
    public class TransportRoute
    {
        public string id;
        public string fromRegion;
        public string toRegion;
        public int fare;

        public TransportRoute(string routeId, string from, string to, int cost)
        {
            id = routeId;
            fromRegion = from;
            toRegion = to;
            fare = Mathf.Max(0, cost);
        }
    }

    public class TransportRouteSystem : MonoBehaviour
    {
        [SerializeField] private List<TransportRoute> routes = new();

        public IReadOnlyList<TransportRoute> Routes => routes;

        public bool CanTravel(string routeId, int coins)
        {
            TransportRoute route = routes.Find(x => x.id == routeId);
            return route != null && coins >= route.fare;
        }

        public bool TryGetRoute(string routeId, out TransportRoute route)
        {
            route = routes.Find(x => x.id == routeId);
            return route != null;
        }
    }
}
