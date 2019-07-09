using System.Windows.Forms;

namespace CAAssignment
{
    partial class GuideDisplay
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuideDisplay));
            this.Title = new System.Windows.Forms.Label();
            this.BoardStationbox = new System.Windows.Forms.ComboBox();
            this.DestStationbox = new System.Windows.Forms.ComboBox();
            this.BoardLabel = new System.Windows.Forms.Label();
            this.DestLabel = new System.Windows.Forms.Label();
            this.SenditButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.MessageBox = new System.Windows.Forms.TextBox();
            this.GoingToLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.MapButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(150, 128);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(203, 69);
            this.Title.TabIndex = 1;
            this.Title.Text = "IMapIt";
            this.Title.Click += new System.EventHandler(this.Title_Click);
            // 
            // BoardStationbox
            // 
            this.BoardStationbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BoardStationbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoardStationbox.FormattingEnabled = true;
            this.BoardStationbox.Location = new System.Drawing.Point(131, 319);
            this.BoardStationbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BoardStationbox.Name = "BoardStationbox";
            this.BoardStationbox.Size = new System.Drawing.Size(237, 28);
            this.BoardStationbox.TabIndex = 7;
            // 
            // DestStationbox
            // 
            this.DestStationbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DestStationbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DestStationbox.FormattingEnabled = true;
            this.DestStationbox.Location = new System.Drawing.Point(131, 608);
            this.DestStationbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DestStationbox.Name = "DestStationbox";
            this.DestStationbox.Size = new System.Drawing.Size(237, 28);
            this.DestStationbox.TabIndex = 8;
            // 
            // BoardLabel
            // 
            this.BoardLabel.AutoSize = true;
            this.BoardLabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoardLabel.Location = new System.Drawing.Point(108, 258);
            this.BoardLabel.Name = "BoardLabel";
            this.BoardLabel.Size = new System.Drawing.Size(288, 30);
            this.BoardLabel.TabIndex = 9;
            this.BoardLabel.Text = "Select Boarding Station";
            this.BoardLabel.Click += new System.EventHandler(this.BoardLabel_Click);
            // 
            // DestLabel
            // 
            this.DestLabel.AutoSize = true;
            this.DestLabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DestLabel.Location = new System.Drawing.Point(99, 541);
            this.DestLabel.Name = "DestLabel";
            this.DestLabel.Size = new System.Drawing.Size(316, 30);
            this.DestLabel.TabIndex = 10;
            this.DestLabel.Text = "Select Destination Station";
            this.DestLabel.Click += new System.EventHandler(this.DestLabel_Click);
            // 
            // SenditButton
            // 
            this.SenditButton.BackColor = System.Drawing.Color.SpringGreen;
            this.SenditButton.Location = new System.Drawing.Point(277, 700);
            this.SenditButton.Margin = new System.Windows.Forms.Padding(4);
            this.SenditButton.Name = "SenditButton";
            this.SenditButton.Size = new System.Drawing.Size(105, 92);
            this.SenditButton.TabIndex = 12;
            this.SenditButton.Text = "GO!";
            this.SenditButton.UseVisualStyleBackColor = false;
            this.SenditButton.Click += new System.EventHandler(this.SenditButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.Color.Salmon;
            this.ClearButton.Location = new System.Drawing.Point(117, 700);
            this.ClearButton.Margin = new System.Windows.Forms.Padding(4);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(105, 92);
            this.ClearButton.TabIndex = 13;
            this.ClearButton.Text = "CLEAR";
            this.ClearButton.UseVisualStyleBackColor = false;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // MessageBox
            // 
            this.MessageBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MessageBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageBox.Location = new System.Drawing.Point(530, 908);
            this.MessageBox.Margin = new System.Windows.Forms.Padding(4);
            this.MessageBox.Multiline = true;
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.ReadOnly = true;
            this.MessageBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MessageBox.Size = new System.Drawing.Size(809, 101);
            this.MessageBox.TabIndex = 14;
            this.MessageBox.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // GoingToLabel
            // 
            this.GoingToLabel.AutoSize = true;
            this.GoingToLabel.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GoingToLabel.Location = new System.Drawing.Point(155, 432);
            this.GoingToLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.GoingToLabel.Name = "GoingToLabel";
            this.GoingToLabel.Size = new System.Drawing.Size(192, 40);
            this.GoingToLabel.TabIndex = 15;
            this.GoingToLabel.Text = "GOING TO";
            this.GoingToLabel.Click += new System.EventHandler(this.GoingToLabel_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 34);
            this.label1.TabIndex = 16;
            this.label1.Text = "label1";
            // 
            // MapButton
            // 
            this.MapButton.Location = new System.Drawing.Point(181, 930);
            this.MapButton.Name = "MapButton";
            this.MapButton.Size = new System.Drawing.Size(134, 54);
            this.MapButton.TabIndex = 17;
            this.MapButton.Text = "Open Full Map";
            this.MapButton.UseVisualStyleBackColor = true;
            this.MapButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pictureBox1.Location = new System.Drawing.Point(438, 6);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1494, 884);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(233, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 19);
            this.label2.TabIndex = 18;
            this.label2.Text = "Peak Hour 0630-0900 Morning";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(308, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 19);
            this.label3.TabIndex = 19;
            this.label3.Text = "1700-1930 Evening";
            // 
            // GuideDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MapButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GoingToLabel);
            this.Controls.Add(this.MessageBox);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.SenditButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.DestLabel);
            this.Controls.Add(this.BoardLabel);
            this.Controls.Add(this.DestStationbox);
            this.Controls.Add(this.BoardStationbox);
            this.Controls.Add(this.Title);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GuideDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GuideDisplay_FormClosing);
            this.Load += new System.EventHandler(this.GuideDisplay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.ComboBox BoardStationbox;
        private System.Windows.Forms.ComboBox DestStationbox;
        private System.Windows.Forms.Label BoardLabel;
        private System.Windows.Forms.Label DestLabel;
        private System.Windows.Forms.Button SenditButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.TextBox MessageBox;
        private System.Windows.Forms.Label GoingToLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button MapButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

