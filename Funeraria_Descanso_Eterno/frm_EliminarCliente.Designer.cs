namespace Funeraria_Descanso_Eterno
{
    partial class frm_EliminarCliente
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
            this.pnl_Titulo = new System.Windows.Forms.Panel();
            this.pic_Restaurar = new System.Windows.Forms.PictureBox();
            this.pic_Minimizar = new System.Windows.Forms.PictureBox();
            this.pic_Redimencionar = new System.Windows.Forms.PictureBox();
            this.pic_Cerrar = new System.Windows.Forms.PictureBox();
            this.pnl_EliminarC = new System.Windows.Forms.Panel();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.btn_Eliminar = new System.Windows.Forms.Button();
            this.lbl_ImprimirApell = new System.Windows.Forms.Label();
            this.lbl_ImprimirNom = new System.Windows.Forms.Label();
            this.lbl_ImprimirDoc = new System.Windows.Forms.Label();
            this.lbl_doc = new System.Windows.Forms.Label();
            this.lbl_ApellidoPC = new System.Windows.Forms.Label();
            this.lbl_NomC = new System.Windows.Forms.Label();
            this.lbl_Buscar = new System.Windows.Forms.Label();
            this.lbl_Elim = new System.Windows.Forms.Label();
            this.txt_Buscar = new System.Windows.Forms.TextBox();
            this.pnl_Titulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Restaurar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Minimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Redimencionar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Cerrar)).BeginInit();
            this.pnl_EliminarC.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Titulo
            // 
            this.pnl_Titulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(76)))), ((int)(((byte)(70)))));
            this.pnl_Titulo.Controls.Add(this.pic_Restaurar);
            this.pnl_Titulo.Controls.Add(this.pic_Minimizar);
            this.pnl_Titulo.Controls.Add(this.pic_Redimencionar);
            this.pnl_Titulo.Controls.Add(this.pic_Cerrar);
            this.pnl_Titulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Titulo.Location = new System.Drawing.Point(0, 0);
            this.pnl_Titulo.Name = "pnl_Titulo";
            this.pnl_Titulo.Size = new System.Drawing.Size(450, 38);
            this.pnl_Titulo.TabIndex = 2;
            // 
            // pic_Restaurar
            // 
            this.pic_Restaurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_Restaurar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_Restaurar.Image = global::Funeraria_Descanso_Eterno.Properties.Resources.res;
            this.pic_Restaurar.Location = new System.Drawing.Point(382, 7);
            this.pic_Restaurar.Name = "pic_Restaurar";
            this.pic_Restaurar.Size = new System.Drawing.Size(25, 25);
            this.pic_Restaurar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_Restaurar.TabIndex = 2;
            this.pic_Restaurar.TabStop = false;
            this.pic_Restaurar.Visible = false;
            // 
            // pic_Minimizar
            // 
            this.pic_Minimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_Minimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_Minimizar.Image = global::Funeraria_Descanso_Eterno.Properties.Resources.minimazar;
            this.pic_Minimizar.Location = new System.Drawing.Point(341, 7);
            this.pic_Minimizar.Name = "pic_Minimizar";
            this.pic_Minimizar.Size = new System.Drawing.Size(25, 25);
            this.pic_Minimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_Minimizar.TabIndex = 2;
            this.pic_Minimizar.TabStop = false;
            this.pic_Minimizar.Click += new System.EventHandler(this.pic_Minimizar_Click);
            // 
            // pic_Redimencionar
            // 
            this.pic_Redimencionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_Redimencionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_Redimencionar.Image = global::Funeraria_Descanso_Eterno.Properties.Resources.maxi;
            this.pic_Redimencionar.Location = new System.Drawing.Point(382, 7);
            this.pic_Redimencionar.Name = "pic_Redimencionar";
            this.pic_Redimencionar.Size = new System.Drawing.Size(25, 25);
            this.pic_Redimencionar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_Redimencionar.TabIndex = 1;
            this.pic_Redimencionar.TabStop = false;
            // 
            // pic_Cerrar
            // 
            this.pic_Cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_Cerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_Cerrar.Image = global::Funeraria_Descanso_Eterno.Properties.Resources.cerrar;
            this.pic_Cerrar.Location = new System.Drawing.Point(422, 7);
            this.pic_Cerrar.Name = "pic_Cerrar";
            this.pic_Cerrar.Size = new System.Drawing.Size(25, 25);
            this.pic_Cerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_Cerrar.TabIndex = 0;
            this.pic_Cerrar.TabStop = false;
            this.pic_Cerrar.Click += new System.EventHandler(this.pic_Cerrar_Click);
            // 
            // pnl_EliminarC
            // 
            this.pnl_EliminarC.BackColor = System.Drawing.Color.White;
            this.pnl_EliminarC.Controls.Add(this.btn_Cancelar);
            this.pnl_EliminarC.Controls.Add(this.btn_Eliminar);
            this.pnl_EliminarC.Controls.Add(this.lbl_ImprimirApell);
            this.pnl_EliminarC.Controls.Add(this.lbl_ImprimirNom);
            this.pnl_EliminarC.Controls.Add(this.lbl_ImprimirDoc);
            this.pnl_EliminarC.Controls.Add(this.lbl_doc);
            this.pnl_EliminarC.Controls.Add(this.lbl_ApellidoPC);
            this.pnl_EliminarC.Controls.Add(this.lbl_NomC);
            this.pnl_EliminarC.Controls.Add(this.lbl_Buscar);
            this.pnl_EliminarC.Controls.Add(this.lbl_Elim);
            this.pnl_EliminarC.Controls.Add(this.txt_Buscar);
            this.pnl_EliminarC.Location = new System.Drawing.Point(12, 44);
            this.pnl_EliminarC.Name = "pnl_EliminarC";
            this.pnl_EliminarC.Size = new System.Drawing.Size(426, 359);
            this.pnl_EliminarC.TabIndex = 3;
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_Cancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(209)))));
            this.btn_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancelar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancelar.ForeColor = System.Drawing.Color.White;
            this.btn_Cancelar.Location = new System.Drawing.Point(141, 292);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(151, 42);
            this.btn_Cancelar.TabIndex = 36;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = false;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_Eliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(76)))), ((int)(((byte)(70)))));
            this.btn_Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Eliminar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Eliminar.ForeColor = System.Drawing.Color.White;
            this.btn_Eliminar.Location = new System.Drawing.Point(141, 244);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(151, 42);
            this.btn_Eliminar.TabIndex = 35;
            this.btn_Eliminar.Text = "Eliminar";
            this.btn_Eliminar.UseVisualStyleBackColor = false;
            // 
            // lbl_ImprimirApell
            // 
            this.lbl_ImprimirApell.AutoSize = true;
            this.lbl_ImprimirApell.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ImprimirApell.Location = new System.Drawing.Point(162, 184);
            this.lbl_ImprimirApell.Name = "lbl_ImprimirApell";
            this.lbl_ImprimirApell.Size = new System.Drawing.Size(16, 21);
            this.lbl_ImprimirApell.TabIndex = 23;
            this.lbl_ImprimirApell.Text = "-";
            // 
            // lbl_ImprimirNom
            // 
            this.lbl_ImprimirNom.AutoSize = true;
            this.lbl_ImprimirNom.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ImprimirNom.Location = new System.Drawing.Point(123, 151);
            this.lbl_ImprimirNom.Name = "lbl_ImprimirNom";
            this.lbl_ImprimirNom.Size = new System.Drawing.Size(16, 21);
            this.lbl_ImprimirNom.TabIndex = 22;
            this.lbl_ImprimirNom.Text = "-";
            // 
            // lbl_ImprimirDoc
            // 
            this.lbl_ImprimirDoc.AutoSize = true;
            this.lbl_ImprimirDoc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ImprimirDoc.Location = new System.Drawing.Point(137, 120);
            this.lbl_ImprimirDoc.Name = "lbl_ImprimirDoc";
            this.lbl_ImprimirDoc.Size = new System.Drawing.Size(16, 21);
            this.lbl_ImprimirDoc.TabIndex = 21;
            this.lbl_ImprimirDoc.Text = "-";
            // 
            // lbl_doc
            // 
            this.lbl_doc.AutoSize = true;
            this.lbl_doc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_doc.Location = new System.Drawing.Point(29, 120);
            this.lbl_doc.Name = "lbl_doc";
            this.lbl_doc.Size = new System.Drawing.Size(105, 21);
            this.lbl_doc.TabIndex = 20;
            this.lbl_doc.Text = "Identificación:";
            this.lbl_doc.Click += new System.EventHandler(this.lbl_doc_Click);
            // 
            // lbl_ApellidoPC
            // 
            this.lbl_ApellidoPC.AutoSize = true;
            this.lbl_ApellidoPC.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ApellidoPC.Location = new System.Drawing.Point(29, 184);
            this.lbl_ApellidoPC.Name = "lbl_ApellidoPC";
            this.lbl_ApellidoPC.Size = new System.Drawing.Size(127, 21);
            this.lbl_ApellidoPC.TabIndex = 12;
            this.lbl_ApellidoPC.Text = "Apellido Paterno:";
            // 
            // lbl_NomC
            // 
            this.lbl_NomC.AutoSize = true;
            this.lbl_NomC.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NomC.Location = new System.Drawing.Point(29, 151);
            this.lbl_NomC.Name = "lbl_NomC";
            this.lbl_NomC.Size = new System.Drawing.Size(88, 21);
            this.lbl_NomC.TabIndex = 8;
            this.lbl_NomC.Text = "Nombre(s):";
            // 
            // lbl_Buscar
            // 
            this.lbl_Buscar.AutoSize = true;
            this.lbl_Buscar.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Buscar.Location = new System.Drawing.Point(26, 56);
            this.lbl_Buscar.Name = "lbl_Buscar";
            this.lbl_Buscar.Size = new System.Drawing.Size(109, 37);
            this.lbl_Buscar.TabIndex = 5;
            this.lbl_Buscar.Text = "Buscar:";
            // 
            // lbl_Elim
            // 
            this.lbl_Elim.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Elim.AutoSize = true;
            this.lbl_Elim.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Elim.Location = new System.Drawing.Point(98, 10);
            this.lbl_Elim.Name = "lbl_Elim";
            this.lbl_Elim.Size = new System.Drawing.Size(219, 37);
            this.lbl_Elim.TabIndex = 4;
            this.lbl_Elim.Text = "Eliminar Cliente";
            // 
            // txt_Buscar
            // 
            this.txt_Buscar.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Buscar.Location = new System.Drawing.Point(141, 63);
            this.txt_Buscar.Name = "txt_Buscar";
            this.txt_Buscar.Size = new System.Drawing.Size(254, 33);
            this.txt_Buscar.TabIndex = 4;
            // 
            // frm_EliminarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 415);
            this.Controls.Add(this.pnl_EliminarC);
            this.Controls.Add(this.pnl_Titulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_EliminarCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_EliminarCliente";
            this.Load += new System.EventHandler(this.frm_EliminarCliente_Load);
            this.pnl_Titulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Restaurar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Minimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Redimencionar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Cerrar)).EndInit();
            this.pnl_EliminarC.ResumeLayout(false);
            this.pnl_EliminarC.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Titulo;
        private System.Windows.Forms.PictureBox pic_Restaurar;
        private System.Windows.Forms.PictureBox pic_Minimizar;
        private System.Windows.Forms.PictureBox pic_Redimencionar;
        private System.Windows.Forms.PictureBox pic_Cerrar;
        private System.Windows.Forms.Panel pnl_EliminarC;
        private System.Windows.Forms.Label lbl_Elim;
        private System.Windows.Forms.Label lbl_Buscar;
        private System.Windows.Forms.TextBox txt_Buscar;
        private System.Windows.Forms.Label lbl_NomC;
        private System.Windows.Forms.Label lbl_ApellidoPC;
        private System.Windows.Forms.Label lbl_doc;
        private System.Windows.Forms.Label lbl_ImprimirApell;
        private System.Windows.Forms.Label lbl_ImprimirNom;
        private System.Windows.Forms.Label lbl_ImprimirDoc;
        private System.Windows.Forms.Button btn_Eliminar;
        private System.Windows.Forms.Button btn_Cancelar;
    }
}