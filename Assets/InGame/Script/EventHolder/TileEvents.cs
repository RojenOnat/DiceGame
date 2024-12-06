using System;

namespace InGame.Script.EventHolder
{
    public static class TileEvents
    {
        /// <summary>
        /// If there is an object on the reached tile, it will collect it.
        /// </summary>
        public static Action<int> CollectTheTileHoldedItemEvent;
    }
}