//RABIA BASHIR
//BSE-6B
//144
                                                                 //Checker Game
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyCheckerGame;
//Main Flow
//Sound Player
 //All pieces(red,black) are placed on the BlackPictureBox
//Check all pieces left and right Diagonal and make Possible Move
//First Turn is given to Blue Piece
//Left and Right Diagonal is shown by Grey Color
//Two Click 1 for select and other for move or jump
namespace MyCheckerGame
{
    public partial class Form1 : Form
    {


        //Dynamic Array for PictureBox(8 rows,4 col)
        PictureBox[,] Board = new PictureBox[8, 8]; //8 row and 4 col
        PictureBox FirstClickBox; //when click on any box it is saved in it
        PictureBox leftDiagonaldown, rightDiagonaldown; //leftDiagonalBox and RightDiagonalBox for pieces
        PictureBox leftDiagonalup, rightDiagonalup;
        PictureBox leftJumpBoxdown, rightJumpBoxdown;
        PictureBox leftJumpBoxup, rightJumpBoxup;



        String Turn;
        int Click;

        public Form1()
        {
            InitializeComponent();
            CreateBoad();

            boardPanel.SendToBack(); //send panel to back end and create a board on it.
            SetPieces();


            Turn = "blue"; //First turn is given to Blue piece
            Click = 0;


            leftDiagonaldown = null;
            rightDiagonaldown = null;
            leftDiagonalup = null;
            rightDiagonalup = null;
            leftJumpBoxdown = null;
            rightJumpBoxdown = null;
            leftJumpBoxup = null;
            rightJumpBoxup = null;

        }

        private void CreateBoad()
        {

            //x-cordinate or starting location along x-axis
            int x = 20;
            //y-cordinate or starting location along y-axis
            int y = 20;
            //loop for rows
            int j = 0;
            for (int i = 0; i < 8; i++)
            {
                j = 0;
                if (i % 2 == 0) //if even no of row
                {
                    x = 20 + 70; //add starting location ie 20 to picturebox size i.e 70
                    j = j + 1;
                }
                else
                {
                    x = 20; //to get odd no of rows
                }
                while (j < 8)
                {
                    //loop for  Col

                    Board[i, j] = new PictureBox();
                    Board[i, j].Location = new Point(x, y);
                    Board[i, j].Size = new Size(70, 70);
                    Board[i, j].BackColor = Color.Black;
                    Board[i, j].AccessibleName = "none";
                    Board[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    Board[i, j].Tag = i.ToString() + j.ToString(); //naming the Tag according to row and col(to get row no and col no)
                    Board[i, j].Click += new EventHandler(BoxClicked); //Create a click event(Event Handler)
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
            for (int i = 0; i < 8; i++) //loop for row
            {
                j = 0;
                if (i % 2 == 0)// if even
                {
                    j = j + 1;
                }
                while (j < 8)

                    if (i == 0 || i == 1 || i == 2) //set blue pieces in row 1,2,3
                    {
                        Board[i, j].BackgroundImage = MyCheckerGame.Properties.Resources.blue_piece;
                        Board[i, j].AccessibleName = "blue";
                    }
                if (i == 5 || i == 6 || i == 7) //set red pieces in row 6,7,8
                {
                    Board[i, j].BackgroundImage = MyCheckerGame.Properties.Resources.red_piece;
                    Board[i, j].AccessibleName = "red";
                }
                j = j + 2;
            }
        }

        private void BoxClicked(object sender, EventArgs e)
        {
            PictureBox clickedBox = (PictureBox)sender; //type casting to convert sender into picture box and save in clickedBox
            if (Turn == "blue") //clickedBox AccessibleName=="blue"
            {
                if (clickedBox.AccessibleName == "red")
                {
                    //clicked on wrong piece
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
                    //clicked on wrong piece
                }
                else
                {
                    // TurnRed(clickedBox);
                }

            }
        }

    




        private void TurnBlue(PictureBox clickedBox)
        {
            int row, col;
            string location = clickedBox.Tag.ToString();

            row = Convert.ToInt32(location[0]) - 48; //to get  row no instead of its assci value and convert to integer
            col = Convert.ToInt32(location[1]) - 48; //to get  col no instaed of its assci value and convert to integer

            //For 1st Click as 1st Turn is given to Blue
            if (Click == 0 && clickedBox.AccessibleName == "blue")   //For simple blue piece
            {

                FirstClickBox = Board[row, col]; //when 1st click on ony box its row,col saved in FirstClickBox

                if ((row + 1 < 8) && (col - 1 >= 0)) //left down diagonal possible
                {
                    if (Board[row + 1, col - 1].AccessibleName == "none") //simple left move
                    {
                        leftDiagonaldown = Board[row + 1, col - 1];
                    }
                    else if (Board[row + 1, col - 1].AccessibleName == "red" || Board[row + 1, col - 1].AccessibleName == "redKing") //if red on diagonal
                    {
                        if ((row + 2 < 8) && (col - 2 >= 0)) //left down jump diagonal possible
                        {
                            if (Board[row + 2, col - 2].AccessibleName == "none")
                            {
                                leftJumpBoxdown = Board[row + 1, col - 1];
                                leftDiagonaldown = Board[row + 2, col - 2];
                            }
                        }
                    }
                    else
                    { //when no leftdiagonaldown and no rightdiagonaldown
                        leftJumpBoxdown = null;
                        leftDiagonaldown = null;
                    }
                }

                if ((row + 1 < 8) && (col + 1 < 8)) // right down diagnol possible
                {
                    if (Board[row + 1, col + 1].AccessibleName == "none") //simple right move
                    {
                        rightDiagonaldown = Board[row + 1, col + 1];
                    }
                    else if (Board[row + 1, col + 1].AccessibleName == "red" || Board[row + 1, col + 1].AccessibleName == "redKing") //if red on diagonal
                    {
                        if ((row + 2 < 8) && (col + 2 < 8)) //left down jump diagonal possible
                        {
                            if (Board[row + 2, col + 2].AccessibleName == "none")
                            {
                                rightJumpBoxdown = Board[row + 1, col + 1];
                                rightDiagonaldown = Board[row + 2, col + 2];
                            }
                        }
                    }
                    else  // when no rightJumpBoxdown or rightDiagonaldown exist
                    {
                        rightJumpBoxdown = null;
                        rightDiagonaldown = null;
                    }
                }

                FirstClickBox.BackColor = Color.Gray;
                if (leftDiagonaldown != null)
                    leftDiagonaldown.BackColor = Color.Gray;
                if (rightDiagonaldown != null)
                    rightDiagonaldown.BackColor = Color.Gray;

                Click = 1;
            }
            else if (Click == 0 && clickedBox.AccessibleName == "blueKing") //for blue King
            {
                FirstClickBox = Board[row, col];

                if ((row - 1 >= 0) && (col - 1 >= 0)) //leftup diagonal possible
                {
                    if (Board[row - 1, col - 1].AccessibleName == "none") //When AccessibleName is none
                    {
                        leftDiagonalup = Board[row - 1, col - 1];
                    }
                    else if (Board[row - 1, col - 1].AccessibleName == "red" || Board[row - 1, col - 1].AccessibleName == "redKing")
                    {
                        if ((row - 2 >= 0) && (col - 2 >= 0))
                        {
                            if (Board[row - 2, col - 2].AccessibleName == "none")
                            {
                                leftJumpBoxup = Board[row - 1, col - 1];
                                leftDiagonalup = Board[row - 2, col - 2];
                            }
                        }
                    }
                    else // when no leftJumpBoxup or no leftDiagonalup exist
                    {
                        leftJumpBoxup = null;
                        leftDiagonalup = null;
                    }
                }
                if ((row + 1 < 8) && (col - 1 >= 0)) //leftdowndiagonal is possible
                {
                    if (Board[row + 1, col - 1].AccessibleName == "none") //when accessiblename is none
                    {
                        leftDiagonaldown = Board[row + 1, col - 1];
                    }
                    else if (Board[row + 1, col - 1].AccessibleName == "red" || Board[row + 1, col - 1].AccessibleName == "redKing")
                    {
                        if ((row + 2 < 8) && (col - 2 >= 0))
                        {
                            if (Board[row + 2, col - 2].AccessibleName == "none")
                            {
                                leftJumpBoxdown = Board[row + 1, col - 1];
                                leftDiagonaldown = Board[row + 2, col - 2];
                            }
                        }
                    }
                    else //when no leftJumpBoxdown or no leftDiagonaldown
                    {
                        leftJumpBoxdown = null;
                        leftDiagonaldown = null;
                    }
                }
                if ((row - 1 >= 0) && (col + 1 < 8)) //rightup diagonal possible
                {
                    if (Board[row - 1, col + 1].AccessibleName == "none")
                    {
                        rightDiagonalup = Board[row - 1, col + 1];
                    }
                    else if (Board[row - 1, col + 1].AccessibleName == "red" || Board[row - 1, col + 1].AccessibleName == "redKing")
                    {
                        if ((row - 2 >= 0) && (col + 2 < 8))
                        {
                            if (Board[row - 2, col + 2].AccessibleName == "none")
                            {
                                rightJumpBoxup = Board[row - 1, col + 1];
                                rightDiagonalup = Board[row - 2, col + 2];

                            }
                        }
                    }
                    else
                    {
                        rightJumpBoxup = null;
                        rightDiagonalup = null;
                    }
                }
                if ((row + 1 < 8) && (col + 1 < 8)) //rightdowndiagonal possible
                {
                    if (Board[row + 1, col + 1].AccessibleName == "none")
                    {
                        rightDiagonaldown = Board[row + 1, col + 1];
                    }
                    else if (Board[row + 1, col + 1].AccessibleName == "red" || Board[row + 1, col + 1].AccessibleName == "redKing")
                    {
                        if ((row + 2 < 8) && (col + 2 < 8))
                        {
                            if (Board[row + 2, col + 2].AccessibleName == "none")
                            {
                                rightJumpBoxdown = Board[row + 1, col + 1];
                                rightDiagonaldown = Board[row + 2, col + 2];
                            }
                        }
                    }
                    else
                    {
                        rightJumpBoxdown = null;
                        rightDiagonaldown = null;
                    }
                }
                FirstClickBox.BackColor = Color.Gray;
                if (leftDiagonaldown != null)
                    leftDiagonaldown.BackColor = Color.Gray;
                if (rightDiagonaldown != null)
                    rightDiagonaldown.BackColor = Color.Gray;
                if (leftDiagonalup != null)
                    leftDiagonalup.BackColor = Color.Gray;
                if (rightDiagonalup != null)
                    rightDiagonalup.BackColor = Color.Gray;
                Click = 1;
            }

            else if (Click == 1) //second click
            {
                //check if clicked on diagonals
                if (clickedBox == leftDiagonaldown || clickedBox == leftDiagonalup || clickedBox == rightDiagonaldown || clickedBox == rightDiagonalup)
                {
                    clickedBox.BackColor = Color.Gray;
                }
            }
        }
    }
}
        
    

    




        



        
    







            
      
       

 
        



        


                         
                
                

                
            
        
        
        
        

                
         

        
