using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Practic
{
    public abstract class GraphDrawer
    {
        protected Canvas canvas;

        public GraphDrawer(Canvas canvas)
        {
            this.canvas = canvas;
        }

        public abstract void DrawGraph();
    }

    public class RandomGraphDrawer : GraphDrawer
    {
        public RandomGraphDrawer(Canvas canvas) : base(canvas)
        {
            canvas.Children.Clear(); // Очищаем холст
        }

        public override void DrawGraph()
        {
            // Логика для отрисовки графика с использованием случайных данных

            Random rnd = new Random(); // Создаем генератор случайных чисел
            int prevValue = 0; // Значение показателя на предыдущем месяце

            for (int i = 1; i <= 12; i++)
            {
                if (i == 3 || i == 4 || i == 5) // Пропускаем зимние месяцы
                {
                    continue;
                }

                int value = prevValue + rnd.Next(1, 10); // Генерируем случайное значение показателя роста

                // Создаем линию-график, отображающую показатели роста
                Line line = new Line();
                line.X1 = (i - 1) * 37; // Задаем начальные координаты линии
                line.Y1 = 420 - prevValue * 5;

                line.X2 = i * 37; // Задаем конечные координаты линии
                line.Y2 = 420 - value * 5;

                line.Stroke = Brushes.Blue; // Задаем цвет линии
                line.StrokeThickness = 2;

                canvas.Children.Add(line); // Добавляем линию на холст

                prevValue = value; // Сохраняем текущее значение показателя для следующего месяца
            }
        }
    }

    public class UserInputGraphDrawer : GraphDrawer
    {
        private string[] textBoxes = new string[9];

        public UserInputGraphDrawer(Canvas canvas, string[] textBoxes) : base(canvas)
        { 
            this.textBoxes = textBoxes;
            canvas.Children.Clear(); // Очищаем холст
        }

        public override void DrawGraph()
        {
            // Логика для отрисовки графика с использованием данных, введенных пользователем

            int prevValue = 0; // Значение показателя на предыдущем месяце

            try
            {
                for (int i = 1; i <= 12; i++)
                {
                    if (i == 3 || i == 4 || i == 5) // Пропускаем зимние месяцы
                    {
                        continue;
                    }

                    int num = 0;

                    switch (i)
                    {
                        case 1:
                            num = Convert.ToInt32(textBoxes[0]);
                            break;
                        case 2:
                            num = Convert.ToInt32(textBoxes[1]);
                            break;
                        case 6:
                            num = Convert.ToInt32(textBoxes[2]);
                            break;
                        case 7:
                            num = Convert.ToInt32(textBoxes[3]);
                            break;
                        case 8:
                            num = Convert.ToInt32(textBoxes[4]);
                            break;
                        case 9:
                            num = Convert.ToInt32(textBoxes[5]);
                            break;
                        case 10:
                            num = Convert.ToInt32(textBoxes[6]);
                            break;
                        case 11:
                            num = Convert.ToInt32(textBoxes[7]);
                            break;
                        case 12:
                            num = Convert.ToInt32(textBoxes[8]);
                            break;
                        default:
                            MessageBox.Show("Введите правильные значения.");
                            break;
                    }

                    int value = prevValue + num;


                    // Создаем линию-график, отображающую показатели роста
                    Line line = new Line();
                    line.X1 = (i - 1) * 37; // Задаем начальные координаты линии
                    line.Y1 = 420 - prevValue * 5;

                    line.X2 = i * 37; // Задаем конечные координаты линии
                    line.Y2 = 420 - value * 5;

                    line.Stroke = Brushes.Red; // Задаем цвет линии
                    line.StrokeThickness = 2;

                    canvas.Children.Add(line); // Добавляем линию на холст

                    prevValue = value; // Сохраняем текущее значение показателя для следующего месяца
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
