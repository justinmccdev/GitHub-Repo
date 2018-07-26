using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace humanmusic
{
    public partial class Form1 : Form
    {

        SongGenerator sg;
        public Form1()
        {
            InitializeComponent();
           
            sg = new SongGenerator();

        }

    private void button1_Click(object sender, EventArgs e)
        {
            Thread play = new Thread(() =>
            {                    
                
            });
            play.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
                sg.stop();
                sg.GenerateSong();
                label1.Text = "Playing Song!";
                programInfo.Text = programInfo.Text + sg.getSongInfo();
        }

        private void programInfo_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            label1.Text = "Stopped!";
            sg.stop();
        }
    }
}
