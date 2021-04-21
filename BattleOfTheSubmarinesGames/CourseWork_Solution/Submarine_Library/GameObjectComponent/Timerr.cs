using System;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Submarine_Library.GameObjectComponent
{
    /// <summary>
    /// Таймер.
    /// </summary>
    public class Timerr
    {
        private Timer aTimer;
        private Action function = null;

        /// <summary>
        /// Запуск таймера.
        /// </summary>
        /// <param name="mlSecond"> Время в миллисекундах. </param>
        /// <param name="function"> Вызывающийся метод. </param>
        public void Start(int mlSecond, Action function)
        {
            if (mlSecond < 100)
            {
                throw new ArgumentException($"Таймер со скоростью {mlSecond} мс не используется", nameof(mlSecond));
            }

            if (function == null)
            {
                throw new ArgumentNullException("Ссылка на метод является пустой", nameof(function));
            }

            this.function = function;

            aTimer = new Timer
            {
                Interval = mlSecond
            };

            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        /// <summary>
        /// Остановка таймера.
        /// </summary>
        public void Stop()
        {
            aTimer.Enabled = false;
        }

        /// <summary>
        /// Вызов метода.
        /// </summary>
        /// <param name="e"> Данные для события. </param>
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            function();
        }
    }
}
