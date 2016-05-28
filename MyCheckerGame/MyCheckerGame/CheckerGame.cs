//Rabia Bashir
//BSE-6B
//01-133132-144
                                                            //VP PROJECT
                                                           //Checker Game
//Project Main flow                                                           
//Sound Player
//Sound system for single click and jumps
//All pieces(red,blue) are placed on the BlackPictureBox
//Check all pieces left and right Diagonal and make Possible Move
//First Turn is given to Blue Piece
//Blue piece move leftdown diagonal and rightdown diagonal
//Red piece move leftup diagonal and rightup diagonal
//Leftup, Rightup ,LeftDown,RightDown Diagonal is shown by Grey Color
//Leftjumpboxup,leftjumpboxdown.rightjumpboxup,rightjumpboxdown for every bluepiece,redpiece, blueking and redking
// Both King Move Forward Diagonal as well as Backward Diagonal
//Scorepanel for both pieces(red,blue)
//Wining panel for both pieces(red,blue)
//Every piece(red,blue) gets 2 click(i.e click==0) and (click==1)
//(click==0) to show possible moves on the diagonal with indicating Gray Color
//(click==1) to move on any of the diagonal

using System;
using System.Media;
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
    public partial class CheckerGame : Form
    {
        SoundPlayer simpleclicksound = new SoundPlayer(MyCheckerGame.Properties.Resources.simple_clicksound);
        SoundPlayer jumpsound = new SoundPlayer(MyCheckerGame.Properties.Resources.jump_sound);
        PictureBox[,] Board = new PictureBox[8, 8]; //8 row and 8 col
        PictureBox Firstclickbox; //on which we 1st click
        PictureBox leftdiagnoldown, rightdiagnoldown;
        PictureBox leftdiagnolup, rightdiagnolup;
        PictureBox leftjumpboxdown, rightjumpboxdown;
        PictureBox leftjumpboxup, rightjumpboxup;
        String turn;
        int click;
        int scoreblue,scorered;

        //Constructor
        public CheckerGame()
        {
            InitializeComponent();
            creatingboard();
            boardpanel.SendToBack(); //sending panel to back
            settingpieces();
            panelturn.BackColor = Color.SteelBlue; //panel backcolor turn to steelblue
            turn = "blue"; //1st turn is given to blue
            click = 0;
            scoreblue = 0;
            scorered = 0;
            
            //initially all the diagonal and jump boxes are null
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
            
            try
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
                        //clicked on the wrong piece
                    }
                    else
                    {
                        redturn(clickedBox); //redturn execute
                    }

                }
            }

            catch (Exception clickedexception)
            {
                MessageBox.Show(clickedexception.Message);
            }

        }

        private void creatingboard()
        {
            try
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
                        j = j + 1; //to get 1st col(i.e 1) and so on
                    }
                    else
                    {
                        x = 20; //otherwise make box  from starting location (i.e for old row)
                    }
                    while (j < 8) //loop for col
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
                    } //while loop end
                    y += 70; //along y only 70 difference
                } //for loop end
            }
            catch(Exception creatingboardexception)
            {
                MessageBox.Show(creatingboardexception.Message);
            }
        }

        private void settingpieces()
        {
            try
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
                        if (i == 0 || i == 1 || i == 2) // set blue pieces in row 1, 2, 3
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
            catch(Exception settingpiecesexception)
            {
                MessageBox.Show(settingpiecesexception.Message);
            }
        }

        //For Blue leftdowndiagonal(leftjumpboxdown) and rightdowndiagonal(rightjumpboxdown)
        private void blueturn(PictureBox clickedBox)
        {
            try
            {

                int row, col;
                string location = clickedBox.Tag.ToString(); //convert tag into string and save it in location
                row = Convert.ToInt32(location[0]) - 48; //to get row no instead of its asscci value
                col = Convert.ToInt32(location[1]) - 48; //to get col no instead of its asscci value
                
                if (click == 0 && clickedBox.AccessibleName == "blue") //simple blue
                {
                    simpleclicksound.Play();
                    Firstclickbox = Board[row, col]; //on which we 1st click

                    if ((row + 1 < 8) && (col - 1 >= 0)) //leftdiagnoldown possible
                    {
                        if (Board[row + 1, col - 1].AccessibleName == "none") //simple move to leftdiagonaldown 
                        {
                            leftdiagnoldown = Board[row + 1, col - 1];
                        }
                        else if (Board[row + 1, col - 1].AccessibleName == "red" || Board[row + 1, col - 1].AccessibleName == "redking")//when opponent piece red or redking on diagonal make it a leftjumpboxdown
                        {
                            if ((row + 2 < 8) && (col - 2 >= 0)) //leftdownjumpbox possible
                            {
                                if (Board[row + 2, col - 2].AccessibleName == "none")
                                {
                                    leftjumpboxdown = Board[row + 1, col - 1];
                                    leftdiagnoldown = Board[row + 2, col - 2];
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
                        else if (Board[row + 1, col + 1].AccessibleName == "red" || Board[row + 1, col + 1].AccessibleName == "redking") //when opponent piece red or redking on diagonal make it a rightjumpboxdown
                        {
                            if ((row + 2 < 8) && (col + 2 < 8)) //rightjumpboxdown possible
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
                    //1:Firstclickbox on which we 1st click
                    //2.leftdiagonaldown should be Gray
                    //3.rightdiagonaldown should be Gray
                    Firstclickbox.BackColor = Color.Gray;
                    if (leftdiagnoldown != null)
                        leftdiagnoldown.BackColor = Color.Gray;
                    if (rightdiagnoldown != null)
                        rightdiagnoldown.BackColor = Color.Gray;

                    click = 1;//reset click to 1
                }

                else if (click == 0 && clickedBox.AccessibleName == "blueking") //when clicked on blueking
                {
                    simpleclicksound.Play();
                    Firstclickbox = Board[row, col]; //on which we 1st click

                    if ((row + 1 < 8) && (col - 1 >= 0))//leftdiagonaldown exist
                    {
                        if (Board[row + 1, col - 1].AccessibleName == "none") //simple move to leftdiagonaldown
                        {
                            leftdiagnoldown = Board[row + 1, col - 1];
                        }
                        else if (Board[row + 1, col - 1].AccessibleName == "red" || Board[row + 1, col - 1].AccessibleName == "redking") //when opponent piece red or redking on diagonal make it a leftjumpboxdown
                        {
                            if ((row + 2 < 8) && (col - 2 >= 0)) //leftjumpboxdown is possible
                            {
                                if (Board[row + 2, col - 2].AccessibleName == "none")
                                {
                                    leftjumpboxdown = Board[row + 1, col - 1];
                                    leftdiagnoldown = Board[row + 2, col - 2];
                                }
                            }
                        }
                        else //when no leftdiagonaldown exist or available
                        {
                            leftdiagnoldown = null;
                            leftjumpboxdown = null;
                        }
                    }

                    if ((row + 1 < 8) && (col + 1 < 8)) //rightdiagonaldown exist
                    {
                        if (Board[row + 1, col + 1].AccessibleName == "none") //simple move to rightdiagonaldown
                        {
                            rightdiagnoldown = Board[row + 1, col + 1];
                        }
                        else if (Board[row + 1, col + 1].AccessibleName == "red" || Board[row + 1, col + 1].AccessibleName == "redking")//when opponent piece red or redking on diagonal make it a rightjumpboxdown
                        {
                            if ((row + 2 < 8) && (col + 2 < 8)) //rightjumpboxdown exist
                            {
                                if (Board[row + 2, col + 2].AccessibleName == "none") //simple jump to rightjumpboxdown
                                {
                                    rightjumpboxdown = Board[row + 1, col + 1];
                                    rightdiagnoldown = Board[row + 2, col + 2];
                                }
                            }

                        }
                        else //when no rightdiagonaldown and rightjumpboxdown exist or available
                        {
                            rightdiagnoldown = null;
                            rightjumpboxdown = null;
                        }
                    }
                    if ((row - 1 >= 0) && (col - 1 >= 0))//rightdiagonalup exist
                    {
                        if (Board[row - 1, col - 1].AccessibleName == "none") //simple move to rightdiagonalup
                        {
                            leftdiagnolup = Board[row - 1, col - 1];
                        }
                        else if (Board[row - 1, col - 1].AccessibleName == "red" || Board[row - 1, col - 1].AccessibleName == "redking") //when opponent piece red or redking on diagonal make it a leftjumpboxup
                        {
                            if ((row - 2 >= 0) && (col - 2 >= 0)) //leftjumboxup exist
                            {
                                if (Board[row - 2, col - 2].AccessibleName == "none") //simple jump to leftjumpboxup
                                {
                                    leftjumpboxup = Board[row - 1, col - 1];
                                    leftdiagnolup = Board[row - 2, col - 2];
                                }
                            }
                        }
                        else //when no leftdiagonalup and leftjumpboxup exist or not possible
                        {
                            leftdiagnolup = null;
                            leftjumpboxup = null;
                        }
                    }
                    if ((row - 1 >= 0) && (col + 1 < 8)) //rightdiagonalup exist
                    {
                        if (Board[row - 1, col + 1].AccessibleName == "none") //simple move to rightdiagonalup
                        {
                            rightdiagnolup = Board[row - 1, col + 1];
                        }
                        else if (Board[row - 1, col + 1].AccessibleName == "red" || Board[row - 1, col + 1].AccessibleName == "redking")//when opponent piece red or redking on diagonal make it a rightjumpboxup
                        {
                            if ((row - 2 >= 0) && (col + 2 < 8)) //when rightjumpboxup is possible
                            {
                                if (Board[row - 2, col + 2].AccessibleName == "none")
                                {
                                    rightjumpboxup = Board[row - 1, col + 1];
                                    rightdiagnolup = Board[row - 2, col + 2];
                                }
                            }
                        }
                        else //when no rightdiagonalup exist or not possible
                        {
                            rightdiagnolup = null;
                            rightjumpboxup = null;
                        }
                    }

                    //5 boxes should be Gray
                    //1.The Box on which we click i.e our Firstclickbox
                    //2.The leftdiagonaldown
                    //3.The rightdiagonaldown
                    //4.The leftdiagonalup
                    //5.The rightdiagonalup
                    Firstclickbox.BackColor = Color.Gray;
                    if (leftdiagnoldown != null)
                        leftdiagnoldown.BackColor = Color.Gray;
                    if (rightdiagnoldown != null)
                        rightdiagnoldown.BackColor = Color.Gray;
                    if (leftdiagnolup != null)
                        leftdiagnolup.BackColor = Color.Gray;
                    if (rightdiagnolup != null)
                        rightdiagnolup.BackColor = Color.Gray;

                    click = 1; //reset click to 1
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

                        //check if there is any jump

                        if (leftjumpboxup != null && clickedBox == leftdiagnolup) //if leftjumpboxup exist and clicked on leftdiagonalup
                        {
                            //Clear the leftjumpboxup
                            leftjumpboxup.BackgroundImage = null;
                            leftjumpboxup.AccessibleName = "none";

                            //jump sound
                            jumpsound.Play();

                            //update bluepiece score
                            scoreblue++;
                            bluescorelabel.Text = scoreblue.ToString();
                            bluescoreupdate(); //Function call of bluescoreupdate

                        }
                        else if (leftjumpboxdown != null && clickedBox == leftdiagnoldown)//if leftjumpboxdown exist and clicked on leftdiagonaldown
                        {
                            //Clear the leftjumpboxdown
                            leftjumpboxdown.BackgroundImage = null;
                            leftjumpboxdown.AccessibleName = "none";

                            //jump sound
                            jumpsound.Play();

                            //update bluepiece score
                            scoreblue++;
                            bluescorelabel.Text = scoreblue.ToString();
                            bluescoreupdate(); //Function call of bluescoreupdate

                        }

                        else if (rightjumpboxup != null && clickedBox == rightdiagnolup) //if rightjumpboxup exist and clicked on rightdiagonalup
                        {
                            //Clear the rightjumpboxup
                            rightjumpboxup.BackgroundImage = null;
                            rightjumpboxup.AccessibleName = "none";

                            //jumpsound
                            jumpsound.Play();

                            //update bluepiece score
                            scoreblue++;
                            bluescorelabel.Text = scoreblue.ToString();
                            bluescoreupdate(); //Function call of bluescoreupdate

                        }
                        else if (rightjumpboxdown != null && clickedBox == rightdiagnoldown) //if rightjumpboxdown exist and clicked on rightdiagonaldown
                        {
                            //Clear the rightjumpboxdown
                            rightjumpboxdown.BackgroundImage = null;
                            rightjumpboxdown.AccessibleName = "none";

                            //jumpsound
                            jumpsound.Play();

                            //update bluepiece score
                            scoreblue++;
                            bluescorelabel.Text = scoreblue.ToString();
                            bluescoreupdate(); //Function call of bluescoreupdate

                        }

                        click = 0; //reset click to 0
                        turn = "red"; //red turn
                        panelturn.BackColor = Color.Crimson; //Panel backcolor turn into crimson

                        //reset all diagonal to null 
                        leftdiagnoldown = null;
                        rightdiagnoldown = null;
                        leftdiagnolup = null;
                        rightdiagnolup = null;
                        leftjumpboxup = null;
                        rightjumpboxup = null;
                        leftjumpboxdown = null;
                        rightjumpboxdown = null;

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

                        //reset all possible diagonal to null
                        leftdiagnolup = null;
                        rightdiagnolup = null;
                        leftdiagnoldown = null;
                        rightdiagnoldown = null;
                        leftjumpboxup = null;
                        rightjumpboxup = null;
                        leftjumpboxdown = null;
                        rightjumpboxdown = null;

                        click = 0; //reset click to 0
                    }
                }
            }
            catch(Exception Bluepieceexception)
            {
                MessageBox.Show(Bluepieceexception.Message);
            }
        }

       
        //For red check left up diagonal(leftjumpboxup) and right up diagonal (rightjumpboxup)
        private void redturn(PictureBox clickedBox)
        {
            try
            {
                int row, col;
                string location = clickedBox.Tag.ToString();//to convert tag into string and store in location

                row = Convert.ToInt32(location[0]) - 48; //to get row no instead of its asscci value
                col = Convert.ToInt32(location[1]) - 48; //to get col no instead of its asscci value

                if (click == 0 && clickedBox.AccessibleName == "red") //for simple red piece
                {
                    simpleclicksound.Play();
                    Firstclickbox = Board[row, col]; //firstbox on which we click

                    if ((row - 1 >= 0) && (col - 1 >= 0)) //left diagonal up is possible
                    {
                        if (Board[row - 1, col - 1].AccessibleName == "none") //when accessiblename is none just simple move to leftdiagonalup
                        {
                            leftdiagnolup = Board[row - 1, col - 1];
                        }
                        else if (Board[row - 1, col - 1].AccessibleName == "blue" || Board[row - 1, col - 1].AccessibleName == "blueking") //when opponent piece blue or blueking on diagonal make it a leftjumpboxup
                        {
                            if ((row - 2 >= 0) && (col - 2 >= 0)) //leftjumpboxup possible
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
                        if (Board[row - 1, col + 1].AccessibleName == "none") //When accessiblename is none just simple move to rightdiagonalup
                        {
                            rightdiagnolup = Board[row - 1, col + 1];
                        }
                        else if (Board[row - 1, col + 1].AccessibleName == "blue" || Board[row - 1, col + 1].AccessibleName == "blueking") //when opponent piece blue or blueking on diagonal make it a rightjumpboxup
                        {
                            if ((row - 2 >= 0) && (col + 2 < 8)) //rightjumpboxup is possible
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
                    //1.The Firstclickbox on which we 1st click
                    //2.leftdiagonalup
                    //3.rightdiagonalup
                    Firstclickbox.BackColor = Color.Gray;
                    if (leftdiagnolup != null)
                        leftdiagnolup.BackColor = Color.Gray;
                    if (rightdiagnolup != null)
                        rightdiagnolup.BackColor = Color.Gray;

                    click = 1; //reset click to 1
                }

                else if (click == 0 && clickedBox.AccessibleName == "redking") //when cliked on redking
                {
                    simpleclicksound.Play();
                    Firstclickbox = Board[row, col]; //on which we 1st click

                    if ((row + 1 < 8) && (col - 1 >= 0)) //leftdiagonaldown possible
                    {
                        if (Board[row + 1, col - 1].AccessibleName == "none")//simple move to leftdiagonaldown
                        {
                            leftdiagnoldown = Board[row + 1, col - 1];
                        }
                        else if (Board[row + 1, col - 1].AccessibleName == "blue" || Board[row + 1, col - 1].AccessibleName == "blueking")
                        {
                            if ((row + 2 < 8) && (col - 2 >= 0)) //leftjumpboxdown possible
                            {
                                if (Board[row + 2, col - 2].AccessibleName == "none") //simple jump to leftjumpboxdown
                                {
                                    leftjumpboxdown = Board[row + 1, col - 1];
                                    leftdiagnoldown = Board[row + 2, col - 2];
                                }
                            }
                        }
                        else //when no leftdiagonaldown and leftjumpboxdown exist or possible
                        {
                            leftdiagnoldown = null;
                            leftjumpboxdown = null;
                        }
                    }

                    if ((row + 1 < 8) && (col + 1 < 8)) //rightdiagonaldown possible
                    {
                        if (Board[row + 1, col + 1].AccessibleName == "none")//simple move to rightdiagonaldown
                        {
                            rightdiagnoldown = Board[row + 1, col + 1];
                        }
                        else if (Board[row + 1, col + 1].AccessibleName == "blue" || Board[row + 2, col + 2].AccessibleName == "blueking")
                        {
                            if ((row + 2 < 8) && (col + 2 < 8)) //rightjumpboxdown possible
                            {
                                if (Board[row + 2, col + 2].AccessibleName == "none") //simple jump to rightjumpboxdown
                                {
                                    rightjumpboxdown = Board[row + 1, col + 1];
                                    rightdiagnoldown = Board[row + 2, col + 2];
                                }
                            }
                        }
                        else //when no rightdiagonaldown and rightjumpboxup exist or possible
                        {
                            rightdiagnoldown = null;
                            rightjumpboxdown = null;
                        }
                    }

                    if ((row - 1 >= 0) && (col - 1 >= 0)) //leftdiagonalup possible
                    {
                        if (Board[row - 1, col - 1].AccessibleName == "none")//simple move to leftdiagonalup
                        {
                            leftdiagnolup = Board[row - 1, col - 1];
                        }
                        else if (Board[row - 1, col - 1].AccessibleName == "blue" || Board[row - 1, col - 1].AccessibleName == "blueking")
                        {
                            if ((row - 2 >= 0) && (col - 2 >= 0)) //leftjumpboxup possible
                            {
                                if (Board[row - 2, col - 2].AccessibleName == "none") //simple jump to leftjumpboxup
                                {
                                    leftjumpboxup = Board[row - 1, col - 1];
                                    leftdiagnolup = Board[row - 2, col - 2];
                                }
                            }
                        }
                        else//when no leftdiagonalup and leftjumpboxup exist or possible
                        {
                            leftdiagnolup = null;
                            leftjumpboxup = null;
                        }
                    }

                    if ((row - 1 >= 0) && (col + 1 < 8)) //rightdiagonalup possible
                    {
                        if (Board[row - 1, col + 1].AccessibleName == "none") //simple move to rightdiagonalup
                        {
                            rightdiagnolup = Board[row - 1, col + 1];
                        }
                        else if (Board[row - 1, col + 1].AccessibleName == "blue" || Board[row - 1, col + 1].AccessibleName == "blueking")
                        {
                            if ((row - 2 < 8) && (col + 2 < 8))  //rightjumpboxup possible
                            {
                                if (Board[row - 2, col + 2].AccessibleName == "none")  //simple jump to rightjumpboxup
                                {
                                    rightjumpboxup = Board[row - 1, col + 1];
                                    rightdiagnolup = Board[row - 2, col + 2];
                                }
                            }
                        }
                        else //when no rightdiagonalup and rightjumpbox exist or possible
                        {
                            rightdiagnolup = null;
                            rightjumpboxup = null;
                        }
                    }

                    //5 boxes should be Gray
                    //1.The Box on which we click i.e our FirstClickBox
                    //2.The leftdiagonalup
                    //3.The rightDiagonalup
                    //4.The leftdiagonaldown
                    //5.The rightdiagonaldown
                    Firstclickbox.BackColor = Color.Gray;
                    if (leftdiagnolup != null)
                        leftdiagnolup.BackColor = Color.Gray;
                    if (rightdiagnolup != null)
                        rightdiagnolup.BackColor = Color.Gray;
                    if (leftdiagnoldown != null)
                        leftdiagnoldown.BackColor = Color.Gray;
                    if (rightdiagnoldown != null)
                        rightdiagnoldown.BackColor = Color.Gray;

                    click = 1; //reset click to 1
                }

                else if (click == 1) //for second click to move
                {
                    // check if clicked on diagnols
                    if (clickedBox == leftdiagnoldown || clickedBox == leftdiagnolup || clickedBox == rightdiagnoldown || clickedBox == rightdiagnolup)
                    {
                        if (row == 0) //when reaches to last row of opponent(i.e row 0)
                        {
                            clickedBox.BackgroundImage = MyCheckerGame.Properties.Resources.red_king_piece;
                            clickedBox.AccessibleName = "redking";
                        }
                        else //when reaches to any row i.e row 1,2,3,4,5,6,7
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

                        //check if there is any jump

                        if (leftjumpboxup != null && clickedBox == leftdiagnolup) //if leftjumpboxup exist and clicked on leftdiagonal up
                        {
                            //Clear the leftjumpboxup
                            leftjumpboxup.BackgroundImage = null;
                            leftjumpboxup.AccessibleName = "none";

                            //jump sound
                            jumpsound.Play();

                            //update redpiece score
                            scorered++;
                            redscorelabel.Text = scorered.ToString();
                            redscoreupdate(); //Function call of redscoreupdate
                        }
                        else if (leftjumpboxdown != null && clickedBox == leftdiagnoldown) //if leftjumpboxdown exist and clicked on leftdiagonaldown
                        {
                            //Clear the leftjumpboxdown
                            leftjumpboxdown.BackgroundImage = null;
                            leftjumpboxdown.AccessibleName = "none";

                            //jump sound
                            jumpsound.Play();

                            //update redpiece score
                            scorered++;
                            redscorelabel.Text = scorered.ToString();
                            redscoreupdate(); //Function call of redscoreupdate
                        }
                        else if (rightjumpboxup != null && clickedBox == rightdiagnolup) //if rightjumpboxup exist and clicked on rightdiagonalup
                        {
                            //Clear the rightjumpboxup
                            rightjumpboxup.BackgroundImage = null;
                            rightjumpboxup.AccessibleName = "none";

                            //jump sound
                            jumpsound.Play();

                            //update redpiece score
                            scorered++;
                            redscorelabel.Text = scorered.ToString();
                            redscoreupdate(); //Function call of redscoreupdate
                        }
                        else if (rightjumpboxdown != null && clickedBox == rightdiagnoldown) //if rightjumpboxdown exist and clicked on rightdiagonaldown
                        {
                            //Clear the rightjumpboxdown
                            rightjumpboxdown.BackgroundImage = null;
                            rightjumpboxdown.AccessibleName = "none";

                            //jump sound
                            jumpsound.Play();

                            //update redpiece score
                            scorered++;
                            redscorelabel.Text = scorered.ToString();
                            redscoreupdate(); //Function call of redscoreupdate
                        }

                        click = 0; //reset click to 0
                        turn = "blue";//when turn is of blue
                        panelturn.BackColor = Color.SteelBlue; //panel backcolor turn to steelblue

                        //reset to null all the diagonal left up,left down,right up,right down
                        leftdiagnoldown = null;
                        rightdiagnoldown = null;
                        leftdiagnolup = null;
                        rightdiagnolup = null;
                        leftjumpboxup = null;
                        rightjumpboxup = null;
                        leftjumpboxdown = null;
                        rightjumpboxdown = null;

                    }
                    else // if click on other boxes  reset its color
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
                        leftjumpboxup = null;
                        rightjumpboxup = null;
                        leftjumpboxdown = null;
                        rightjumpboxdown = null;

                        click = 0; //reset click to 0
                    }
                }
            }
            catch(Exception redpieceexception)
            {
                MessageBox.Show(redpieceexception.Message);
            }

        }
        //blue piece score
       public void bluescoreupdate()
        {
            try
            {
                if (scoreblue == 1)
                {
                    r1.BackgroundImage = MyCheckerGame.Properties.Resources.red_piece;
                }
                else if (scoreblue == 2)
                {
                    r2.BackgroundImage = MyCheckerGame.Properties.Resources.red_piece;
                }
                else if (scoreblue == 3)
                {
                    r3.BackgroundImage = MyCheckerGame.Properties.Resources.red_piece;
                }
                else if (scoreblue == 4)
                {
                    r4.BackgroundImage = MyCheckerGame.Properties.Resources.red_piece;
                }
                else if (scoreblue == 5)
                {
                    r5.BackgroundImage = MyCheckerGame.Properties.Resources.red_piece;
                }
                else if (scoreblue == 6)
                {
                    r6.BackgroundImage = MyCheckerGame.Properties.Resources.red_piece;
                }
                else if (scoreblue == 7)
                {
                    r7.BackgroundImage = MyCheckerGame.Properties.Resources.red_piece;
                }
                else if (scoreblue == 8)
                {
                    r8.BackgroundImage = MyCheckerGame.Properties.Resources.red_piece;
                }
                else if (scoreblue == 9)
                {
                    r9.BackgroundImage = MyCheckerGame.Properties.Resources.red_piece;
                }
                else if (scoreblue == 10)
                {
                    r10.BackgroundImage = MyCheckerGame.Properties.Resources.red_piece;
                }
                else if (scoreblue == 11)
                {
                    r11.BackgroundImage = MyCheckerGame.Properties.Resources.red_piece;
                }
                else if(scoreblue==12)
                {
                    b12.BackgroundImage = MyCheckerGame.Properties.Resources.red_piece;
                }
                 if (scoreblue == 12)
                {
                    winingpanel.BackgroundImage = MyCheckerGame.Properties.Resources.blue_wins;
                    winingpanel.BringToFront();
                    winingpanel.Visible = true;
                }
            }
           catch(Exception bluepiecescoreexception)
            {
                MessageBox.Show(bluepiecescoreexception.Message);
            }
        }
        
        //red piece score
       public void redscoreupdate()
       {
           try
           {
               if (scorered == 1)
               {
                   b1.BackgroundImage = MyCheckerGame.Properties.Resources.blue_piece;
               }
               else if (scorered == 2)
               {
                   b2.BackgroundImage = MyCheckerGame.Properties.Resources.blue_piece;
               }
               else if (scorered == 3)
               {
                   b3.BackgroundImage = MyCheckerGame.Properties.Resources.blue_piece;
               }
               else if (scorered == 4)
               {
                   b4.BackgroundImage = MyCheckerGame.Properties.Resources.blue_piece;
               }
               else if (scorered == 5)
               {
                   b5.BackgroundImage = MyCheckerGame.Properties.Resources.blue_piece;
               }
               else if (scorered == 6)
               {
                   b6.BackgroundImage = MyCheckerGame.Properties.Resources.blue_piece;
               }
               else if (scorered == 7)
               {
                   b7.BackgroundImage = MyCheckerGame.Properties.Resources.blue_piece;
               }
               else if (scorered == 8)
               {
                   b8.BackgroundImage = MyCheckerGame.Properties.Resources.blue_piece;
               }
               else if (scorered == 9)
               {
                   b9.BackgroundImage = MyCheckerGame.Properties.Resources.blue_piece;
               }
               else if (scorered == 10)
               {
                   b10.BackgroundImage = MyCheckerGame.Properties.Resources.blue_piece;
               }
               else if (scorered == 11)
               {
                   b11.BackgroundImage = MyCheckerGame.Properties.Resources.blue_piece;
               }
               else if(scorered==12)
               {
                   b12.BackgroundImage = MyCheckerGame.Properties.Resources.blue_piece;
               }
                if (scorered == 12)
               {
                   winingpanel.BackgroundImage = MyCheckerGame.Properties.Resources.red_wins;
                   winingpanel.Visible = true;
                   winingpanel.BringToFront();
               }
           }
           catch(Exception redpiecescoreexception)
           {
               MessageBox.Show(redpiecescoreexception.Message);
           }
       }
    }
}

        
        
    




