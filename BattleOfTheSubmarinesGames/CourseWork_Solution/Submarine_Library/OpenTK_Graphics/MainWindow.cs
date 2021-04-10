using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using OpenTK.Input;
using System.Drawing;
using System.Timers;
using System.Collections.Generic;
using Timer = System.Timers.Timer;
using System.Windows.Forms;

namespace Submarine_Library.OpenTK_Graphics
{
    /// <summary>
    /// Окно игрового приложения, сцена.
    /// </summary>
    public partial class MainWindow : GameWindow
    {
        private Background background;
        private GameObject firstSubmarine;
        List<GameObject> torpedoList = new List<GameObject>();
        //private GameObject torpedoGraphics;
        private Matrix4 ortho;

        //private Timer aTimer;

        //private TextRenderer textRenderer;
        bool  activeTorpedo = false;

        /// <summary>
        /// Конструктор окна.
        /// </summary>
        /// <param name="width"> Ширина окна. </param>
        /// <param name="height"> Высота окна. </param>
        public MainWindow(int width, int height)
        {
            if (width < 800)
            {
                throw new ArgumentException($"Ширина окна - {width} недопустима.", nameof(width));
            }

            if (height < 600)
            {
                throw new ArgumentException($"Высота окна - {height} недопустима.", nameof(height));
            }

            Width = width;
            Height = height;
            Title = "BattleOfTheSubmarines";

            GL.Enable(EnableCap.PointSmooth);
            GL.Enable(EnableCap.LineSmooth);
            GL.Enable(EnableCap.PolygonSmooth);
            GL.Enable(EnableCap.Multisample);
            // Активировать прозрачный фон текстур.
            GL.Enable(EnableCap.Blend);
            //GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.AlphaTest);
            GL.Enable(EnableCap.CullFace);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            GL.FrontFace(FrontFaceDirection.Cw);
            GL.CullFace(CullFaceMode.Back);

            try
            {
                background = new Background(Width, Height, @"SpritesAndTextures\seaFloor2.jpg");
                firstSubmarine = new Submarine(Width / 10, Height / 10, Vector2.Zero, @"SpritesAndTextures\submarine1.png");
                torpedoList.Add(new TorpedoGraphics(Width / 12, Height / 20, Vector2.Zero, @"SpritesAndTextures\fieryTorpedo1.png"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Exit();
            }     
        }

        public void Timerr()
        {
            //aTimer = new System.Timers.Timer
            //{
            //    Interval = 2000
            //};

            //// Hook up the Elapsed event for the timer. 
            //aTimer.Elapsed += OnTimedEvent;

            //// Have the timer fire repeated events (true is the default)
            //aTimer.AutoReset = true;

            //// Start the timer
            //aTimer.Enabled = true;
        }


        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (activeTorpedo)
            {
                activeTorpedo = false;
            }
            else
            {
                activeTorpedo = true;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Width, Height);
            ortho = Matrix4.CreateOrthographicOffCenter(0, Width, Height, 0, -1, 1);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref ortho);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            background.Resize(Width, Height);
            firstSubmarine.Resize(Width / 10, Height / 10);
        }

        /// <summary>
        /// Покадровое считывание действий объектов сцены.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnUpdateFrame(FrameEventArgs e)
        {      
            base.OnUpdateFrame(e);
            KeyboardState kb = Keyboard.GetState();
            int submarineSpeed = 4;
            int torpedosSpeed = 8;

            if (activeTorpedo)
            {
                torpedoList[0].Move(new Vector2(1, 0) * torpedosSpeed);
            }

            // Активация ракеты.
            if (kb.IsKeyDown(Key.Enter) && !activeTorpedo)
            {
                if (activeTorpedo)
                {
                    activeTorpedo = false;                 
                }
                else
                {
                    torpedoList[0].Position = firstSubmarine.Position + new Vector2(30, 70);
                    activeTorpedo = true;
                }

            }



            // Пересмотреть реализацию управленния.
            if (kb.IsKeyDown(Key.Escape))
            {
                Exit();
            }
            
            
            // Добавит корень из 2!!






            if (kb.IsKeyDown(Key.W))
            {
                firstSubmarine.Move(new Vector2(0, -1) * submarineSpeed);
            }
                
            if (kb.IsKeyDown(Key.S))
            {
                firstSubmarine.Move(new Vector2(0, 1) * submarineSpeed);
            }
                
            if (kb.IsKeyDown(Key.A))
            {
                firstSubmarine.Move(new Vector2(-1, 0) * submarineSpeed);
            }
                
            if (kb.IsKeyDown(Key.D))
            {
                firstSubmarine.Move(new Vector2(1, 0) * submarineSpeed);
            }  
        }

        /// <summary>
        /// Покадровая отрисовка объектов сцены.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(Color4.Aqua);
            KeyboardState kb = Keyboard.GetState();

            background.Draw();
            firstSubmarine.Draw();
            
            if (activeTorpedo && torpedoList[0].Position.X < Width)
            {
                torpedoList[0].Draw();
            }
           

            //GL.LoadIdentity();
            SwapBuffers();
        }
    }
}
