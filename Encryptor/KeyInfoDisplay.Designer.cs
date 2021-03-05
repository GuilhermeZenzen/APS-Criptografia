namespace Encryptor
{
	partial class KeyInfoDisplay
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
			this.KeyInfoLayout = new System.Windows.Forms.TableLayoutPanel();
			this.PublicKeyTextBox = new System.Windows.Forms.TextBox();
			this.PrivateKeyTextBox = new System.Windows.Forms.TextBox();
			this.PublicKeyTitle = new System.Windows.Forms.Label();
			this.PrivateKeyTitle = new System.Windows.Forms.Label();
			this.PublicKeyCopyButton = new System.Windows.Forms.Button();
			this.PrivateKeyCopyButton = new System.Windows.Forms.Button();
			this.EditButton = new System.Windows.Forms.Button();
			this.KeyNameBackground = new System.Windows.Forms.Panel();
			this.KeyName = new System.Windows.Forms.Label();
			this.KeyInfoLayout.SuspendLayout();
			this.KeyNameBackground.SuspendLayout();
			this.SuspendLayout();
			// 
			// KeyInfoLayout
			// 
			this.KeyInfoLayout.ColumnCount = 3;
			this.KeyInfoLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.KeyInfoLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
			this.KeyInfoLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.KeyInfoLayout.Controls.Add(this.PublicKeyTextBox, 1, 5);
			this.KeyInfoLayout.Controls.Add(this.PrivateKeyTextBox, 1, 10);
			this.KeyInfoLayout.Controls.Add(this.PublicKeyTitle, 1, 3);
			this.KeyInfoLayout.Controls.Add(this.PrivateKeyTitle, 1, 8);
			this.KeyInfoLayout.Controls.Add(this.PublicKeyCopyButton, 1, 6);
			this.KeyInfoLayout.Controls.Add(this.PrivateKeyCopyButton, 1, 11);
			this.KeyInfoLayout.Controls.Add(this.EditButton, 1, 13);
			this.KeyInfoLayout.Controls.Add(this.KeyNameBackground, 1, 1);
			this.KeyInfoLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.KeyInfoLayout.Location = new System.Drawing.Point(0, 0);
			this.KeyInfoLayout.Margin = new System.Windows.Forms.Padding(0);
			this.KeyInfoLayout.Name = "KeyInfoLayout";
			this.KeyInfoLayout.RowCount = 15;
			this.KeyInfoLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
			this.KeyInfoLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
			this.KeyInfoLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3F));
			this.KeyInfoLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
			this.KeyInfoLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
			this.KeyInfoLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.KeyInfoLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
			this.KeyInfoLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3F));
			this.KeyInfoLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
			this.KeyInfoLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
			this.KeyInfoLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.KeyInfoLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
			this.KeyInfoLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3F));
			this.KeyInfoLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
			this.KeyInfoLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
			this.KeyInfoLayout.Size = new System.Drawing.Size(306, 296);
			this.KeyInfoLayout.TabIndex = 0;
			// 
			// PublicKeyTextBox
			// 
			this.PublicKeyTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PublicKeyTextBox.Location = new System.Drawing.Point(30, 52);
			this.PublicKeyTextBox.Margin = new System.Windows.Forms.Padding(0);
			this.PublicKeyTextBox.Multiline = true;
			this.PublicKeyTextBox.Name = "PublicKeyTextBox";
			this.PublicKeyTextBox.ReadOnly = true;
			this.PublicKeyTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.PublicKeyTextBox.Size = new System.Drawing.Size(244, 59);
			this.PublicKeyTextBox.TabIndex = 0;
			// 
			// PrivateKeyTextBox
			// 
			this.PrivateKeyTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PrivateKeyTextBox.Location = new System.Drawing.Point(30, 161);
			this.PrivateKeyTextBox.Margin = new System.Windows.Forms.Padding(0);
			this.PrivateKeyTextBox.Multiline = true;
			this.PrivateKeyTextBox.Name = "PrivateKeyTextBox";
			this.PrivateKeyTextBox.ReadOnly = true;
			this.PrivateKeyTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.PrivateKeyTextBox.Size = new System.Drawing.Size(244, 59);
			this.PrivateKeyTextBox.TabIndex = 1;
			// 
			// PublicKeyTitle
			// 
			this.PublicKeyTitle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PublicKeyTitle.Location = new System.Drawing.Point(33, 36);
			this.PublicKeyTitle.Name = "PublicKeyTitle";
			this.PublicKeyTitle.Size = new System.Drawing.Size(238, 14);
			this.PublicKeyTitle.TabIndex = 3;
			this.PublicKeyTitle.Text = "Chave Pública";
			this.PublicKeyTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// PrivateKeyTitle
			// 
			this.PrivateKeyTitle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PrivateKeyTitle.Location = new System.Drawing.Point(33, 145);
			this.PrivateKeyTitle.Name = "PrivateKeyTitle";
			this.PrivateKeyTitle.Size = new System.Drawing.Size(238, 14);
			this.PrivateKeyTitle.TabIndex = 4;
			this.PrivateKeyTitle.Text = "Chave Privada";
			this.PrivateKeyTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// PublicKeyCopyButton
			// 
			this.PublicKeyCopyButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PublicKeyCopyButton.Location = new System.Drawing.Point(30, 111);
			this.PublicKeyCopyButton.Margin = new System.Windows.Forms.Padding(0);
			this.PublicKeyCopyButton.Name = "PublicKeyCopyButton";
			this.PublicKeyCopyButton.Size = new System.Drawing.Size(244, 26);
			this.PublicKeyCopyButton.TabIndex = 5;
			this.PublicKeyCopyButton.Text = "Copiar";
			this.PublicKeyCopyButton.UseVisualStyleBackColor = true;
			this.PublicKeyCopyButton.Click += new System.EventHandler(this.PublicKeyCopyButton_Click);
			// 
			// PrivateKeyCopyButton
			// 
			this.PrivateKeyCopyButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PrivateKeyCopyButton.Location = new System.Drawing.Point(30, 220);
			this.PrivateKeyCopyButton.Margin = new System.Windows.Forms.Padding(0);
			this.PrivateKeyCopyButton.Name = "PrivateKeyCopyButton";
			this.PrivateKeyCopyButton.Size = new System.Drawing.Size(244, 26);
			this.PrivateKeyCopyButton.TabIndex = 6;
			this.PrivateKeyCopyButton.Text = "Copiar";
			this.PrivateKeyCopyButton.UseVisualStyleBackColor = true;
			this.PrivateKeyCopyButton.Click += new System.EventHandler(this.PrivateKeyCopyButton_Click);
			// 
			// EditButton
			// 
			this.EditButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.EditButton.Location = new System.Drawing.Point(30, 254);
			this.EditButton.Margin = new System.Windows.Forms.Padding(0);
			this.EditButton.Name = "EditButton";
			this.EditButton.Size = new System.Drawing.Size(244, 26);
			this.EditButton.TabIndex = 7;
			this.EditButton.Text = "Editar";
			this.EditButton.UseVisualStyleBackColor = true;
			this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
			// 
			// KeyNameBackground
			// 
			this.KeyNameBackground.BackColor = System.Drawing.Color.SlateGray;
			this.KeyNameBackground.Controls.Add(this.KeyName);
			this.KeyNameBackground.Dock = System.Windows.Forms.DockStyle.Fill;
			this.KeyNameBackground.Location = new System.Drawing.Point(30, 5);
			this.KeyNameBackground.Margin = new System.Windows.Forms.Padding(0);
			this.KeyNameBackground.Name = "KeyNameBackground";
			this.KeyNameBackground.Size = new System.Drawing.Size(244, 23);
			this.KeyNameBackground.TabIndex = 8;
			// 
			// KeyName
			// 
			this.KeyName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.KeyName.Location = new System.Drawing.Point(0, 0);
			this.KeyName.Name = "KeyName";
			this.KeyName.Size = new System.Drawing.Size(244, 23);
			this.KeyName.TabIndex = 2;
			this.KeyName.Text = "Nome";
			this.KeyName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// KeyInfoDisplay
			// 
			this.AccessibleName = "KeyInfoDisplay";
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.KeyInfoLayout);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "KeyInfoDisplay";
			this.Size = new System.Drawing.Size(306, 296);
			this.Load += new System.EventHandler(this.KeyInfoDisplay_Load);
			this.SizeChanged += new System.EventHandler(this.KeyInfoDisplay_SizeChanged);
			this.KeyInfoLayout.ResumeLayout(false);
			this.KeyInfoLayout.PerformLayout();
			this.KeyNameBackground.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel KeyInfoLayout;
		private System.Windows.Forms.TextBox PublicKeyTextBox;
		private System.Windows.Forms.TextBox PrivateKeyTextBox;
		private System.Windows.Forms.Label KeyName;
		private System.Windows.Forms.Label PublicKeyTitle;
		private System.Windows.Forms.Label PrivateKeyTitle;
		private System.Windows.Forms.Button PublicKeyCopyButton;
		private System.Windows.Forms.Button PrivateKeyCopyButton;
		private System.Windows.Forms.Button EditButton;
		private System.Windows.Forms.Panel KeyNameBackground;
	}
}
