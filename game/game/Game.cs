using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace game
{
    class Game
    {
        private static BufferedGraphicsContext context;
        public static BufferedGraphics Buffer;
        public static int Width { get; set; }
        public static int Height { get; set; }

        static Game()
        {

        }
        public static void Init(Form form)
        {
            Graphics g;
            context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            Buffer = context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
            Load();
        }


        private static void Timer_Tick(object sender, EventArgs e)
        {
        Draw();
        Update();
        }


        
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            Buffer.Render();

            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in objs)
                obj.Draw();
           


        }
        public static void Update()
        {
            foreach (BaseObject obj in objs)
            {
                obj.Update();
            }
           
           
        }
        public static BaseObject[] objs;

        public static void Load()
        {


            objs = new BaseObject[30];
            for (int i = 0; i < objs.Length / 2; i++)
                objs[i] = new BaseObject(new Point(600, i * 20), new Point(-i, -i), new Size(10, 10));
            for (int i = objs.Length/2; i < objs.Length; i++)
                objs[i] = new Star(new Point(600, i * 20), new Point(-i, 0), new Size(5, 5));






        }
    }
}
