/*
 * Created by SharpDevelop.
 * User: Sergio Ruiz
 * Date: 8/24/2019
 * Time: 11:24 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace act_2_reyna
{
	/// <summary>
	/// Description of Reyna.
	/// </summary>
	public class Reyna
	{
		private int row, col;
		public Reyna(int c, int r)
		{
			this.col=c;
			this.row=r;
		}
		
		public int getCol(){
		
			return col;
		}
		public int getRow(){
		
			return row;
		}
		
	}
}
