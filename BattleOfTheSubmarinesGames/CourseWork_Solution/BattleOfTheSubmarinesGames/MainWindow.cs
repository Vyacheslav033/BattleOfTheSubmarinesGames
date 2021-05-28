﻿using System;
using OpenTK;
using System.Drawing;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using GameLogic;
using GameEngine;

namespace BattleOfTheSubmarinesGames
{
    public class MainWindow : GameWindow
    {       
        List<GameObject> gameObjects;
        Dictionary<string, Texture2D> textures;
        List<string> sprites;
        Timerr bonusTimer = new Timerr();
        Timerr blueSubmarineCooldown = new Timerr();
        Timerr redSubmarineCooldown = new Timerr();
        Timerr destroyerTimer = new Timerr();
        RocketAmmunition blueSubAmmunition;
        RocketAmmunition redSubAmmunition;
        RocketType blueRocketType = RocketType.FieryRocket;
        RocketType redRocketType = RocketType.FieryRocket;       
        bool activeRocket_1 = true;
        bool activeRocket_2 = true;
        bool activeMina = false;

        /// <summary>
        /// Инициализатор окна OpenTK.
        /// </summary>
        /// <param name="width"> Ширина. </param>
        /// <param name="height"> Высота. </param>
        /// <param name="blueAmmo"> Снаряжение синей лодки. </param>
        /// <param name="redAmmo"> Снаряжение красной лодки. </param>
        public MainWindow(int width, int height, RocketAmmunition blueAmmo, RocketAmmunition redAmmo ) : base(width, height)
        {        
            this.Location = new Point(-10, 0);

            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            blueSubAmmunition = blueAmmo;
            redSubAmmunition = redAmmo;

            gameObjects = new List<GameObject>();
            textures = new Dictionary<string, Texture2D>();
            sprites = new List<string>()
            {
                "seaFloor.jpg",
                "blueSubmarine.png",
                "redSubmarine.png",
                "health.png",
                "armor.png",
                "speed.png",
                "ammunition.png",
                "destroyer.png",
                "mina.png",
                "fieryRocket.png",
                "iceRocket.png",
                "atomicRocket.png",
                "win_1.png",
                "win_2.png"
            };

            LoadingGameObjects();

            bonusTimer.Start(12000, CreateBonus);
            destroyerTimer.Start(10000, CreateDestroyer);
        }

        /// <summary>
        /// Загрузка игровых объектов.
        /// </summary>
        private void LoadingGameObjects()
        {
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

            // Синяя лодка.
            var blueSubmarine = new BlueSubmarine(blueSubAmmunition);
            var sub2_Texture = textures["blueSubmarine.png"];
            blueSubmarine.Transform.Position = new Vector2(-(ClientSize.Width / 2) + sub2_Texture.Width, 0);
            blueSubmarine.Components.Add(sub2_Texture);
            blueSubmarine.Components.Add(new BoxCollider(sub2_Texture.Width, sub2_Texture.Height));
            gameObjects.Add(blueSubmarine);

            // Красная лодка.
            var redSubmarine = new RedSubmarine(redSubAmmunition);
            var sub1_Texture = textures["redSubmarine.png"];
            redSubmarine.Transform.Position = new Vector2((ClientSize.Width / 2) - sub1_Texture.Width, 0);
            redSubmarine.Transform.Scale = new Vector2(-redSubmarine.Transform.Scale.X, redSubmarine.Transform.Scale.Y);
            redSubmarine.Components.Add(sub1_Texture);
            redSubmarine.Components.Add(new BoxCollider(sub1_Texture.Width, sub1_Texture.Height));
            gameObjects.Add(redSubmarine);
        }

        /// <summary>
        /// Завершение игры.
        /// </summary>
        /// <param name="typeSubmarine"> Тип победившей лодки.</param>
        public void GameWin(Type typeSubmarine)
        {
            var texture = string.Empty;

            if (typeSubmarine.Name.ToString() == nameof(BlueSubmarine))
            {
                texture = "win_2.png";
            }
            else if (typeSubmarine.Name.ToString() == nameof(RedSubmarine))
            {
                texture = "win_1.png";
            }

            var stopGame = new Timerr();
            stopGame.Start(9000, StopGame);
            bonusTimer.Stop();
            destroyerTimer.Stop();
            activeMina = true;

            var win = new Background();
            win.Components.Add(textures[texture]);
            gameObjects.Add(win); 
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
            for (var i = 0; i < gameObjects.Count; i++)
            {
                if (gameObjects[i].GetType() == go.GetType())
                {
                    gameObjects.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Контроль перезарядки синей лодки.
        /// </summary>
        private void ActivateCooldown_1()
        {
            blueSubmarineCooldown.Stop();
            activeRocket_1 = true;
        }

        /// <summary>
        /// Контроль перезарядки красной лодки
        /// </summary>
        private void ActivateCooldown_2()
        {
            redSubmarineCooldown.Stop();
            activeRocket_2 = true;
        }

        /// <summary>
        /// Создание мины.
        /// </summary>
        /// <param name="transform"> Позиция миноносца. </param>
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
        /// <param name="owner"> Тип стреляющей лодки. </param>
        /// <param name="rocketType"> Тип ракеты. </param>
        /// <returns> Скорострельность запускаемой ракеты. </returns>
        private int CreateRocket(Transform transform, Type owner, RocketType rocketType)
        {
            int sign = (transform.Scale.X < 0) ? (-1) : (1);
            Direction direction = (transform.Scale.X < 0) ? (Direction.Left) : (Direction.Right);

            Rocket rocket = null;
         
            switch (rocketType)
            {
                case RocketType.FieryRocket:
                    rocket = new FieryRocket(direction, owner);
                    rocket.Components.Add(textures["fieryRocket.png"]);
                    rocket.Components.Add(new BoxCollider(textures["fieryRocket.png"].Width, textures["fieryRocket.png"].Height));
                    break;
                case RocketType.IceRocket:
                    rocket = new IceRocket(direction, owner);
                    rocket.Components.Add(textures["iceRocket.png"]);
                    rocket.Components.Add(new BoxCollider(textures["iceRocket.png"].Width, textures["iceRocket.png"].Height));
                    break;
                case RocketType.AtomicRocket:
                    rocket = new AtomicRocket(direction, owner);
                    rocket.Components.Add(textures["atomicRocket.png"]);
                    rocket.Components.Add(new BoxCollider(textures["atomicRocket.png"].Width, textures["atomicRocket.png"].Height));
                    break;
                default:
                    break;
            }

            rocket.Transform.Position = new Vector2(transform.Position.X, transform.Position.Y - 50);
            rocket.Transform.Scale = new Vector2(rocket.Transform.Scale.X * sign, rocket.Transform.Scale.Y);  
            gameObjects.Add(rocket);

            return rocket.FiringRate;
        }         

        /// <summary>
        /// Проверка на столкновение объектов.
        /// </summary>
        /// <param name="go"> Игровой объект. </param>
        /// <returns> Итог проверги на столкновения. </returns>
        private bool CheckingColliders(GameObject go)
        {
            if (go.GetComponent<Collider>() == null)
            {
                throw new Exception($"Игровой объект {go.GetType().Name} не имеет коллайдера!"); ;
            }

            for (var i = 0; i < gameObjects.Count; i++)
            {
                if (!gameObjects[i].Equals(go))
                {
                    if (gameObjects[i].GetComponent<Collider>() != null)
                    {
                        if (Collider.CheckCollision(gameObjects[i], go))
                        {
                            // При столкновении лодки с лодкой, стеной.
                            if (go is Submarine && gameObjects[i] is Submarine || gameObjects[i] is Border)
                            {
                                return true;
                            }

                            // При столкновении ракеты с лодкой.
                            if (go is Rocket && gameObjects[i] is Submarine)
                            {
                                var sub = (Submarine)gameObjects[i];
                                var rocket = (Rocket)go;
                        
                                if (rocket.Owner != sub.BasicType)
                                {
                                    sub.TakingDamage(rocket.LifeDamage, rocket.ArmorDamage);
                                    gameObjects[i] = sub;

                                    return true;
                                }

                                return false;
                            }

                            // При столкновении бонуса с лодкой.
                            if (go is BonusGenerator && gameObjects[i] is Submarine)
                            {
                                gameObjects[i] = DecorationSubmarine(gameObjects[i], go);

                                return true;
                            }

                            // При столкновении мины с лодкой.
                            if (go is Mina)
                            {
                                if (gameObjects[i] is Submarine)
                                {
                                    var sub = (Submarine)gameObjects[i];
                                    var mina = (Mina)go;

                                    sub.TakingDamage(mina.LifeDamage, mina.ArmorDamage);
                                    gameObjects[i] = sub;
                                    
                                    return true;
                                }

                                if (gameObjects[i] is Rocket)
                                {
                                    return true;
                                }
                            }                        
                        }
                    }
                }
            }

            return false;
        }    

        /// <summary>
        /// Декарирование лодки.
        /// </summary>
        /// <param name="goSub"> Лодка. </param>
        /// <param name="goBonus"> Бонус. </param>
        /// <returns> Декарированную лодку.</returns>
        private Submarine DecorationSubmarine(GameObject goSub, GameObject goBonus)
        {
            var sub = (Submarine)goSub;
            var bonusGenerator = (BonusGenerator)goBonus;

            var oldPosition = sub.Transform.Position;
            var oldScale = sub.Transform.Scale;

            var bonus = bonusGenerator.GenerateBonus();
            sub = bonus.Activation(sub);

            sub.Transform.Position = oldPosition;
            sub.Transform.Scale = oldScale;

            return sub; 
        }

        /// <summary>
        /// OnRenderFrame.
        /// </summary>
        /// <param name="e"> Данные события. </param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
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
                foreach (GameObject gameObject in gameObjects)
                {
                    if (gameObject.GetComponent<Texture2D>() != null)
                    {
                        SpriteRendering.Draw((Texture2D)gameObject.GetComponent<Texture2D>(), gameObject.Transform);
                    }
                }
            }
            catch { }

            SwapBuffers(); 
        }

        /// <summary>
        /// Покадровая логика.
        /// </summary>
        /// <param name="e"> Данные события. </param>
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            var property = String.Empty;
            var gameObjectOrderRemove = new List<GameObject>();

            for (var i = 0; i < gameObjects.Count; i++)
            {
                if (gameObjects[i] is Submarine)
                {
                    var sub = (Submarine)gameObjects[i];

                    var subDel = TrackingSubmarine(sub, e);

                    if(subDel)
                    {
                        gameObjectOrderRemove.Add(gameObjects[i]);
                    }

                    property += sub.ToString() +
                        "                                                     " +
                        "                                                     ";
                }

                if (gameObjects[i] is Rocket)
                {
                    var rocket = (Rocket)gameObjects[i];

                    rocket.Move(e.Time);

                    if (CheckingColliders(rocket))
                    {
                        gameObjectOrderRemove.Add(gameObjects[i]);
                    }
                }

                if (gameObjects[i] is BonusGenerator)
                {
                    var bonus = (BonusGenerator)gameObjects[i];

                    if (CheckingColliders(bonus))
                    {
                        gameObjectOrderRemove.Add(gameObjects[i]);
                    }
                }

                if (gameObjects[i] is Destroyer)
                {
                    var destroyer = (Destroyer)gameObjects[i];

                    destroyer.Move(e.Time);

                    DropingMine(destroyer, e);
                }

                if (gameObjects[i] is Mina)
                {
                    var mina = (Mina)gameObjects[i];

                    mina.Move(e.Time);

                    if (CheckingColliders(mina))
                    {                       
                        gameObjectOrderRemove.Add(gameObjects[i]);
                        activeMina = false;
                    }
                }
            }

            foreach (GameObject go in gameObjectOrderRemove)
            {
                gameObjects.Remove(go);
            }

            Title = property;
        }

        /// <summary>
        /// Контроль движения и уничтожения лодок.
        /// </summary>
        /// <param name="submarine"> Лодка. </param>
        /// <param name="e"> Данные события. </param>
        /// <returns> Логическое значение отвечающее, за удаление лодок. </returns>
        private bool TrackingSubmarine(Submarine submarine, FrameEventArgs e)
        {
            if (submarine.BasicType.Name.ToString() == nameof(BlueSubmarine))
            {
                ControllingBluePlayer(e, submarine);
            }
            else if (submarine.BasicType.Name.ToString() == nameof(RedSubmarine))
            {
                ControllingRedPlayer(e, submarine);
            }

            if (submarine.Health <= 0)
            {
                GameWin(submarine.BasicType);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Сброс мины.
        /// </summary>
        /// <param name="destroyer"> Миноносец. </param>
        /// <param name="e"> Данные собятия. </param>
        private void DropingMine(Destroyer destroyer, FrameEventArgs e)
        {        
            var rn = new Random();
            var subId = SearchSubmarineId(rn.Next(1, 3));

            if (subId != -1 && !activeMina)
            {
                if (destroyer.Transform.Position.X <= gameObjects[subId].Transform.Position.X)
                {
                    CreateMina(destroyer.Transform);
                    activeMina = true;
                }
            }
        }

        /// <summary>
        /// Поиск айди лодки в коллекции.
        /// </summary>
        /// <param name="numberOject"> Номер лодки, которую нужно найти. </param>
        /// <returns> Айди лодки. </returns>
        private int SearchSubmarineId(int numberOject)
        {
            for (var i = 0; i < gameObjects.Count; i++)
            {
                if (gameObjects[i] is Submarine)
                {
                    var sub = (Submarine)gameObjects[i];

                    if (sub.BasicType.Name.ToString() == nameof(BlueSubmarine) && numberOject == 1)
                    {
                        return i;
                    }
                    if (sub.BasicType.Name.ToString() == nameof(RedSubmarine) && numberOject == 2)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        /// <summary>
        /// Управление синего игрока.
        /// </summary>
        /// <param name="e"> Данные собятия. </param>
        /// <param name="submarine"> Лодка. </param>
        private void ControllingBluePlayer(FrameEventArgs e, Submarine submarine)
        {
            KeyboardState kb = Keyboard.GetState();

            var scaleX = submarine.Transform.Scale.X < 0 ? submarine.Transform.Scale.X * -1 : submarine.Transform.Scale.X;
            var scaleY = submarine.Transform.Scale.Y;

            Vector2 oldPosition = submarine.Transform.Position;

            if (kb.IsKeyDown(Key.Number1))
            {
                blueRocketType = RocketType.FieryRocket;
            }

            if (kb.IsKeyDown(Key.Number2))
            {
                blueRocketType = RocketType.IceRocket;
            }

            if (kb.IsKeyDown(Key.Number3))
            {
                blueRocketType = RocketType.AtomicRocket;
            }

            if (kb.IsKeyDown(Key.Space) && activeRocket_1 && submarine.Ammunition.GetRockets(blueRocketType) > 0)
            {
                var colldown = CreateRocket(submarine.Transform, submarine.BasicType, blueRocketType);               
                blueSubmarineCooldown.Start(colldown, ActivateCooldown_1);
                submarine.Shoot(blueRocketType);
                activeRocket_1 = false;
            }

            if (kb.IsKeyDown(Key.W) ^ kb.IsKeyDown(Key.S))
            {
                if (kb.IsKeyDown(Key.W))
                {
                    submarine.Move(Direction.Up, e.Time);
                }
                else
                {
                    submarine.Move(Direction.Down, e.Time);
                }

                if (CheckingColliders(submarine))
                {
                    submarine.Transform.Position = oldPosition;
                }
            }

            if (kb.IsKeyDown(Key.A) ^ kb.IsKeyDown(Key.D))
            {
                if (kb.IsKeyDown(Key.A))
                {
                    submarine.Transform.Scale = new Vector2(-scaleX, scaleY);
                    submarine.Move(Direction.Left, e.Time);
                }
                else
                {
                    submarine.Transform.Scale = new Vector2(scaleX, scaleY);
                    submarine.Move(Direction.Right, e.Time);
                }

                if (CheckingColliders(submarine))
                {
                    submarine.Transform.Position = oldPosition;
                }
            }   
        }

        /// <summary>
        /// Управление красного игрока.
        /// </summary>
        /// <param name="e"> Данные события. </param>
        /// <param name="submarine"> Лодка.</param>
        private void ControllingRedPlayer(FrameEventArgs e, Submarine submarine)
        {
            KeyboardState kb = Keyboard.GetState();           

            var scaleX = submarine.Transform.Scale.X < 0 ? submarine.Transform.Scale.X * -1 : submarine.Transform.Scale.X;
            var scaleY = submarine.Transform.Scale.Y;

            Vector2 oldPosition = submarine.Transform.Position;

            if (kb.IsKeyDown(Key.Keypad1))
            {
                redRocketType = RocketType.FieryRocket;
            }

            if (kb.IsKeyDown(Key.Keypad2))
            {
                redRocketType = RocketType.IceRocket;
            }

            if (kb.IsKeyDown(Key.Keypad3))
            {
                redRocketType = RocketType.AtomicRocket;
            }

            if (kb.IsKeyDown(Key.KeypadEnter) && activeRocket_2 && submarine.Ammunition.GetRockets(redRocketType) > 0)
            {
                var colldown = CreateRocket(submarine.Transform, submarine.BasicType, redRocketType);              
                redSubmarineCooldown.Start(colldown, ActivateCooldown_2);
                submarine.Shoot(redRocketType);
                activeRocket_2 = false;
            }          

            if (kb.IsKeyDown(Key.Up) ^ kb.IsKeyDown(Key.Down))
            {
                if (kb.IsKeyDown(Key.Up))
                {
                    submarine.Move(Direction.Up, e.Time);
                }
                else
                {
                    submarine.Move(Direction.Down, e.Time);
                }

                if (CheckingColliders(submarine))
                {
                    submarine.Transform.Position = oldPosition;
                }
            }

            if (kb.IsKeyDown(Key.Left) ^ kb.IsKeyDown(Key.Right))
            {
                if (kb.IsKeyDown(Key.Left))
                {
                    submarine.Transform.Scale = new Vector2(-scaleX, scaleY);
                    submarine.Move(Direction.Left, e.Time);
                }
                else
                {
                    submarine.Transform.Scale = new Vector2(scaleX, scaleY);
                    submarine.Move(Direction.Right, e.Time);
                }

                if (CheckingColliders(submarine))
                {
                    submarine.Transform.Position = oldPosition;
                }
            }   
        }
    }
}
