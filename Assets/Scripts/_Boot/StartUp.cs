﻿using Bugbear.Managers;
using UnityEngine;

namespace Bugbear.StartUp
{
    public class StartUp : MonoBehaviour
    {
        [SerializeField] private Router _router;

        public bool isColdStartup = false;

        private void Awake()
        {
            Debug.Log("Booting game....");
        }

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            _router.OnStartUp();
        }
    }
}
