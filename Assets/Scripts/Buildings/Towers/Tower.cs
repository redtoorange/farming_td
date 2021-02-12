using UnityEngine;

namespace Buildings.Towers
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private int goldCost = 75;
        [SerializeField] private int woodCost = 0;


        public int GetGoldCost()
        {
            return goldCost;
        }

        public int GetWoodCost()
        {
            return woodCost;
        }
    }
}
