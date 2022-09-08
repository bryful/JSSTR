using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSSTR
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		public string[] JSstrCOnvert(string [] src,bool isRN)
		{
			string[] ret = new string[0];
			if (src.Length <= 0) return ret;
			ret = new string[src.Length];
			
			for(int i=0; i< src.Length;i++)
			{
				string s = src[i];
				s = s.Replace("\\", "\\\\");
				s = s.Replace("\"", "\\\"");
				s = s.Replace("\t", "\\t");
				if (isRN) s += "\\r\\n";
				s = "\"" + s + "\"";
				if (i != 0) { s = "+" + s; }
				ret[i] = s;
			}
			ret[src.Length-1] += ";";
			ret[0] = "var str = \r\n " + ret[0];

			return ret;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			textBox2.Lines = JSstrCOnvert(textBox1.Lines,cbRN.Checked);
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void convertToolStripMenuItem_Click(object sender, EventArgs e)
		{
			textBox2.Lines = JSstrCOnvert(textBox1.Lines, cbRN.Checked);
		}
	}

}
