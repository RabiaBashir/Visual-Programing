using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCheckerGame
{
    public partial class Form1 : Form
    {
        PictureBox[,] Board = new PictureBox[8, 8];
        PictureBox FirstClickBox;
        PictureBox leftDiagnoldown, rightDiagnoldown;
        PictureBox leftDiagnolup, rightDiagnolup;
        PictureBox leftJumpBoxdown, rightJumpBoxdown;
        PictureBox leftJumpBoxup, rightJumpBoxup;
        String Turn;
        int click;

        public Form1()
        {
            InitializeComponent();
            CreateBoad();
            boardPanel.SendToBack();
            SetPieces();
            Turn = "blue";
            click = 0;

            leftDiagnoldown = null;
            rightDiagnoldown = null;
            leftDiagnolup = null;
            rightDiagnolup = null;
            leftJumpBoxup = null;
            rightJumpBoxup = null;
            leftJumpBoxdown = null;
            rightJumpBoxdown = null;

        }

        private void BoxClicked(object sender, EventArgs e)
        {
            PictureBox clickedBox = (PictureBox)sender;
            if (Turn == "blue") //clickedBox.AccessibleName=="blue" 
            {
                if (clickedBox.AccessibleName == "red")
                {
                    /// clicked wrong piece
                }
                else
                {
                    TurnBlue(clickedBox);
                }

            }
            else if (Turn == "red")
            {
                if (clickedBox.AccessibleName == "blue")
                {
                    /// clicked wrong piece
                }
                else
                {
                    TurnRed(clickedBox);
                }
            }

        }
        private void CreateBoad()
        {
            int x = 20;
            int y = 20;
            int j = 0;
            for (int i = 0; i < 8; i++)
            {
                j = 0;
                if (i % 2 == 0) //if Even
                {
                    x = 20 + 70;
                    j = j + 1;
                }
                else
                {
                    x = 20;
                }
                while (j < 8)
                {
                    Board[i, j] = new PictureBox();
                    Board[i, j].Location = new Point(x, y);
                    Board[i, j].Size = new Size(70, 70);
                    Board[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                    Board[i, j].BackColor = Color.Black;

                    Board[i, j].AccessibleName = "none";
                    Board[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    Board[i, j].Tag = i.ToString() + j.ToString(); // naming tag according to row and col
                    Board[i, j].Click += new EventHandler(BoxClicked);// Create a click event
                    this.Controls.Add(Board[i, j]);
                    x += 140;
                    j = j + 2;
                }
                y += 70;
            }
        }


        private void SetPieces()
        {
            int j = 0;
            for (int i = 0; i < 8; i++)
            {
                j = 0;
                if (i % 2 == 0) //if Even
                {
                    j = j + 1;
                }
                while (j < 8)
                {
                    if (i == 0 || i == 1 || i == 2) // set blue pieces in row 1 2 3
                    {
                        Board[i, j].BackgroundImage = MyCheckerGame.Properties.Resources.blue_piece;
                        Board[i, j].AccessibleName = "blue";

                    }
                    else if (i == 5 || i == 6 || i == 7) // set red pieces in row 6,7,8
                    {
                        Board[i, j].BackgroundImage = MyCheckerGame.Properties.Resources.red_piece;
                        Board[i, j].AccessibleName = "red";
                    }
                    j = j + 2;
                }
            }
        }

        //For Blue leftdowndiagonal(leftJumpBoxdown) and rightdowndiagonal(rightJumpBoxdown)
        private void TurnBlue(PictureBox clickedBox)
        {

            int row, col;
            string location = clickedBox.Tag.ToString();
            row = Convert.ToInt32(location[0]) - 48;
            col = Convert.ToInt32(location[1]) - 48;
            if (click == 0 && clickedBox.AccessibleName == "blue") //simple blue
            {

                FirstClickBox = Board[row, col];

                if ((row + 1 < 8) && (col - 1 >= 0)) //left down diagnol possible
                {
                    if (Board[row + 1, col - 1].AccessibleName == "none") //simple left move
                    {
                        leftDiagnoldown = Board[row + 1, col - 1];
                    }
                    else if (Board[row + 1, col - 1].AccessibleName == "red" || Board[row + 1, col - 1].AccessibleName == "redKing")// if red on diagnol
                    {
                        if ((row + 2 < 8) && (col - 2 >= 0)) //left down jump diagnol possible
                        {
                            if (Board[row + 2, col - 2].AccessibleName == "none")
                            {
                                leftJumpBoxdown = Board[row + 1, col - 1];
                                leftDiagnoldown = Board[row + 2, col - 2];
                            }
                        }
                    }
                    else //no leftJumpBoxdown and no leftDiagonaldown exist
                    {
                        leftJumpBoxdown = null;
                        leftDiagnoldown = null;
                    }
                }
                if ((row + 1 < 8) && (col + 1 < 8)) //right down diagnol possible
                {
                    if (Board[row + 1, col + 1].AccessibleName == "none") //simple right move
                    {
                        rightDiagnoldown = Board[row + 1, col + 1];
                    }
                    else if (Board[row + 1, col + 1].AccessibleName == "red" || Board[row + 1, col + 1].AccessibleName == "redKing")// if red on diagnol
                    {
                        if ((row + 2 < 8) && (col + 2 < 8)) //left down jump diagnol possible
                        {
                            if (Board[row + 2, col + 2].AccessibleName == "none")
                            {
                                rightJumpBoxdown = Board[row + 1, col + 1];
                                rightDiagnoldown = Board[row + 2, col + 2];
                            }
                        }
                    }
                    else //no rightJumpBoxdown and no rightDiagonaldown exist
                    {
                        rightJumpBoxdown = null;
                        rightDiagnoldown = null;
                    }
                }
                //3 boxes shoulD be Gray
                //1.The Box on which we click i.e our FirstClickBox
                //2.The leftdiagonaldown
                //3.The rightDiagonaldown
                FirstClickBox.BackColor = Color.Gray;
                if (leftDiagnoldown != null)
                    leftDiagnoldown.BackColor = Color.Gray;
                if (rightDiagnoldown != null)
                    rightDiagnoldown.BackColor = Color.Gray;
                click = 1;
            }

            else if (click == 1) // second click
            {
                // check if clicked on diagnols
                if (clickedBox == leftDiagnoldown || clickedBox == leftDiagnolup || clickedBox == rightDiagnoldown || clickedBox == rightDiagnolup)
                {

                    if (row == 7) //when blue piece reaches to last row i.e 7
                    {
                        clickedBox.BackgroundImage = MyCheckerGame.Properties.Resources.blue_king_piece; //blue piece become blueKing Piece
                        clickedBox.AccessibleName = "blueKing";
                    }
                    else //when row 0...6 the FirstClickBox AccessibleName and Background image shift  or save on the box we clicked i.e clickedBox
                    {
                        clickedBox.AccessibleName = FirstClickBox.AccessibleName;
                        clickedBox.BackgroundImage = FirstClickBox.BackgroundImage;
                    }

                    clickedBox.BackColor = Color.Gray;

                    ///Clear First click
                    FirstClickBox.BackgroundImage = null; // rest pic
                    FirstClickBox.AccessibleName = "none";
                    FirstClickBox.BackColor = Color.Black;

                    ///reset diagnol colors to black
                    if (leftDiagnoldown != null)
                        leftDiagnoldown.BackColor = Color.Black;
                    if (leftDiagnolup != null)
                        leftDiagnolup.BackColor = Color.Black;
                    if (rightDiagnoldown != null)
                        rightDiagnoldown.BackColor = Color.Black;
                    if (rightDiagnolup != null)
                        rightDiagnolup.BackColor = Color.Black;


                    click = 0;
                    Turn = "red";

                    //reset to null 
                    leftDiagnoldown = null;
                    rightDiagnoldown = null;
                    leftDiagnolup = null;
                    rightDiagnolup = null;

                }
                else // if click on other boxes exept diagnols //reset
                {
                    FirstClickBox.BackColor = Color.Black;
                    if (leftDiagnoldown != null)
                        leftDiagnoldown.BackColor = Color.Black;
                    if (leftDiagnolup != null)
                        leftDiagnolup.BackColor = Color.Black;
                    if (rightDiagnoldown != null)
                        rightDiagnoldown.BackColor = Color.Black;
                    if (rightDiagnolup != null)
                        rightDiagnolup.BackColor = Color.Black;

                    leftDiagnoldown = null;
                    rightDiagnoldown = null;
                    leftDiagnolup = null;
                    rightDiagnolup = null;


                    click = 0;
                }
            }
        }
        //For red check left up diagonal(leftJumpBoxup) and right up diagonal (rightJumpBoxup)
        private void TurnRed(PictureBox clickedBox)
        {
            int row, col;
            string location = clickedBox.Tag.ToString();

            row = Convert.ToInt32(location[0]) - 48;
            col = Convert.ToInt32(location[1]) - 48;

            if (click == 0 && clickedBox.AccessibleName == "red") //for simple red piece
            {
                if ((row - 1 >= 0) && (col - 1 >= 0)) //left diagonal up is possible
                {
                    if (Board[row - 1, col - 1].AccessibleName == "none") //when accessiblename is none just simple move
                    {
                        leftDiagnolup = Board[row - 1, col - 1];
                    }
                    else if (Board[row - 1, col - 1].AccessibleName == "blue" || Board[row - 1, col - 1].AccessibleName == "blueKing") //when accessiblename is blue and blueKing
                    {
                        if ((row - 2 >= 0) && (col - 2 >= 0)) // left jump Box up diagonal is possible
                        {
                            if (Board[row - 2, col - 2].AccessibleName == "none")
                            {
                                leftJumpBoxup = Board[row - 1, col - 1];
                                leftDiagnolup = Board[row - 2, col - 2];
                            }
                        }
                    }
                    else //when no leftJumpBoxup and leftDiagonalup exists or not possible both
                    {
                        leftJumpBoxup = null;
                        leftDiagnolup = null;
                    }
                }
                if ((row - 1 >= 0) && (col + 1 < 8))  // right diagonal up is possible
                {
                    if (Board[row - 1, col + 1].AccessibleName == "none") //When accessiblename is none just simple move
                    {
                        rightDiagnolup = Board[row - 1, col + 1];
                    }
                    else if (Board[row - 1, col + 1].AccessibleName == "blue" || Board[row - 1, col + 1].AccessibleName == "blueKing") //when accessible name is blue and blueKing
                    {
                        if ((row - 2 >= 0) && (col + 2 < 8)) //right JumpBox up diagonal is possible
                        {
                            if (Board[row - 2, col + 2].AccessibleName == "none")
                            {
                                rightJumpBoxup = Board[row - 1, col + 1];
                                rightDiagnolup = Board[row - 2, col + 2];
                            }
                        }
                    }
                    else //when no rightJumpBoxup and rightDiagonalup exist or not possible both
                    {
                        rightJumpBoxup = Board[row - 1, col + 1];
                        rightDiagnolup = Board[row - 2, col + 2];
                    }
                }
                //3 boxes shoulD be Gray
                //1.The Box on which we click i.e our FirstClickBox
                //2.The leftdiagonalup
                //3.The rightDiagonalup
                FirstClickBox.BackColor = Color.Gray;
                if (leftDiagnolup != null)
                    leftDiagnolup.BackColor = Color.Gray;

                if (rightDiagnolup != null)
                    rightDiagnolup.BackColor = Color.Gray;
                click = 1;
            }
            else if (click == 1) //for second click to move
            {
                // check if clicked on diagnols
                if (clickedBox == leftDiagnoldown || clickedBox == leftDiagnolup || clickedBox == rightDiagnoldown || clickedBox == rightDiagnolup)
                {

                    if (row == 0) //when blue piece reaches to row 0
                    {
                        clickedBox.BackgroundImage = MyCheckerGame.Properties.Resources.red_king_piece; //blue piece become blueKing Piece
                        clickedBox.AccessibleName = "blueKing";
                    }
                    else //when row 1..7 the FirstClickBox AccessibleName and Background image shift  or save on the box we clicked i.e clickedBox
                    {
                        clickedBox.AccessibleName = FirstClickBox.AccessibleName;
                        clickedBox.BackgroundImage = FirstClickBox.BackgroundImage;
                    }

                    clickedBox.BackColor = Color.Gray;

                    ///Clear First click
                    FirstClickBox.BackgroundImage = null; // rest pic
                    FirstClickBox.AccessibleName = "none";
                    FirstClickBox.BackColor = Color.Black;

                    ///reset diagnol colors to black
                    if (leftDiagnoldown != null)
                        leftDiagnoldown.BackColor = Color.Black;
                    if (leftDiagnolup != null)
                        leftDiagnolup.BackColor = Color.Black;
                    if (rightDiagnoldown != null)
                        rightDiagnoldown.BackColor = Color.Black;
                    if (rightDiagnolup != null)
                        rightDiagnolup.BackColor = Color.Black;


                    click = 0;
                    Turn = "blue";

                    //reset to null 
                    leftDiagnoldown = null;
                    rightDiagnoldown = null;
                    leftDiagnolup = null;
                    rightDiagnolup = null;

                }
                else // if click on other boxes exept diagnols //reset
                {
                    FirstClickBox.BackColor = Color.Black;
                    if (leftDiagnoldown != null)
                        leftDiagnoldown.BackColor = Color.Black;
                    if (leftDiagnolup != null)
                        leftDiagnolup.BackColor = Color.Black;
                    if (rightDiagnoldown != null)
                        rightDiagnoldown.BackColor = Color.Black;
                    if (rightDiagnolup != null)
                        rightDiagnolup.BackColor = Color.Black;

                    leftDiagnoldown = null;
                    rightDiagnoldown = null;
                    leftDiagnolup = null;
                    rightDiagnolup = null;


                    click = 0;
                }
            }

        }
    }
}











