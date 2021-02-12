using System;
using UnityEngine;

namespace Game
{
    [Serializable]
    public enum GameRoundState
    {
        STARTING,
        RUNNING,
        WAITING,
        PAUSED,
    }

    public class GameRoundManager : MonoBehaviour
    {
        public static event Action<int> OnRoundChange;
        public static event Action<int> OnRoundStart;
        public static event Action<int> OnRoundFinished;

        [SerializeField] private float roundLength = 10.0f;
        [SerializeField] private float waitTime = 5.0f;
        [SerializeField] private GameRoundState currentState = GameRoundState.STARTING;
       
        private int currentRound = 0;
        private float timeRemaining = 0;


        private void Update()
        {
            if (currentState != GameRoundState.PAUSED)
            {
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                }
                else
                {
                    ProcessState();
                }
            }
        }

        private void ProcessState()
        {
            switch (currentState)
            {
                case GameRoundState.STARTING:
                    timeRemaining = waitTime;
                    currentState = GameRoundState.WAITING;
                    break;
                case GameRoundState.WAITING:
                    timeRemaining = roundLength;

                    currentRound++;
                    OnRoundChange?.Invoke(currentRound);

                    currentState = GameRoundState.RUNNING;
                    OnRoundStart?.Invoke(currentRound);
                    break;
                case GameRoundState.RUNNING:
                    timeRemaining = waitTime;
                    
                    currentState = GameRoundState.WAITING;
                    OnRoundFinished?.Invoke(currentRound);
                    break;
            }
        }
    }
}