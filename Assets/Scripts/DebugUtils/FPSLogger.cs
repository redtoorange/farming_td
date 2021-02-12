using TMPro;
using UnityEngine;

namespace DebugUtils
{
    public class FPSLogger : MonoBehaviour
    {
        [SerializeField] private TMP_Text loggerOutput = null;

        private float timeElapsed = 0.0f;
        private int frames = 0;

        private void Update()
        {
            timeElapsed += Time.deltaTime;
            frames++;

            if (timeElapsed >= 1)
            {
                timeElapsed = 0;
                loggerOutput.text = "FPS: " + frames;
                frames = 0;
            }
        }
    }
}