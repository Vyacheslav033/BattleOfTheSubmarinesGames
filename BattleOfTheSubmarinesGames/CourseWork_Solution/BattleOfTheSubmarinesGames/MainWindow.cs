using System;
using System.Drawing;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Windows.Forms;
using Submarine_Library.GameObjectComponent;
using Submarine_Library.Submarines;
using Submarine_Library.Rockets;
using Submarine_Library.OpenTK_Graphics;
using Submarine_Library.Destroyer;

namespace BattleOfTheSubmarinesGames
{
    public class MainWindow : GameWindow
    {
        private static object locker = new object();
        List<GameObject> gameObjects;
        Timerr bonusTimer = new Timerr();
        Timerr submarineCooldown_1 = new Timerr();
        Timerr submarineCooldown_2 = new Timerr();
        Timerr destroyerTimer = new Timerr();
        bool activeRocket_1 = false;
        bool activeRocket_2 = false;
        List<string> textures = new List<string>()
        {
            "health.png",
            "armor.png",
            "speed.png",
            "ammunition.png",
            "destroyer.png"
        };    

        /// <summary>
        /// Инициализатор окна OpenTK.
        /// </summary>
        /// <param name="width"> Ширина. </param>
        /// <param name="height"> Высота. </param>
        public MainWindow(int width, int height) : base(width, height)
        {
            int cooldown = 2000;
            this.Location = new Point(-10, 0);

            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            gameObjects = new List<GameObject>();

            LoadingGameObjects();

            //submarineCooldown_1.Start(cooldown, ActivateCooldown_1);
            //submarineCooldown_2.Start(cooldown, ActivateCooldown_2);
            //bonusTimer.Start(1000, CreateBonus);
            destroyerTimer.Start(15000, CreateDestroyer);

        }
      
        /// <summary>
        /// Удаление игровых объектов.
        /// </summary>
        /// <param name="go"></param>
        private void RemoveGameObjects(GameObject go)
        {
            lock (locker)
            {
                for (var i = 0; i < gameObjects.Count; i++)
                {
                    if (gameObjects[i].GetType() == go.GetType())
                    {
                        gameObjects.RemoveAt(i);
                    }
                }
            }
        }

        /// <summary>
        /// Контроль перезарядки первой лодки.
        /// </summary>
        private void ActivateCooldown_1()
        {
            activeRocket_1 = activeRocket_1 == true ? (false) : (true);
        }

        /// <summary>
        /// Контроль перезарядки второй лодки
        /// </summary>
        private void ActivateCooldown_2()
        {
            activeRocket_2 = activeRocket_2 == true ? (false) : (true);      
        }

        /// <summary>
        /// Создание эсминца.
        /// </summary>
        private void CreateDestroyer()
        {
            var random = new Random();
            int side = random.Next(0, 2);
            Direction direction = (side == 0) ? (Direction.Right) : (Direction.Left);
            side = (side == 0) ? (1) : (-1);

            var destroyer = new Destroyer(direction);
            RemoveGameObjects(destroyer);

            destroyer.Transform.Scale = new Vector2(destroyer.Transform.Scale.X * side, destroyer.Transform.Scale.Y);
            Texture2D destroyerTexture = TextureProcessing.LoadTexture2D(textures[4]);
            destroyer.Transform.Position = new Vector2((-(ClientSize.Width + destroyerTexture.Width) / 2) * side, (ClientSize.Height - destroyerTexture.Height) / 2);
            destroyerTexture.Id = 5;
            destroyer.Components.Add(destroyerTexture);
            gameObjects.Add(destroyer);
        }

        /// <summary>
        /// Генерация бонусов.
        /// </summary>
        private void CreateBonus()
        {
            var bonus = new BonusGenerator();            
            Texture2D bonusGeneratorTexture = null;
            RemoveGameObjects(bonus);

            switch (bonus.RandomBonus)
            {
                case 0:
                    bonusGeneratorTexture = TextureProcessing.LoadTexture2D(textures[0]);
                    bonusGeneratorTexture.Id = bonus.RandomBonus + 1;
                    break;
                case 1:
                    bonusGeneratorTexture = TextureProcessing.LoadTexture2D(textures[1]);
                    bonusGeneratorTexture.Id = bonus.RandomBonus + 1;
                    break;
                case 2:
                    bonusGeneratorTexture = TextureProcessing.LoadTexture2D(textures[2]);
                    bonusGeneratorTexture.Id = bonus.RandomBonus + 1;
                    break;
                case 3:
                    bonusGeneratorTexture = TextureProcessing.LoadTexture2D(textures[3]);
                    bonusGeneratorTexture.Id = bonus.RandomBonus + 1;
                    break;
                default:
                    break;
            }

            var random = new Random();
            int x = random.Next(-(ClientSize.Width - bonusGeneratorTexture.Width) / 2, (ClientSize.Width - bonusGeneratorTexture.Width) / 2);
            int y = random.Next(-((ClientSize.Height - bonusGeneratorTexture.Height) / 2), (ClientSize.Height - bonusGeneratorTexture.Height) / 2);

            bonus.Transform.Position = new Vector2(x, y);
            bonus.Components.Add(bonusGeneratorTexture);
            bonus.Components.Add(new BoxCollider(bonusGeneratorTexture.Width, bonusGeneratorTexture.Height));
            gameObjects.Add(bonus);
        }

        /// <summary>   
        /// Создание ракеты.
        /// </summary>
        /// <param name="transform"> Позиция стреляющей лодки. </param>
        private void CreateRocket(Transform transform)
        {
            int sign;
            Direction direction;

            if (transform.Scale.X < 0)
            {
                sign = -1;
                direction = Direction.Left;
            }
            else
            {
                sign = 1;
                direction = Direction.Right;
            }

            var rocket = new FieryRocket(direction);
            rocket.Transform.Position = new Vector2(transform.Position.X, transform.Position.Y - 70);
            rocket.Transform.Scale = new Vector2(rocket.Transform.Scale.X * sign, rocket.Transform.Scale.Y);
            var rocketTexture = TextureProcessing.LoadTexture2D("rocket.png");
            rocket.Components.Add(rocketTexture);
            rocket.Components.Add(new BoxCollider(rocketTexture.Width, rocketTexture.Height));
            gameObjects.Add(rocket);
        } 

        /// <summary>
        /// Загрузка игровых объектов.
        /// </summary>
        private void LoadingGameObjects()
        {          
            try
            {
                //Загрузка текстур.
                for (var i = 0; i < textures.Count; i++)
                {
                    TextureProcessing.LoadTexture2D(textures[i]);
                }

                // Фон.
                var background = new Background();
                background.Components.Add(TextureProcessing.LoadTexture2D("seaFloor.jpg"));
                gameObjects.Add(background);

                // Правая граница.
                var rightBorder = new Border(Width, Height, Direction.Right);
                gameObjects.Add(rightBorder);

                // Левая граница.
                var leftBorder = new Border(Width, Height, Direction.Left);
                gameObjects.Add(leftBorder);

                // Верхняя граница.
                var upBorder = new Border(Width, Height, Direction.Up);
                gameObjects.Add(upBorder);

                // Нижняя граница.
                var bottomBorder = new Border(Width, Height, Direction.Down);
                gameObjects.Add(bottomBorder);

                // Первая лодка.
                var firstSubmarine = new FirstSubmarine();
                firstSubmarine.Transform.Position = new Vector2(-300, 0);
                var firstSubmarineTexture = TextureProcessing.LoadTexture2D("firstSubmarine.png");
                firstSubmarine.Components.Add(firstSubmarineTexture);
                firstSubmarine.Components.Add(new BoxCollider(firstSubmarineTexture.Width, firstSubmarineTexture.Height));
                gameObjects.Add(firstSubmarine);

                // Вторая  лодка.
                var secondSubmarine = new SecondSubmarine();
                secondSubmarine.Transform.Position = new Vector2(300, 0);
                secondSubmarine.Transform.Scale = new Vector2(-1, 1);
                var secondSubmarineTexture = TextureProcessing.LoadTexture2D("secondSubmarine.png");
                secondSubmarine.Components.Add(secondSubmarineTexture);
                secondSubmarine.Components.Add(new BoxCollider(secondSubmarineTexture.Width, secondSubmarineTexture.Height));
                gameObjects.Add(secondSubmarine);  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Проверка на столкновение объектов.
        /// </summary>
        /// <param name="go"> Игровой объект. </param>
        /// <param name="object_id"> Номер объекта в коллекции. </param>
        /// <returns></returns>
        private bool CheckingColliders(GameObject go, int object_id)
        {
            try
            {
                if (go.GetComponent<Collider>() == null)
                {
                    throw new Exception($"Игровой объект {go.GetType().Name} не имеет коллайдера!"); ;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }

            lock (locker)
            {
                for (var i = 0; i < gameObjects.Count; i++)
                {
                    if (!gameObjects[i].Equals(go))
                    {
                        if (gameObjects[i].GetComponent<Collider>() != null)
                        {
                            if (Collider.CheckCollision(gameObjects[i], go))
                            {
                                if (gameObjects[i] is BonusGenerator && go is Submarine)
                                {
                                    var oldPosition = go.Transform.Position;
                                    var oldScale = go.Transform.Scale;

                                    var bonusGenerator = (BonusGenerator)gameObjects[i];
                                    var bonus = bonusGenerator.GenerateBonus();
                                    gameObjects[object_id] = bonus.Activation((Submarine)go);

                                    gameObjects[object_id].Transform.Position = oldPosition;
                                    gameObjects[object_id].Transform.Scale = oldScale;

                                    gameObjects.RemoveAt(i);
                                }

                                if (go is Rocket && gameObjects[i] is BonusGenerator)
                                {
                                    return false;
                                }

                                if (go is Rocket && gameObjects[i] is Rocket)
                                {
                                    return false;
                                }

                                if (go is Rocket && gameObjects[i] is Submarine)
                                {
                                    var sub = (Submarine)gameObjects[i];
                                    var rocket = (Rocket)go;

                                    sub.TakingDamage(rocket.LifeDamage, rocket.ArmorDamage);
                                    gameObjects[i] = sub;

                                    return true;
                                }

                                return true;
                            }                           
                        }
                    }
                }
            }

            return false;
        }    

        /// <summary>
        /// OnRenderFrame.
        /// </summary>
        /// <param name="e"> Данные события. </param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //GL.ClearColor(Color.FromArgb(54, 54, 38));
            SpriteRendering.Begin(Width, Height);
        }

        /// <summary>
        /// Покадровая отрисовка.
        /// </summary>
        /// <param name="e"> Данные события. </param>
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            base.OnRenderFrame(e);
           
            try
            {
                lock (locker)
                {
                    foreach (GameObject gameObject in gameObjects)
                    {
                        if (gameObject.GetComponent<Texture2D>() != null)
                        {
                            SpriteRendering.Draw((Texture2D)gameObject.GetComponent<Texture2D>(), gameObject.Transform);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            SwapBuffers(); 
        }

        /// <summary>
        /// Покадровая логика.
        /// </summary>
        /// <param name="e"> Данные события. </param>
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            ControllingFirstPlayer(e);
            ControllingSecondPlayer(e);
            ControllingRocket(e);
            OutputProperty();
        }

        /// <summary>
        /// Вывод характеристик в Title.
        /// </summary>
        private void OutputProperty()
        {
            var property = String.Empty;

            for (var i = 0; i < gameObjects.Count; i++)
            {
                if (gameObjects[i] is Submarine)
                {
                    property += gameObjects[i].ToString() + "             ";
                }
            }

            Title = property;
        }

        /// <summary>
        /// Поиск айди лодки в коллекции.
        /// Вывод своств лодок в Title.
        /// </summary>
        /// <param name="numberOject"> Айди лодки. </param>
        /// <returns></returns>
        private int SearchSubmarineId(int numberOject)
        {
            int id = 0, num = 0;

            if (numberOject < 1 || numberOject > 2)
            {
                throw new ArgumentException("Необходимо выбрать объект 1 или 2 !", nameof(numberOject));
            }

            for (var i = 0; i < gameObjects.Count; i++)
            {
                if (gameObjects[i] is Submarine)
                {
                    num++;
                    if (num == numberOject)
                    {
                        id = i;
                        break;
                    }
                }
            }

            return id;
        }  

        /// <summary>
        /// Движение ракет.
        /// </summary>
        /// <param name="e"></param>
        private void ControllingRocket(FrameEventArgs e)
        {
            for (var i = 0; i < gameObjects.Count; i++)
            {
                if (gameObjects[i] is Rocket)
                {
                    var rocket = (Rocket)gameObjects[i];
                    rocket.Move(e.Time * rocket.Speed);

                    if (CheckingColliders(gameObjects[i], i))
                    {
                        gameObjects.RemoveAt(i);
                    }
                }

                if (gameObjects[i] is Destroyer)
                {
                    var destroyer = (Destroyer)gameObjects[i];
                    destroyer.Move(e.Time * destroyer.Speed);      
                }


            }
        }

        /// <summary>
        /// Управление первого игрока.
        /// </summary>
        /// <param name="e"></param>
        private void ControllingFirstPlayer(FrameEventArgs e)
        {
            KeyboardState kb = Keyboard.GetState();          
            int submarine_id = SearchSubmarineId(1);
            Submarine firstSubmarine = (Submarine)gameObjects[submarine_id];
            
            var scaleX = firstSubmarine.Transform.Scale.X < 0 ? firstSubmarine.Transform.Scale.X * -1 : firstSubmarine.Transform.Scale.X;
            var scaleY = firstSubmarine.Transform.Scale.Y;

            Vector2 oldPosition = firstSubmarine.Transform.Position;

            if (kb.IsKeyDown(Key.F) && !activeRocket_1)
            {
                CreateRocket(firstSubmarine.Transform);
                activeRocket_1 = true;
            }
          
            if (kb.IsKeyDown(Key.W) ^ kb.IsKeyDown(Key.S))
            {
                if (kb.IsKeyDown(Key.W))
                {
                    firstSubmarine.Move(Direction.Up, e.Time * firstSubmarine.Speed);
                }
                else
                {
                    firstSubmarine.Move(Direction.Down, e.Time * firstSubmarine.Speed);
                }

                if (CheckingColliders(firstSubmarine, submarine_id))
                {
                    firstSubmarine.Transform.Position = oldPosition;
                }
            }

            if (kb.IsKeyDown(Key.A) ^ kb.IsKeyDown(Key.D))
            {
                if (kb.IsKeyDown(Key.A))
                {
                    firstSubmarine.Transform.Scale = new Vector2(-scaleX, scaleY);
                    firstSubmarine.Move(Direction.Left, e.Time * firstSubmarine.Speed);
                }
                else
                {
                    firstSubmarine.Transform.Scale = new Vector2(scaleX, scaleY);
                    firstSubmarine.Move(Direction.Right, e.Time * firstSubmarine.Speed);
                }

                if (CheckingColliders(firstSubmarine, submarine_id))
                {
                    firstSubmarine.Transform.Position = oldPosition;
                }
            }   
        }

        /// <summary>
        /// Управление второго игрока.
        /// </summary>
        /// <param name="e"> Данные события. </param>
        private void ControllingSecondPlayer(FrameEventArgs e)
        {
            KeyboardState kb = Keyboard.GetState();           
            int submarine_id = SearchSubmarineId(2);
            Submarine secondSubmarine = (Submarine)gameObjects[submarine_id];

            var scaleX = secondSubmarine.Transform.Scale.X < 0 ? secondSubmarine.Transform.Scale.X * -1 : secondSubmarine.Transform.Scale.X;
            var scaleY = secondSubmarine.Transform.Scale.Y;

            Vector2 oldPosition = secondSubmarine.Transform.Position;

            if (kb.IsKeyDown(Key.ControlRight) && !activeRocket_2)
            {
                CreateRocket(secondSubmarine.Transform);
                activeRocket_2 = true;
            }

            if (kb.IsKeyDown(Key.Up) ^ kb.IsKeyDown(Key.Down))
            {
                if (kb.IsKeyDown(Key.Up))
                {
                    secondSubmarine.Move(Direction.Up, e.Time * secondSubmarine.Speed);
                }
                else
                {
                    secondSubmarine.Move(Direction.Down, e.Time * secondSubmarine.Speed);
                }

                if (CheckingColliders(secondSubmarine, submarine_id))
                {
                    secondSubmarine.Transform.Position = oldPosition;
                }
            }

            if (kb.IsKeyDown(Key.Left) ^ kb.IsKeyDown(Key.Right))
            {
                if (kb.IsKeyDown(Key.Left))
                {
                    secondSubmarine.Transform.Scale = new Vector2(-scaleX, scaleY);
                    secondSubmarine.Move(Direction.Left, e.Time * secondSubmarine.Speed);
                }
                else
                {
                    secondSubmarine.Transform.Scale = new Vector2(scaleX, scaleY);
                    secondSubmarine.Move(Direction.Right, e.Time * secondSubmarine.Speed);
                }

                if (CheckingColliders(secondSubmarine, submarine_id))
                {
                    secondSubmarine.Transform.Position = oldPosition;
                }
            }   
        }
    }
}
