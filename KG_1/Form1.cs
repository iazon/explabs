using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace KG_1
{
    public partial class Form1 : Form
    {
        Graphics gr;       //объявляем объект - графику, на которой будем рисовать
        Pen p;             //объявляем объект - карандаш, которым будем рисовать контур
        SolidBrush fon;    //объявляем объект - заливки, для заливки соответственно фона
        SolidBrush fig;    //и внутренности рисуемой фигуры

        int count = 100;   //количество фигур
        int size_figure;   //размер фигур
        Random rand;       //объект, для получения случайных чисел
        int glob_x, glob_y;//координаты фигуры

        public Form1()
        {
            InitializeComponent();
        }

        //опишем функцию для рисования фигуры по заданию (квадрат с диагоналями)
        void Draw_My_Figure(int x, int y)
        {
            p = new Pen(Color.Lime);           // задали цвет для карандаша 
            int xc, yc;
            xc = x - size_figure;
            yc = y - size_figure;
            gr.DrawRectangle(p, xc, yc, size_figure, size_figure);
            gr.DrawLine(p, xc, yc, xc + size_figure, yc + size_figure);
            gr.DrawLine(p, xc + size_figure, yc, xc, yc + size_figure);
        }

        void Up_left ()
        {
            --glob_x;
            --glob_y;
            if (glob_x == 0)
            {
                Up_right();
            }
            else if (glob_y == 0)
            {

            }
        }

        void Up_right()
        {

        }

        void Down_left()
        {

        }

        void Down_right()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            gr = pictureBox1.CreateGraphics();  //инициализируем объект типа графики привязав к PictureBox

            fon = new SolidBrush(Color.Black); // и для заливки
            fig = new SolidBrush(Color.Purple);

            size_figure = 30;                          //задали радиус для круга
            rand = new Random();               //инициализируем объект для рандомных числе

            gr.FillRectangle(fon, 0, 0, pictureBox1.Width, pictureBox1.Height); // закрасим черным 
            // нашу область рисования

            // вызываем написанную нами функцию, для прорисовки круга
            // случайным образом выбрав перед этим координаты центра

            for (int i = 0; i < count; i++)
            {
                glob_x = rand.Next(pictureBox1.Width);
                glob_y = rand.Next(pictureBox1.Height);
                Draw_My_Figure(glob_x, glob_y);
            }

            timer1.Enabled = true;  //включим в работу наш таймер,
            // то есть теперь будет происходить событие Tick и его будет обрабатывать функция On_Tick (по умолчанию)

        }

        // для получения данной функции перейдите к конструктору формы 
        // и сделайте двойной щелчок по таймеру, добавленному на форму. См. на фото после кода
        private void timer1_Tick_1(object sender, EventArgs e)
        {

            //сначала будем очищать область рисования цветом фона
            gr.FillRectangle(fon, 0, 0, pictureBox1.Width, pictureBox1.Height);


            // затем опять случайным образом выбираем координаты центров кругов
            // и рисуем их при помощи описанной нами функции
            int x, y;

            for (int i = 0; i < count; i++)
            {
                x = rand.Next(pictureBox1.Width);
                y = rand.Next(pictureBox1.Height);
                Draw_My_Figure(x, y);
            }
        }
    }
}
