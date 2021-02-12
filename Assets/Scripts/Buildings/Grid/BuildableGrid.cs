using System.Collections.Generic;
using UnityEngine;

namespace Buildings.Grid
{
    public class BuildableGrid : MonoBehaviour
    {
        [SerializeField] private int width = 2;
        [SerializeField] private int depth = 2;
        [SerializeField] private BuildableTile buildableTilePrefab = null;

        private List<BuildableTile> tileInstances;

       private void Awake()
        {
            tileInstances = new List<BuildableTile>(width * depth);
            Vector3 startingPosition = transform.position;
            startingPosition.x -= width / 2.0f;
            startingPosition.z -= depth / 2.0f;


            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < depth; y++)
                {
                    Vector3 tilePosition = new Vector3(x + 0.5f, 0, y + 0.5f);
                    BuildableTile instance = Instantiate(
                        buildableTilePrefab,
                        startingPosition + tilePosition,
                        Quaternion.identity,
                        transform
                    );
                    tileInstances.Add(instance);
                    // NetworkServer.Spawn(instance.gameObject);
                }
            }
        }


        private void OnDrawGizmosSelected()
        {
            Vector3 startingPosition = transform.position;
            startingPosition.x -= width / 2.0f;
            startingPosition.z -= depth / 2.0f;

            Gizmos.color = Color.red;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < depth; y++)
                {
                    Vector3 tilePosition = new Vector3(x + 0.5f, 0, y + 0.5f);
                    Gizmos.DrawCube(tilePosition + startingPosition, new Vector3(0.9f, 0.1f, 0.9f));
                }
            }
        }

        public List<BuildableTile> GetTiles()
        {
            return tileInstances;
        }
    }
}