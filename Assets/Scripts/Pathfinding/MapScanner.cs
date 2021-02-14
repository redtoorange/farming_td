using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
    public class MapScanner : MonoBehaviour
    {
        [SerializeField] private Vector2 mapOrigin = Vector2.zero;
        [SerializeField] private int mapWidth = 10;
        [SerializeField] private int mapHeight = 10;
        [SerializeField] private float pointRadius = 0.4f;
        
        private Dictionary<Vector2Int, bool> colliderMapping;

        [SerializeField]
        private List<Collider2D> tileColliders = new List<Collider2D>();

        private void Awake()
        {
            colliderMapping = new Dictionary<Vector2Int, bool>();

            ScanMap();
        }

        private void ScanMap()
        {
            Vector2 topLeft = mapOrigin - new Vector2(mapWidth / 2.0f * pointRadius, mapHeight / 2.0f * pointRadius);

            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    Vector2 positionToScan = new Vector2(x * pointRadius, y * pointRadius) + topLeft;
                    RaycastHit2D hit = Physics2D.CircleCast(positionToScan, pointRadius, Vector2.one, 0.0f);
                    if (hit.collider)
                    {
                        Debug.Log("Hit something");
                        tileColliders.Add(hit.collider);
                    }
                }
            }
        }

        private void OnDrawGizmos()
        {
            Vector2 topLeft = mapOrigin - new Vector2(mapWidth / 2, mapHeight / 2);

            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    Vector2 positionToScan = new Vector2(x + 0.5f, y + 0.5f) + topLeft;
                    RaycastHit2D hit = Physics2D.CircleCast(positionToScan, 0.4f, Vector2.one, 0.0f);
                    if (hit.collider)
                    {
                        Gizmos.DrawSphere(positionToScan, 0.4f);
                    }
                }
            }
        }
    }
}