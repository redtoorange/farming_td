using UnityEngine;

namespace Enemies.AI
{
    public class MobController : MonoBehaviour
    {
        [SerializeField] private WayPointController wayPointController;

        private void OnEnable()
        {
            Mob.OnMobSpawned += HandleMobSpawned;
            Mob.OnMobDestroyed += HandleMobDestroyed;
            
            MobMover.OnNeedWaypoint += HandleOnNeedWaypoint;
            MobMover2D.OnNeedWaypoint += HandleOnNeedWaypoint;
        }

        private void OnDisable()
        {
            Mob.OnMobSpawned -= HandleMobSpawned;
            Mob.OnMobDestroyed -= HandleMobDestroyed;
            
            MobMover.OnNeedWaypoint -= HandleOnNeedWaypoint;
            MobMover2D.OnNeedWaypoint -= HandleOnNeedWaypoint;
        }

        private void HandleMobSpawned(Mob newMob)
        {
        }

        private void HandleMobDestroyed(Mob destroyedMob)
        {
            Debug.Log("Mob Destroyed");
        }

        private void HandleOnNeedWaypoint(MobMover mover)
        {
            mover.SetWaypoint(wayPointController.GetNextWaypoint(mover.GetWayPoint()));
        }
        
        private void HandleOnNeedWaypoint(MobMover2D mover)
        {
            mover.SetWaypoint(wayPointController.GetNextWaypoint(mover.GetWayPoint()));
        }
    }
}