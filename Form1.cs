using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Form1 : Form
    {
        int playerCx;
        int playerCy = 1;
        int playerdrop = 0;
        int height = 20;
        int width = 10;
        int firstBrick;
        int secondBrick;
        int score = 0;
        int highscore = 0;
        int level = 1;
        bool gameStarted = false;
        const int SCALE = 34;

        Random r = new Random();
        Timer timer = new Timer();

        Graphics g;
        SolidBrush background = new SolidBrush(Color.Black);
        SolidBrush[] brushPalette =
        {
            new SolidBrush(Color.FromArgb(158, 22, 230)),
            new SolidBrush(Color.FromArgb(229, 223, 5)),
            new SolidBrush(Color.FromArgb(0, 223, 34)),
            new SolidBrush(Color.FromArgb(230, 0, 43)),
            new SolidBrush(Color.FromArgb(5, 81, 227)),
            new SolidBrush(Color.FromArgb(230, 102, 1)),
            new SolidBrush(Color.FromArgb(2, 228, 224))
        };


        public static int[,] board;
        public int[,] useBrick;

        public Form1()
        {
            InitializeComponent();
            Startup();
        }

        //Meny knappar
        private void btnAvsluta_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnStarta_Click_1(object sender, EventArgs e)
        {
            GameStart();
        }

        private void PbxRestart_Click(object sender, EventArgs e)
        {
            GameRestart();
        }

        private void PbxExitmenu_Click(object sender, EventArgs e)
        {
            Exittomenu();
        }


        int[,] Bricks(int value)
        {
            int[,] brick1 = {
                { 0, 1, 0 },
                { 1, 1, 1 },
                { 0, 0, 0 }};

            int[,] brick2 = {
                { 1, 1 },
                { 1, 1 } };

            int[,] brick3 = {
                { 0, 1, 1 },
                { 1, 1, 0 },
                { 0, 0, 0 }};

            int[,] brick4 = {
                { 1, 1, 0 },
                { 0, 1, 1 },
                { 0, 0, 0 }};

            int[,] brick5 = {
                { 0, 1, 0 },
                { 0, 1, 0 },
                { 1, 1, 0 }};

            int[,] brick6 = {
                { 0, 1, 0 },
                { 0, 1, 0 },
                { 0, 1, 1 }};

            int[,] brick7 = {
                {0, 1, 0, 0 },
                {0, 1, 0, 0 },
                {0, 1, 0, 0 },
                {0, 1, 0, 0 }};
            int[,] empty = {
                { 0,0 }};

            switch (value)
            {
                case 1:
                    return brick1;

                case 2:
                    return brick2;

                case 3:
                    return brick3;

                case 4:
                    return brick4;

                case 5:
                    return brick5;

                case 6:
                    return brick6;

                case 7:
                    return brick7;

                default:
                    return empty;
            }
        }

        //Metoder

        void Startup()
        {
            pMenu.Show();
            pGame.Hide();
        }

        void Exittomenu()
        {
            timer.Tick -= new EventHandler(Gameloop);
            pMenu.Show();
            pGame.Hide();
        }
        void GameStart()
        {
            firstBrick = r.Next(1, 8);
            secondBrick = r.Next(1, 8);
            gameStarted = true;

            pMenu.Hide();
            pGameover.Hide();
            pGame.Show();

            CreateGameboard(ref width, ref height);
            useBrick = Bricks(firstBrick);

            timer.Interval = 750;
            timer.Tick += new EventHandler(Gameloop);
            timer.Start();


            playerCx = (board.GetLength(1) / 2) - (useBrick.GetLength(0) / 2);

            lblLevel.Text = level.ToString();
            lblScore.Text = score.ToString();
        }

        private void Gameloop(object sender, EventArgs e)
        {
            DropBrick();
            LevelChange();
            if (playerdrop == 0)
            {
                playerCy++;
            }
            playerdrop = 0;
            Refresh();
        }

        void CreateGameboard(ref int wb, ref int hb)
        {
            board = new int[hb, wb];

            for (int i = 0; i < hb; i++)
            {
                for (int y = 0; y < wb; y++)
                {
                    if (i == hb - 1)
                    {
                        board[i, y] = 10;
                    }
                    else if (y == 0)
                    {
                        board[i, y] = 8;
                    }
                    else if (y == wb - 1)
                    {
                        board[i, y] = 9;
                    }
                    else
                    {
                        board[i, y] = 0;
                    }


                    Debug.Write(board[i, y] + " ");
                }
                Debug.Write("\n");
            }
        }
        void DropBrick()
        {
            if (CheckCollision(useBrick))
            {
                Merge(useBrick);
                firstBrick = secondBrick;
                secondBrick = r.Next(1, 8);
                useBrick = Bricks(firstBrick);
                playerCx = 4;
                playerCy = 1;
                if (CheckCollision(useBrick) && playerCy == 1 && playerCx == 4)
                {
                    if(score > highscore)
                    {
                        highscore = score;
                    }
                    timer.Stop();
                    lblScoreGameover.Text = score.ToString();
                    lblHighscore.Text = highscore.ToString();
                    pGameover.Show();

                }
            }

        }

        private void pGame_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            DrawGameBoard(board);
            DrawPlayer(useBrick);
            DrawNextPlayer(Bricks(secondBrick));
        }

        

        void DrawGameBoard(int[,] gb)
        {
            for (int row = 0; row < gb.GetLength(0); row++)
            {
                for (int colume = 0; colume < gb.GetLength(1); colume++)
                {
                    if (gb[row, colume] != 0 && gb[row, colume] != 8 && gb[row, colume] != 9 && gb[row, colume] != 10)
                    {
                        g.FillRectangle(brushPalette[gb[row, colume] - 1], SCALE * colume + SCALE, SCALE * row + SCALE, SCALE, SCALE);
                    }
                    else if (gb[row, colume] == 10)
                    {
                        //Det tomma golvet!
                    }
                    else
                    {
                        g.FillRectangle(background, SCALE * colume + SCALE, SCALE * row + SCALE, SCALE, SCALE);
                    }
                }
            }

            g.FillRectangle(new SolidBrush(Color.Black), SCALE * 11.5f + 52, SCALE * 2 + SCALE, SCALE * 5.9f, SCALE * 3);
        }

        void DrawPlayer(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int colume = 0; colume < matrix.GetLength(1); colume++)
                {
                    if (matrix[row, colume] != 0)
                    {
                        g.FillRectangle(brushPalette[firstBrick - 1], SCALE * (colume + playerCx), SCALE * (row + playerCy), SCALE, SCALE);
                    }

                }
            }
        }

        void DrawNextPlayer(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int colume = 0; colume < matrix.GetLength(1); colume++)
                {
                    if (!(matrix[row, colume] == 0))
                    {
                        g.FillRectangle(brushPalette[secondBrick - 1], SCALE * (colume + 25) / 2f + 100, SCALE * (row + 7) / 2f + 10, SCALE / 2f, SCALE / 2f);
                    }

                }
            }
        }

        bool CheckCollision(int[,] matrix)
        {
            try
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int colume = 0; colume < matrix.GetLength(1); colume++)
                    {
                        if (matrix[row, colume] != 0)
                        {
                            if (board[row + playerCy, colume + playerCx - 1] != 0 && board[row + playerCy, colume + playerCx - 1] != 8 && board[row + playerCy, colume + playerCx - 1] != 9)
                            {
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        void Fullline(int[,] b)
        {
            int fullRow = 0;
            for (int row = 0; row < b.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < b.GetLength(1); col++)
                {
                    if (b[row, col] == 0 || b[row, col] == 8 || b[row, col] == 9)
                    {
                        break;
                    }
                    else if (col + 1 == b.GetLength(1))
                    {
                        fullRow++;
                        for (int x = 0; x < col + 1; x++)
                        {
                            for (int y = 0; y < row - 1; y++)
                            {
                                b[row - y, x] = b[row - (y + 1), x];
                            }
                        }
                    }
                }


            }

            if (fullRow != 0)
            {
                score += fullRow * 100 + level * 10;
                lblScore.Text = score.ToString();
            }
        }

        void Merge(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    if (matrix[i, y] != 0)
                    {
                        board[i + playerCy - 1, y + playerCx -1] = matrix[i, y] * firstBrick;
                    }

                }
            }
            Fullline(board);
        }

        void Rotate(int[,] matrix)
        {
            int amount;
            for (int i = 0; i < matrix.GetLength(0) / 2; i++)
            {
                for (int j = i; j < matrix.GetLength(0) - i - 1; j++)
                {
                    if (CheckWall(useBrick, out amount) == "v")
                    {
                        if (amount == 3)
                        {
                            PlayerMove(1);
                        }
                        else if (amount == 4)
                        {
                            PlayerMove(1);
                        }
                    }
                    else if (CheckWall(useBrick, out amount) == "h")
                    {
                        if(amount == 3)
                        {
                            PlayerMove(-1);
                        }
                        else if(amount == 4)
                        {
                            PlayerMove(-1);
                        }
                    }
                    // Roterar klockvisriktning
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[matrix.GetLength(0) - 1 - j, i];
                    matrix[matrix.GetLength(0) - 1 - j, i] = matrix[matrix.GetLength(0) - 1 - i, matrix.GetLength(0) - 1 - j];
                    matrix[matrix.GetLength(0) - 1 - i, matrix.GetLength(0) - 1 - j] = matrix[j, matrix.GetLength(0) - 1 - i];
                    matrix[j, matrix.GetLength(0) - 1 - i] = temp;
                    Debug.Write(matrix[i, j]);
                }
                Debug.WriteLine("");
            }


            Refresh();

        }

        string CheckWall(int[,] matrix, out int amountCollide)
        {
            string dir = "";
            amountCollide = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int colume = 0; colume < matrix.GetLength(1); colume++)
                {
                    if (matrix[row, colume] != 0)
                    {
                        if (board[row + playerCy, colume + playerCx - 1] == 8)
                        {
                            amountCollide++;
                            dir = "v";
                        }
                        else if (board[row + playerCy, colume + playerCx - 1] == 9)
                        {
                            amountCollide++;
                            dir = "h";
                        }
                    }
                }
            }

            if(amountCollide > 0)
            {
                return dir;
            }
            return "n";
        }
        string CheckWall(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int colume = 0; colume < matrix.GetLength(1); colume++)
                {
                    if (matrix[row, colume] != 0)
                    {
                        if (board[row + playerCy, colume + playerCx - 1] == 8)
                        {
                            return "v";
                        }
                        else if (board[row + playerCy, colume + playerCx - 1] == 9)
                        {
                            return "h";
                        }
                    }
                }
            }
            return "n";
        }

        void PlayerMove(int dir)
        {
            playerCx += dir;
            if (CheckCollision(useBrick))
            {
                playerCx -= dir;
            }
            Refresh();
        }

        void GameRestart()
        {
            
            pGameover.Hide();
            Refresh();
            timer.Stop();
            playerCy = 1;
            playerdrop = 0;

            score = 0;
            level = 1;

            firstBrick = r.Next(1, 8);
            secondBrick = r.Next(1, 8);

            CreateGameboard(ref width, ref height);
            useBrick = Bricks(firstBrick);

            timer.Interval = 750;
            timer.Start();

            
            playerCx = (board.GetLength(1) / 2) - (useBrick.GetLength(0) / 2);

            lblLevel.Text = level.ToString();
            lblScore.Text = score.ToString();
        }

        void LevelChange()
        {
            if(score >= (500*level))
            {
                level++;
            }

            switch (level)
            {
                case 1:
                    timer.Interval = 750;
                    break;
                case 2:
                    timer.Interval = 650;
                    break;
                case 3:
                    timer.Interval = 550;
                    break;
                case 4:
                    timer.Interval = 450;
                    break;
                case 5:
                    timer.Interval = 350;
                    break;
                case 6:
                    timer.Interval = 250;
                    break;
                case 7:
                    timer.Interval = 150;
                    break;
                case 8:
                    timer.Interval = 100;
                    break;
                case 9:
                    timer.Interval = 75;
                    break;
                case 10:
                    timer.Interval = 50;
                    break;
                case 11:
                    timer.Interval = 45;
                    break;
                case 12:
                    timer.Interval = 40;
                    break;
                case 13:
                    timer.Interval = 35;
                    break;
                case 14:
                    timer.Interval = 30;
                    break;
                case 15:
                    timer.Interval = 25;
                    break;
            }

            lblLevel.Text = level.ToString();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameStarted)
            {
                if (e.KeyCode == Keys.Right)
                {
                    if (!CheckCollision(useBrick) && CheckWall(useBrick) != "h")
                    {
                        PlayerMove(1);
                    }
                }
                else if (e.KeyCode == Keys.Left)
                {
                    if (!CheckCollision(useBrick) && CheckWall(useBrick) != "v")
                    {
                        PlayerMove(-1);
                    }
                }
                else if (e.KeyCode == Keys.Down)
                {
                    DropBrick();
                    playerCy++;
                    playerdrop = 1;
                    Refresh();
                }
                else if (e.KeyCode == Keys.Up)
                {
                    if (!CheckCollision(useBrick))
                    {
                        Rotate(useBrick);
                    }
                    Refresh();
                }
                else if (e.KeyCode == Keys.R)
                {
                    GameRestart();
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }

        }

        
    }
}
