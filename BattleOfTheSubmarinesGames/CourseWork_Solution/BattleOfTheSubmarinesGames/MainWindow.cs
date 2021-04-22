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
        List<GameObject> gameObjects;
        Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();
        List<string> sprites = new List<string>()
        {
            "seaFloor.jpg",
            "firstSubmarine.png",
            "secondSubmarine.png",
            "health.png",
            "armor.png",
            "speed.png",
            "ammunition.png",
            "destroyer.png",
            "mina.png",
            "atomicRocket.png",
            "win_1.png",
            "win_2.png"
        };
        Timerr bonusTimer = new Timerr();
        Timerr submarineCooldown_1 = new Timerr();
        Timerr submarineCooldown_2 = new Timerr();
        Timerr destroyerTimer = new Timerr();
        Timerr stopGame = new Timerr();
        static object locker = new object();
        bool activeRocket_1 = true;
        bool activeRocket_2 = true;
        bool activeMina = false;
        int rocketCooldown = 750;
          

        /// <summary>
        /// Инициализатор окна OpenTK.
        /// </summary>
        /// <param name="width"> Ширина. </param>
        /// <param name="height"> Высота. </param>
        public MainWindow(int width, int height) : base(width, height)
        {
            this.Location = new Point(-10, 0);

            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            gameObjects = new List<GameObject>();

            LoadingGameObjects();        
  
            bonusTimer.Start(10000, CreateBonus);
            destroyerTimer.Start(12000, CreateDestroyer);
        }
        
        public void GameWin(int numberSubmarine)
        {
            var texture = string.Empty;

            if (numberSubmarine == 1)
            {
                texture = "win_2.png";
            }
            else
            {
                texture = "win_1.png";
            }

            bonusTimer.Stop();
            destroyerTimer.Stop();
            var win = new Background();
            win.Components.Add(textures[texture]);
            gameObjects.Add(win);
            stopGame.Start(7000, StopGame);
        }

        /// <summary>
        /// Закрыть окно.
        /// </summary>
        private void StopGame()
        {
            this.Close();
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
            submarineCooldown_1.Stop();
            activeRocket_1 = true;
        }

        /// <summary>
        /// Контроль перезарядки второй лодки
        /// </summary>
        private void ActivateCooldown_2()
        {
            submarineCooldown_2.Stop();
            activeRocket_2 = true;
        }

        /// <summary>
        /// Создание мины.
        /// </summary>
        /// <param name="transform"></param>
        private void CreateMina(Transform transform)
        {
            var mina = new Mina();
            //RemoveGameObjects(mina);

            mina.Transform.Scale = new Vector2(-transform.Scale.X, transform.Scale.Y);
            mina.Transform.Position = new Vector2(transform.Position.X, transform.Position.Y);
            mina.Components.Add(textures["mina.png"]);
            mina.Components.Add(new BoxCollider(textures["mina.png"].Width, textures["mina.png"].Height));
            gameObjects.Add(mina);
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
            destroyer.Transform.Position = new Vector2((-(ClientSize.Width + textures["destroyer.png"].Width) / 2) * side, (ClientSize.Height - textures["destroyer.png"].Height) / 2);
            destroyer.Components.Add(textures["destroyer.png"]);
            gameObjects.Add(destroyer);
        }

        /// <summary>
        /// Генерация бонусов.
        /// </summary>
        private void CreateBonus()
        {
            var bonus = new BonusGenerator();
            RemoveGameObjects(bonus);
            Texture2D bonusTexture = null;          

            switch (bonus.RandomBonus)
            {
                case 0:
                    bonusTexture = textures["health.png"];
                    break;
                case 1:
                    bonusTexture = textures["armor.png"];
                    break;
                case 2:
                    bonusTexture = textures["speed.png"];
                    break;
                case 3:
                    bonusTexture = textures["ammunition.png"];
                    break;
                default:
                    break;
            }

            var random = new Random();
            int x = random.Next(-(ClientSize.Width - bonusTexture.Width) / 2, (ClientSize.Width - bonusTexture.Width) / 2);
            int y = random.Next(-((ClientSize.Height - bonusTexture.Height) / 2), (ClientSize.Height - bonusTexture.Height) / 2);

            bonus.Transform.Position = new Vector2(x, y);
            bonus.Components.Add(bonusTexture);
            bonus.Components.Add(new BoxCollider(bonusTexture.Width, bonusTexture.Height));
            gameObjects.Add(bonus);
        }

        /// <summary>   
        /// Создание ракеты.
        /// </summary>
        /// <param name="transform"> Позиция стреляющей лодки. </param>
        private void CreateRocket(Transform transform, Type owner)
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

            var rocket = new AtomicRocket(direction, owner);
            rocket.Transform.Position = new Vector2(transform.Position.X, transform.Position.Y - 50);
            rocket.Transform.Scale = new Vector2(rocket.Transform.Scale.X * sign, rocket.Transform.Scale.Y);
            rocket.Components.Add(textures["atomicRocket.png"]);
            rocket.Components.Add(new BoxCollider(textures["atomicRocket.png"].Width, textures["atomicRocket.png"].Height));
            gameObjects.Add(rocket);
        } 

        /// <summary>
        /// Загрузка игровых объектов.
        /// </summary>
        private void LoadingGameObjects()
        {
            // try

            //Загрузка текстур.
            for (var i = 0; i < sprites.Count; i++)
            {
                textures.Add(sprites[i], TextureProcessing.LoadTexture2D(sprites[i]));
            }

            // Фон.
            var background = new Background();
            background.Components.Add(textures["seaFloor.jpg"]);
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
            firstSubmarine.Transform.Position = new Vector2(-600, 0);
            firstSubmarine.Components.Add(textures["firstSubmarine.png"]);
            firstSubmarine.Components.Add(new BoxCollider(textures["firstSubmarine.png"].Width, textures["firstSubmarine.png"].Height));
            gameObjects.Add(firstSubmarine);

            // Вторая  лодка.
            var secondSubmarine = new SecondSubmarine();
            secondSubmarine.Transform.Position = new Vector2(600, 0);
            secondSubmarine.Transform.Scale = new Vector2(-1, 1);
            secondSubmarine.Components.Add(textures["secondSubmarine.png"]);
            secondSubmarine.Components.Add(new BoxCollider(textures["secondSubmarine.png"].Width, textures["secondSubmarine.png"].Height));
            gameObjects.Add(secondSubmarine);

        }

        /// <summary>
        /// Проверка на столкновение объектов.
        /// </summary>
        /// <param name="go"> Игровой объект. </param>
        /// <param name="object_id"> Номер объекта в коллекции. </param>
        /// <returns></returns>
        private bool CheckingColliders(GameObject go, int object_id)
        {
            if (go.GetComponent<Collider>() == null)
            {
                throw new Exception($"Игровой объект {go.GetType().Name} не имеет коллайдера!"); ;
            }

            // try

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
                                // При столкновении лодки с лодкой, стеной. И при столкновении ракеты со стеной ???
                                if (go is Submarine && gameObjects[i] is Submarine || gameObjects[i] is Border)
                                {
                                    return true;
                                }

                                // При столкновении ракеты с лодкой.
                                if (go is Rocket && gameObjects[i] is Submarine)
                                {
                                    var sub = (Submarine)gameObjects[i];
                                    var rocket = (Rocket)go;

                                    if (sub.GetType() != rocket.Owner)
                                    {
                                        sub.TakingDamage(rocket.LifeDamage, rocket.ArmorDamage);
                                        gameObjects[i] = sub;

                                        return true;
                                    }

                                    return false;
                                }

                                // При столкновении лодки с бонусом.
                                if (go is Submarine && gameObjects[i] is BonusGenerator)
                                {
                                    var sub = (Submarine)go;

                                    var oldPosition = sub.Transform.Position;
                                    var oldScale = sub.Transform.Scale;

                                    var bonusGenerator = (BonusGenerator)gameObjects[i];
                                    var bonus = bonusGenerator.GenerateBonus();
                                    sub = bonus.Activation(sub);

                                    sub.Transform.Position = oldPosition;
                                    sub.Transform.Scale = oldScale;
                                    gameObjects[object_id] = sub;

                                    gameObjects.RemoveAt(i);
                                    return false;
                                }

                                // При столкновении мины с лодкой.
                                if (go is Mina && gameObjects[i] is Submarine)
                                {
                                    var sub = (Submarine)gameObjects[i];
                                    var mina = (Mina)go;

                                    sub.TakingDamage(mina.LifeDamage, mina.ArmorDamage);
                                    gameObjects[i] = sub;

                                    return true;
                                }

                                return false;
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

            // try

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

            SwapBuffers(); 
        }

        /// <summary>
        /// Покадровая логика.
        /// </summary>
        /// <param name="e"> Данные события. </param>
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            // try
            var property = String.Empty;
            int numberSubmarine = 0;

            lock (locker)
            {
                try
                {
                    for (var i = 0; i < gameObjects.Count; i++)
                    {
                        if (gameObjects[i] is Destroyer)
                        {
                            var destroyer = (Destroyer)gameObjects[i];
                            destroyer.Move(e.Time * destroyer.Speed);

                            var random = new Random();
                            var sub = (Submarine)gameObjects[SearchSubmarineId(random.Next(1, 3))];

                            if (destroyer.Transform.Position.X <= sub.Transform.Position.X && !activeMina)
                            {
                                CreateMina(destroyer.Transform);
                                activeMina = true;
                            }
                        }

                        if (gameObjects[i] is Rocket)
                        {
                            var rocket = (Rocket)gameObjects[i];
                            rocket.Move(e.Time * rocket.Speed);

                            if (CheckingColliders(rocket, i))
                            {
                                gameObjects.RemoveAt(i);
                            }
                        }

                        if (gameObjects[i] is Mina)
                        {
                            var mina = (Mina)gameObjects[i];
                            mina.Move(e.Time * mina.Speed);

                            if (CheckingColliders(gameObjects[i], i))
                            {
                                gameObjects.RemoveAt(i);
                                activeMina = false;
                            }
                        }

                        if (gameObjects[i] is Submarine)
                        {
                            var sub = (Submarine)gameObjects[i];
                            numberSubmarine++;

                            if (numberSubmarine == 1)
                            {
                                ControllingFirstPlayer(e, sub, i);
                            }
                            if (numberSubmarine == 2)
                            {
                                ControllingSecondPlayer(e, sub, i);
                            }

                            if (sub.Health <= 0)
                            {
                                GameWin(numberSubmarine);
                                gameObjects.RemoveAt(i);
                            }

                            property += sub.ToString() + 
                                "                                                " +
                                "                                                " +
                                "                                                ";
                        }
                    }
                }
                catch { }
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

            if (numberOject < 0 || numberOject > 2)
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
        /// Контроль игровых объектов.
        /// </summary>
        /// <param name="e"></param>
        private void ControllingGameObjects(FrameEventArgs e)
        {
            
        }

        /// <summary>
        /// Управление первого игрока.
        /// </summary>
        /// <param name="e"></param>
        private void ControllingFirstPlayer(FrameEventArgs e, Submarine submarine, int submarine_id)
        {
            KeyboardState kb = Keyboard.GetState();

            var scaleX = submarine.Transform.Scale.X < 0 ? submarine.Transform.Scale.X * -1 : submarine.Transform.Scale.X;
            var scaleY = submarine.Transform.Scale.Y;

            Vector2 oldPosition = submarine.Transform.Position;
           
            if (kb.IsKeyDown(Key.Space) && activeRocket_1 && submarine.Ammunition > 0)
            {
                CreateRocket(submarine.Transform, submarine.GetType());
                submarine.Shoot();
                activeRocket_1 = false;
                submarineCooldown_1.Start(rocketCooldown, ActivateCooldown_1);
            }

            if (kb.IsKeyDown(Key.W) ^ kb.IsKeyDown(Key.S))
            {
                if (kb.IsKeyDown(Key.W))
                {
                    submarine.Move(Direction.Up, e.Time * submarine.Speed);
                }
                else
                {
                    submarine.Move(Direction.Down, e.Time * submarine.Speed);
                }

                if (CheckingColliders(submarine, submarine_id))
                {
                    submarine.Transform.Position = oldPosition;
                }
            }

            if (kb.IsKeyDown(Key.A) ^ kb.IsKeyDown(Key.D))
            {
                if (kb.IsKeyDown(Key.A))
                {
                    submarine.Transform.Scale = new Vector2(-scaleX, scaleY);
                    submarine.Move(Direction.Left, e.Time * submarine.Speed);
                }
                else
                {
                    submarine.Transform.Scale = new Vector2(scaleX, scaleY);
                    submarine.Move(Direction.Right, e.Time * submarine.Speed);
                }

                if (CheckingColliders(submarine, submarine_id))
                {
                    submarine.Transform.Position = oldPosition;
                }
            }   
        }

        /// <summary>
        /// Управление второго игрока.
        /// </summary>
        /// <param name="e"> Данные события. </param>
        private void ControllingSecondPlayer(FrameEventArgs e, Submarine submarine, int submarine_id)
        {
            KeyboardState kb = Keyboard.GetState();           

            var scaleX = submarine.Transform.Scale.X < 0 ? submarine.Transform.Scale.X * -1 : submarine.Transform.Scale.X;
            var scaleY = submarine.Transform.Scale.Y;

            Vector2 oldPosition = submarine.Transform.Position;

            if (kb.IsKeyDown(Key.KeypadEnter) && activeRocket_2 && submarine.Ammunition > 0)
            {
                CreateRocket(submarine.Transform, submarine.GetType());
                submarine.Shoot();
                activeRocket_2 = false;
                submarineCooldown_2.Start(rocketCooldown, ActivateCooldown_2);
            }          

            if (kb.IsKeyDown(Key.Up) ^ kb.IsKeyDown(Key.Down))
            {
                if (kb.IsKeyDown(Key.Up))
                {
                    submarine.Move(Direction.Up, e.Time * submarine.Speed);
                }
                else
                {
                    submarine.Move(Direction.Down, e.Time * submarine.Speed);
                }

                if (CheckingColliders(submarine, submarine_id))
                {
                    submarine.Transform.Position = oldPosition;
                }
            }

            if (kb.IsKeyDown(Key.Left) ^ kb.IsKeyDown(Key.Right))
            {
                if (kb.IsKeyDown(Key.Left))
                {
                    submarine.Transform.Scale = new Vector2(-scaleX, scaleY);
                    submarine.Move(Direction.Left, e.Time * submarine.Speed);
                }
                else
                {
                    submarine.Transform.Scale = new Vector2(scaleX, scaleY);
                    submarine.Move(Direction.Right, e.Time * submarine.Speed);
                }

                if (CheckingColliders(submarine, submarine_id))
                {
                    submarine.Transform.Position = oldPosition;
                }
            }   
        }
    }
}
