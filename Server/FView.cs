using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
  public partial class FView : Form
  {
    public FView()
    {
      InitializeComponent();
    }
    public void AddString(string value)
    {
      if (textBox1.InvokeRequired)
        textBox1.BeginInvoke(new Action<TextBox>(x => x.Text = value), textBox1);
      else
        textBox1.Text = value;
    }

    private void ExitButton_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
