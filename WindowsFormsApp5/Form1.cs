using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (var g = Graphics.FromImage(pictureBox1.Image))
            {
                g.DrawRectangle(Pens.Black, 10, 10, 300, 300);
                g.DrawLine(Pens.Black, 10, 110, 310, 110);
                g.DrawLine(Pens.Black, 10, 210, 310, 210);
                g.DrawLine(Pens.Black, 110, 10, 110, 310);
                g.DrawLine(Pens.Black, 210, 10, 210, 310);
            }
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }
        Graphics battlefield;
        private bool isRestarted;
        bool[,] flagX = { { true, true, true },
                          { true, true, true }, 
                          { true, true, true } };
        bool[,] flagO = { { true, true, true },
                          { true, true, true },
                          { true, true, true } };
        int count = 0;
        int count2 = 0;
        int count3 = 0;
        bool mess;

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            battlefield = pictureBox1.CreateGraphics();
            if (comboBox1.SelectedIndex == 0 && comboBox2.SelectedIndex == 0)
            {
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                mess = true;
                bool flag2 = true;
                switch (count)
                {
                    case 0:
                        bool f = false;
                        CreateX1(battlefield, e, ref f);
                        RandomO(battlefield);
                        count++;
                        break;
                    case 1:
                        CreateX1(battlefield, e, ref flag2);
                        if (!flag2)
                        {
                            CreateO1(battlefield, e);
                            count++;
                        }
                        break;
                    case 2:
                        CreateX1(battlefield, e, ref flag2);
                        if (!flag2)
                        {
                            CreateO1(battlefield, e);
                            count++;
                        }
                        break;
                    case 3:
                        CreateX1(battlefield, e, ref flag2);
                        if (!flag2)
                        {
                            CreateO1(battlefield, e);
                            count++;
                        }
                        break;
                    case 4:
                        CreateX1(battlefield, e, ref flag2);
                        if (!flag2)
                        {
                            MessageBox.Show("Ничья!");
                            if (!isRestarted)
                            {
                                isRestarted = true;
                                Application.Restart();
                            }
                            count++;
                        }
                        break;
                    default:
                        break;
                }
            }
            else if (comboBox1.SelectedIndex == 0 && comboBox2.SelectedIndex == 1)
            {
                mess = false;
                bool fl = true;
                bool flag2 = true;
                switch (count2)
                {
                    case 1:
                        CreateO2(battlefield, e, ref fl);
                        if(!fl)
                        {
                            RandomX(battlefield);
                            count2++;
                        }
                        break;
                    case 2:
                        
                        CreateO2(battlefield, e, ref flag2);
                        if (!flag2)
                        {
                            CreateX2(battlefield, e);
                            count2++;
                        }
                        break;
                    case 3:
                        CreateO2(battlefield, e, ref flag2);
                        if (!flag2)
                        {
                            CreateX2(battlefield, e);
                            count2++;
                        }
                        break;
                    case 4:
                        CreateO2(battlefield, e, ref flag2);
                        if (!flag2)
                        {
                            CreateX2(battlefield, e);
                            count2++;
                            MessageBox.Show("Ничья!");
                            if (!isRestarted)
                            {
                                isRestarted = true;
                                Application.Restart();
                            }
                        }
                        break;
                    default:
                        break;
                }

            }
            else if (comboBox1.SelectedIndex == 1)
            {
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                bool flag_ = true;
                switch (count3)
                {
                    case 0:
                        PutX(battlefield, e, ref flag_);
                        break;
                    case 1:
                        PutO(battlefield, e, ref flag_);
                        break;
                    case 2:
                        PutX(battlefield, e, ref flag_);
                        break;
                    case 3:
                        PutO(battlefield, e, ref flag_);
                        break;
                    case 4:
                        PutX(battlefield, e, ref flag_);
                        break;
                    case 5:
                        PutO(battlefield, e, ref flag_);
                        break;
                    case 6:
                        PutX(battlefield, e, ref flag_);
                        break;
                    case 7:
                        PutO(battlefield, e, ref flag_);
                        break;
                    case 8:
                        PutX(battlefield, e, ref flag_);
                        if (count3 == 9)
                        {
                            MessageBox.Show("Ничья!");
                            if (!isRestarted)
                            {
                                isRestarted = true;
                                Application.Restart();
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void PutX(Graphics battlefield, MouseEventArgs e, ref bool flag_)
        {
            CreateX1(battlefield, e, ref flag_);
            if (!flag_)
            {
                count3++;
                flag_ = true;
            }
        }

        private void PutO(Graphics battlefield, MouseEventArgs e, ref bool flag_)
        {
            CreateO2(battlefield, e, ref flag_);
            if (!flag_)
            {
                count3++;
                flag_ = true;
            }
        }

        private void RandomO(Graphics battlefield)
        {
            if (isRestarted)
            {
                return;
            }
            int[] num = { 20, 120, 220 };
            Random rnd = new Random();
            bool flag = true;

            while (flag)
            {
                int index1 = rnd.Next(0, 3);
                int index2 = rnd.Next(0, 3);
                if (flagX[index2, index1] && flagO[index2, index1])
                {
                    battlefield.DrawEllipse(new Pen(Color.Black, 3), num[index1], num[index2], 80, 80);
                    flag = false;
                    flagO[index2, index1] = false;
                }
            }
            Res(battlefield);
        }

        private void RandomX(Graphics battlefield)
        {
            if (isRestarted)
            {
                return;
            }
            int[] num1 = { 20, 120, 220 };
            int[] num2 = { 100, 200, 300 };
            Random rnd = new Random();
            bool flag = true;

            while (flag)
            {
                int index1 = rnd.Next(0, 3);
                int index2 = rnd.Next(0, 3);
                if (flagX[index2, index1] && flagO[index2, index1])
                {
                    battlefield.DrawLine(new Pen(Color.Black, 3), num1[index1], num1[index2], num2[index1], num2[index2]);
                    battlefield.DrawLine(new Pen(Color.Black, 3), num1[index1], num2[index2], num2[index1], num1[index2]);
                    flag = false;
                    flagX[index2, index1] = false;
                }
            }
            Res(battlefield);
        }

        private void CreateX1(Graphics battlefield, MouseEventArgs e, ref bool flag2)
        {
            if (isRestarted)
            {
                return;
            }
            if (e.X > 10 && e.X < 110 && e.Y > 10 && e.Y < 110 && flagX[0, 0] && flagO[0, 0])
            {
                battlefield.DrawLine(new Pen(Color.Black, 3), 20, 20, 100, 100);
                battlefield.DrawLine(new Pen(Color.Black, 3), 20, 100, 100, 20);
                flagX[0, 0] = false;
                flag2 = false;
            }
            else if (e.X > 110 && e.X < 210 && e.Y > 10 && e.Y < 110 && flagX[0, 1] && flagO[0, 1])
            {
                battlefield.DrawLine(new Pen(Color.Black, 3), 120, 20, 200, 100);
                battlefield.DrawLine(new Pen(Color.Black, 3), 120, 100, 200, 20);
                flagX[0, 1] = false;
                flag2 = false;
            }
            else if (e.X > 210 && e.X < 310 && e.Y > 10 && e.Y < 110 && flagX[0, 2] && flagO[0, 2])
            {
                battlefield.DrawLine(new Pen(Color.Black, 3), 220, 20, 300, 100);
                battlefield.DrawLine(new Pen(Color.Black, 3), 220, 100, 300, 20);
                flagX[0, 2] = false;
                flag2 = false;
            }
            else if (e.X > 10 && e.X < 110 && e.Y > 110 && e.Y < 210 && flagX[1, 0] && flagO[1, 0])
            {
                battlefield.DrawLine(new Pen(Color.Black, 3), 20, 120, 100, 200);
                battlefield.DrawLine(new Pen(Color.Black, 3), 20, 200, 100, 120);
                flagX[1, 0] = false;
                flag2 = false;
            }
            else if (e.X > 110 && e.X < 210 && e.Y > 110 && e.Y < 210 && flagX[1, 1] && flagO[1, 1])
            {
                battlefield.DrawLine(new Pen(Color.Black, 3), 120, 120, 200, 200);
                battlefield.DrawLine(new Pen(Color.Black, 3), 120, 200, 200, 120);
                flagX[1, 1] = false;
                flag2 = false;
            }
            else if (e.X > 210 && e.X < 310 && e.Y > 110 && e.Y < 210 && flagX[1, 2] && flagO[1, 2])
            {
                battlefield.DrawLine(new Pen(Color.Black, 3), 220, 120, 300, 200);
                battlefield.DrawLine(new Pen(Color.Black, 3), 220, 200, 300, 120);
                flagX[1, 2] = false;
                flag2 = false;
            }
            else if (e.X > 10 && e.X < 110 && e.Y > 210 && e.Y < 310 && flagX[2, 0] && flagO[2, 0])
            {
                battlefield.DrawLine(new Pen(Color.Black, 3), 20, 220, 100, 300);
                battlefield.DrawLine(new Pen(Color.Black, 3), 20, 300, 100, 220);
                flagX[2, 0] = false;
                flag2 = false;
            }
            else if (e.X > 110 && e.X < 210 && e.Y > 210 && e.Y < 310 && flagX[2, 1] && flagO[2, 1])
            {
                battlefield.DrawLine(new Pen(Color.Black, 3), 120, 220, 200, 300);
                battlefield.DrawLine(new Pen(Color.Black, 3), 120, 300, 200, 220);
                flagX[2, 1] = false;
                flag2 = false;
            }
            else if (e.X > 210 && e.X < 310 && e.Y > 210 && e.Y < 310 && flagX[2, 2] && flagO[2, 2])
            {
                battlefield.DrawLine(new Pen(Color.Black, 3), 220, 220, 300, 300);
                battlefield.DrawLine(new Pen(Color.Black, 3), 220, 300, 300, 220);
                flagX[2, 2] = false;
                flag2 = false;
            }
            Res(battlefield);
        }

        private void CreateO2(Graphics battlefield, MouseEventArgs e, ref bool flag2)
        {
            if (isRestarted)
            {
                return;
            }
            if (e.X > 10 && e.X < 110 && e.Y > 10 && e.Y < 110 && flagX[0, 0] && flagO[0, 0])
            {
                battlefield.DrawEllipse(new Pen(Color.Black, 3), 20, 20, 80, 80);
                flagO[0, 0] = false;
                flag2 = false;
            }
            else if (e.X > 110 && e.X < 210 && e.Y > 10 && e.Y < 110 && flagX[0, 1] && flagO[0, 1])
            {
                battlefield.DrawEllipse(new Pen(Color.Black, 3), 120, 20, 80, 80);
                flagO[0, 1] = false;
                flag2 = false;
            }
            else if (e.X > 210 && e.X < 310 && e.Y > 10 && e.Y < 110 && flagX[0, 2] && flagO[0, 2])
            {
                battlefield.DrawEllipse(new Pen(Color.Black, 3), 220, 20, 80, 80);
                flagO[0, 2] = false;
                flag2 = false;
            }
            else if (e.X > 10 && e.X < 110 && e.Y > 110 && e.Y < 210 && flagX[1, 0] && flagO[1, 0])
            {
                battlefield.DrawEllipse(new Pen(Color.Black, 3), 20, 120, 80, 80);
                flagO[1, 0] = false;
                flag2 = false;
            }
            else if (e.X > 110 && e.X < 210 && e.Y > 110 && e.Y < 210 && flagX[1, 1] && flagO[1, 1])
            {
                battlefield.DrawEllipse(new Pen(Color.Black, 3), 120, 120, 80, 80);
                flagO[1, 1] = false;
                flag2 = false;
            }
            else if (e.X > 210 && e.X < 310 && e.Y > 110 && e.Y < 210 && flagX[1, 2] && flagO[1, 2])
            {
                battlefield.DrawEllipse(new Pen(Color.Black, 3), 220, 120, 80, 80);
                flagO[1, 2] = false;
                flag2 = false;
            }
            else if (e.X > 10 && e.X < 110 && e.Y > 210 && e.Y < 310 && flagX[2, 0] && flagO[2, 0])
            {
                battlefield.DrawEllipse(new Pen(Color.Black, 3), 20, 220, 80, 80);
                flagO[2, 0] = false;
                flag2 = false;
            }
            else if (e.X > 110 && e.X < 210 && e.Y > 210 && e.Y < 310 && flagX[2, 1] && flagO[2, 1])
            {
                battlefield.DrawEllipse(new Pen(Color.Black, 3), 120, 220, 80, 80);
                flagO[2, 1] = false;
                flag2 = false;
            }
            else if (e.X > 210 && e.X < 310 && e.Y > 210 && e.Y < 310 && flagX[2, 2] && flagO[2, 2])
            {
                battlefield.DrawEllipse(new Pen(Color.Black, 3), 220, 220, 80, 80);
                flagO[2, 2] = false;
                flag2 = false;
            }
            Res(battlefield);
        }

        private void CreateO1(Graphics battlefield, MouseEventArgs e)
        {
            if (isRestarted)
            {
                return;
            }
            if (((!flagO[0, 1] && !flagO[0, 2]) || (!flagO[1, 1] && !flagO[2, 2]) || (!flagO[1, 0] && !flagO[2, 0])) && flagX[0, 0] && flagO[0, 0])
            {
                battlefield.DrawEllipse(new Pen(Color.Black, 3), 20, 20, 80, 80);
                flagO[0, 0] = false;
            }
            else if (((!flagO[0, 0] && !flagO[0, 2]) || (!flagO[1, 1] && !flagO[2, 1])) && flagX[0, 1] && flagO[0, 1])
            {
                battlefield.DrawEllipse(new Pen(Color.Black, 3), 120, 20, 80, 80);
                flagO[0, 1] = false;
            }
            else if (((!flagO[0, 0] && !flagO[0, 1]) || (!flagO[2, 0] && !flagO[1, 1]) || (!flagO[1, 2] && !flagO[2, 2])) && flagX[0, 2] && flagO[0, 2])
            {
                battlefield.DrawEllipse(new Pen(Color.Black, 3), 220, 20, 80, 80);
                flagO[0, 2] = false;
            }
            else if (((!flagO[0, 0] && !flagO[2, 0]) || (!flagO[1, 1] && !flagO[1, 2])) && flagX[1, 0] && flagO[1, 0])
            {
                battlefield.DrawEllipse(new Pen(Color.Black, 3), 20, 120, 80, 80);
                flagO[1, 0] = false;
            }
            else if (((!flagO[0, 0] && !flagO[2, 2]) || (!flagO[2, 0] && !flagO[0, 2]) || (!flagO[0, 1] && !flagO[2, 1]) || (!flagO[1, 0] && !flagO[1, 2])) && flagX[1, 1] && flagO[1, 1])
            {
                battlefield.DrawEllipse(new Pen(Color.Black, 3), 120, 120, 80, 80);
                flagO[1, 1] = false;
            }
            else if (((!flagO[0, 2] && !flagO[2, 2]) || (!flagO[1, 0] && !flagO[1, 1])) && flagX[1, 2] && flagO[1, 2])
            {
                battlefield.DrawEllipse(new Pen(Color.Black, 3), 220, 120, 80, 80);
                flagO[1, 2] = false;
            }
            else if (((!flagO[0, 2] && !flagO[1, 1]) || (!flagO[0, 0] && !flagO[1, 0]) || (!flagO[2, 1] && !flagO[2, 2])) && flagX[2, 0] && flagO[2, 0])
            {
                battlefield.DrawEllipse(new Pen(Color.Black, 3), 20, 220, 80, 80);
                flagO[2, 0] = false;
            }
            else if (((!flagO[0, 1] && !flagO[1, 1]) || (!flagO[2, 0] && !flagO[2, 2])) && flagX[2, 1] && flagO[2, 1])
            {
                battlefield.DrawEllipse(new Pen(Color.Black, 3), 120, 220, 80, 80);
                flagO[2, 1] = false;
            }
            else if (((!flagO[2, 0] && !flagO[2, 1]) || (!flagO[0, 0] && !flagO[1, 1]) || (!flagO[0, 2] && !flagO[1, 2])) && flagX[2, 2] && flagO[2, 2])
            {
                battlefield.DrawEllipse(new Pen(Color.Black, 3), 220, 220, 80, 80);
                flagO[2, 2] = false;
            }

            else if (((!flagX[0, 1] && !flagX[0, 2]) || (!flagX[1, 1] && !flagX[2, 2]) || (!flagX[1, 0] && !flagX[2, 0])) && flagX[0, 0] && flagO[0, 0])
            {
                battlefield.DrawEllipse(new Pen(Color.Black, 3), 20, 20, 80, 80);
                flagO[0, 0] = false;
            }
            else if (((!flagX[0, 0] && !flagX[0, 2]) || (!flagX[1, 1] && !flagX[2, 1])) && flagX[0, 1] && flagO[0, 1])
            {
                battlefield.DrawEllipse(new Pen(Color.Black, 3), 120, 20, 80, 80);
                flagO[0, 1] = false;
            }
            else if (((!flagX[0, 0] && !flagX[0, 1]) || (!flagX[2, 0] && !flagX[1, 1]) || (!flagX[1, 2] && !flagX[2, 2])) && flagX[0, 2] && flagO[0, 2])
            {
                battlefield.DrawEllipse(new Pen(Color.Black, 3), 220, 20, 80, 80);
                flagO[0, 2] = false;
            }
            else if (((!flagX[0, 0] && !flagX[2, 0]) || (!flagX[1, 1] && !flagX[1, 2])) && flagX[1, 0] && flagO[1, 0])
            {
                battlefield.DrawEllipse(new Pen(Color.Black, 3), 20, 120, 80, 80);
                flagO[1, 0] = false;
            }
            else if (((!flagX[0, 0] && !flagX[2, 2]) || (!flagX[2, 0] && !flagX[0, 2]) || (!flagX[0, 1] && !flagX[2, 1]) || (!flagX[1, 0] && !flagX[1, 2])) && flagX[1, 1] && flagO[1, 1])
            {
                battlefield.DrawEllipse(new Pen(Color.Black, 3), 120, 120, 80, 80);
                flagO[1, 1] = false;
            }
            else if (((!flagX[0, 2] && !flagX[2, 2]) || (!flagX[1, 0] && !flagX[1, 1])) && flagX[1, 2] && flagO[1, 2])
            {
                battlefield.DrawEllipse(new Pen(Color.Black, 3), 220, 120, 80, 80);
                flagO[1, 2] = false;
            }
            else if (((!flagX[0, 2] && !flagX[1, 1]) || (!flagX[0, 0] && !flagX[1, 0]) || (!flagX[2, 1] && !flagX[2, 2])) && flagX[2, 0] && flagO[2, 0])
            {
                battlefield.DrawEllipse(new Pen(Color.Black, 3), 20, 220, 80, 80);
                flagO[2, 0] = false;
            }
            else if (((!flagX[0, 1] && !flagX[1, 1]) || (!flagX[2, 0] && !flagX[2, 2])) && flagX[2, 1] && flagO[2, 1])
            {
                battlefield.DrawEllipse(new Pen(Color.Black, 3), 120, 220, 80, 80);
                flagO[2, 1] = false;
            }
            else if (((!flagX[2, 0] && !flagX[2, 1]) || (!flagX[0, 0] && !flagX[1, 1]) || (!flagX[0, 2] && !flagX[1, 2])) && flagX[2, 2] && flagO[2, 2])
            {
                battlefield.DrawEllipse(new Pen(Color.Black, 3), 220, 220, 80, 80);
                flagO[2, 2] = false;
            }
            else
            {
                RandomO(battlefield);
            }
            Res(battlefield);
        }

        private void CreateX2(Graphics battlefield, MouseEventArgs e)
        {
            if (isRestarted)
            {
                return;
            }
            if (((!flagX[0, 1] && !flagX[0, 2]) || (!flagX[1, 1] && !flagX[2, 2]) || (!flagX[1, 0] && !flagX[2, 0])) && flagX[0, 0] && flagO[0, 0])
            {
                battlefield.DrawLine(new Pen(Color.Black, 3), 20, 20, 100, 100);
                battlefield.DrawLine(new Pen(Color.Black, 3), 20, 100, 100, 20);
                flagX[0, 0] = false;
            }
            else if (((!flagX[0, 0] && !flagX[0, 2]) || (!flagX[1, 1] && !flagX[2, 1])) && flagX[0, 1] && flagO[0, 1])
            {
                battlefield.DrawLine(new Pen(Color.Black, 3), 120, 20, 200, 100);
                battlefield.DrawLine(new Pen(Color.Black, 3), 120, 100, 200, 20);
                flagX[0, 1] = false;
            }
            else if (((!flagX[0, 0] && !flagX[0, 1]) || (!flagX[2, 0] && !flagX[1, 1]) || (!flagX[1, 2] && !flagX[2, 2])) && flagX[0, 2] && flagO[0, 2])
            {
                battlefield.DrawLine(new Pen(Color.Black, 3), 220, 20, 300, 100);
                battlefield.DrawLine(new Pen(Color.Black, 3), 220, 100, 300, 20);
                flagX[0, 2] = false;
            }
            else if (((!flagX[0, 0] && !flagX[2, 0]) || (!flagX[1, 1] && !flagX[1, 2])) && flagX[1, 0] && flagO[1, 0])
            {
                battlefield.DrawLine(new Pen(Color.Black, 3), 20, 120, 100, 200);
                battlefield.DrawLine(new Pen(Color.Black, 3), 20, 200, 100, 120);
                flagX[1, 0] = false;
            }
            else if (((!flagX[0, 0] && !flagX[2, 2]) || (!flagX[2, 0] && !flagX[0, 2]) || (!flagX[0, 1] && !flagX[2, 1]) || (!flagX[1, 0] && !flagX[1, 2])) && flagX[1, 1] && flagO[1, 1])
            {
                battlefield.DrawLine(new Pen(Color.Black, 3), 120, 120, 200, 200);
                battlefield.DrawLine(new Pen(Color.Black, 3), 120, 200, 200, 120);
                flagX[1, 1] = false;
            }
            else if (((!flagX[0, 2] && !flagX[2, 2]) || (!flagX[1, 0] && !flagX[1, 1])) && flagX[1, 2] && flagO[1, 2])
            {
                battlefield.DrawLine(new Pen(Color.Black, 3), 220, 120, 300, 200);
                battlefield.DrawLine(new Pen(Color.Black, 3), 220, 200, 300, 120);
                flagX[1, 2] = false;
            }
            else if (((!flagX[0, 2] && !flagX[1, 1]) || (!flagX[0, 0] && !flagX[1, 0]) || (!flagX[2, 1] && !flagX[2, 2])) && flagX[2, 0] && flagO[2, 0])
            {
                battlefield.DrawLine(new Pen(Color.Black, 3), 20, 220, 100, 300);
                battlefield.DrawLine(new Pen(Color.Black, 3), 20, 300, 100, 220);
                flagX[2, 0] = false;
            }
            else if (((!flagX[0, 1] && !flagX[1, 1]) || (!flagX[2, 0] && !flagX[2, 2])) && flagX[2, 1] && flagO[2, 1])
            {
                battlefield.DrawLine(new Pen(Color.Black, 3), 120, 220, 200, 300);
                battlefield.DrawLine(new Pen(Color.Black, 3), 120, 300, 200, 220);
                flagX[2, 1] = false;
            }
            else if (((!flagX[2, 0] && !flagX[2, 1]) || (!flagX[0, 0] && !flagX[1, 1]) || (!flagX[0, 2] && !flagX[1, 2])) && flagX[2, 2] && flagO[2, 2])
            {
                battlefield.DrawLine(new Pen(Color.Black, 3), 220, 220, 300, 300);
                battlefield.DrawLine(new Pen(Color.Black, 3), 220, 300, 300, 220);
                flagX[2, 2] = false;
            }

            else if (((!flagO[0, 1] && !flagO[0, 2]) || (!flagO[1, 1] && !flagO[2, 2]) || (!flagO[1, 0] && !flagO[2, 0])) && flagX[0, 0] && flagO[0, 0])
            {
                battlefield.DrawLine(new Pen(Color.Black, 3), 20, 20, 100, 100);
                battlefield.DrawLine(new Pen(Color.Black, 3), 20, 100, 100, 20);
                flagX[0, 0] = false;
            }
            else if (((!flagO[0, 0] && !flagO[0, 2]) || (!flagO[1, 1] && !flagO[2, 1])) && flagX[0, 1] && flagO[0, 1])
            {
                battlefield.DrawLine(new Pen(Color.Black, 3), 120, 20, 200, 100);
                battlefield.DrawLine(new Pen(Color.Black, 3), 120, 100, 200, 20);
                flagX[0, 1] = false;
            }
            else if (((!flagO[0, 0] && !flagO[0, 1]) || (!flagO[2, 0] && !flagO[1, 1]) || (!flagO[1, 2] && !flagO[2, 2])) && flagX[0, 2] && flagO[0, 2])
            {
                battlefield.DrawLine(new Pen(Color.Black, 3), 220, 20, 300, 100);
                battlefield.DrawLine(new Pen(Color.Black, 3), 220, 100, 300, 20);
                flagX[0, 2] = false;
            }
            else if (((!flagO[0, 0] && !flagO[2, 0]) || (!flagO[1, 1] && !flagO[1, 2])) && flagX[1, 0] && flagO[1, 0])
            {
                battlefield.DrawLine(new Pen(Color.Black, 3), 20, 120, 100, 200);
                battlefield.DrawLine(new Pen(Color.Black, 3), 20, 200, 100, 120);
                flagX[1, 0] = false;
            }
            else if (((!flagO[0, 0] && !flagO[2, 2]) || (!flagO[2, 0] && !flagO[0, 2]) || (!flagO[0, 1] && !flagO[2, 1]) || (!flagO[1, 0] && !flagO[1, 2])) && flagX[1, 1] && flagO[1, 1])
            {
                battlefield.DrawLine(new Pen(Color.Black, 3), 120, 120, 200, 200);
                battlefield.DrawLine(new Pen(Color.Black, 3), 120, 200, 200, 120);
                flagX[1, 1] = false;
            }
            else if (((!flagO[0, 2] && !flagO[2, 2]) || (!flagO[1, 0] && !flagO[1, 1])) && flagX[1, 2] && flagO[1, 2])
            {
                battlefield.DrawLine(new Pen(Color.Black, 3), 220, 120, 300, 200);
                battlefield.DrawLine(new Pen(Color.Black, 3), 220, 200, 300, 120);
                flagX[1, 2] = false;
            }
            else if (((!flagO[0, 2] && !flagO[1, 1]) || (!flagO[0, 0] && !flagO[1, 0]) || (!flagO[2, 1] && !flagO[2, 2])) && flagX[2, 0] && flagO[2, 0])
            {
                battlefield.DrawLine(new Pen(Color.Black, 3), 20, 220, 100, 300);
                battlefield.DrawLine(new Pen(Color.Black, 3), 20, 300, 100, 220);
                flagX[2, 0] = false;
            }
            else if (((!flagO[0, 1] && !flagO[1, 1]) || (!flagO[2, 0] && !flagO[2, 2])) && flagX[2, 1] && flagO[2, 1])
            {
                battlefield.DrawLine(new Pen(Color.Black, 3), 120, 220, 200, 300);
                battlefield.DrawLine(new Pen(Color.Black, 3), 120, 300, 200, 220);
                flagX[2, 1] = false;
            }
            else if (((!flagO[2, 0] && !flagO[2, 1]) || (!flagO[0, 0] && !flagO[1, 1]) || (!flagO[0, 2] && !flagO[1, 2])) && flagX[2, 2] && flagO[2, 2])
            {
                battlefield.DrawLine(new Pen(Color.Black, 3), 220, 220, 300, 300);
                battlefield.DrawLine(new Pen(Color.Black, 3), 220, 300, 300, 220);
                flagX[2, 2] = false;
            }
            else
            {
                RandomX(battlefield);
            }
            Res(battlefield);
        }

        private void Res(Graphics battlefield)
        {
            if (isRestarted)
            {
                return;
            }
            if (!flagX[0, 0] && !flagX[0, 1] && !flagX[0, 2])
            {
                battlefield.DrawLine(new Pen(Color.Red, 3), 10, 60, 310, 60);
                Mess1();

            }
            else if (!flagX[1, 0] && !flagX[1, 1] && !flagX[1, 2])
            {
                battlefield.DrawLine(new Pen(Color.Red, 3), 10, 160, 310, 160);
                Mess1();
            }
            else if (!flagX[2, 0] && !flagX[2, 1] && !flagX[2, 2])
            {
                battlefield.DrawLine(new Pen(Color.Red, 3), 10, 260, 310, 260);
                Mess1();
            }
            else if (!flagX[0, 0] && !flagX[1, 0] && !flagX[2, 0])
            {
                battlefield.DrawLine(new Pen(Color.Red, 3), 60, 10, 60, 310);
                Mess1();
            }
            else if (!flagX[0, 1] && !flagX[1, 1] && !flagX[2, 1])
            {
                battlefield.DrawLine(new Pen(Color.Red, 3), 160, 10, 160, 310);
                Mess1();
            }
            else if (!flagX[0, 2] && !flagX[1, 2] && !flagX[2, 2])
            {
                battlefield.DrawLine(new Pen(Color.Red, 3), 260, 10, 260, 310);
                Mess1();
            }
            else if (!flagX[0, 0] && !flagX[1, 1] && !flagX[2, 2])
            {
                battlefield.DrawLine(new Pen(Color.Red, 3), 10, 10, 310, 310);
                Mess1();
            }
            else if (!flagX[0, 2] && !flagX[1, 1] && !flagX[2, 0])
            {
                battlefield.DrawLine(new Pen(Color.Red, 3), 310, 10, 10, 310);
                Mess1();
            }
            else if (!flagO[0, 0] && !flagO[0, 1] && !flagO[0, 2])
            {
                battlefield.DrawLine(new Pen(Color.Red, 3), 10, 60, 310, 60);
                Mess2();
            }
            else if (!flagO[1, 0] && !flagO[1, 1] && !flagO[1, 2])
            {
                battlefield.DrawLine(new Pen(Color.Red, 3), 10, 160, 310, 160);
                Mess2();
            }
            else if (!flagO[2, 0] && !flagO[2, 1] && !flagO[2, 2])
            {
                battlefield.DrawLine(new Pen(Color.Red, 3), 10, 260, 310, 260);
                Mess2();
            }
            else if (!flagO[0, 0] && !flagO[1, 0] && !flagO[2, 0])
            {
                battlefield.DrawLine(new Pen(Color.Red, 3), 60, 10, 60, 310);
                Mess2();
            }
            else if (!flagO[0, 1] && !flagO[1, 1] && !flagO[2, 1])
            {
                battlefield.DrawLine(new Pen(Color.Red, 3), 160, 10, 160, 310);
                Mess2();
            }
            else if (!flagO[0, 2] && !flagO[1, 2] && !flagO[2, 2])
            {
                battlefield.DrawLine(new Pen(Color.Red, 3), 260, 10, 260, 310);
                Mess2();
            }
            else if (!flagO[0, 0] && !flagO[1, 1] && !flagO[2, 2])
            {
                battlefield.DrawLine(new Pen(Color.Red, 3), 10, 10, 310, 310);
                Mess2();
            }
            else if (!flagO[0, 2] && !flagO[1, 1] && !flagO[2, 0])
            {
                battlefield.DrawLine(new Pen(Color.Red, 3), 310, 10, 10, 310);
                Mess2();
            }
        }

        private void Mess1()
        {
            if (comboBox1.SelectedIndex == 1)
                WinX();
            else if (mess)
                MessWin();
            else
                MessLoss();
        }

        private void Mess2()
        {
            if (comboBox1.SelectedIndex == 1)
                WinO();
            else if (mess)
                MessLoss();
            else
                MessWin();
        }

        private void MessWin()
        {
            MessageBox.Show("Победа!");
            if (!isRestarted)
            {
                isRestarted = true;
                Application.Restart();
            }
        }

        private void WinX()
        {
            MessageBox.Show("Крестики победили!");
            if (!isRestarted)
            {
                isRestarted = true;
                Application.Restart();
            }
        }

        private void WinO()
        {
            MessageBox.Show("Нолики победили!");
            if (!isRestarted)
            {
                isRestarted = true;
                Application.Restart();
            }
        }

        private void MessLoss()
        {
            MessageBox.Show("Поражение!");
            if (!isRestarted)
            {
                isRestarted = true;
                Application.Restart();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
                comboBox2.Enabled = true;
            else
                comboBox2.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!isRestarted)
            {
                isRestarted = true;
                Application.Restart();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            battlefield = pictureBox1.CreateGraphics();
            if (comboBox1.SelectedIndex == 0 && comboBox2.SelectedIndex == 1)
            {
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                switch (count2)
                {
                    case 0:
                        RandomX(battlefield);
                        count2++;
                        break;
                    default:
                        break;
                }

            }
        }
    }
}