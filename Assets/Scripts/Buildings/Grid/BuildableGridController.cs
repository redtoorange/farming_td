using System.Collections.Generic;
using UnityEngine;

// This will be run the same on all clients and host
namespace Buildings.Grid
{
    public class BuildableGridController : MonoBehaviour
    {
        [SerializeField] private int slot = -1;
        private Dictionary<int, BuildableTile> tileIdToTiles = new Dictionary<int, BuildableTile>();

        public int GetSlotNumber()
        {
            return slot;
        }


        private void Start()
        {
            BuildableGrid[] grids = GetComponentsInChildren<BuildableGrid>();

            int tileId = 0;
            for (int i = 0; i < grids.Length; i++)
            {
                List<BuildableTile> tilesInGrid = grids[i].GetTiles();
                for (int j = 0; j < tilesInGrid.Count; j++)
                {
                    BuildableTile tile = tilesInGrid[j];
                    tileIdToTiles[tileId] = tile;
                    tile.SetTileId(tileId);
                    tileId++;
                }
            }
        }

        public BuildableTile GetTileById(int id)
        {
            return tileIdToTiles[id];
        }
    }
}