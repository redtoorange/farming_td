using UnityEngine;

namespace Enemies
{
    public class Targetable : MonoBehaviour
    {
        [SerializeField] private Transform aimPoint;

        public Transform GetAimPoint()
        {
            return aimPoint;
        }
    }
}