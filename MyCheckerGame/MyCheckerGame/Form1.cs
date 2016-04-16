using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 //All pieces(red,black) are placed on the BlackPictureBox
//Check all pieces left and right Diagonal and make Possible Move
//First Turn is given to Blue Piece
//Left and Right Diagonal is shown by Grey Color
namespace MyCheckerGame
{
    public partial class Form1 : Form
    {
        //Dynamic Array for PictureBox(8 rows,4 col)
        PictureBox[,] Board = new PictureBox[8, 4];
        PictureBox FirstClickBox;
        PictureBox leftDiagonalBox;
        PictureBox rightDiagonalBox;
        String Turn;
        int Click;

        public Form1()
        {
            InitializeComponent();
            CreateBoard();
            //boardPanel.SendToBack();
            SetPieces();
            Click = 0;
            EnableBluePieces();
            Turn = "blue"; //First turn is given to Blue piece
            //enableRed();
            //disableBlue();
            //disableRed();

        }

        private void EnableBluePieces()
        {
            
        }

        //Function to Create Borad of the Game
        private void CreateBoard()
        {
            //x-cordinate even row start from here
            int x = 150;
            //y-cordinate
            int y = 20;
            //loop for rows
            for (int i = 0; i < 8; i++)
            {
                if (i % 2 == 0) //if even no of row
                    x = 150 + 70; //to get 2nd so on even rows
                else
                    x = 150; //to get even no of rows
                //loop for odd Col
                for (int j = 0; j < 4; j++)
                {
                    Board[i, j] = new PictureBox();
                    Board[i, j].Location = new Point(x, y);
                    Board[i, j].Size = new Size(70, 70);
                    Board[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                    Board[i, j].BackColor = Color.Black;
                    Board[i, j].AccessibleName = "none";
                    Board[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    Board[i, j].Tag = i.ToString() + j.ToString(); //naming the Tag according to row and col
                    Board[i, j].Click += new EventHandler(BoxClicked); //Create a click event
                    this.Controls.Add(Board[i, j]);
                    x += 140; 
                }
                y += 70;
            }
        }
        private void SetPieces()
        {
            for (int i = 0; i < 8; i++) //loop for row
            {
                for (int j = 0; j < 4; j++) //loop for 
                {
                    if (i == 0 || i == 1 || i == 2) //set blue pieces in row 1,2,3

                    Board[i, j].BackgroundImage = MyCheckerGame.Properties.Resources.blue_piece;
                    Board[i, j].AccessibleName = "blue";

                    if (i == 5 || i == 6 || i == 7) //set red pieces in row 6,7,8
                    {
                        Board[i, j].BackgroundImage = MyCheckerGame.Properties.Resources.red_piece;
                        Board[i, j].AccessibleName = "red";
                    }
                }
            }
        }

        private void BoxClicked(object sender, EventArgs e)
        {
            PictureBox clickedBox = (PictureBox)sender;
            if(Turn=="blue") //clickedBox AccessibleName=="blue"
            {
                int row, col;
                string location = clickedBox.Tag.ToString();

                row = Convert.ToInt32(location[0]) - 48; //to get disc row no instead of its assci value
                col = Convert.ToInt32(location[1]) - 48; //to get disc col no instaed of its assci value

                if(Click==0)
                {
                    FirstClickBox = Board[row, col];
                    if(row<8)
                    {
                        if((col==0)&&(row%2!=0)) //odd
                        {
                            leftDiagonalBox = null;
                           // rightDiagonalBox = Board[row + 1, col];
                        }

                        else if((col==0)&&(row%2==0))
                        {
                            leftDiagonalBox = Board[row + 1, col];
                            rightDiagonalBox = Board[row + 1, col + 1];
                        }

                        else if((col==3)&&(row%2!=0))
                        {
                            leftDiagonalBox = Board[row + 1, col];
                            rightDiagonalBox = Board[row+1, col-1];
                        }

                        else if((col==3)&&(row%2==0))
                        {
                            leftDiagonalBox=Board[row+1,col];
                            rightDiagonalBox=null;
                        }

                        else if(col>0 && col<3 && row%2==0)
                        {
                            leftDiagonalBox = Board[row + 1, col];
                            rightDiagonalBox = Board[row + 1, col + 1];
                        }

                        else if(col>0 && col<3)
                        {
                            leftDiagonalBox=Board[row+1,col-1];
                            rightDiagonalBox=Board[row+1,col];
                        }

                    }

                    clickedBox.BackColor = Color.Gray;

                    if (leftDiagonalBox != null && leftDiagonalBox.AccessibleName == "none")
                        leftDiagonalBox.BackColor = Color.Gray;

                    if (rightDiagonalBox != null && rightDiagonalBox.AccessibleName == "none") ;
                        //rightDiagonalBox.BackColor = Color.Gray;
                    Click=1;
                }
                else if(Click==1) //for click 1
                {
                    if (clickedBox==leftDiagonalBox ||clickedBox== rightDiagonalBox)
                    {
                        clickedBox.BackgroundImage=MyCheckerGame.Properties.Resources.red_piece;
                        clickedBox.BackColor=Color.Black;  //reset color
                        clickedBox.AccessibleName="red";

                        FirstClickBox.BackgroundImage=null; //reset pic
                        FirstClickBox.AccessibleName="none";
                        FirstClickBox.BackColor=Color.Black; //reset color

                        if (rightDiagonalBox != null)
                            rightDiagonalBox.BackColor = Color.Black;  //reset color
                        if (leftDiagonalBox != null)
                            leftDiagonalBox.BackColor = Color.Black;

                       // leftDiagonalBox = null;
                       // rightDiagonalBox = null;
                        Click = 0;
                        EnableBluePieces();
                        Turn = "blue";
}
                    else
                    {
                        if (rightDiagonalBox != null)
                            rightDiagonalBox.BackColor = Color.Black; //reset color

                        if (leftDiagonalBox != null)
                            leftDiagonalBox.BackColor = Color.Black;

                        FirstClickBox.BackColor = Color.Black;
                        Click = 0;
                        //re click

                    }
                   
                }
                
                
                }
            }
        
        }
    }
//private void  EnableBluePieces()
//        {

//        }



    


                
         

        
