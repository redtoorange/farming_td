using Buildings.Grid;
using Buildings.Towers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Buildings
{
    public class BuildingBuilder : MonoBehaviour
    {
        [SerializeField] private Tower towerPrefab = null;
        [SerializeField] private LayerMask layerMask = new LayerMask();

        private Camera mainCamera = null;

        private void Start()
        {
            mainCamera = Camera.main;
        }

        private void Update()
        {
            if (Mouse.current.leftButton.wasReleasedThisFrame)
            {
                Vector2 worldPoint = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                RaycastHit2D[] hits = Physics2D.RaycastAll(worldPoint, Vector2.one, 0.0f, layerMask);
                
                if (hits.Length > 0)
                {
                    BuildableTile tile = hits[0].collider.GetComponent<BuildableTile>();
                    if (tile && !tile.IsOccupied())
                    {
                        SpawnTower(tile);
                    }
                }
            }
        }

        private void SpawnTower(BuildableTile tile)
        {
            GameObject tower = Instantiate(
                towerPrefab.gameObject,
                tile.GetBuildLocation(),
                Quaternion.identity
            );
            tile.SetTileOccupied(true);
        }
    }
}