using System.Collections.Generic;
using UnityEngine;

namespace Buildings.Grid
{
    public class BuildableGridController : MonoBehaviour
    {
        [SerializeField] private Vector2Int worldSize = Vector2Int.zero;
        [SerializeField] private BuildableTile buildableTilePrefab = null;
        [SerializeField] private LayerMask layerMask = new LayerMask();
        
        private Dictionary<Vector2Int, BuildableTile> buildableTiles;

        private void Start()
        {
            buildableTiles = new Dictionary<Vector2Int, BuildableTile>();

            // Scan map for all tiles
            ScanMap();

            // Add them to a list
        }

        private void ScanMap()
        {
            Vector2 bottomLeft = new Vector2(-worldSize.x / 2.0f + 0.5f, -worldSize.y / 2.0f + 0.5f);

            for (int x = 0; x < worldSize.x; x++)
            {
                for (int y = 0; y < worldSize.y; y++)
                {
                    Vector2 positionToScan = new Vector2(x, y) + bottomLeft;
                    RaycastHit2D hit = Physics2D.CircleCast(positionToScan, 0.01f, Vector2.one, 0.0f, layerMask);
                    if (hit.collider)
                    {
                        buildableTiles[new Vector2Int((int) positionToScan.x, (int) positionToScan.y)] = Instantiate(
                            buildableTilePrefab,
                            positionToScan,
                            Quaternion.identity,
                            transform
                        );
                    }
                }
            }
        }
    }
}