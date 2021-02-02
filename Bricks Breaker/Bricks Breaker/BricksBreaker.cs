using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bricks_Breaker
{
    public partial class BricksBreaker : Form
    {
        public BricksBreaker()
        {
            InitializeComponent();
        }

        int score = 0;
        Board board = new Board(151, 399, 130, 10);
        Ball ball = new Ball(216, 390);
        Bricks bricks = new Bricks();
        DateTime beginTime = new DateTime();

        private void Welcome()
        {
            GameStart.Visible = true;
            GameTitle.Visible = true;
            Hint.Visible = true;

            GameBox.Visible = false;
            Suggestion.Visible = false;
            ScoreBoard.Visible = false;
            ScoreRec.Visible = false;
            PlayersTitle.Visible = false;
            BestPlayers.Visible = false;
            GameTime.Visible = false;

            GameOverTitle.Visible = false;
            NameRecTitle.Visible = false;
            NameRec.Visible = false;
            NameConfirm.Visible = false;

            Close.Visible = false;
        }

        private void GameStartFunc()
        {
            GameStart.Visible = false;
            GameTitle.Visible = false;
            Hint.Visible = false;

            string gamePageImagePath = Application.StartupPath;
            gamePageImagePath += @"\imgs\GamePage\GamePage.png";
            GameBox.BackgroundImage = Image.FromFile(gamePageImagePath);
            GameBox.BackgroundImageLayout = ImageLayout.Stretch;
            GameBox.Visible = true;

            Suggestion.Visible = true;
            ScoreBoard.Visible = true;
            ScoreRec.Visible = true;
            PlayersTitle.Visible = true;
            BestPlayers.Visible = true;
            GameTime.Visible = true;

            objectList.Add(board);
            objectList.Add(ball);
            objectList.Add(bricks);

            string nameListPath = Application.StartupPath;
            nameListPath += @"\data\PlayersNameList.txt";
            System.IO.StreamReader streamReader = new System.IO.StreamReader(nameListPath);
            BestPlayers.Text = streamReader.ReadToEnd();
            streamReader.Close();

            players.Add(new Player(BestPlayers.Lines[0]));
            players.Add(new Player(BestPlayers.Lines[1]));
            players.Add(new Player(BestPlayers.Lines[2]));
        }

        private void GameStart_Click(object sender, EventArgs e)
        {
            GameStartFunc();
            this.GameBox.Refresh();
        }

        private void BricksBreaker_Load(object sender, EventArgs e)
        {
            Welcome();
            string backgroundImagePath = Application.StartupPath;
            backgroundImagePath += @"\imgs\Welcome\BackGround.png";
            this.BackgroundImage = Image.FromFile(backgroundImagePath);
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        public const int BorderWidth = 15;
        List<Object> objectList = new List<Object> ();

        private void GameBox_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bitmap = new Bitmap(GameBox.Width, GameBox.Height);
            foreach(Object @object in objectList)
            {
                // @object.Draw(e.Graphics, this.GameBox);
                @object.Draw(Graphics.FromImage(bitmap), this.GameBox);
            }
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        public bool gameStarted = false;

        private void BricksBreaker_KeyDown(object sender, KeyEventArgs e)
        {
            if (GameBox.Visible)
            {
                switch (e.KeyData)
                {
                    case Keys.A:
                        if (gameStarted)
                        {
                            board.Move(Board.BoardDirection.Left, GameBox);
                        }
                        break;
                    case Keys.D:
                        if (gameStarted)
                        {
                            board.Move(Board.BoardDirection.Right, GameBox);
                        }
                        break;
                    case Keys.Space:
                        if (!gameStarted)
                        {
                            gameStarted = true;
                            Suggestion.Visible = false;
                            beginTime = System.DateTime.Now;
                            Action.Interval = 100;
                            Action.Start();
                        }
                        break;
                    default:
                        break;
                }
                // GameBox.Refresh();
            }
        }

        private int timeScore = 0;
        private const int timeScoreLoop = 15;
        private bool UpdateCheck()
        {
            return false;
        }

        private void Action_Tick(object sender, EventArgs e)
        {
            timeScore = (timeScore + 1) % timeScoreLoop;
            if(timeScore == 0)
            {
                score++;
            }
            ball.Run(GameBox, board, bricks, ref score);
            if (ball.touchedBound)
            {
                Action.Stop();
                GameOver();
            }
            GameBox.Refresh();

            if (UpdateCheck())
            {
                ball.SpeedUpdate();
            }

            ScoreRec.Text = score.ToString("D5");
            DateTime nowTime = System.DateTime.Now;
            TimeSpan gameTime = nowTime - beginTime;
            GameTime.Text = System.DateTime.MinValue.AddMilliseconds(gameTime.TotalMilliseconds).ToLongTimeString();
        }

        List<Player> players = new List<Player>();
        private int playerRank = -1;
        private void GameOver()
        {
            GameOverTitle.Visible = true;
            int index = 0;
            for(;index < players.Count; index++)
            {
                if(score >= players[index].score)
                {
                    for(int i = players.Count - 1;i > index; i--)
                    {
                        players[i] = players[i - 1];
                    }
                    playerRank = index;

                    NameRecTitle.Visible = true;
                    NameRec.Visible = true;
                    NameConfirm.Visible = true;

                    break;
                }
            }
            if(playerRank == -1)
            {
                GameOverButtons();
            }
        }

        private void NameConfirm_Click(object sender, EventArgs e)
        {
            string playerName = NameRec.Text;
            players[playerRank] = new Player(playerName, score);
            string[] lines = new string[players.Count];
            for(int i = 0;i < players.Count; i++)
            {
                lines[i] = (i + 1).ToString() + ". " + players[i].ToString();
            }
            string nameListPath = Application.StartupPath;
            nameListPath += @"\data\PlayersNameList.txt";
            System.IO.File.WriteAllLines(nameListPath, lines);
            
            System.IO.StreamReader streamReader = new System.IO.StreamReader(nameListPath);
            BestPlayers.Text = streamReader.ReadToEnd();
            streamReader.Close();

            GameOverButtons();
        }

        private void GameOverButtons()
        {
            NameRecTitle.Visible = false;
            NameRec.Visible = false;
            NameConfirm.Visible = false;

            Close.Visible = true;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    class Object
    {
        public int xPos { get; set; }
        public int yPos { get; set; }
        public Rectangle rectangle { get; set; }

        public bool isDelete = false;
        public virtual void Draw(Graphics g, PictureBox GameBox) { }
    }
    class Board : Object
    {
        /// <summary>
        /// 挡板自身宽度
        /// </summary>
        public int boardWidth, boardHeight;
        public int speedX { get; set; }

        public const double collsion_MaxAngleIncrement = 0.25;

        public enum BoardDirection
        {
            Left, Right, None
        }
        /// <summary>
        /// 构造挡板初始位置坐标，速度和宽度
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="speed"></param>
        public Board(int x, int y, int width, int height, int speedx=8)
        {
            this.xPos = x;
            this.yPos = y;
            this.speedX = speedx;
            boardWidth = width;
            boardHeight = height;
        }
        /// <summary>
        /// 绘制挡板
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g, PictureBox GameBox)
        {
            SolidBrush solidBrush = new SolidBrush(Color.BurlyWood);
            Pen pen = new Pen(Color.SaddleBrown, 2);
            rectangle = new Rectangle(GameBox.Left + xPos, GameBox.Top + yPos, boardWidth, boardHeight);
            g.DrawRectangle(pen, rectangle);
            g.FillRectangle(solidBrush, rectangle);
        }

        public void Move(BoardDirection direction, PictureBox GameBox)
        {
            switch (direction)
            {
                case BoardDirection.Left:
                    if(xPos - speedX > BricksBreaker.BorderWidth)
                    {
                        xPos -= speedX;
                    }
                    else
                    {
                        xPos = BricksBreaker.BorderWidth;
                    }
                    break;
                case BoardDirection.Right:
                    if(xPos + boardWidth + BricksBreaker.BorderWidth + speedX < GameBox.Width)
                    {
                        xPos += speedX;
                    }
                    else
                    {
                        xPos = GameBox.Width - boardWidth - BricksBreaker.BorderWidth;
                    }
                    break;
            }
        }
    }
    class Ball : Object
    {
        public const int radius = 8;
        public double speedAngle { get; set; }
        public int speedDis { get; set; }

        public bool touchedBound = false;

        private const int speedIncrement = 1;

        public Ball(int x, int y, double angle=0.5, int dis = 5)
        {
            this.xPos = x;
            this.yPos = y;
            this.speedAngle = angle;
            this.speedDis = dis;
        }

        public void SpeedUpdate()
        {
            this.speedDis += speedIncrement;
        }

        public override void Draw(Graphics g, PictureBox GameBox)
        {
            SolidBrush solidBrush = new SolidBrush(Color.LightGoldenrodYellow);
            Pen pen = new Pen(Color.SaddleBrown, 2);
            rectangle = new Rectangle(GameBox.Left + xPos - radius, GameBox.Top + yPos - radius, 2 * radius, 2 * radius);
            g.DrawEllipse(pen, rectangle);
            g.FillEllipse(solidBrush, rectangle);
        }

        private void Hit(Board board, Bricks brickset, ref int score)
        {
            for (int i = 0; i < brickset.bricks.Count; i++)
            {
                if (brickset.bricks[i].isDelete)
                {
                    continue;
                }

                int leftBound = brickset.bricks[i].xPos;
                int rightBound = leftBound + Brick.brickWidth;

                int upBound = brickset.bricks[i].yPos;
                int downBound = upBound + Brick.brickHeight;

                if(xPos < leftBound && xPos + radius >= leftBound)
                {
                    if(yPos > upBound && yPos < downBound)
                    {
                        xPos = leftBound - radius;
                        speedAngle = 1.0 - speedAngle;
                        brickset.bricks[i].isDelete = true;
                        score += Brick.score;
                    }
                    if(yPos == downBound)
                    {
                        xPos = leftBound - radius;
                        speedAngle = 1.0 - speedAngle;
                        brickset.bricks[i].isDelete = true;
                        score += Brick.score;
                        if (i + Bricks.width < brickset.bricks.Count && !brickset.bricks[i + Bricks.width].isDelete)
                        {
                            brickset.bricks[i + Bricks.width].isDelete = true;
                            score += Brick.score;
                        }
                    }
                    
                }
                else if(xPos > rightBound && xPos - radius <= rightBound)
                {
                    if(yPos > upBound && yPos < downBound)
                    {
                        xPos = rightBound + radius;
                        speedAngle = 1.0 - speedAngle;
                        brickset.bricks[i].isDelete = true;
                        score += Brick.score;
                    }
                    if (yPos == downBound)
                    {
                        xPos = rightBound + radius;
                        speedAngle = 1.0 - speedAngle;
                        brickset.bricks[i].isDelete = true;
                        score += Brick.score;
                        if (i + Bricks.width < brickset.bricks.Count && !brickset.bricks[i + Bricks.width].isDelete)
                        {
                            brickset.bricks[i + Bricks.width].isDelete = true;
                            score += Brick.score;
                        }
                    }
                }
                else if(yPos < upBound && yPos + radius >= upBound)
                {
                    if(xPos > leftBound && xPos < rightBound)
                    {
                        yPos = upBound - radius;
                        speedAngle = -speedAngle;
                        brickset.bricks[i].isDelete = true;
                        score += Brick.score;
                    }
                    if(xPos == rightBound)
                    {
                        yPos = upBound - radius;
                        speedAngle = -speedAngle;
                        brickset.bricks[i].isDelete = true;
                        score += Brick.score;
                        if(i % Bricks.width < 5 && !brickset.bricks[i + 1].isDelete)
                        {
                            brickset.bricks[i + 1].isDelete = true;
                            score += Brick.score;
                        }
                    }

                }
                else if(yPos > downBound && yPos - radius <= downBound)
                {
                    if (xPos > leftBound && xPos < rightBound)
                    {
                        yPos = downBound + radius;
                        speedAngle = -speedAngle;
                        brickset.bricks[i].isDelete = true;
                        score += Brick.score;
                    }
                    if (xPos == rightBound)
                    {
                        yPos = downBound + radius;
                        speedAngle = -speedAngle;
                        brickset.bricks[i].isDelete = true;
                        score += Brick.score;
                        if (i % Bricks.width < 5 && !brickset.bricks[i + 1].isDelete)
                        {
                            brickset.bricks[i + 1].isDelete = true;
                            score += Brick.score;
                        }
                    }
                }
            }

            if (yPos < board.yPos && yPos + radius >= board.yPos && xPos >= board.xPos && xPos <= board.xPos + board.boardWidth)
            {
                yPos = board.yPos - radius - 1;
                speedAngle = -speedAngle;

                int dis = board.xPos + board.boardWidth / 2 - xPos;
                double angleIncrement = (double)dis / (double)board.boardWidth * Board.collsion_MaxAngleIncrement;
                speedAngle += angleIncrement;
            }
        }

        public void Run(PictureBox GameBox, Board board, Bricks bricks, ref int score)
        {
            int xDis = (int)(speedDis * Math.Cos(Math.PI * speedAngle));
            int yDis = -(int)(speedDis * Math.Sin(Math.PI * speedAngle));

            xPos += xDis;
            yPos += yDis;

            Hit(board, bricks, ref score);

            if (xPos + radius + BricksBreaker.BorderWidth >= GameBox.Width)
            {
                xPos = GameBox.Width - BricksBreaker.BorderWidth - radius;
                speedAngle = 1.0 - speedAngle;
            }
            if(xPos - radius <= BricksBreaker.BorderWidth)
            {
                xPos = BricksBreaker.BorderWidth + radius;
                speedAngle = 1.0 - speedAngle;
            }

            if(yPos + radius >= board.yPos + board.boardHeight)
            {
                yPos = board.yPos + board.boardHeight - radius;
                speedAngle = -speedAngle;
                this.touchedBound = true;
            }
            if(yPos - radius <= BricksBreaker.BorderWidth)
            {
                yPos = BricksBreaker.BorderWidth + radius;
                speedAngle = -speedAngle;
            }
        }
    }

    class Brick : Object
    {
        public const int brickWidth = 67, brickHeight = 20;

        public const int score = 5;
        public Brick() { }
        public Brick(int x, int y)
        {
            xPos = x;
            yPos = y;
        }

        public override void Draw(Graphics g, PictureBox GameBox)
        {
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(181, 99, 0));
            Pen pen = new Pen(Color.SaddleBrown, 4);
            rectangle = new Rectangle(GameBox.Left + xPos, GameBox.Top + yPos, brickWidth, brickHeight);
            g.DrawRectangle(pen, rectangle);
            g.FillRectangle(solidBrush, rectangle);
        }
    }
    class Bricks : Object
    {
        private const int _width = 402+BricksBreaker.BorderWidth, _height = 140+BricksBreaker.BorderWidth;

        public const int width = 6, height = 7;
        public List<Brick> bricks { get; set; }
        public Bricks()
        {
            MakeBrickWall();
        }
        private void MakeBrickWall()
        {
            bricks = new List<Brick>();
            for (int y = 15; y < _height; y += Brick.brickHeight) 
            {
                for (int x = 15;x < _width;x += Brick.brickWidth)
                {
                    Brick brick = new Brick(x, y);
                    bricks.Add(brick);
                }
            }
        }
        public override void Draw(Graphics g, PictureBox GameBox)
        {
            foreach(Brick brick in bricks)
            {
                if(brick.isDelete)
                {
                    continue;
                }
                brick.Draw(g, GameBox);
            }
        }
    }

    class Player
    {
        public string name;
        public int score;
        public Player(string line)
        {
            string[] info = line.Split(' ');
            this.name = info[1];
            this.score = Convert.ToInt32(info[2]);
        }
        public Player(string nam, int scor)
        {
            this.name = nam;
            this.score = scor;
        }
        public override string ToString()
        {
            return name + " " + score.ToString("D5");
        }
    }
}