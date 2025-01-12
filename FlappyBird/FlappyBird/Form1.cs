using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        int pipspeed = 8; // Boru hızı
        int gravity = 10; // Yer çekimi
        int score = 0; // Skor

        public Form1()
        {
            InitializeComponent();
        }
        // Oyun döngüsü
        private void gameTimerEvent(object sender, EventArgs e)
        {
            FlappyBird.Top += gravity;
            pipebottom.Left -= pipspeed;
            pipetop.Left -= pipspeed;
            scoreText.Text = "Score: " + score;

            // Borular ekrandan çıkarsa sıfırlanır ve skor artar
            if (pipebottom.Left < -150)
            {
                pipebottom.Left = 800;
                score++;
            }
            if(pipetop.Left<-180)
            {
                pipetop.Left = 950;
                score++;
            }
            // Kuş borulara veya yere çarparsa oyun biter
            if (FlappyBird.Bounds.IntersectsWith(pipebottom.Bounds) ||
                FlappyBird.Bounds.IntersectsWith(pipetop.Bounds) ||
                 FlappyBird.Bounds.IntersectsWith(ground.Bounds) || FlappyBird.Top < -25
                )
            {
                endGame();
            }

            // Skor 5'i geçerse boru hızı artar
            if (score >5)
            {
                pipspeed = 15;
            }
        }

        // Space tuşuna basıldığında kuş yukarı uçar
        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Space)
            {
                gravity = -10;
            }
        }
        // Space tuşu bırakıldığında kuş aşağı düşer
        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 10;
            }
        }
        // Oyun bitişi
        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += " OYUN BİTTİ !!!";
        }
    }
}
