using System;
using System.Drawing;
using System.Windows.Forms;

namespace Segmentation
{
	/// <summary> ���������� ����� ����������. </summary>
	public partial class AboutProgram : Form
	{
		/// <summary> ������� ����� ���������� ����� ����������. </summary>
		public AboutProgram()
		{
			InitializeComponent();
		}
		
		/// <summary> ���������� ������� '������� �� ������'. </summary>
		private void ButtonOkClick(object sender, EventArgs e)
		{
			Close();
		}        
	}
}
