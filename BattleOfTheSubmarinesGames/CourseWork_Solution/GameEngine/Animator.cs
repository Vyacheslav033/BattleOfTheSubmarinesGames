using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using OpenTK.Graphics.OpenGL;


namespace GameEngine
{
    public class Animator : GameComponents
    {
        public int Id { get;  }
        public int Width { get; }
        public int Height { get; }
        public int SpriteWidth { get; }
        public int SpriteHeight { get; }
        public int Columns { get; }
        public int Rows { get; }
        public int BufferId { get; private set; }
        public float[] Coordinates { get; private set; }

        private bool mipMap;
        private double frameTimer = 0.0;
        private double time = 0.0;
        private int framesCount = 1;
        private int currentFrame = 0;

        public Animator(string path)
        {
            bool mip = true;
            int columns = 1;
            int rows = 1;
            TextureWrapMode wrapMode = TextureWrapMode.ClampToEdge;
            TextureMinFilter minFilter = TextureMinFilter.Linear;
            TextureMagFilter magFilter = TextureMagFilter.Linear;


            if (!File.Exists("Sprites/" + path))
            {
                throw new ArgumentException($"Файл не найден, проверьте путь {path}");
            }
            mipMap = mip;

            if (mipMap)
            {
                minFilter = TextureMinFilter.LinearMipmapLinear;
            }


            Bitmap bmp = new Bitmap(1, 1);
            bmp = (Bitmap)Image.FromFile(path);
            bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
            //bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);
        

            Width = bmp.Width;
            Height = bmp.Height;
            Columns = columns;
            Rows = rows;
            framesCount = Columns * Rows;
            SpriteWidth = Width / Columns;
            SpriteHeight = Height / Rows;

            BitmapData data = bmp.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Id = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, Id);

            // Привязка координат к границе текстуры. 
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.ClampToEdge);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.ClampToEdge);

            // Фильтрация текстур.
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMinFilter.Linear);


            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

            if(mipMap)
            {
                GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
            }

            GL.BindTexture(TextureTarget.Texture2D, 0);
            bmp.UnlockBits(data);

            Coordinates = new[]
            {
                0f,             1f,                 // left up
                1f / Columns,   1f,                 // righr up
                1f / Columns ,  1 - 1.0f / Rows,    // left down
                0f,             1 - 1.0f / Rows     // right down
            };

            BufferId = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, BufferId);
            GL.BufferData(BufferTarget.ArrayBuffer, Coordinates.Length * sizeof(float), Coordinates, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

        }

        public void Update(double time)
        {
            time = time;
        }

       
        private void UpdateCoordinates(int curent_frame)
        {
            int rowNumber = (int)Math.Truncate((double)curent_frame) / Columns;
            int colNumber = curent_frame - (rowNumber * Columns);
            float stepW = 1.0f / Columns;
            float stepH = 1.0f / Rows;

            Coordinates = new[]
            {
                stepW * colNumber,              1f - (rowNumber * stepH),                   // left up
                stepW * colNumber + stepW,      1f - (rowNumber * stepH),                   // righr up
                stepW * colNumber + stepW,      1f - ( (rowNumber + 1) * stepH),            // left down
                stepW * colNumber,              1f - ( (rowNumber + 1) * stepH)             // right down
            };

            GL.BindBuffer(BufferTarget.ArrayBuffer, BufferId);
            GL.BufferData(BufferTarget.ArrayBuffer, Coordinates.Length * sizeof(float), Coordinates, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        /// <summary>
        /// Привязка текстуры.
        /// </summary>
        public void Bind()
        {
            double timeForFrame = 0;

            if (timeForFrame > 0 && framesCount > 1)
            {
                frameTimer += time;

                if (frameTimer > timeForFrame)
                {
                    UpdateCoordinates(currentFrame);

                    currentFrame++;

                    if (currentFrame > framesCount)
                    {
                        currentFrame = 0;
                    }

                    frameTimer = 0;

                }
            }


            GL.BindTexture(TextureTarget.Texture2D, Id);
            GL.BindBuffer(BufferTarget.ArrayBuffer, BufferId);
            GL.TexCoordPointer(2, TexCoordPointerType.Float, 0, IntPtr.Zero);
        }

        /// <summary>
        /// Отвязка текстуры.
        /// </summary>
        public void Unbind()
        {
            GL.BindTexture(TextureTarget.Texture2D, 0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        /// <summary>
        /// Очистка памяти.
        /// </summary>
        public void Dispose()
        {
            GL.DeleteBuffer(BufferId);
            GL.DeleteTexture(Id);
        }

    }
}
