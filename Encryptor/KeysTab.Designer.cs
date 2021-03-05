namespace Encryptor
{
	partial class KeysTab
	{
		/// <summary> 
		/// Variável de designer necessária.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Limpar os recursos que estão sendo usados.
		/// </summary>
		/// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código gerado pelo Designer de Componentes

		/// <summary> 
		/// Método necessário para suporte ao Designer - não modifique 
		/// o conteúdo deste método com o editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.KeysTabLayout = new System.Windows.Forms.TableLayoutPanel();
			this.KeysList = new System.Windows.Forms.DataGridView();
			this.KeyNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.EditButtonColumn = new System.Windows.Forms.DataGridViewButtonColumn();
			this.RemoveButtonColumn = new System.Windows.Forms.DataGridViewButtonColumn();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.RevertButton = new System.Windows.Forms.Button();
			this.KeyInfoDisplay = new Encryptor.KeyInfoDisplay();
			this.KeysTabLayout.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.KeysList)).BeginInit();
			this.SuspendLayout();
			// 
			// KeysTabLayout
			// 
			this.KeysTabLayout.ColumnCount = 6;
			this.KeysTabLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
			this.KeysTabLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.25F));
			this.KeysTabLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.25F));
			this.KeysTabLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.25F));
			this.KeysTabLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.25F));
			this.KeysTabLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.KeysTabLayout.Controls.Add(this.KeysList, 1, 1);
			this.KeysTabLayout.Controls.Add(this.button1, 1, 2);
			this.KeysTabLayout.Controls.Add(this.button2, 3, 2);
			this.KeysTabLayout.Controls.Add(this.button3, 4, 2);
			this.KeysTabLayout.Controls.Add(this.KeyInfoDisplay, 5, 0);
			this.KeysTabLayout.Controls.Add(this.RevertButton, 2, 2);
			this.KeysTabLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.KeysTabLayout.Location = new System.Drawing.Point(0, 0);
			this.KeysTabLayout.Margin = new System.Windows.Forms.Padding(0);
			this.KeysTabLayout.Name = "KeysTabLayout";
			this.KeysTabLayout.RowCount = 4;
			this.KeysTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
			this.KeysTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82F));
			this.KeysTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
			this.KeysTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
			this.KeysTabLayout.Size = new System.Drawing.Size(624, 274);
			this.KeysTabLayout.TabIndex = 0;
			// 
			// KeysList
			// 
			this.KeysList.AllowUserToAddRows = false;
			this.KeysList.AllowUserToDeleteRows = false;
			this.KeysList.AllowUserToResizeColumns = false;
			this.KeysList.AllowUserToResizeRows = false;
			this.KeysList.BackgroundColor = System.Drawing.Color.DimGray;
			this.KeysList.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.KeysList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
			this.KeysList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.KeysList.ColumnHeadersVisible = false;
			this.KeysList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KeyNameColumn,
            this.EditButtonColumn,
            this.RemoveButtonColumn});
			this.KeysTabLayout.SetColumnSpan(this.KeysList, 4);
			this.KeysList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.KeysList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.KeysList.EnableHeadersVisualStyles = false;
			this.KeysList.GridColor = System.Drawing.Color.Black;
			this.KeysList.Location = new System.Drawing.Point(6, 5);
			this.KeysList.Margin = new System.Windows.Forms.Padding(0);
			this.KeysList.MultiSelect = false;
			this.KeysList.Name = "KeysList";
			this.KeysList.ReadOnly = true;
			this.KeysList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.KeysList.RowHeadersVisible = false;
			this.KeysList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.KeysList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.KeysList.Size = new System.Drawing.Size(304, 224);
			this.KeysList.TabIndex = 0;
			this.KeysList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.KeysList_CellContentClick);
			this.KeysList.SelectionChanged += new System.EventHandler(this.KeysList_SelectionChanged);
			this.KeysList.SizeChanged += new System.EventHandler(this.KeysList_SizeChanged);
			// 
			// KeyNameColumn
			// 
			this.KeyNameColumn.HeaderText = "Key Name";
			this.KeyNameColumn.Name = "KeyNameColumn";
			this.KeyNameColumn.ReadOnly = true;
			// 
			// EditButtonColumn
			// 
			this.EditButtonColumn.HeaderText = "Edit";
			this.EditButtonColumn.Name = "EditButtonColumn";
			this.EditButtonColumn.ReadOnly = true;
			// 
			// RemoveButtonColumn
			// 
			this.RemoveButtonColumn.HeaderText = "Remove";
			this.RemoveButtonColumn.Name = "RemoveButtonColumn";
			this.RemoveButtonColumn.ReadOnly = true;
			// 
			// button1
			// 
			this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.button1.Location = new System.Drawing.Point(6, 229);
			this.button1.Margin = new System.Windows.Forms.Padding(0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(76, 38);
			this.button1.TabIndex = 1;
			this.button1.Text = "Salvar";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.SaveChangesButton_Click);
			// 
			// button2
			// 
			this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.button2.Location = new System.Drawing.Point(158, 229);
			this.button2.Margin = new System.Windows.Forms.Padding(0);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(76, 38);
			this.button2.TabIndex = 2;
			this.button2.Text = "Remover Todos";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.RemoveAllButton_Click);
			// 
			// button3
			// 
			this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.button3.Location = new System.Drawing.Point(234, 229);
			this.button3.Margin = new System.Windows.Forms.Padding(0);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(76, 38);
			this.button3.TabIndex = 3;
			this.button3.Text = "Adicionar";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.AddKeyButton_Click);
			// 
			// RevertButton
			// 
			this.RevertButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RevertButton.Location = new System.Drawing.Point(82, 229);
			this.RevertButton.Margin = new System.Windows.Forms.Padding(0);
			this.RevertButton.Name = "RevertButton";
			this.RevertButton.Size = new System.Drawing.Size(76, 38);
			this.RevertButton.TabIndex = 5;
			this.RevertButton.Text = "Reverter";
			this.RevertButton.UseVisualStyleBackColor = true;
			this.RevertButton.Click += new System.EventHandler(this.RevertButton_Click);
			// 
			// KeyInfoDisplay
			// 
			this.KeyInfoDisplay.AccessibleName = "KeyInfoDisplay";
			this.KeyInfoDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
			this.KeyInfoDisplay.Location = new System.Drawing.Point(310, 0);
			this.KeyInfoDisplay.Margin = new System.Windows.Forms.Padding(0);
			this.KeyInfoDisplay.Name = "KeyInfoDisplay";
			this.KeysTabLayout.SetRowSpan(this.KeyInfoDisplay, 4);
			this.KeyInfoDisplay.Size = new System.Drawing.Size(314, 274);
			this.KeyInfoDisplay.TabIndex = 4;
			// 
			// KeysTab
			// 
			this.AccessibleName = "KeysTab";
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.KeysTabLayout);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "KeysTab";
			this.Size = new System.Drawing.Size(624, 274);
			this.SizeChanged += new System.EventHandler(this.KeysTab_SizeChanged);
			this.KeysTabLayout.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.KeysList)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel KeysTabLayout;
		private System.Windows.Forms.DataGridView KeysList;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.DataGridViewTextBoxColumn KeyNameColumn;
		private System.Windows.Forms.DataGridViewButtonColumn EditButtonColumn;
		private System.Windows.Forms.DataGridViewButtonColumn RemoveButtonColumn;
		private KeyInfoDisplay KeyInfoDisplay;
		private System.Windows.Forms.Button RevertButton;
	}
}
