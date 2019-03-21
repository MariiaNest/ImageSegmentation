using System;
using System.Drawing;
using System.Windows.Forms;

namespace Segmentation
{
	/// <summary> Справочная форма приложения. </summary>
	public partial class AboutProgram : Form
	{
		/// <summary> Создает новую справочную форму приложения. </summary>
		public AboutProgram()
		{
			InitializeComponent();
		}
		
		/// <summary> Обработчик события 'Нажатие на кнопке'. </summary>
		private void ButtonOkClick(object sender, EventArgs e)
		{
			Close();
		}        
	}
}
