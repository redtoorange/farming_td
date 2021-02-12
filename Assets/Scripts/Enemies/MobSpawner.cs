using System.Collections.Generic;
using Game;
using UnityEngine;

namespace Enemies
{
    public class MobSpawner : MonoBehaviour
    {
        [SerializeField] private Transform spawnPoint = null;
        [SerializeField] private Transform endPoint = null;
        [SerializeField] private List<Mob> mobPrefabList = new List<Mob>();

        [SerializeField] private float spawnCoolDown = 2.0f;
        [SerializeField] private float timeRemaining = 0.0f;

        private bool roundStarted = false;

        private void OnEnable()
        {
            GameRoundManager.OnRoundStart += HandleOnRoundStart;
            GameRoundManager.OnRoundFinished += HandleOnRoundFinished;
        }

        private void OnDisable()
        {
            GameRoundManager.OnRoundStart -= HandleOnRoundStart;
            GameRoundManager.OnRoundFinished -= HandleOnRoundFinished;
        }

        private void HandleOnRoundStart(int round)
        {
            roundStarted = true;
        }

        private void HandleOnRoundFinished(int round)
        {
            roundStarted = false;
        }

        private void Update()
        {
            if (!roundStarted) return;

            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = spawnCoolDown;
                SpawnMob();
            }
        }

        private void SpawnMob()
        {
            Instantiate(mobPrefabList[0], spawnPoint.position, Quaternion.identity, transform);
        }
    }
}