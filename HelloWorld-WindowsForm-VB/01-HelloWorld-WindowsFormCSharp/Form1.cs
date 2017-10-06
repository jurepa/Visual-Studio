using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_HelloWorld_WindowsFormCSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Este método se ejecutará cuando se pulse el botón
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void boton_Click(object sender, EventArgs e)
        {
            String nombre="";
            nombre = this.texto.Text;

            if (String.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Error, no se ha escrito ningun nombre", "Con dio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"Hola {nombre} crack", "Con dio");
            }
        }
    }
}
