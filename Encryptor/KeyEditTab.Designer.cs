namespace Encryptor
{
	partial class KeyEditTab
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
			this.KeyEditTabLayout = new System.Windows.Forms.TableLayoutPanel();
			this.RevertButton = new System.Windows.Forms.Button();
			this.SaveButton = new System.Windows.Forms.Button();
			this.BackButton = new System.Windows.Forms.Button();
			this.KeyNameTextBox = new System.Windows.Forms.TextBox();
			this.EncryptionModeDropdown = new System.Windows.Forms.ComboBox();
			this.AutoEditLayout = new System.Windows.Forms.TableLayoutPanel();
			this.KeySizeTextBox = new System.Windows.Forms.TextBox();
			this.PrivateKeyValidationPanel = new System.Windows.Forms.Panel();
			this.ValidatePrivateKeyButton = new System.Windows.Forms.Button();
			this.PrivateKeyValidationMessage = new System.Windows.Forms.Label();
			this.PublicKeyValidationPanel = new System.Windows.Forms.Panel();
			this.ValidatePublicKeyButton = new System.Windows.Forms.Button();
			this.PublicKeyValidationMessage = new System.Windows.Forms.Label();
			this.GenerateKeysButton = new System.Windows.Forms.Button();
			this.PrivateKeyTitle = new System.Windows.Forms.Label();
			this.PublicKeyTitle = new System.Windows.Forms.Label();
			this.PublicKeyTextBox = new System.Windows.Forms.TextBox();
			this.PrivateKeyTextBox = new System.Windows.Forms.TextBox();
			this.EditPanel = new System.Windows.Forms.Panel();
			this.KeyEditTabLayout.SuspendLayout();
			this.AutoEditLayout.SuspendLayout();
			this.PrivateKeyValidationPanel.SuspendLayout();
			this.PublicKeyValidationPanel.SuspendLayout();
			this.EditPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// KeyEditTabLayout
			// 
			this.KeyEditTabLayout.ColumnCount = 4;
			this.KeyEditTabLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.KeyEditTabLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.KeyEditTabLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.KeyEditTabLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.KeyEditTabLayout.Controls.Add(this.RevertButton, 1, 5);
			this.KeyEditTabLayout.Controls.Add(this.SaveButton, 2, 5);
			this.KeyEditTabLayout.Controls.Add(this.BackButton, 1, 6);
			this.KeyEditTabLayout.Controls.Add(this.KeyNameTextBox, 1, 1);
			this.KeyEditTabLayout.Controls.Add(this.EncryptionModeDropdown, 1, 3);
			this.KeyEditTabLayout.Controls.Add(this.EditPanel, 0, 4);
			this.KeyEditTabLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.KeyEditTabLayout.Location = new System.Drawing.Point(0, 0);
			this.KeyEditTabLayout.Margin = new System.Windows.Forms.Padding(0);
			this.KeyEditTabLayout.Name = "KeyEditTabLayout";
			this.KeyEditTabLayout.RowCount = 8;
			this.KeyEditTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
			this.KeyEditTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
			this.KeyEditTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
			this.KeyEditTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
			this.KeyEditTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63F));
			this.KeyEditTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
			this.KeyEditTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
			this.KeyEditTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
			this.KeyEditTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.KeyEditTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.KeyEditTabLayout.Size = new System.Drawing.Size(624, 322);
			this.KeyEditTabLayout.TabIndex = 0;
			// 
			// RevertButton
			// 
			this.RevertButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RevertButton.Location = new System.Drawing.Point(124, 261);
			this.RevertButton.Margin = new System.Windows.Forms.Padding(0);
			this.RevertButton.Name = "RevertButton";
			this.RevertButton.Size = new System.Drawing.Size(187, 25);
			this.RevertButton.TabIndex = 2;
			this.RevertButton.Text = "Reverter";
			this.RevertButton.UseVisualStyleBackColor = true;
			this.RevertButton.Click += new System.EventHandler(this.RevertButton_Click);
			// 
			// SaveButton
			// 
			this.SaveButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SaveButton.Location = new System.Drawing.Point(311, 261);
			this.SaveButton.Margin = new System.Windows.Forms.Padding(0);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(187, 25);
			this.SaveButton.TabIndex = 3;
			this.SaveButton.Text = "Salvar";
			this.SaveButton.UseVisualStyleBackColor = true;
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// BackButton
			// 
			this.KeyEditTabLayout.SetColumnSpan(this.BackButton, 2);
			this.BackButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BackButton.Location = new System.Drawing.Point(124, 286);
			this.BackButton.Margin = new System.Windows.Forms.Padding(0);
			this.BackButton.Name = "BackButton";
			this.BackButton.Size = new System.Drawing.Size(374, 25);
			this.BackButton.TabIndex = 4;
			this.BackButton.Text = "Voltar";
			this.BackButton.UseVisualStyleBackColor = true;
			this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
			// 
			// KeyNameTextBox
			// 
			this.KeyEditTabLayout.SetColumnSpan(this.KeyNameTextBox, 2);
			this.KeyNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.KeyNameTextBox.Location = new System.Drawing.Point(124, 6);
			this.KeyNameTextBox.Margin = new System.Windows.Forms.Padding(0);
			this.KeyNameTextBox.Multiline = true;
			this.KeyNameTextBox.Name = "KeyNameTextBox";
			this.KeyNameTextBox.Size = new System.Drawing.Size(374, 25);
			this.KeyNameTextBox.TabIndex = 5;
			this.KeyNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// EncryptionModeDropdown
			// 
			this.KeyEditTabLayout.SetColumnSpan(this.EncryptionModeDropdown, 2);
			this.EncryptionModeDropdown.Dock = System.Windows.Forms.DockStyle.Fill;
			this.EncryptionModeDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.EncryptionModeDropdown.FormattingEnabled = true;
			this.EncryptionModeDropdown.Location = new System.Drawing.Point(124, 34);
			this.EncryptionModeDropdown.Margin = new System.Windows.Forms.Padding(0);
			this.EncryptionModeDropdown.Name = "EncryptionModeDropdown";
			this.EncryptionModeDropdown.Size = new System.Drawing.Size(374, 21);
			this.EncryptionModeDropdown.TabIndex = 8;
			this.EncryptionModeDropdown.SelectedIndexChanged += new System.EventHandler(this.EncryptionModeDropdown_SelectedIndexChanged);
			// 
			// AutoEditLayout
			// 
			this.AutoEditLayout.ColumnCount = 7;
			this.AutoEditLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
			this.AutoEditLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
			this.AutoEditLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2F));
			this.AutoEditLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
			this.AutoEditLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2F));
			this.AutoEditLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
			this.AutoEditLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
			this.AutoEditLayout.Controls.Add(this.PrivateKeyTextBox, 5, 3);
			this.AutoEditLayout.Controls.Add(this.PublicKeyTextBox, 1, 3);
			this.AutoEditLayout.Controls.Add(this.PublicKeyTitle, 1, 1);
			this.AutoEditLayout.Controls.Add(this.PrivateKeyTitle, 5, 1);
			this.AutoEditLayout.Controls.Add(this.GenerateKeysButton, 3, 4);
			this.AutoEditLayout.Controls.Add(this.PublicKeyValidationPanel, 1, 6);
			this.AutoEditLayout.Controls.Add(this.PrivateKeyValidationPanel, 5, 6);
			this.AutoEditLayout.Controls.Add(this.KeySizeTextBox, 3, 3);
			this.AutoEditLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AutoEditLayout.Location = new System.Drawing.Point(0, 0);
			this.AutoEditLayout.Margin = new System.Windows.Forms.Padding(0);
			this.AutoEditLayout.Name = "AutoEditLayout";
			this.AutoEditLayout.RowCount = 8;
			this.AutoEditLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.5F));
			this.AutoEditLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.AutoEditLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
			this.AutoEditLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.AutoEditLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.AutoEditLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
			this.AutoEditLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.AutoEditLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.5F));
			this.AutoEditLayout.Size = new System.Drawing.Size(624, 202);
			this.AutoEditLayout.TabIndex = 0;
			// 
			// KeySizeTextBox
			// 
			this.KeySizeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.KeySizeTextBox.Location = new System.Drawing.Point(261, 37);
			this.KeySizeTextBox.Margin = new System.Windows.Forms.Padding(0);
			this.KeySizeTextBox.MaxLength = 5;
			this.KeySizeTextBox.Name = "KeySizeTextBox";
			this.KeySizeTextBox.Size = new System.Drawing.Size(99, 20);
			this.KeySizeTextBox.TabIndex = 10;
			this.KeySizeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.KeySizeTextBox.TextChanged += new System.EventHandler(this.KeySizeTextBox_TextChanged);
			// 
			// PrivateKeyValidationPanel
			// 
			this.PrivateKeyValidationPanel.Controls.Add(this.PrivateKeyValidationMessage);
			this.PrivateKeyValidationPanel.Controls.Add(this.ValidatePrivateKeyButton);
			this.PrivateKeyValidationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PrivateKeyValidationPanel.Location = new System.Drawing.Point(372, 147);
			this.PrivateKeyValidationPanel.Margin = new System.Windows.Forms.Padding(0);
			this.PrivateKeyValidationPanel.Name = "PrivateKeyValidationPanel";
			this.PrivateKeyValidationPanel.Size = new System.Drawing.Size(218, 40);
			this.PrivateKeyValidationPanel.TabIndex = 9;
			// 
			// ValidatePrivateKeyButton
			// 
			this.ValidatePrivateKeyButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ValidatePrivateKeyButton.Location = new System.Drawing.Point(0, 0);
			this.ValidatePrivateKeyButton.Margin = new System.Windows.Forms.Padding(0);
			this.ValidatePrivateKeyButton.Name = "ValidatePrivateKeyButton";
			this.ValidatePrivateKeyButton.Size = new System.Drawing.Size(218, 40);
			this.ValidatePrivateKeyButton.TabIndex = 7;
			this.ValidatePrivateKeyButton.Text = "Validar Chave";
			this.ValidatePrivateKeyButton.UseVisualStyleBackColor = true;
			this.ValidatePrivateKeyButton.Click += new System.EventHandler(this.ValidatePrivateKeyButton_Click);
			// 
			// PrivateKeyValidationMessage
			// 
			this.PrivateKeyValidationMessage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PrivateKeyValidationMessage.ForeColor = System.Drawing.Color.LimeGreen;
			this.PrivateKeyValidationMessage.Location = new System.Drawing.Point(0, 0);
			this.PrivateKeyValidationMessage.Margin = new System.Windows.Forms.Padding(0);
			this.PrivateKeyValidationMessage.Name = "PrivateKeyValidationMessage";
			this.PrivateKeyValidationMessage.Size = new System.Drawing.Size(218, 40);
			this.PrivateKeyValidationMessage.TabIndex = 8;
			this.PrivateKeyValidationMessage.Text = "Chave válida";
			this.PrivateKeyValidationMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// PublicKeyValidationPanel
			// 
			this.PublicKeyValidationPanel.Controls.Add(this.PublicKeyValidationMessage);
			this.PublicKeyValidationPanel.Controls.Add(this.ValidatePublicKeyButton);
			this.PublicKeyValidationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PublicKeyValidationPanel.Location = new System.Drawing.Point(31, 147);
			this.PublicKeyValidationPanel.Margin = new System.Windows.Forms.Padding(0);
			this.PublicKeyValidationPanel.Name = "PublicKeyValidationPanel";
			this.PublicKeyValidationPanel.Size = new System.Drawing.Size(218, 40);
			this.PublicKeyValidationPanel.TabIndex = 8;
			// 
			// ValidatePublicKeyButton
			// 
			this.ValidatePublicKeyButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ValidatePublicKeyButton.Location = new System.Drawing.Point(0, 0);
			this.ValidatePublicKeyButton.Margin = new System.Windows.Forms.Padding(0);
			this.ValidatePublicKeyButton.Name = "ValidatePublicKeyButton";
			this.ValidatePublicKeyButton.Size = new System.Drawing.Size(218, 40);
			this.ValidatePublicKeyButton.TabIndex = 6;
			this.ValidatePublicKeyButton.Text = "Validar Chave";
			this.ValidatePublicKeyButton.UseVisualStyleBackColor = true;
			this.ValidatePublicKeyButton.Click += new System.EventHandler(this.ValidatePublicKeyButton_Click);
			// 
			// PublicKeyValidationMessage
			// 
			this.PublicKeyValidationMessage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PublicKeyValidationMessage.ForeColor = System.Drawing.Color.LimeGreen;
			this.PublicKeyValidationMessage.Location = new System.Drawing.Point(0, 0);
			this.PublicKeyValidationMessage.Margin = new System.Windows.Forms.Padding(0);
			this.PublicKeyValidationMessage.Name = "PublicKeyValidationMessage";
			this.PublicKeyValidationMessage.Size = new System.Drawing.Size(218, 40);
			this.PublicKeyValidationMessage.TabIndex = 7;
			this.PublicKeyValidationMessage.Text = "Chave válida";
			this.PublicKeyValidationMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// GenerateKeysButton
			// 
			this.GenerateKeysButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GenerateKeysButton.Location = new System.Drawing.Point(261, 87);
			this.GenerateKeysButton.Margin = new System.Windows.Forms.Padding(0);
			this.GenerateKeysButton.Name = "GenerateKeysButton";
			this.GenerateKeysButton.Size = new System.Drawing.Size(99, 50);
			this.GenerateKeysButton.TabIndex = 5;
			this.GenerateKeysButton.Text = "Gerar Chaves";
			this.GenerateKeysButton.UseVisualStyleBackColor = true;
			this.GenerateKeysButton.Click += new System.EventHandler(this.GenerateKeysButton_Click);
			// 
			// PrivateKeyTitle
			// 
			this.PrivateKeyTitle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PrivateKeyTitle.Location = new System.Drawing.Point(372, 13);
			this.PrivateKeyTitle.Margin = new System.Windows.Forms.Padding(0);
			this.PrivateKeyTitle.Name = "PrivateKeyTitle";
			this.PrivateKeyTitle.Size = new System.Drawing.Size(218, 20);
			this.PrivateKeyTitle.TabIndex = 3;
			this.PrivateKeyTitle.Text = "Chave Privada";
			this.PrivateKeyTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// PublicKeyTitle
			// 
			this.PublicKeyTitle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PublicKeyTitle.Location = new System.Drawing.Point(31, 13);
			this.PublicKeyTitle.Margin = new System.Windows.Forms.Padding(0);
			this.PublicKeyTitle.Name = "PublicKeyTitle";
			this.PublicKeyTitle.Size = new System.Drawing.Size(218, 20);
			this.PublicKeyTitle.TabIndex = 2;
			this.PublicKeyTitle.Text = "Chave Pública";
			this.PublicKeyTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// PublicKeyTextBox
			// 
			this.PublicKeyTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PublicKeyTextBox.Location = new System.Drawing.Point(31, 37);
			this.PublicKeyTextBox.Margin = new System.Windows.Forms.Padding(0);
			this.PublicKeyTextBox.Multiline = true;
			this.PublicKeyTextBox.Name = "PublicKeyTextBox";
			this.AutoEditLayout.SetRowSpan(this.PublicKeyTextBox, 2);
			this.PublicKeyTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.PublicKeyTextBox.Size = new System.Drawing.Size(218, 100);
			this.PublicKeyTextBox.TabIndex = 0;
			this.PublicKeyTextBox.TextChanged += new System.EventHandler(this.PublicKeyTextBox_TextChanged);
			// 
			// PrivateKeyTextBox
			// 
			this.PrivateKeyTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PrivateKeyTextBox.Location = new System.Drawing.Point(372, 37);
			this.PrivateKeyTextBox.Margin = new System.Windows.Forms.Padding(0);
			this.PrivateKeyTextBox.Multiline = true;
			this.PrivateKeyTextBox.Name = "PrivateKeyTextBox";
			this.AutoEditLayout.SetRowSpan(this.PrivateKeyTextBox, 2);
			this.PrivateKeyTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.PrivateKeyTextBox.Size = new System.Drawing.Size(218, 100);
			this.PrivateKeyTextBox.TabIndex = 1;
			this.PrivateKeyTextBox.TextChanged += new System.EventHandler(this.PrivateKeyTextBox_TextChanged);
			// 
			// EditPanel
			// 
			this.KeyEditTabLayout.SetColumnSpan(this.EditPanel, 4);
			this.EditPanel.Controls.Add(this.AutoEditLayout);
			this.EditPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.EditPanel.Location = new System.Drawing.Point(0, 59);
			this.EditPanel.Margin = new System.Windows.Forms.Padding(0);
			this.EditPanel.Name = "EditPanel";
			this.EditPanel.Size = new System.Drawing.Size(624, 202);
			this.EditPanel.TabIndex = 7;
			// 
			// KeyEditTab
			// 
			this.AccessibleName = "KeyEditTab";
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.KeyEditTabLayout);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "KeyEditTab";
			this.Size = new System.Drawing.Size(624, 322);
			this.SizeChanged += new System.EventHandler(this.KeyEditTab_SizeChanged);
			this.KeyEditTabLayout.ResumeLayout(false);
			this.KeyEditTabLayout.PerformLayout();
			this.AutoEditLayout.ResumeLayout(false);
			this.AutoEditLayout.PerformLayout();
			this.PrivateKeyValidationPanel.ResumeLayout(false);
			this.PublicKeyValidationPanel.ResumeLayout(false);
			this.EditPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel KeyEditTabLayout;
		private System.Windows.Forms.Button RevertButton;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Button BackButton;
		private System.Windows.Forms.TextBox KeyNameTextBox;
		private System.Windows.Forms.ComboBox EncryptionModeDropdown;
		private System.Windows.Forms.Panel EditPanel;
		private System.Windows.Forms.TableLayoutPanel AutoEditLayout;
		private System.Windows.Forms.TextBox PrivateKeyTextBox;
		private System.Windows.Forms.TextBox PublicKeyTextBox;
		private System.Windows.Forms.Label PublicKeyTitle;
		private System.Windows.Forms.Label PrivateKeyTitle;
		private System.Windows.Forms.Button GenerateKeysButton;
		private System.Windows.Forms.Panel PublicKeyValidationPanel;
		private System.Windows.Forms.Label PublicKeyValidationMessage;
		private System.Windows.Forms.Button ValidatePublicKeyButton;
		private System.Windows.Forms.Panel PrivateKeyValidationPanel;
		private System.Windows.Forms.Label PrivateKeyValidationMessage;
		private System.Windows.Forms.Button ValidatePrivateKeyButton;
		private System.Windows.Forms.TextBox KeySizeTextBox;
	}
}
