using System;
using System.Drawing;
using System.Windows.Forms;

namespace BombGame;

public partial class Form1 : Form
{
    const int Rows = 8;
    const int Cols = 8;

    const int ElementSize = 100; 
    const int BoxSize = 70;      

    const int BombCount = 10;

    static Random random = new Random();

    Panel[,] fields = new Panel[Rows, Cols];
    bool[,] bombs = new bool[Rows, Cols];
    bool[,] clicked = new bool[Rows, Cols];

    int points = 0;

    Label lblPoints = new Label()
    {
        ForeColor = Color.White,
        Location = new Point(10, 10),
        AutoSize = true,
        Font = new Font("Arial", 14)
    };

    public Form1()
    {
        Text = "Bomb Game";
        BackColor = Color.Black;

        Width = Cols * ElementSize + 30;
        Height = Rows * ElementSize + 100;

        Controls.Add(lblPoints);
        lblPoints.Text = "Points: 0";

        CreateGame();
    }

    void CreateGame()
    {
        PlaceBombs();
        CreateFields();
    }
    void PlaceBombs()
    {
        int placed = 0;

        while (placed < BombCount)
        {
            int x = random.Next(Cols);
            int y = random.Next(Rows);

            if (!bombs[y, x])
            {
                bombs[y, x] = true;
                placed++;
            }
        }
    }
    void CreateFields()
    {
        for (int y = 0; y < Rows; y++)
        {
            for (int x = 0; x < Cols; x++)
            {

                Panel p = new Panel();

                p.Size = new Size(BoxSize, BoxSize);


                // Abstand zwischen Boxen
                p.Location = new Point(
                    x * ElementSize + 10,
                    y * ElementSize + 50);


                p.BackColor = Color.Gray;


                p.BorderStyle = BorderStyle.FixedSingle;


                int cx = x;
                int cy = y;


                p.Click += (s, e) =>
                {
                    ClickField(cx, cy, p);
                };


                fields[y, x] = p;

                Controls.Add(p);
            }
        }
    }
    void ClickField(int x, int y, Panel field)
    {

        if (clicked[y, x])
            return;


        clicked[y, x] = true;


        if (bombs[y, x])
        {
            field.BackColor = Color.Red;
            field.Text = "💣";
            field.Font = new Font("Arial", 20);

            GameOver();
        }
        else
        {
            field.BackColor = Color.LimeGreen;

            points++;

            lblPoints.Text =
                $"Points: {points}";
        }

    }
    void GameOver()
    {
        foreach (Panel p in fields)
        {
            p.Enabled = false;

            int y = p.Location.Y;
            int x = p.Location.X;
        }


        DialogResult r =
        MessageBox.Show(
            "Bombe! Nochmal?",
            "Game Over",
            MessageBoxButtons.YesNo);


        if (r == DialogResult.Yes)
        {
            Controls.Clear();

            bombs = new bool[Rows, Cols];
            clicked = new bool[Rows, Cols];

            points = 0;

            Controls.Add(lblPoints);
            lblPoints.Text = "Points: 0";

            CreateGame();
        }
        else
        {
            Close();
        }
    }
}