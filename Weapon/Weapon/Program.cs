using System;

namespace Weapon
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    public class Weapon
    {
        private int _damage;
        private int _bullets;

        public void Fire(Player player)
        {
            if (_bullets <= 0)
            {
                throw new InvalidOperationException("В обойме недостаточно пуль");
            }

            player.TakeDamage(_damage);
            _bullets -= 1;
        }
    }

    public class Player
    {
        private int _health;

        public event Action Died;

        public void TakeDamage(int damage)
        {
            if (_health < 0)
            {
                throw new InvalidOperationException("Игрок уже мертв");
            }

            if (damage < 0)
            {
                throw new InvalidOperationException("Не правильное значение урона");
            }

            _health -= damage;

            if(_health <= 0)
                Died?.Invoke();
        }
    }

    public class Bot
    {
        private Weapon _weapon;

        public void OnSeePlayer(Player player)
        {
            _weapon.Fire(player);
        }
    }
}
