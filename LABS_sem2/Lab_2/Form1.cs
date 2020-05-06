using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_2
{
    public partial class Form1 : Form
    {
        int counter = 0;
        int i = 0;
        Timer Timer1 = new Timer();
        public Form1()
        {
            InitializeComponent();
            this.MouseMove += Button_Move;
            this.button1.MouseEnter += Button_OK_MouseEnter;
            this.button1.TabStop = false;
            Text = " ";
            if (Timer1.Enabled)
            {
                Timer1.Enabled = false;
            }
            else
            {
                Timer1.Interval = 1000;
                Timer1.Tick += new EventHandler(Timer1_Tick);
                Timer1.Start();
            }

        }

        

        private void Timer1_Tick(object sender, EventArgs e)
        {
            i++;
            
            if (this.Text == " ")
            {
                this.Text = "Натисніть кнопку “ОK”!!!";
            }
            else if (this.Text == "Натисніть кнопку “ОK”!!!")
            {
                this.Text = " ";
            }
            if (i == 15)
            {
                Timer1.Stop();
            }
        }


        private void Button_Move(object sender, MouseEventArgs e)
        {
            if (button1.Size.Width < 1 || button1.Size.Height < 1)
            {
                this.Text = "Кнопка “Ок” не може бути натиснута";
            }
                

            int step_distance = 2;
            int field_distance_from_the_button = 30;
            int button_width = 100;
            int button_height = 50;
            int cursor_position_x = e.X;
            int cursor_position_y = e.Y;
            int button_position_x = button1.Location.X;
            int button_position_y = button1.Location.Y;
            bool move = false;

            if (cursor_position_x > button_position_x - field_distance_from_the_button && cursor_position_y > button_position_y - field_distance_from_the_button && cursor_position_x < button_position_x && cursor_position_y < button_position_y)
            {
                button1.Location = new Point(button_position_x + step_distance, button_position_y + step_distance);
                move = true;
                counter++;
            }//field left top (move down and right)
            else if (cursor_position_x < button_position_x + button_width && cursor_position_y > button_position_y - field_distance_from_the_button && cursor_position_x > button_position_x && cursor_position_y < button_position_y)
            {
                button1.Location = new Point(button_position_x, button_position_y + step_distance);
                move = true;
                counter++;
            }//field top (move down)
            else if(cursor_position_x < button_position_x + button_width + field_distance_from_the_button && cursor_position_y > button_position_y - field_distance_from_the_button && cursor_position_x > button_position_x + button_width && cursor_position_y < button_position_y)
            {
                button1.Location = new Point(button_position_x - step_distance, button_position_y + step_distance);
                move = true;
                counter++;
            }//field right top (move down and left)
            else if (cursor_position_x > button_position_x - field_distance_from_the_button && cursor_position_y < button_position_y + button_height && cursor_position_x < button_position_x && cursor_position_y > button_position_y)
            {
                button1.Location = new Point(button_position_x + step_distance, button_position_y);
                move = true;
                counter++;
            }//field left (move right)
            else if (cursor_position_x < button_position_x + button_width + field_distance_from_the_button && cursor_position_y < button_position_y + button_height && cursor_position_x > button_position_x + button_width && cursor_position_y > button_position_y)
            {
                button1.Location = new Point(button_position_x - step_distance, button_position_y);
                move = true;
                counter++;
            }//field right (move left)
            else if (cursor_position_x > button_position_x - field_distance_from_the_button && cursor_position_y < button_position_y + button_height + field_distance_from_the_button && cursor_position_x < button_position_x && cursor_position_y > button_position_y + button_height)
            {
                button1.Location = new Point(button_position_x + step_distance, button_position_y - step_distance);
                move = true;
                counter++;
            }//field left bottom (move right and up)
            else if (cursor_position_x < button_position_x + button_width && cursor_position_y < button_position_y + button_height + field_distance_from_the_button && cursor_position_x > button_position_x && cursor_position_y > button_position_y + button_height)
            {
                button1.Location = new Point(button_position_x, button_position_y - step_distance);
                move = true;
                counter++;
            }//field bottom (move up)
            else if (cursor_position_x < button_position_x + button_width + field_distance_from_the_button && cursor_position_y < button_position_y + button_height + field_distance_from_the_button && cursor_position_x > button_position_x + button_width && cursor_position_y > button_position_y + button_height)
            {
                button1.Location = new Point(button_position_x - step_distance, button_position_y - step_distance);
                move = true;
                counter++;
            }//field right bottom (move left and up)





            field_distance_from_the_button = 150;
            if (button_position_x + button_width > this.Size.Width)
            {
                button_position_x -= field_distance_from_the_button;
                button1.Location = new Point(button_position_x, button_position_y);
            }
            else if (button_position_y + button_height > this.Size.Height)
            {
                button_position_y -= field_distance_from_the_button;
                button1.Location = new Point(button_position_x, button_position_y);
            }
            else if (button_position_x < 0)
            {
                button_position_x += field_distance_from_the_button;
                button1.Location = new Point(button_position_x, button_position_y);
            }
            else if (button_position_y < 0)
            {
                button_position_y += field_distance_from_the_button;
                button1.Location = new Point(button_position_x, button_position_y);
            }



            if (move && counter % 20 == 0)
            {
                this.button1.Size = new Size(button1.Width, --button1.Height);
            }

        }

        private void Button_OK_MouseEnter(object sender, EventArgs e)
        {
            Random rand = new Random();
            int x = this.button1.Location.X;
            int y = this.button1.Location.Y;
            int delta = rand.Next(50, 100);
            x = (x < this.Size.Width / 2 ? x -= delta : x += delta);
            y = (y < this.Size.Height / 2 ? y -= delta : y += delta);

            button1.Location = new Point(x, y);
        }


        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
