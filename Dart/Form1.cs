using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dart
{
    public partial class Form1 : Form
    {
        Players Players = new Players();
        private int secondsRemaining = 180;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void txtPlayer2_TextChanged(object sender, EventArgs e)
        {
          
            
           
            
        }

        private void txtPlayer1_TextChanged(object sender, EventArgs e)
        {
           
            
        }

        private void txtPlayer1_Enter(object sender, EventArgs e)
        {
           
        }

        private void txtPlayer1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                int score;
                if(int.TryParse(txtPlayer1.Text, out score))
                {
                    Players.Player1 -= score;
                    lbPlayer1.Items.Add(Players.Player1);
                    txtPlayer1.Clear();

                    if(Players.Player1 < 0)
                    {
                        MessageBox.Show("BUBU");
                        lbPlayer1.Items.Clear();
                        Players.Player1 = 0;
                    }
                    else if (Players.Player1 == 0)
                    {
                        MessageBox.Show("Payer 1 WINS!");
                    }
                }
                if (char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }
            }
        }

        private void txtPlayer2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                int score;
                if (int.TryParse(txtPlayer2.Text, out score))
                {
                    Players.Player2 -= score;
                    lbPlayer2.Items.Add(Players.Player2);
                    txtPlayer2.Clear();
                    
                    if (Players.Player2 < 0)
                    {
                        MessageBox.Show("BUBU");
                        lbPlayer2.Items.Clear();
                        Players.Player2 = 0;
                    }
                    else if (Players.Player2 == 0)
                    {
                        MessageBox.Show("Payer 2 WINS!");
                    }
                }
                if (char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbPlayer1.Items.Add("301");
            lbPlayer2.Items.Add("301");
            DialogResult dialogResult = MessageBox.Show("START GAME?", "PROMPT", MessageBoxButtons.YesNo);
            if(dialogResult== DialogResult.Yes)
            {
                timer.Start();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            secondsRemaining--;

            if (secondsRemaining <= 0)
            {
                timer.Stop();
                MessageBox.Show("Time's up!", "Timer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPlayer1.Enabled = false;
                txtPlayer2.Enabled = false;
                return;
            }

            int minutes = secondsRemaining / 60;
            int seconds = secondsRemaining % 60;
            lblTimer.Text = $"Time Remaining: {minutes:D2}:{seconds:D2}";
        }
    }
    }

