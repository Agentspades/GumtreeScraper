
namespace GumTreeScrape
{
    partial class GUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            this.label1 = new System.Windows.Forms.Label();
            this.search_TextBox = new System.Windows.Forms.TextBox();
            this.add_Button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.current_TextBox = new System.Windows.Forms.TextBox();
            this.remove_Button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.sent_TextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cost_TextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.refresh_TextBox = new System.Windows.Forms.TextBox();
            this.start_Button = new System.Windows.Forms.Button();
            this.stop_Button = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label6 = new System.Windows.Forms.Label();
            this.Radius_ComboBox = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search Term:";
            // 
            // search_TextBox
            // 
            this.search_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_TextBox.Location = new System.Drawing.Point(179, 27);
            this.search_TextBox.Name = "search_TextBox";
            this.search_TextBox.Size = new System.Drawing.Size(150, 29);
            this.search_TextBox.TabIndex = 1;
            // 
            // add_Button
            // 
            this.add_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_Button.Location = new System.Drawing.Point(179, 135);
            this.add_Button.Name = "add_Button";
            this.add_Button.Size = new System.Drawing.Size(150, 29);
            this.add_Button.TabIndex = 2;
            this.add_Button.Text = "Add";
            this.add_Button.UseVisualStyleBackColor = true;
            this.add_Button.Click += new System.EventHandler(this.add_Button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Current Searches:";
            // 
            // current_TextBox
            // 
            this.current_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.current_TextBox.Location = new System.Drawing.Point(179, 189);
            this.current_TextBox.Multiline = true;
            this.current_TextBox.Name = "current_TextBox";
            this.current_TextBox.ReadOnly = true;
            this.current_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.current_TextBox.Size = new System.Drawing.Size(324, 119);
            this.current_TextBox.TabIndex = 4;
            // 
            // remove_Button
            // 
            this.remove_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remove_Button.Location = new System.Drawing.Point(353, 135);
            this.remove_Button.Name = "remove_Button";
            this.remove_Button.Size = new System.Drawing.Size(150, 29);
            this.remove_Button.TabIndex = 5;
            this.remove_Button.Text = "Remove";
            this.remove_Button.UseVisualStyleBackColor = true;
            this.remove_Button.Click += new System.EventHandler(this.remove_Button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 390);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Messages Sent:";
            // 
            // sent_TextBox
            // 
            this.sent_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sent_TextBox.Location = new System.Drawing.Point(179, 387);
            this.sent_TextBox.Name = "sent_TextBox";
            this.sent_TextBox.ReadOnly = true;
            this.sent_TextBox.Size = new System.Drawing.Size(324, 29);
            this.sent_TextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(121, 444);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "Cost:";
            // 
            // cost_TextBox
            // 
            this.cost_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cost_TextBox.Location = new System.Drawing.Point(179, 441);
            this.cost_TextBox.Name = "cost_TextBox";
            this.cost_TextBox.ReadOnly = true;
            this.cost_TextBox.Size = new System.Drawing.Size(324, 29);
            this.cost_TextBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 24);
            this.label5.TabIndex = 10;
            this.label5.Text = "Refresh Duration:";
            // 
            // refresh_TextBox
            // 
            this.refresh_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refresh_TextBox.Location = new System.Drawing.Point(179, 81);
            this.refresh_TextBox.Name = "refresh_TextBox";
            this.refresh_TextBox.Size = new System.Drawing.Size(324, 29);
            this.refresh_TextBox.TabIndex = 11;
            // 
            // start_Button
            // 
            this.start_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_Button.Location = new System.Drawing.Point(179, 332);
            this.start_Button.Name = "start_Button";
            this.start_Button.Size = new System.Drawing.Size(150, 29);
            this.start_Button.TabIndex = 12;
            this.start_Button.Text = "Start";
            this.start_Button.UseVisualStyleBackColor = true;
            this.start_Button.Click += new System.EventHandler(this.start_Button_Click);
            // 
            // stop_Button
            // 
            this.stop_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stop_Button.Location = new System.Drawing.Point(353, 332);
            this.stop_Button.Name = "stop_Button";
            this.stop_Button.Size = new System.Drawing.Size(150, 29);
            this.stop_Button.TabIndex = 13;
            this.stop_Button.Text = "Stop";
            this.stop_Button.UseVisualStyleBackColor = true;
            this.stop_Button.Click += new System.EventHandler(this.stop_Button_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(515, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(335, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 24);
            this.label6.TabIndex = 15;
            this.label6.Text = "Radius:";
            // 
            // Radius_ComboBox
            // 
            this.Radius_ComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Radius_ComboBox.FormattingEnabled = true;
            this.Radius_ComboBox.Items.AddRange(new object[] {
            "+0km",
            "+2km",
            "+5km",
            "+10km",
            "+20km",
            "+50km",
            "+100km",
            "+250km",
            "+500km"});
            this.Radius_ComboBox.Location = new System.Drawing.Point(414, 27);
            this.Radius_ComboBox.Name = "Radius_ComboBox";
            this.Radius_ComboBox.Size = new System.Drawing.Size(89, 32);
            this.Radius_ComboBox.TabIndex = 16;
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 491);
            this.Controls.Add(this.Radius_ComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.stop_Button);
            this.Controls.Add(this.start_Button);
            this.Controls.Add(this.refresh_TextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cost_TextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sent_TextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.remove_Button);
            this.Controls.Add(this.current_TextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.add_Button);
            this.Controls.Add(this.search_TextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GUI";
            this.Text = "Gumtree Moniter";
            this.Load += new System.EventHandler(this.GUI_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox search_TextBox;
        private System.Windows.Forms.Button add_Button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox current_TextBox;
        private System.Windows.Forms.Button remove_Button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox sent_TextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox cost_TextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox refresh_TextBox;
        private System.Windows.Forms.Button start_Button;
        private System.Windows.Forms.Button stop_Button;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox Radius_ComboBox;
    }
}