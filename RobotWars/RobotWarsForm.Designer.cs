namespace RobotWars
{
    partial class RobotWarsForm
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
            this.commandTextBox = new System.Windows.Forms.TextBox();
            this.restartButton = new System.Windows.Forms.Button();
            this.arenaPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.finalPositionLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandTextBox
            // 
            this.commandTextBox.BackColor = System.Drawing.Color.Black;
            this.commandTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commandTextBox.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commandTextBox.ForeColor = System.Drawing.Color.DodgerBlue;
            this.commandTextBox.Location = new System.Drawing.Point(3, 53);
            this.commandTextBox.Multiline = true;
            this.commandTextBox.Name = "commandTextBox";
            this.commandTextBox.Size = new System.Drawing.Size(294, 529);
            this.commandTextBox.TabIndex = 0;
            this.commandTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.commandTextBox_KeyPress);
            // 
            // restartButton
            // 
            this.restartButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.restartButton.Location = new System.Drawing.Point(3, 3);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(294, 44);
            this.restartButton.TabIndex = 3;
            this.restartButton.Text = "Restart";
            this.restartButton.UseVisualStyleBackColor = true;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // arenaPanel
            // 
            this.arenaPanel.AutoScroll = true;
            this.arenaPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.arenaPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.arenaPanel.Location = new System.Drawing.Point(303, 53);
            this.arenaPanel.Name = "arenaPanel";
            this.arenaPanel.Size = new System.Drawing.Size(628, 529);
            this.arenaPanel.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.commandTextBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.restartButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.arenaPanel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.finalPositionLabel, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 319F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(934, 585);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // finalPositionLabel
            // 
            this.finalPositionLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finalPositionLabel.Location = new System.Drawing.Point(303, 0);
            this.finalPositionLabel.Name = "finalPositionLabel";
            this.finalPositionLabel.Size = new System.Drawing.Size(307, 47);
            this.finalPositionLabel.TabIndex = 5;
            this.finalPositionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RobotWarsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 585);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RobotWarsForm";
            this.Text = "Robot Wars";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox commandTextBox;
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.Panel arenaPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label finalPositionLabel;
    }
}

