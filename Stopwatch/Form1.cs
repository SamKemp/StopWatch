using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Stopwatch
{
    public partial class Form1 : Form
    {
        public int _running= 0;
        public int _counter = 0;
        public int _counter2 = 00;
        public int _toggle = 0;
        public int _clocktype = 0;

        List<string> _items = new List<string>(); // <-- Add this

        public Form1()
        {
            InitializeComponent();

            timer1.Interval = 100;
            timer2.Interval = 50;
            timer3.Interval = 10;
        }

        private void startTimers()
        {
            timer1.Start();
            timer3.Start();
            _running = 1;
        }

        private void stopTimers()
        {
            timer1.Stop();
            timer3.Stop();
            _running = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_running == 0)
            {
                startTimers();
            }
            else
            {
                stopTimers();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _counter ++;

            if (_counter > 9)
            {
                _counter = 0;
                _counter2++;
            }

            labTime.Text = _counter.ToString();

            if (_counter2 >= 10)
            {
                this.labSecTime.Location = new Point(7, 36);
                if (_counter2 >= 100)
                {
                    this.labSecTime.Location = new Point(-65, 36);
                }
            }
            else
            {
                this.labSecTime.Location = new Point(83, 36);
            }

            labSecTime.Text = _counter2.ToString();

            if (_counter2 == 99)
            //if (_counter2 == 10)
            {
                stopTimers();
                MessageBox.Show("You should go outside and get a propper stopwatch!", "An error occured");
                timer2.Start();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _items.Add(_counter2 + "." + _counter);
            //MessageBox.Show(_counter2.ToString()+ "." + _counter.ToString(), "Split");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_running == 1)
            {
                stopTimers();
            }

            Reset();
        }

        private void Reset()
        {
            _counter = 0;
            _counter2 = 00;

            _items.Clear();
            listRefresh();

            timer2.Stop();
            pictureBox1.BackColor = Color.White;

            labTime.Text = _counter.ToString();
            labSecTime.Text = _counter2.ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (_toggle == 1)
            {
                pictureBox1.BackColor = Color.Red;
                _toggle = 0;
            }
            else
            {
                pictureBox1.BackColor = Color.White;
                _toggle = 1;
            }


        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (_items.Count == 16)
            {
                _items.RemoveAt(0);
            }
            listRefresh();
        }

        private void listRefresh()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = _items;
        }

        private void buttClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
