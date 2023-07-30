namespace Bugbear.Combat
{
    public interface IDamagable
    {
        public void TakeDamage(int damageTaken);

        public void TakeHeal(int healTaken);

        public void Die();
    }
}
