﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory_Work_2
{
    public partial class Form1 : Form
    {
        GLGraphics GLGraphics = new GLGraphics();
        public Form1()
        {
            InitializeComponent();
        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            GLGraphics.Resize(glControl1.Width, glControl1.Height);
            Application.Idle += Application_Idle;
            int texID = GLGraphics.LoadTexture(
                "C:\\Users\\T1620\\Desktop\\CGraphics\\OpenGL Project\\Laboratory Work 2\\Laboratory Work 2\\assets\\wood.jpg");
            GLGraphics.texturesIDs.Add(texID);
            
        }
        

        private void glControl1_Paint_1(object sender, PaintEventArgs e)
        {
            GLGraphics.Update();
            glControl1.SwapBuffers();
        }

        private void glControl1_MouseMove(object sender, MouseEventArgs e)
        {
            float widthCoef = (e.X - glControl1.Width * 0.5f) / (float)glControl1.Width;
            float heightCoef = (-e.Y + glControl1.Height * 0.5f) / (float)glControl1.Height;
            GLGraphics.latitude = heightCoef * 180;
            GLGraphics.longitude = widthCoef * 360;
        }

        void Application_Idle(object sender, EventArgs e)
        {
            while (glControl1.IsIdle)
            {
                glControl1.Refresh();
            }
        }
    }
}
