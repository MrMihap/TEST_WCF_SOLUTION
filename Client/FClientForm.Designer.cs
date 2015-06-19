namespace Client
{
  partial class FClientForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.Connect = new System.Windows.Forms.Button();
      this.Disconnect = new System.Windows.Forms.Button();
      this.RecievedData = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // Connect
      // 
      this.Connect.Location = new System.Drawing.Point(13, 13);
      this.Connect.Name = "Connect";
      this.Connect.Size = new System.Drawing.Size(179, 23);
      this.Connect.TabIndex = 0;
      this.Connect.Text = "Connect + Subscribe";
      this.Connect.UseVisualStyleBackColor = true;
      this.Connect.Click += new System.EventHandler(this.Connect_Click);
      // 
      // Disconnect
      // 
      this.Disconnect.Location = new System.Drawing.Point(13, 43);
      this.Disconnect.Name = "Disconnect";
      this.Disconnect.Size = new System.Drawing.Size(179, 23);
      this.Disconnect.TabIndex = 1;
      this.Disconnect.Text = "Disconnect";
      this.Disconnect.UseVisualStyleBackColor = true;
      this.Disconnect.Click += new System.EventHandler(this.Disconnect_Click);
      // 
      // RecievedData
      // 
      this.RecievedData.Location = new System.Drawing.Point(198, 13);
      this.RecievedData.Multiline = true;
      this.RecievedData.Name = "RecievedData";
      this.RecievedData.Size = new System.Drawing.Size(203, 176);
      this.RecievedData.TabIndex = 2;
      // 
      // FClientForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(414, 201);
      this.Controls.Add(this.RecievedData);
      this.Controls.Add(this.Disconnect);
      this.Controls.Add(this.Connect);
      this.Name = "FClientForm";
      this.Text = "FClientForm";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button Connect;
    private System.Windows.Forms.Button Disconnect;
    private System.Windows.Forms.TextBox RecievedData;
  }
}