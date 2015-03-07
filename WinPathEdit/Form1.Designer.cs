namespace WinPathEdit
{
    partial class Form1
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
            this.dgvPaths = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnVarType = new System.Windows.Forms.Button();
            this.cmsItemOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Paths = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaths)).BeginInit();
            this.cmsItemOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPaths
            // 
            this.dgvPaths.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPaths.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPaths.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Paths});
            this.dgvPaths.Location = new System.Drawing.Point(13, 13);
            this.dgvPaths.Name = "dgvPaths";
            this.dgvPaths.Size = new System.Drawing.Size(491, 367);
            this.dgvPaths.TabIndex = 0;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(510, 13);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnVarType
            // 
            this.btnVarType.Location = new System.Drawing.Point(510, 43);
            this.btnVarType.Name = "btnVarType";
            this.btnVarType.Size = new System.Drawing.Size(75, 23);
            this.btnVarType.TabIndex = 2;
            this.btnVarType.Text = "User";
            this.btnVarType.UseVisualStyleBackColor = true;
            this.btnVarType.Click += new System.EventHandler(this.btnVarType_Click);
            // 
            // cmsItemOptions
            // 
            this.cmsItemOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.cmsItemOptions.Name = "cmsItemOptions";
            this.cmsItemOptions.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // Paths
            // 
            this.Paths.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Paths.ContextMenuStrip = this.cmsItemOptions;
            this.Paths.DataPropertyName = "Var";
            this.Paths.HeaderText = "Paths";
            this.Paths.Name = "Paths";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 392);
            this.Controls.Add(this.btnVarType);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dgvPaths);
            this.Name = "Form1";
            this.Text = "Windows Path Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaths)).EndInit();
            this.cmsItemOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPaths;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnVarType;
        private System.Windows.Forms.ContextMenuStrip cmsItemOptions;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Paths;

    }
}

