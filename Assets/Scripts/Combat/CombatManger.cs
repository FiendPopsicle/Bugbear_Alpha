using System.Collections;
using UnityEngine;

namespace Bugbear.Managers
{
    public class CombatManger : MonoBehaviour, ICombatManger, IGlobalRouter
    {
        public IEnumerator InitializeComponent()
        {
            Debug.Log("Combat Initialized....");

            return null;
        }
    }
}
