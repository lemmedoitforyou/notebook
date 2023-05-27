using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteApplication
{
    public partial class GameForm : Form
    { 
        private Timer timer;
        private int score;
        private int hearts;
        private Random coordinateRandom;
        private Random diameterRandom;
        private Random colorPickerRandom;
        private int timeBetweenAppearances;
        private int timeToClick;
        private const int maxBallSize = 100;
        private const int minBallSize = 20;
        private int ballsClicked;
        private int currentMinBallSize;
        private const string recordsFile = "..\\..\\Records.csv";
        public GameForm()
        {
            InitializeComponent();
            InitializeGame();
        }
        private void InitializeGame()
        {
            Controls.Remove(gameOverLabel);
            Controls.Remove(scoreLabel);
            Controls.Remove(heartsLabel);
            Controls.Remove(mainMenuButton);
            Controls.Add(exitButton);
            score = 0;
            hearts = 3;
            ballsClicked = 0;
            currentMinBallSize = maxBallSize;
            timeBetweenAppearances = 2000;
            timeToClick = 2000;
            coordinateRandom = new Random();
            diameterRandom = new Random();
            colorPickerRandom = new Random();

            timer = new Timer();
            timer.Interval = 3000;
            timer.Tick += Timer_Tick;

            #region RecordTable Values Adding
            recordsTable.Rows.Clear();
            recordsTable.Columns.Clear();
            recordsTable.Columns.Add("Place", "Place");
            recordsTable.Columns.Add("Score", "Score");
            recordsTable.Columns.Add("Date", "Date");

            List<List<string>> userRecords = new List<List<string>>();

            using (StreamReader reader = new StreamReader(recordsFile))
            {
                reader.ReadLine();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');

                    if (fields.Length == 2)
                    {
                        string date = fields[1];
                        string recordsScore = fields[0];
                        userRecords.Add(new List<string> { recordsScore, date });
                    }
                }
            }

            userRecords.Sort((x, y) => Convert.ToInt32(y[0]).CompareTo(Convert.ToInt32(x[0])));

            for (int i = 0; i < 10; i++)
            {
                if (i < userRecords.Count)
                {
                    recordsTable.Rows.Add((i + 1).ToString(), userRecords[i][0], userRecords[i][1]);
                }
            }
            #endregion RecordTable Values Adding
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            Controls.Remove(startButton);
            Controls.Remove(recordsTable);
            Controls.Remove(exitButton);
            timer.Start();
            Cursor = Cursors.Cross;
            Controls.Add(scoreLabel);
            Controls.Add(heartsLabel);
            scoreLabel.Visible = true;
            heartsLabel.Visible = true;
            UpdateHeartsLabel();
            UpdateScoreLabel();
        }

        private void UpdateHeartsLabel()
        {
            heartsLabel.Text = "Hearts: ";
            for (int i = 0; i < hearts; i++)
            {
                heartsLabel.Text += "♥";
            }
        }

        private void UpdateScoreLabel()
        {
            scoreLabel.Text = $"Score: {score}";
        }

        private void Ball_Click(object sender, EventArgs e)
        {
            var ball = (Ball)sender;
            var ballTimer = (Timer)ball.Tag;
            ballTimer.Stop();

            ball.ScoreByColor(ref hearts, ref score);
            UpdateHeartsLabel();
            if (hearts == 0)
            {
                GameOver();
            }

            Controls.Remove(ball);
            UpdateScoreLabel();
            if (ballsClicked % 2 == 0)
            {
                if (timeToClick > 1000)
                {
                    timeBetweenAppearances = timeBetweenAppearances - (int)timeBetweenAppearances / 10;
                    timeToClick = timeBetweenAppearances;
                }
            }
            if (ballsClicked % 3 == 0)
            {
                if (currentMinBallSize > minBallSize)
                {
                    currentMinBallSize = (int)(currentMinBallSize - currentMinBallSize / 10);
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            int diameter = diameterRandom.Next(currentMinBallSize, maxBallSize);

            int x = coordinateRandom.Next(ClientSize.Width - 50 - diameter);
            int y = coordinateRandom.Next(ClientSize.Height - 50 - diameter);

            var ball = new Ball(diameter, x, y, colorPickerRandom);
            ball.Click += Ball_Click;

            var ballTimer = new Timer();
            ballTimer.Interval = timeToClick;
            ballTimer.Tick += BallTimer_Tick;
            ballTimer.Tag = ball;

            ball.Tag = ballTimer;
            Controls.Add(ball);

            ballTimer.Start();

            timer.Interval = timeBetweenAppearances;
        }

        private void BallTimer_Tick(object sender, EventArgs e)
        {
            var ballTimer = (Timer)sender;
            ballTimer.Stop();
            ballTimer.Tick -= BallTimer_Tick;

            var ball = (Ball)ballTimer.Tag;
            Controls.Remove(ball);
            ball.BallDisappearHpHandler(ref hearts, ref score);
            UpdateScoreLabel();
            ball.Dispose();

            UpdateHeartsLabel();

            if (hearts == 0)
            {
                GameOver();
            }
        }

        private async void GameOver()
        {
            timer.Stop();
            Cursor = Cursors.Default;
            Controls.Clear();

            Controls.Add(gameOverLabel);
            Controls.Add(mainMenuButton);
            Controls.Add(exitButton);
            gameOverLabel.Text = $"Game over \nYour score: {score}";
            string[] lines = File.ReadAllLines(recordsFile);
            DateTime date = DateTime.Now;

            string recordLine = $"{score},{date}";

            Array.Resize(ref lines, lines.Length + 1);
            lines[lines.Length - 1] = recordLine;

            await Task.Run(() =>
            {
                File.WriteAllLines(recordsFile, lines);
            });
        }

        private void playAgainButton_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            Controls.Add(startButton);
            Controls.Add(recordsTable);
            InitializeGame();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mainMenuButton_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            Controls.Add(startButton);
            Controls.Add(recordsTable);
            InitializeGame();
        }
    }
}
