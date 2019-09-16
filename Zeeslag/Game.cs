using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zeeslag.Boards;

namespace Zeeslag
{
    public partial class Game : Form
    {
        private const int TurnDelay = 1000;

        private Size TileSize;
        private Point ownColumnStart;
        private Point shotColumnStart;

        private bool MayShoot = false;

        public List<PictureBox> OwnBoard { get; set; }
        public List<PictureBox> ShotBoard { get; set; }

        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        private TaskCompletionSource<Coordinates> hasShot;

        public Game()
        {
            InitializeComponent();

            Player1 = new Player("Amy");
            Player2 = new Player("Vince");

            //DEBUG
            this.KeyPreview = true;
            this.KeyPress +=
                new KeyPressEventHandler(Form1_KeyPress);
        }

        private async void PlayRound()
        {
            hasShot = new TaskCompletionSource<Coordinates>();

            Player1.OutputBoards(OwnBoard, ShotBoard);
            MayShoot = true;
            await hasShot.Task;
            MayShoot = false;

            var coordinates = hasShot.Task.Result;
            var result = Player2.ProcessShot(coordinates, lbResponse);
            Player1.ProcessShotResult(coordinates, result);
            Player1.OutputBoards(OwnBoard, ShotBoard);

            Thread.Sleep(TurnDelay);

            if (!Player2.HasLost)
            {
                coordinates = Player2.FireShot();
                result = Player1.ProcessShot(coordinates, lbResponse);
                Player2.ProcessShotResult(coordinates, result);
            }

            if (!Player1.HasLost && !Player2.HasLost)
            {
                PlayRound();
            }
        }

        private void PlayToEnd()
        {
            PlayRound();

            if (Player1.HasLost)
            {
                lbResponse.Text = $"{Player2.Name} has won the game!";
                return;
            }
            else if (Player2.HasLost)
            {
                lbResponse.Text = $"{Player1.Name} has won the game!";
                return;
            }
        }

        public void CreateBoard()
        {
            OwnBoard = new List<PictureBox>();
            ShotBoard = new List<PictureBox>();

            for (int row = 0; row <= 9; row++)
            {
                for (int ownColumn = 0; ownColumn <= 9; ownColumn++)
                {
                    var picture = new PictureBox
                    {
                        Name = $"OwnBoard_{row}_{ownColumn}",
                        Size = TileSize,
                        Location = new Point(ownColumnStart.X + TileSize.Width * ownColumn, ownColumnStart.Y + TileSize.Height * row),
                        BackColor = Color.AliceBlue,
                        BorderStyle = BorderStyle.FixedSingle,
                        BackgroundImageLayout = ImageLayout.Stretch,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Visible = true
                    };
                    OwnBoard.Add(picture);
                }

                for (int firingColumn = 0; firingColumn <= 9; firingColumn++)
                {
                    var picture = new PictureBox
                    {
                        Name = $"{row}_{firingColumn}",
                        Size = TileSize,
                        Location = new Point(shotColumnStart.X + TileSize.Width * firingColumn, shotColumnStart.Y + TileSize.Height * row),
                        BackColor = Color.AliceBlue,
                        BorderStyle = BorderStyle.FixedSingle,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Visible = true
                    };
                    picture.Click += new EventHandler(ShotboardClick);
                    ShotBoard.Add(picture);
                }
            }
            this.Controls.AddRange(OwnBoard.ToArray());
            this.Controls.AddRange(ShotBoard.ToArray());
        }

        private void btnPlacePlayer1_Click(object sender, EventArgs e)
        {
            Player1.PlaceShips();
            Player1.OutputBoards(OwnBoard, ShotBoard);
            placePlayer1.Enabled = false;
        }

        private void btnPlacePlayer2_Click(object sender, EventArgs e)
        {
            Player2.PlaceShips();
            Player2.OutputBoards(OwnBoard, ShotBoard);
            placePlayer2.Enabled = false;
        }

        private void ShotboardClick(object sender, EventArgs e)
        {
            if (MayShoot == true)
            {
                var pictureBox = (PictureBox)sender;
                var splitName = pictureBox.Name.Split(new[] { '_' }, 2);
                var coordinates = new Coordinates(Convert.ToInt16(splitName.First()) + 1, Convert.ToInt16(splitName.Last()) + 1);
                hasShot.TrySetResult(coordinates);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if(Player1.Ships.Any() && Player2.Ships.Any())
            {
                start.Enabled = false;
                PlayToEnd();
            }
        }

        private void btnGame_Load(object sender, EventArgs e)
        {
            TileSize = new Size(ClientRectangle.Width / 2 / 11, ClientRectangle.Width / 2 / 11);
            ownColumnStart = new Point(ClientRectangle.Width / 4 - (TileSize.Width * 5), ClientRectangle.Height - (TileSize.Height * 11));
            shotColumnStart = new Point(ClientRectangle.Width / 4 * 3 - (TileSize.Width * 5), ClientRectangle.Height - (TileSize.Height * 11));

            CreateBoard();
        }

        //DEBUG
        void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                switch (e.KeyChar)
                {
                    case (char)49:
                        Player1.OutputBoards(OwnBoard, ShotBoard);

                        break;
                    case (char)50:
                        Player2.OutputBoards(OwnBoard, ShotBoard);

                        break;
                }
            }
        }
    }
}