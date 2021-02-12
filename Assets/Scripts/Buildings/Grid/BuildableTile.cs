using UnityEngine;

namespace Buildings.Grid
{
    public class BuildableTile : MonoBehaviour
    {
        [SerializeField] private int tileId = -1;
        private bool isOccupied = false;


        public Vector3 GetBuildLocation()
        {
            return transform.position;
        }

        public void SetTileId(int newId)
        {
            tileId = newId;
        }

        public int GetTileId()
        {
            return tileId;
        }

        public void SetTileOccupied(bool occupied)
        {
            isOccupied = occupied;
        }

        public bool IsOccupied()
        {
            return isOccupied;
        }
    }
}