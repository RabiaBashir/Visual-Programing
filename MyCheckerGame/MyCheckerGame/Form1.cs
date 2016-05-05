﻿//Rabia Bashir
//BSE-6B
//01-133132-144
                                                            //VP PROJECT
//Project Main flow                                                           //Checker Game
//Sound Player
//Sound system for single click and jumps
//All pieces(red,blue) are placed on the BlackPictureBox
//Check all pieces left and right Diagonal and make Possible Move
//First Turn is given to Blue Piece
//Blue piece move leftdown diagonal and rightdown diagonal
//Red piece move leftup diagonal and rightup diagonal
//Leftup, Rightup ,LeftDown,RightDown Diagonal is shown by Grey Color
//Leftjumpboxup,leftjumpboxdown.rightjumpboxup,rightjumpboxdown for every bluepiece,redpiece blueking.redking
// Both King Move Forward Diagonal as well as Backward Diagonal
//Scorepanel for both pieces(red,blue)
//Wining panel for both pieces
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
        PictureBox[,] Board = new PictureBox[8, 8]; //8 row and 8 col
        PictureBox Firstclickbox; //on which we 1st click
        PictureBox leftdiagnoldown, rightdiagnoldown;
        PictureBox leftdiagnolup, rightdiagnolup;
        PictureBox leftjumpboxdown, rightjumpboxdown;
        PictureBox leftjumpboxup, rightjumpboxup;
        String turn;
        int click;

        public Form1()
        {
            InitializeComponent();
            creatingboard();
            boardpanel.SendToBack();
            settingpieces();
            turn = "blue";
            click = 0;
            //initially all the diagonal and jump box is null
            leftdiagnoldown = null;
            rightdiagnoldown = null;
            leftdiagnolup = null;
            rightdiagnolup = null;
            leftjumpboxup = null;
            rightjumpboxup = null;
            leftjumpboxdown = null;
            rightjumpboxdown = null;

        }

        private void Clicked(object sender, EventArgs e)
        {
            PictureBox clickedBox = (PictureBox)sender; //type casting to convert sender into clickedBox of PictureBox data type

            if (turn == "blue")
            {
                if (clickedBox.AccessibleName == "red")
                {
                    // clicked on the wrong piece
                }
                else
                {
                    blueturn(clickedBox); //BlueTurn execute
                }

            }
            else if (turn == "red")
            {
                if (clickedBox.AccessibleName == "blue")
                {
                    //clicked on wrong piece
                }
                else
                {
                    redturn(clickedBox); //redturn execute
                }

            }
        }

        private void creatingboard()
        {
            int x = 20; //starting location along x-axis
            int y = 20; //starting location along y-axis
            int j = 0;
            //loop for row
            for (int i = 0; i < 8; i++)
            {
                j = 0;
                if (i % 2 == 0) //if Even
                {
                    x = 20 + 70; //1st even picturebox location
                    j = j + 1; //to get 1st col(i.e 1) ans so on
                }
                else
                {
                    x = 20; //otherwise make box  from starting location (i.e for old row)
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
                    Board[i, j].Tag = i.ToString() + j.ToString(); // naming tag according to row and col(to store reference of object)
                    Board[i, j].Click += new EventHandler(Clicked);// Create a click event(Event Handler)
                    this.Controls.Add(Board[i, j]); //Add all these controls
                    x += 140; // 70+70 to get picturebox
                    j = j + 2; //2 col difference
                }
                y += 70; //along y only 70 difference
            }
        }

        private void settingpieces()
        {
            int j = 0;
            for (int i = 0; i < 8; i++)
            {
                j = 0;
                if (i % 2 == 0) //if Even
                {
                    j = j + 1; //to get col(i.e 1)
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

        //For Blue leftdowndiagonal(leftjumpboxdown) and rightdowndiagonal(rightjumpboxdown)
        private void blueturn(PictureBox clickedBox)
        {

            int row, col;
            string location = clickedBox.Tag.ToString(); //convert tag into string and save it in location
            row = Convert.ToInt32(location[0]) - 48; //to get row no instead of its asscci value
            col = Convert.ToInt32(location[1]) - 48; //to get col no instead of its asscci value

            if (click == 0 && clickedBox.AccessibleName == "blue") //simple blue
            {

                Firstclickbox = Board[row, col]; //on which we 1st click

                if ((row + 1 < 8) && (col - 1 >= 0)) //left down diagnol possible
                {
                    if (Board[row + 1, col - 1].AccessibleName == "none") //simple left move
                    {
                        leftdiagnoldown = Board[row + 1, col - 1];
                    }
                    else if (Board[row + 1, col - 1].AccessibleName == "red" || Board[row + 1, col - 1].AccessibleName == "redking")//when opponent piece exist
                    {
                        if ((row + 2 < 8) && (col - 2 >= 0)) //leftdownjumpbox possible
                        {
                            if (Board[row + 2, col - 2].AccessibleName == "none")
                            {
                                leftjumpboxdown = Board[row + 1, col - 1];
                                leftdiagnoldown = Board[row + 2, col - 2];
                              //  leftjumpboxdown.BackgroundImage = null;
                              //  leftjumpboxdown.AccessibleName = "none";
                            }
                        }
                    }

                    else //no leftJumpBoxdown and no leftDiagonaldown exist
                    {
                        leftjumpboxdown = null;
                        leftdiagnoldown = null;
                    }
                }
                if ((row + 1 < 8) && (col + 1 < 8)) //right down diagnol possible
                {
                    if (Board[row + 1, col + 1].AccessibleName == "none") //simple right move
                    {
                        rightdiagnoldown = Board[row + 1, col + 1];
                    }
                    else if (Board[row + 1, col + 1].AccessibleName == "red" || Board[row + 1, col + 1].AccessibleName == "redking")
                    {
                        if ((row + 2 < 8) && (col + 1 < 8))
                        {
                            if (Board[row + 2, col + 2].AccessibleName == "none")
                            {
                                rightjumpboxdown = Board[row + 1, col + 1];
                                rightdiagnoldown = Board[row + 2, col + 2];
                            }
                        }
                    }
                    else //no rightJumpBoxdown and no rightDiagonaldown exist or available
                    {
                        rightjumpboxdown = null;
                        rightdiagnoldown = null;
                    }
                }
                
                //3 boxes should be Gray
                //1.The Box on which we click i.e our Firstclickbox
                //2.The leftdiagonaldown
                //3.The rightdiagonaldown
                Firstclickbox.BackColor = Color.Gray;
                if (leftdiagnoldown != null)
                    leftdiagnoldown.BackColor = Color.Gray;
                if (rightdiagnoldown != null)
                    rightdiagnoldown.BackColor = Color.Gray;
                click = 1;
            }

            else if (click == 1) // second click for move
            {
                // check if clicked on diagnols
                if (clickedBox == leftdiagnoldown || clickedBox == leftdiagnolup || clickedBox == rightdiagnoldown || clickedBox == rightdiagnolup)
                {
                    if (row == 7) //when reaches to last row of opponent
                    {
                        clickedBox.BackgroundImage = MyCheckerGame.Properties.Resources.blue_king_piece;
                        clickedBox.AccessibleName = "blueking";
                    }
                    else //when click on any row i.e row 0,1,2,3,4,5,6
                    {
                        clickedBox.BackgroundImage = Firstclickbox.BackgroundImage;
                        clickedBox.AccessibleName = Firstclickbox.AccessibleName;
                    }
                  
                    clickedBox.BackColor = Color.Gray;
                    
                    //Clear First click
                    Firstclickbox.BackgroundImage = null; // rest pic
                    Firstclickbox.AccessibleName = "none";
                    Firstclickbox.BackColor = Color.Black;

                    //reset diagnol colors to black
                    if (leftdiagnoldown != null)
                        leftdiagnoldown.BackColor = Color.Black;
                    if (leftdiagnolup != null)
                        leftdiagnolup.BackColor = Color.Black;
                    if (rightdiagnoldown != null)
                        rightdiagnoldown.BackColor = Color.Black;
                    if (rightdiagnolup != null)
                        rightdiagnolup.BackColor = Color.Black;

                    click = 0; //reset click to 0
                    turn = "red"; //red turn

                    //reset to null 
                    leftdiagnoldown = null;
                    rightdiagnoldown = null;
                    leftdiagnolup = null;
                    rightdiagnolup = null;

                }
                else // if click on other boxes exept diagnols reset the color of diagonal
                {
                    Firstclickbox.BackColor = Color.Black;
                    if (leftdiagnoldown != null)
                        leftdiagnoldown.BackColor = Color.Black;
                    if (leftdiagnolup != null)
                        leftdiagnolup.BackColor = Color.Black;
                    if (rightdiagnoldown != null)
                        rightdiagnoldown.BackColor = Color.Black;
                    if (rightdiagnolup != null)
                        rightdiagnolup.BackColor = Color.Black;

                    //reset all possible diagonal
                    leftdiagnolup = null;
                    rightdiagnolup = null;
                    leftdiagnoldown = null;
                    rightdiagnoldown = null;

                    click = 0; //reset click to 0
                }
            }
        }

        //For red check left up diagonal(leftjumpboxup) and right up diagonal (rightjumpboxup)
        private void redturn(PictureBox clickedBox)
        {
            int row, col;
            string location = clickedBox.Tag.ToString();//to convert tag into string and store in location

            row = Convert.ToInt32(location[0]) - 48; //to get row no instead of its asscci value
            col = Convert.ToInt32(location[1]) - 48; //to get col no instead of its asscci value

            if (click == 0 && clickedBox.AccessibleName == "red") //for simple red piece
            {
                Firstclickbox = Board[row, col]; //firstbox on whic we click
                if ((row - 1 >= 0) && (col - 1 >= 0)) //left diagonal up is possible
                {
                    if (Board[row - 1, col - 1].AccessibleName == "none") //when accessiblename is none just simple move
                    {
                        leftdiagnolup = Board[row - 1, col - 1];
                    }
                    else if (Board[row - 1, col - 1].AccessibleName == "blue" || Board[row - 1, col - 1].AccessibleName == "blueking")
                    {
                        if ((row - 2 >= 0) && (col - 2 >= 0))
                        {
                            if (Board[row - 2, col - 2].AccessibleName == "none")
                            {
                                leftjumpboxup = Board[row - 1, col - 1];
                                leftdiagnolup = Board[row - 2, col - 2];
                            }
                        }
                    }
                    else //when no leftJumpBoxup and leftDiagonalup exists or not possible both
                    {
                        leftjumpboxup = null;
                        leftdiagnolup = null;
                    }
                }
                if ((row - 1 >= 0) && (col + 1 < 8))  // right diagonal up is possible
                {
                    if (Board[row - 1, col + 1].AccessibleName == "none") //When accessiblename is none just simple move
                    {
                        rightdiagnolup = Board[row - 1, col + 1];
                    }
                    else if (Board[row - 1, col + 1].AccessibleName == "blue" || Board[row - 1, col + 1].AccessibleName == "blueking")
                    {
                        if ((row - 2 >= 0) && (col + 2 < 8))
                        {
                            if (Board[row - 2, col + 2].AccessibleName == "none")
                            {
                                rightjumpboxup = Board[row - 1, col + 1];
                                rightdiagnolup = Board[row - 2, col + 2];
                            }
                        }
                    }
                    else //when no rightJumpBoxup and rightDiagonalup exist or not possible both
                    {
                        rightjumpboxup = null;
                        rightdiagnolup = null;
                    }
                }
                //3 boxes should be Gray
                //1.The Box on which we click i.e our FirstClickBox
                //2.The leftdiagonalup
                //3.The rightDiagonalup
                Firstclickbox.BackColor = Color.Gray;
                if (leftdiagnolup != null)
                    leftdiagnolup.BackColor = Color.Gray;

                if (rightdiagnolup != null)
                    rightdiagnolup.BackColor = Color.Gray;
                click = 1;
            }

            else if (click == 1) //for second click to move
            {
                // check if clicked on diagnols
                if (clickedBox == leftdiagnoldown || clickedBox == leftdiagnolup || clickedBox == rightdiagnoldown || clickedBox == rightdiagnolup)
                {
                    if (row == 0) //when reaches to last row of opponent(i.e 0)
                    {
                        clickedBox.BackgroundImage = MyCheckerGame.Properties.Resources.red_king_piece;
                        clickedBox.AccessibleName = "redking";
                    }
                    else
                    {
                        clickedBox.BackgroundImage = Firstclickbox.BackgroundImage;//firstbox backgroundimage is given or save to clickedbox backgroundimage
                        clickedBox.AccessibleName = Firstclickbox.AccessibleName; //firstbox accessible name is given or save to clickedbox accessible name
                    }
                    //the diagonal on which we move or clicked its color is gray
                    clickedBox.BackColor = Color.Gray;

                    //Clear First click
                    Firstclickbox.BackgroundImage = null; // reset the firstclickbox
                    Firstclickbox.AccessibleName = "none";
                    Firstclickbox.BackColor = Color.Black;

                    //reset diagnol colors to black
                    if (leftdiagnoldown != null)
                        leftdiagnoldown.BackColor = Color.Black;
                    if (leftdiagnolup != null)
                        leftdiagnolup.BackColor = Color.Black;
                    if (rightdiagnoldown != null)
                        rightdiagnoldown.BackColor = Color.Black;
                    if (rightdiagnolup != null)
                        rightdiagnolup.BackColor = Color.Black;


                    click = 0; //reset click to 0
                    turn = "blue";//when turn is of blue

                    //reset to null all the diagonal left up,left down,right up,right down
                    leftdiagnoldown = null;
                    rightdiagnoldown = null;
                    leftdiagnolup = null;
                    rightdiagnolup = null;

                }
                else // if click on other boxes except diagnols reset its color
                {
                    Firstclickbox.BackColor = Color.Black;
                    if (leftdiagnoldown != null)
                        leftdiagnoldown.BackColor = Color.Black;
                    if (leftdiagnolup != null)
                        leftdiagnolup.BackColor = Color.Black;
                    if (rightdiagnoldown != null)
                        rightdiagnoldown.BackColor = Color.Black;
                    if (rightdiagnolup != null)
                        rightdiagnolup.BackColor = Color.Black;

                    //reset the all possible diagonal
                    leftdiagnoldown = null;
                    rightdiagnoldown = null;
                    leftdiagnolup = null;
                    rightdiagnolup = null;

                    click = 0; //reset click to 0
                }
            }

        }
       
    }

    
        }
        
    




