using System.Collections;
using UnityEngine;

namespace Bugbear.Managers
{
    public class SaveManager : MonoBehaviour, ISaveManager, IGlobalRouter
    {
        [SerializeField] private SaveSystem _saveSystem;
        [SerializeField] private bool _hasSaveData;

        private void Awake()
        {

        }
        private void Start()
        {

        }
        private void OnEnable()
        {
            _hasSaveData = _saveSystem.LoadSaveDataFromDisk();
        }

        private void OnDisable()
        {

        }

        public bool CheckSaveData()
        {
            return _hasSaveData;
        }

        public SaveSystem GetSaveSystem()
        {
            return _saveSystem;
        }

        public IEnumerator InitializeComponent()
        {
            Debug.Log("SaveManager Initialize");

            return null;
        }
    }
}
