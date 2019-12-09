using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var game = true;
            while (game)                                 //цикл игры
            {
                int number;  //отгадываемое число
                int min = 1; //мин граница
                int max = 100; //макс граница
                int tips = 0; //счетчик попыток

                MessageBox.Show("Загадайте число от 1 до 100", "Старт!");
                var rnd = new System.Random();

                var circle = true;
                while (circle)                            //цикл попыток
                {
                    number = rnd.Next(min, max);
                    tips++;
                    DialogResult result = MessageBox.Show("Загаданая цифра - " + number + "?", "Ответьте на вопрос:",
                MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        MessageBox.Show("Число угадано за " + tips + " попыток", "Окна сообщений");
                        circle = false;
                        DialogResult resMenu = MessageBox.Show("Начать игру заново?", "Сделайте выбор:", MessageBoxButtons.YesNo);
                        if (resMenu == DialogResult.No) game = false;

                    }
                    else if (result == DialogResult.No)
                    {
                        DialogResult result1 = MessageBox.Show("Загаданая цифра больше, чем " + number + "?", "Окна сообщений", MessageBoxButtons.YesNo);
                        if (result1 == DialogResult.No)       { max = --number; }
                        else if (result1 == DialogResult.Yes) { min = ++number; }

                        if (max < min)
                        {
                            MessageBox.Show("Неверный выбор границ", "Ошибка выбора", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            circle = false;
                        }
                    }
                }
            }
            Close();
        }
    }
}
