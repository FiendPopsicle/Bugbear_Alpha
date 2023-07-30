using Bugbear.Common;
using Bugbear.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bugbear.Managers
{
    public class UiManager : MonoBehaviour, IUiManager, IGlobalRouter
    {
        private Dictionary<string, IUiComponent> _uiComponents;

        private void Awake()
        {
            _uiComponents = new Dictionary<string, IUiComponent>();
        }
        public void LoadUiComponent(string key, IUiComponent component)
        {
            if (_uiComponents.ContainsKey(key)) { Debug.Log($"{key} is already loaded to UI Manager..."); }
            _uiComponents.Add(key, component);

            Debug.Log($"{key} added to UI Manager....");
        }

        public IEnumerator InitializeComponent()
        {
            Debug.Log("Ui Manager Intialized...");

            return null;
        }

        public void ReceiveCommand(ICommand command, string receiver)
        {
            if (!_uiComponents.ContainsKey(receiver)) { Debug.Log($"{receiver} is not present in UI Manager..."); }

            _uiComponents[receiver].ReceiveCommand(command);
        }

        public void SendCommand(ICommand command, string receiver)
        {
            throw new System.NotImplementedException();
        }
    }
}