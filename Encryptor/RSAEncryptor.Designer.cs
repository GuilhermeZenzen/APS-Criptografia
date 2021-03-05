namespace Encryptor
{
	partial class RSAEncryptor
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

		#region Código gerado pelo Windows Form Designer

		/// <summary>
		/// Método necessário para suporte ao Designer - não modifique 
		/// o conteúdo deste método com o editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.EncryptorLayout = new System.Windows.Forms.TableLayoutPanel();
			this.EncryptorTabButton = new System.Windows.Forms.Button();
			this.KeysTabButton = new System.Windows.Forms.Button();
			this.TabsPanel = new System.Windows.Forms.Panel();
			this.KeysTab = new Encryptor.KeysTab();
			this.EncryptorTab = new Encryptor.EncryptorTab();
			this.EncryptorPanel = new System.Windows.Forms.Panel();
			this.KeyEditTab = new Encryptor.KeyEditTab();
			this.EncryptorLayout.SuspendLayout();
			this.TabsPanel.SuspendLayout();
			this.EncryptorPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// EncryptorLayout
			// 
			this.EncryptorLayout.ColumnCount = 2;
			this.EncryptorLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.EncryptorLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.EncryptorLayout.Controls.Add(this.EncryptorTabButton, 0, 0);
			this.EncryptorLayout.Controls.Add(this.KeysTabButton, 1, 0);
			this.EncryptorLayout.Controls.Add(this.TabsPanel, 0, 1);
			this.EncryptorLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.EncryptorLayout.Location = new System.Drawing.Point(0, 0);
			this.EncryptorLayout.Margin = new System.Windows.Forms.Padding(0);
			this.EncryptorLayout.Name = "EncryptorLayout";
			this.EncryptorLayout.RowCount = 2;
			this.EncryptorLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
			this.EncryptorLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
			this.EncryptorLayout.Size = new System.Drawing.Size(624, 322);
			this.EncryptorLayout.TabIndex = 0;
			// 
			// EncryptorTabButton
			// 
			this.EncryptorTabButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.EncryptorTabButton.Location = new System.Drawing.Point(0, 0);
			this.EncryptorTabButton.Margin = new System.Windows.Forms.Padding(0);
			this.EncryptorTabButton.Name = "EncryptorTabButton";
			this.EncryptorTabButton.Size = new System.Drawing.Size(312, 48);
			this.EncryptorTabButton.TabIndex = 0;
			this.EncryptorTabButton.Text = "Criptografar / Descriptografar";
			this.EncryptorTabButton.UseVisualStyleBackColor = true;
			this.EncryptorTabButton.Click += new System.EventHandler(this.EncryptorTabButton_Click);
			// 
			// KeysTabButton
			// 
			this.KeysTabButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.KeysTabButton.Location = new System.Drawing.Point(312, 0);
			this.KeysTabButton.Margin = new System.Windows.Forms.Padding(0);
			this.KeysTabButton.Name = "KeysTabButton";
			this.KeysTabButton.Size = new System.Drawing.Size(312, 48);
			this.KeysTabButton.TabIndex = 1;
			this.KeysTabButton.Text = "Chaves";
			this.KeysTabButton.UseVisualStyleBackColor = true;
			this.KeysTabButton.Click += new System.EventHandler(this.KeysTabButton_Click);
			// 
			// TabsPanel
			// 
			this.EncryptorLayout.SetColumnSpan(this.TabsPanel, 2);
			this.TabsPanel.Controls.Add(this.KeysTab);
			this.TabsPanel.Controls.Add(this.EncryptorTab);
			this.TabsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TabsPanel.Location = new System.Drawing.Point(0, 48);
			this.TabsPanel.Margin = new System.Windows.Forms.Padding(0);
			this.TabsPanel.Name = "TabsPanel";
			this.TabsPanel.Size = new System.Drawing.Size(624, 274);
			this.TabsPanel.TabIndex = 3;
			// 
			// KeysTab
			// 
			this.KeysTab.AccessibleName = "KeysTab";
			this.KeysTab.Dock = System.Windows.Forms.DockStyle.Fill;
			this.KeysTab.Location = new System.Drawing.Point(0, 0);
			this.KeysTab.Margin = new System.Windows.Forms.Padding(0);
			this.KeysTab.Name = "KeysTab";
			this.KeysTab.Size = new System.Drawing.Size(624, 274);
			this.KeysTab.TabIndex = 3;
			// 
			// EncryptorTab
			// 
			this.EncryptorTab.AccessibleName = "EncryptorTab";
			this.EncryptorTab.Dock = System.Windows.Forms.DockStyle.Fill;
			this.EncryptorTab.Location = new System.Drawing.Point(0, 0);
			this.EncryptorTab.Margin = new System.Windows.Forms.Padding(0);
			this.EncryptorTab.MinimumSize = new System.Drawing.Size(624, 274);
			this.EncryptorTab.Name = "EncryptorTab";
			this.EncryptorTab.Size = new System.Drawing.Size(624, 274);
			this.EncryptorTab.TabIndex = 2;
			// 
			// EncryptorPanel
			// 
			this.EncryptorPanel.Controls.Add(this.EncryptorLayout);
			this.EncryptorPanel.Controls.Add(this.KeyEditTab);
			this.EncryptorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.EncryptorPanel.Location = new System.Drawing.Point(0, 0);
			this.EncryptorPanel.Margin = new System.Windows.Forms.Padding(0);
			this.EncryptorPanel.Name = "EncryptorPanel";
			this.EncryptorPanel.Size = new System.Drawing.Size(624, 322);
			this.EncryptorPanel.TabIndex = 1;
			// 
			// KeyEditTab
			// 
			this.KeyEditTab.AccessibleName = "KeyEditTab";
			this.KeyEditTab.Dock = System.Windows.Forms.DockStyle.Fill;
			this.KeyEditTab.Location = new System.Drawing.Point(0, 0);
			this.KeyEditTab.Margin = new System.Windows.Forms.Padding(0);
			this.KeyEditTab.Name = "KeyEditTab";
			this.KeyEditTab.Size = new System.Drawing.Size(624, 322);
			this.KeyEditTab.TabIndex = 1;
			// 
			// RSAEncryptor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 322);
			this.Controls.Add(this.EncryptorPanel);
			this.MinimumSize = new System.Drawing.Size(640, 360);
			this.Name = "RSAEncryptor";
			this.Text = "Encriptador RSA";
			this.Load += new System.EventHandler(this.RSAEncryptor_Load);
			this.SizeChanged += new System.EventHandler(this.RSAEncryptor_SizeChanged);
			this.EncryptorLayout.ResumeLayout(false);
			this.TabsPanel.ResumeLayout(false);
			this.EncryptorPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel EncryptorLayout;
		private System.Windows.Forms.Button EncryptorTabButton;
		private System.Windows.Forms.Button KeysTabButton;
		private EncryptorTab EncryptorTab;
		private System.Windows.Forms.Panel TabsPanel;
		private KeysTab KeysTab;
		private System.Windows.Forms.Panel EncryptorPanel;
		private KeyEditTab KeyEditTab;
	}
}

