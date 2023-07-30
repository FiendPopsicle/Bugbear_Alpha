using Bugbear.Common;
using Bugbear.Managers;
using Bugbear.Stats;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Bugbear.UI
{
    public class Healthbar : MonoBehaviour, IUiComponent
    {
        public Health health;
        public Slider slider;
        public int currentEntityId;

        private void Start()
        {
            GlobalPointer._uiManager.LoadUiComponent("healthbar", this);
        }

        private void UpdateSlider(int newHp, int entityId)
        {
            if (entityId != currentEntityId) return;
            slider.value = newHp;
        }

        private void OnDisable()
        {
            health.OnHpChange -= UpdateSlider;
        }
        public void SendCommand(ICommand command, string receiver)
        {

        }

        public void ReceiveCommand(ICommand command)
        {
            switch (command)
            {
                case SetHealthBarCommand setHealthBarCommand when setHealthBarCommand != null:
                    HandleSetHealthBarCommand(setHealthBarCommand);
                    break;
                default:
                    // Handle unknown command or throw an exception
                    throw new ArgumentException("Unknown command type");
            }
        }

        private void HandleSetHealthBarCommand(SetHealthBarCommand command)
        {
            health = command.health;
            currentEntityId = command.healthId;
            health.OnHpChange += UpdateSlider;
        }
    }
}