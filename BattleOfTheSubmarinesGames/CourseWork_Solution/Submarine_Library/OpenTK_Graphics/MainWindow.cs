using System;
using System.Drawing;
using System.Collections.Generic;
using Submarine_Library.GameObjectComponent;
using Submarine_Library.Submarines;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Windows.Forms;

namespace Submarine_Library.OpenTK_Graphics
{
    public class MainWindow : GameWindow
    {
        List<GameObject> gameObjects;
        Dictionary<GameObject, Texture2D> textures;


        

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
            textures = new Dictionary<GameObject, Texture2D>();

            LoadingGameObjects();
        }

        /// <summary>
        /// Загрузка игровых объектов.
        /// </summary>
        private void LoadingGameObjects()
        {
            //int submarieSize = 1;

            // Первая лодка.
            var firstSubmarine = new Submarine(3);
            firstSubmarine.Transform.Position = new Vector2(-300.0f, 0);
            //firstSubmarine.Transform.Scale = new Vector2(Width / submarieSize, Height / submarieSize);
            var firstSubmarineTexture = TextureProcessing.LoadTexture2D("secondSubmarine.png");
            textures.Add(firstSubmarine, firstSubmarineTexture);
            gameObjects.Add(firstSubmarine);

            firstSubmarine.Components.Add(new BoxCollider(textures[firstSubmarine].Width, textures[firstSubmarine].Height));          

            // Вторая  лодка.
            var secondSubmarine = new Submarine(3);
            //secondSubmarine.Transform.Scale = new Vector2(Width / submarieSize, Height / submarieSize);
            secondSubmarine.Transform.Position = new Vector2(300.0f, 0);
            var secondSubmarineTexture = TextureProcessing.LoadTexture2D("secondSubmarine.png");
            textures.Add(secondSubmarine, secondSubmarineTexture);
            gameObjects.Add(secondSubmarine);

            secondSubmarine.Components.Add(new BoxCollider(textures[secondSubmarine].Width, textures[secondSubmarine].Height));
        }

        private bool CheckingColliders(GameObject gameObject)
        {
            if (gameObject.GetComponent<Collider>() == null)
            {
                throw new Exception("gameObject has no collider!");
            }

            foreach (GameObject go in gameObjects)
            {
                if (!go.Equals(gameObject))
                {
                    if (go.GetComponent<Collider>() != null)
                    {
                        if (Collider.CheckCollision(go, gameObject))
                        {
                            return true;
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
            GL.ClearColor(Color.FromArgb(54, 54, 38));
            SpriteRendering.Begin(this.Width, this.Height);
        }


         
        /// <summary>
        /// Покадровая отрисовка.
        /// </summary>
        /// <param name="e"> Данные события. </param>
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            base.OnRenderFrame(e);

            foreach (GameObject gameObject in gameObjects)
            {
                SpriteRendering.Draw(textures[gameObject], gameObject.Transform);
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
        }

        /// <summary>
        /// Управление первого игрока.
        /// </summary>
        /// <param name="e"></param>
        private void ControllingFirstPlayer(FrameEventArgs e)
        {
            KeyboardState kb = Keyboard.GetState();

            var firstSubmarine = (Submarine)gameObjects[0];

            var scaleX = firstSubmarine.Transform.Scale.X < 0 ? firstSubmarine.Transform.Scale.X * -1 : firstSubmarine.Transform.Scale.X;
            var scaleY = firstSubmarine.Transform.Scale.Y;

            Vector2 oldPosition = firstSubmarine.Transform.Position;

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

                if (CheckingColliders(firstSubmarine))
                {
                    firstSubmarine.Transform.Position = oldPosition;
                }
            }

            if (kb.IsKeyDown(Key.A) ^ kb.IsKeyDown(Key.D))
            {
                if (kb.IsKeyDown(Key.A))
                {
                    //firstSubmarine.Transform.Scale = new Vector2(-scaleX, scaleY);
                    firstSubmarine.Move(Direction.Left, e.Time * firstSubmarine.Speed);
                }
                else
                {
                    //firstSubmarine.Transform.Scale = new Vector2(scaleX, scaleY);
                    firstSubmarine.Move(Direction.Right, e.Time * firstSubmarine.Speed);
                }

                if (CheckingColliders(firstSubmarine))
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

            var secondSubmarine = (Submarine)gameObjects[1];

            var scaleX = secondSubmarine.Transform.Scale.X < 0 ? secondSubmarine.Transform.Scale.X * -1 : secondSubmarine.Transform.Scale.X;
            var scaleY = secondSubmarine.Transform.Scale.Y;

            Vector2 oldPosition = secondSubmarine.Transform.Position;

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

                if (CheckingColliders(secondSubmarine))
                {
                    secondSubmarine.Transform.Position = oldPosition;
                }
            }

            if (kb.IsKeyDown(Key.Left) ^ kb.IsKeyDown(Key.Right))
            {
                if (kb.IsKeyDown(Key.Left))
                {
                    //secondSubmarine.Transform.Scale = new Vector2(-scaleX, scaleY);
                    secondSubmarine.Move(Direction.Left, e.Time * secondSubmarine.Speed);
                }
                else
                {
                    //secondSubmarine.Transform.Scale = new Vector2(scaleX, scaleY);
                    secondSubmarine.Move(Direction.Right, e.Time * secondSubmarine.Speed);
                }

                if (CheckingColliders(secondSubmarine))
                {
                    secondSubmarine.Transform.Position = oldPosition;
                }
            }   
        }
    }
}
