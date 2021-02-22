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
                Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
                if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, layerMask))
                {
                    BuildableTile tile = hitInfo.collider.GetComponent<BuildableTile>();
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