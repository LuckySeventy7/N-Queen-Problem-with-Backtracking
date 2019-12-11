/*
 * Created by SharpDevelop.
 * User: Sergio Ruiz
 * Date: 8/22/2019
 * Time: 8:43 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Linq;
using System.IO;


/*
 *
 * CLASS: SEM DE ALGOR.
 * 
 * ------------------------------
 * FIND SOLUTION WHERE ALL 6 QUEENS CAN BE PLACED OUT WITHOUT BEING ABLE TO INTERSECT EACHOTHER.
 * 
 * 
 * */
namespace act_2_reyna
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		
		Graphics g;
		Bitmap bmpChessBoard,bmpQueen,bmpAnimation;
		int col, row;
        List<Reyna> rL;
        List<Reyna> ListAnim;
        bool flag;
        bool safeC;

      
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
            rL = new List<Reyna>();
			bmpChessBoard = new Bitmap("chess_board.png");
			bmpQueen = new Bitmap("queen.png");
			bmpAnimation = new Bitmap(bmpChessBoard.Width, bmpChessBoard.Height);
			pictureBox1.BackgroundImageLayout = ImageLayout.Zoom ;
			pictureBox1.BackgroundImage= bmpChessBoard;
			
			
			pictureBox1.Image= bmpAnimation;

			g = Graphics.FromImage(bmpAnimation);		
			
			button2.Enabled=false;		
			
			
	
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Button1Click(object sender, EventArgs e)//button initialize
		{
		
			rL = new List<Reyna>();//list of position of all 6 queens
			ListAnim = new List<Reyna>();//list of position of all 6 queens for animation
			flag= true;
            safeC=true;
            col = 0;
            row=0;
            backTrack();
		}
	
		void backTrack(){
		while ( row<6){
			while (col<6){
				Reyna rPos = new Reyna(col, row);//position of queen
       
				clearBitmap(bmpAnimation,Color.Transparent);
                if(safeC){
                	ListAnim.Add(rPos);
				}
                else
                	ListAnim[row]=rPos;//row
              
        
                for(int x=0; x<ListAnim.Count();x++){//animation onboard 
                	g.DrawImage(bmpQueen, ListAnim[x].getCol()*100+27,  ListAnim[x].getRow()* 100, bmpQueen.Width,bmpQueen.Height );//col row
      
                }
				pictureBox1.Refresh();
               
			
                if (checkSafe(rPos))
                {
                	button2.Enabled=true;
                	safeC=true;
                    flag = true;
                    rL.Add(rPos);
                    
                    if(rL.Count()==6){
                    	MessageBox.Show("Solution Found");
                    	row=0;
		                    	col= ListAnim[0].getCol()+1;
		                    	ListAnim= new List<Reyna>();
		                    	rL= new List<Reyna>();
	                    
                    	return;
                    }
                    
                    break;
                }
                   safeC=false;
                    flag = false;
                    col++;
            }
          	
            if (flag == false)
            {
                row = row - 1;
                if(row==-1){
                	MessageBox.Show("Programa terminado");
                 	button2.Enabled=false;
                	break;
                }
                col = rL[row].getCol()+1;
   
                rL.RemoveAt(row);
                ListAnim.RemoveAt(row);
               
            }
            else
            {
                col = 0;
                row++;
                
            }

        }
	
	}


	bool checkSafe(Reyna rP)
    {
		var Lr = new List<Reyna>(rL);
           

        Lr.ToString();

            for (int b = 0; b < Lr.Count; b++)
            {
                {
                    if(rP.getCol() == Lr[b].getCol())
           
                    {
            
                        return false;
                    }

                if (Math.Pow(rP.getRow() - Lr[b].getRow(), 2) == Math.Pow(rP.getCol() - Lr[b].getCol(), 2))
                    {
                     
                        return false;
                    }

                }

            }
       
            return true;
        }
        
		
        
		
		void clearBitmap(Bitmap bmpC, Color c)//clears pictuebox
        {
            g = Graphics.FromImage(bmpC);

            g.Clear(c);
        }
		
		
		
		void Button2Click(object sender, EventArgs e)//button conttinue
		{
			backTrack();
		
		}

	}
}
