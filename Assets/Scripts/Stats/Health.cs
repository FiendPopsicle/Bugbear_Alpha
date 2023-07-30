using Bugbear.Combat;
using Bugbear.Common;
using Bugbear.Managers;
using System;
using UnityEngine;

namespace Bugbear.Stats
{
    public class Health : MonoBehaviour, IDamagable
    {
        [SerializeField] private int _maxHealth = 100;
        private int _currentHealth;
        public int entityId;
        public bool isZeroHP => _currentHealth <= 0;
        public bool isBloodied => _currentHealth <= _maxHealth / 4;

        public event Action<int, int> OnHpChange;

        public int currentHealth
        {
            get => _currentHealth;
            private set
            {
                int oldValue = _currentHealth;
                _currentHealth = Mathf.Clamp(value, 0, _maxHealth);
                if (_currentHealth != oldValue && OnHpChange != null)
                {
                    OnHpChange(_currentHealth, entityId);
                }
            }
        }

        private void Awake()
        {
            currentHealth = _maxHealth;
            SetHealthBar();
        }

        public void TakeDamage(int damageTaken)
        {
            currentHealth = Mathf.Clamp(currentHealth - damageTaken, 0, _maxHealth);
        }
        public void TakeHeal(int healTaken)
        {
            currentHealth = Mathf.Clamp(currentHealth + healTaken, 0, _maxHealth);
        }
        public void Die()
        {

        }

        private void SetHealthBar()
        {
            var newCommand = new SetHealthBarCommand
            {
                health = this,
                healthId = entityId
            };

            GlobalPointer._uiManager.ReceiveCommand(newCommand, "healthbar");
        }
    }
}
