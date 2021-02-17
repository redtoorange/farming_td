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

        // Every instance of BuildingBuilder will need a GridController
        private void Start()
        {
            mainCamera = Camera.main;
        }

        // Only the owning player needs the camera
        // public override void OnStartAuthority()
        // {
        //     mainCamera = Camera.main;
        // }

        // [ClientCallback]
        private void Update()
        {
            // Each player will have a BuildingBuilder so there are multiple copies in the same scene, only execute on
            // the owning player
            // if (!hasAuthority)
            // {
            //     return;
            // }


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

        // Called on the server after one of the clients tries to build a building
        // [Command]
        private void SpawnTower(BuildableTile tile)
        {
            GameObject tower = Instantiate(
                towerPrefab.gameObject,
                tile.GetBuildLocation(),
                Quaternion.identity
            );
            tile.SetTileOccupied(true);
        }

        // This is getting called on all instances of the BuildingBuilder
        // Should this be handled with a SyncVar?
        // [ClientRpc]
        // private void RpcSetTileOccupied(int tileId, bool occupied)
        // {
        //     Debug.Log("[RpcSetTileOccupied]");
        //     if (!hasAuthority) return;
        //
        //     BuildableTile tile = gridController.GetTileById(tileId);
        //     tile.SetTileOccupied(occupied);
        // }
    }
}