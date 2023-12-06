using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TicTacToe
{
    public partial class MainForm : Form
    {

        bool turn = true; //true = x; false = y
        int turn_count = 0;
        static string player1, player2;

        public MainForm()
        {
            InitializeComponent();
        }

        public static void setPlayerName(string name1, string name2)
        {
            player1 = name1;
            player2 = name2;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Revannchist", "About");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (turn)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }
            turn = !turn;
            b.Enabled = false;
            turn_count++;
            checkForWinner();
        }

        private void checkForWinner()
        {

            bool there_is_a_winner = false;

            //horizontal
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                there_is_a_winner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                there_is_a_winner = true;   

            //vertical
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                there_is_a_winner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                there_is_a_winner = true;

            //diagonal
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                there_is_a_winner = true;


            if (there_is_a_winner)
            {
                disableButtons();
                String winner = string.Empty;
                if (turn)
                {
                    winner = player2;
                    Ocount.Text = (Int32.Parse(Ocount.Text) + 1).ToString();
                }
                else
                {;
                    winner = player1;
                    XCount.Text = (Int32.Parse(XCount.Text) + 1).ToString();
                }
                MessageBox.Show("The winner is " + winner, "Congratulations!");
            }
            else
            {
                if (turn_count == 9)
                {
                    MessageBox.Show("It's a draw!", "Unlucky!");
                    DrawCount.Text = (Int32.Parse(DrawCount.Text) + 1).ToString();
                }
            }
        }

        private void disableButtons()
        {
            foreach (Control c in Controls)
            {
                try
                {       
                    Button b = (Button)c;
                    b.Enabled = false;
                }
                catch { }
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;

            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = string.Empty;
                } catch { }
            }

        }

        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                if (turn)
                    b.Text = "X";
                else
                    b.Text = "O";
            }
        }

        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
                b.Text = string.Empty;

        }

        private void restWinCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ocount.Text = "0";
            XCount.Text = "0";
            DrawCount.Text = "0";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoginForm lf = new LoginForm();
            lf.ShowDialog();

            if(String.IsNullOrEmpty(player1) || String.IsNullOrEmpty(player2)) { Application.Exit(); }

            label1.Text = player1;
            label3.Text = player2;
        }
    }
}
