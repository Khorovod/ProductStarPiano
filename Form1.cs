using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductStarPiano
{
    public partial class Form1 : Form
    {
        private readonly Engine _beep;

        public Form1()
        {
            InitializeComponent();

            _beep = new Engine();
            textBox1.Text = $"frqcy:{_beep.Frequency}";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            _beep.GoBeep(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _beep.GoBeep(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _beep.GoBeep(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _beep.GoBeep(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _beep.GoBeep(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            _beep.GoBeep(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            _beep.GoBeep(7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            _beep.GoBeep(8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            _beep.GoBeep(9);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            _beep.GoBeep(10);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            _beep.GoBeep(11);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            _beep.GoBeep(12);
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Task.Run(() => {

                switch (e.KeyCode)
                {
                    case Keys.A:
                        button1_Click_1(sender, e);
                        break;
                    case Keys.S:
                        button2_Click(sender, e);
                        break;
                    case Keys.D:
                        button3_Click(sender, e);
                        break;
                    case Keys.W:
                        button8_Click(sender, e);
                        break;
                    case Keys.E:
                        button9_Click(sender, e);
                        break;
                    case Keys.G:
                        button4_Click(sender, e);
                        break;
                    case Keys.H:
                        button5_Click(sender, e);
                        break;
                    case Keys.J:
                        button6_Click(sender, e);
                        break;
                    case Keys.K:
                        button7_Click(sender, e);
                        break;
                    case Keys.Y:
                        button10_Click(sender, e);
                        break;
                    case Keys.U:
                        button11_Click(sender, e);
                        break;
                    case Keys.I:
                        button12_Click(sender, e);
                        break;
                    default:
                        break;
                }

            });
        }
    }


    public class Engine
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool Beep(int frequency, int duration);

        public int Frequency { get; }
        private int duration = 1000;
        private readonly Dictionary<int, int> _tones = new Dictionary<int, int>();

        public Engine()
        {
            Frequency = new Random().Next(100, 500);
            CreateTone(Frequency);
        }

        public void GoBeep(int button)
        {
            _tones.TryGetValue(button, out var freq);
            Task.Run(() => Beep(freq, duration));
        }

        public void CreateTone(int frequency)
        {
            _tones.Add(1, frequency);
            _tones.Add(8, frequency += 50);
            _tones.Add(2, frequency += 100);
            _tones.Add(9, frequency += 50);
            _tones.Add(3, frequency += 100);

            _tones.Add(4, frequency += 100);
            _tones.Add(10, frequency += 50);
            _tones.Add(5, frequency += 100);
            _tones.Add(11, frequency += 50);
            _tones.Add(6, frequency += 100);
            _tones.Add(12, frequency += 50);
            _tones.Add(7, frequency += 100);
        }
    }
}
