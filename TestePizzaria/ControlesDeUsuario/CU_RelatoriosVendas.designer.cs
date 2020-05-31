namespace PizzariaWinForm.ControlesDeUsuario
{
    partial class CU_RelatoriosVendas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CU_RelatoriosVendas));
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvVenda = new System.Windows.Forms.DataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtConsultaVenda = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbConsultaVenda = new System.Windows.Forms.ComboBox();
            this.btnAddVenda = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVenda)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.lblTotal);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(10, 624);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1095, 33);
            this.panel4.TabIndex = 11;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.lblTotal.Location = new System.Drawing.Point(189, 3);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(45, 19);
            this.lblTotal.TabIndex = 12;
            this.lblTotal.Text = "0000";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.label6.Location = new System.Drawing.Point(51, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 19);
            this.label6.TabIndex = 11;
            this.label6.Text = "Total Recebido :";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(10, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1095, 10);
            this.panel3.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1105, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 657);
            this.panel2.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 657);
            this.panel1.TabIndex = 8;
            // 
            // dgvVenda
            // 
            this.dgvVenda.AllowUserToAddRows = false;
            this.dgvVenda.AllowUserToDeleteRows = false;
            this.dgvVenda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVenda.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvVenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVenda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVenda.Location = new System.Drawing.Point(10, 95);
            this.dgvVenda.Name = "dgvVenda";
            this.dgvVenda.ReadOnly = true;
            this.dgvVenda.RowHeadersVisible = false;
            this.dgvVenda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVenda.Size = new System.Drawing.Size(1095, 529);
            this.dgvVenda.TabIndex = 17;
            this.dgvVenda.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVenda_CellContentClick);
            this.dgvVenda.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVenda_CellDoubleClick);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.panel6.Controls.Add(this.txtConsultaVenda);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.cmbConsultaVenda);
            this.panel6.Controls.Add(this.btnAddVenda);
            this.panel6.Controls.Add(this.btnAtualizar);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel6.Location = new System.Drawing.Point(10, 10);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1095, 85);
            this.panel6.TabIndex = 18;
            // 
            // txtConsultaVenda
            // 
            this.txtConsultaVenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConsultaVenda.Location = new System.Drawing.Point(665, 40);
            this.txtConsultaVenda.Name = "txtConsultaVenda";
            this.txtConsultaVenda.Size = new System.Drawing.Size(218, 27);
            this.txtConsultaVenda.TabIndex = 15;
            this.txtConsultaVenda.TextChanged += new System.EventHandler(this.txtConsultaVenda_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(373, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 23);
            this.label2.TabIndex = 16;
            this.label2.Text = "Procure Por :";
            // 
            // cmbConsultaVenda
            // 
            this.cmbConsultaVenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbConsultaVenda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConsultaVenda.FormattingEnabled = true;
            this.cmbConsultaVenda.Items.AddRange(new object[] {
            "Nome Cliente",
            "Id Venda"});
            this.cmbConsultaVenda.Location = new System.Drawing.Point(503, 40);
            this.cmbConsultaVenda.Name = "cmbConsultaVenda";
            this.cmbConsultaVenda.Size = new System.Drawing.Size(156, 27);
            this.cmbConsultaVenda.TabIndex = 14;
            this.cmbConsultaVenda.SelectedIndexChanged += new System.EventHandler(this.cmbConsultaVenda_SelectedIndexChanged);
            // 
            // btnAddVenda
            // 
            this.btnAddVenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.btnAddVenda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddVenda.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAddVenda.FlatAppearance.BorderSize = 0;
            this.btnAddVenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddVenda.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddVenda.ForeColor = System.Drawing.Color.White;
            this.btnAddVenda.Image = ((System.Drawing.Image)(resources.GetObject("btnAddVenda.Image")));
            this.btnAddVenda.Location = new System.Drawing.Point(187, 0);
            this.btnAddVenda.Name = "btnAddVenda";
            this.btnAddVenda.Size = new System.Drawing.Size(187, 85);
            this.btnAddVenda.TabIndex = 13;
            this.btnAddVenda.Text = "Add Nova Venda";
            this.btnAddVenda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddVenda.UseVisualStyleBackColor = false;
            this.btnAddVenda.Click += new System.EventHandler(this.btnAddVenda_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.btnAtualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtualizar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAtualizar.FlatAppearance.BorderSize = 0;
            this.btnAtualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtualizar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizar.ForeColor = System.Drawing.Color.White;
            this.btnAtualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnAtualizar.Image")));
            this.btnAtualizar.Location = new System.Drawing.Point(0, 0);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(187, 85);
            this.btnAtualizar.TabIndex = 12;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAtualizar.UseVisualStyleBackColor = false;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(368, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(391, 23);
            this.label5.TabIndex = 11;
            this.label5.Text = "Histórico de Vendas Sorocaba,SP (Matriz)";
            // 
            // CU_RelatoriosVendas
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.dgvVenda);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CU_RelatoriosVendas";
            this.Size = new System.Drawing.Size(1115, 657);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVenda)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridView dgvVenda;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddVenda;
        private System.Windows.Forms.TextBox txtConsultaVenda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbConsultaVenda;
    }
}
