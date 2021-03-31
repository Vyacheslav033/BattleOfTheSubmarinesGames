using System;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using OpenTK.Input;

namespace BattleOfTheSubmarinesGames
{
    /// <summary>
    /// Окно игрового приложения, сцена.
    /// </summary>
    public partial class MainWindow : GameWindow
    {
        private Background background;
        private Submarine firstSubmarine;
        private Submarine secondSubmarine;
        private Matrix4 ortho;

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
                // Настроить изменение размера подводных лодок с изменениями размерами окна !!!
                background = new Background(Width, Height, @"D:\CourseWorkRepos\BattleOfTheSubmarinesGames\CourseWork_Solution\SpritesAndTextures\seaFloor.jpg");
                firstSubmarine = new Submarine(Width / 10, Height / 10, Vector2.Zero, @"D:\CourseWorkRepos\BattleOfTheSubmarinesGames\CourseWork_Solution\SpritesAndTextures\firstSubmarine.png");
                secondSubmarine = new Submarine(Width / 10, Height / 10, Vector2.Zero, @"D:\CourseWorkRepos\BattleOfTheSubmarinesGames\CourseWork_Solution\SpritesAndTextures\secondSubmarine.png");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Exit();
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
        }

        /// <summary>
        /// Управление лодкой.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnUpdateFrame(FrameEventArgs e)
        {      
            
            base.OnUpdateFrame(e);
            KeyboardState kb = Keyboard.GetState();
            int speed = 4;

            // Пересмотреть реализацию управленния.
            if (kb.IsKeyDown(Key.Escape))
            {
                Exit();
            }

            // Добавит корень из 2!!
            // Первая лодка.
            if (kb.IsKeyDown(Key.W))
            {
                firstSubmarine.Move(new Vector2(0, -1) * speed);
            }
                
            if (kb.IsKeyDown(Key.S))
            {
                firstSubmarine.Move(new Vector2(0, 1) * speed);
            }
                
            if (kb.IsKeyDown(Key.A))
            {
                firstSubmarine.Move(new Vector2(-1, 0) * speed);
            }
                
            if (kb.IsKeyDown(Key.D))
            {
                firstSubmarine.Move(new Vector2(1, 0) * speed);
            }

            // Вторая лодка.
            if (kb.IsKeyDown(Key.Up))
            {
                secondSubmarine.Move(new Vector2(0, -1) * speed);
            }

            if (kb.IsKeyDown(Key.Down))
            {
                secondSubmarine.Move(new Vector2(0, 1) * speed);
            }

            if (kb.IsKeyDown(Key.Left))
            {
                secondSubmarine.Move(new Vector2(-1, 0) * speed);
            }

            if (kb.IsKeyDown(Key.Right))
            {
                secondSubmarine.Move(new Vector2(1, 0) * speed);
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(Color4.Aqua);

            background.Draw();
            firstSubmarine.Draw();
            secondSubmarine.Draw();

            //GL.LoadIdentity();
            SwapBuffers();
        }
    }
}
