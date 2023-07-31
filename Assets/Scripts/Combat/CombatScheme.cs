using UnityEngine;

namespace Bugbear.Combat
{
    public class CombatScheme : MonoBehaviour
    {
        private Animator _animator;
        private bool _isAttacking = false;
        private float gcd;
        private string attackIndexHash = "AttackIndex";
        private int currentAttack = 0;

        //Animations
        private int attackHash = Animator.StringToHash("Attack");
        private int currentAttackString = Animator.StringToHash("CurrentAttack");

        public void OnAttack(bool isAttacking)
        {
            _isAttacking = isAttacking;
        }

        private void Start()
        {
            InitializeAnimations();
        }

        private void Update()
        {
            CycleGCD();
            InteractWithBasicAttack();
        }

        private void InitializeAnimations()
        {
            _animator = GetComponent<Animator>();
        }

        private void InteractWithBasicAttack()
        {
        }
        private void CycleGCD()
        {
            gcd += Time.deltaTime;
        }
    }
}