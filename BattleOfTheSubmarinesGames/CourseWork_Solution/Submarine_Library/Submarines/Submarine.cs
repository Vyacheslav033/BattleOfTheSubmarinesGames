﻿using System;
using OpenTK;
using Submarine_Library.GameObjectComponent;
using Submarine_Library.Interfaces;

namespace Submarine_Library.Submarines
{
    /// <summary>
    /// Подводная лодка.
    /// </summary>
    public abstract class Submarine : GameObject, IMovableSubmarine
    {
        /// <summary>
        /// Количество жизней.
        /// </summary>
        public int Health { get; protected set; }

        /// <summary>
        /// Запас брони.
        /// </summary>
        public int Armor { get; protected set; }

        /// <summary>
        /// Скорость.
        /// </summary>
        public float Speed { get; protected set; }

        /// <summary>
        /// Количество ракет.
        /// </summary>
        public int Ammunition { get; protected set; }

        public Type BasicType { get; protected set; }

        /// <summary>
        /// Инициализатор лодки.
        /// </summary>
        public Submarine()
        {
            Health = 100;
            Speed = 18;
            Armor = 100;
            Ammunition = 15;
            BasicType = this.GetType();
        }

        /// <summary>
        /// Получение урона.
        /// </summary>
        /// <param name="lifeDamage"> Урон по здоровью. </param>
        /// <param name="armorDamage"> Урон по броне. </param>
        public void TakingDamage(int lifeDamage, int armorDamage)
        {
            if(Armor == 0)
            {
                Health -= lifeDamage;
            }
            else
            {
                Armor -= armorDamage;

                if (Armor < 0)
                {  
                    Health -= lifeDamage - (-Armor);
                    Armor = 0;
                }
            }   
        }

        /// <summary>
        /// Выстрел, расходует ракету.
        /// </summary>
        public void Shoot()
        {
            Ammunition--;
        }

        /// <summary>
        /// Движение лодки.
        /// </summary>
        /// <param name="direction"> Направление. </param>
        /// <param name="time"> Время. </param>
        public void Move(Direction direction, double time)
        {
            float x = Transform.Position.X;
            float y = Transform.Position.Y;

            switch (direction)
            {
                case Direction.Up:
                    y += Speed * (float)time;
                    break;

                case Direction.Down:
                    y -= Speed * (float)time;
                    break;

                case Direction.Left:
                    x -= Speed * (float)time;
                    break;

                case Direction.Right:
                    x += Speed * (float)time;
                    break;

                default:
                    break;
            }

            Transform.Position = new Vector2(x, y);
        }

        /// <summary>
        /// Вывод характеристик лодки.
        /// </summary>
        /// <returns> Характеристика лодки. </returns>
        public override string ToString()
        {
            return $"Жизни: {Health} | Броня: {Armor} | Скорость: {Speed} | Снаряды: {Ammunition}";
        }
    }
}
