namespace Cadastro_Estoque
{
    partial class Buscar_Deletar_Excluir
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
            this.list_Itens = new System.Windows.Forms.ListView();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.BtExcluir = new System.Windows.Forms.Button();
            this.BtBuscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btEdit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // list_Itens
            // 
            this.list_Itens.BackColor = System.Drawing.SystemColors.MenuBar;
            this.list_Itens.HideSelection = false;
            this.list_Itens.Location = new System.Drawing.Point(12, 60);
            this.list_Itens.Name = "list_Itens";
            this.list_Itens.Size = new System.Drawing.Size(731, 164);
            this.list_Itens.TabIndex = 0;
            this.list_Itens.UseCompatibleStateImageBehavior = false;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(12, 34);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(144, 20);
            this.txtBuscar.TabIndex = 1;
            // 
            // BtExcluir
            // 
            this.BtExcluir.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BtExcluir.Location = new System.Drawing.Point(538, 34);
            this.BtExcluir.Name = "BtExcluir";
            this.BtExcluir.Size = new System.Drawing.Size(64, 23);
            this.BtExcluir.TabIndex = 3;
            this.BtExcluir.Text = "Excluir";
            this.BtExcluir.UseVisualStyleBackColor = false;
            this.BtExcluir.Click += new System.EventHandler(this.BtExcluir_Click);
            // 
            // BtBuscar
            // 
            this.BtBuscar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BtBuscar.Location = new System.Drawing.Point(178, 31);
            this.BtBuscar.Name = "BtBuscar";
            this.BtBuscar.Size = new System.Drawing.Size(75, 23);
            this.BtBuscar.TabIndex = 4;
            this.BtBuscar.Text = "Buscar";
            this.BtBuscar.UseVisualStyleBackColor = false;
            this.BtBuscar.Click += new System.EventHandler(this.BtBuscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Buscar Itens";
            // 
            // btEdit
            // 
            this.btEdit.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btEdit.Location = new System.Drawing.Point(608, 34);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(64, 23);
            this.btEdit.TabIndex = 7;
            this.btEdit.Text = "Editar";
            this.btEdit.UseVisualStyleBackColor = false;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button1.Location = new System.Drawing.Point(679, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Inserir";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Buscar_Deletar_Excluir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(767, 230);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtBuscar);
            this.Controls.Add(this.BtExcluir);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.list_Itens);
            this.Name = "Buscar_Deletar_Excluir";
            this.Text = "Deletar";
            this.Load += new System.EventHandler(this.Deletar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView list_Itens;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button BtExcluir;
        private System.Windows.Forms.Button BtBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.Button button1;
    }
}