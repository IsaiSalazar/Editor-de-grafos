namespace EditorGrafos
{
    partial class Configuracion
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
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.Cancel = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.Default = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ColorContornoNodo = new System.Windows.Forms.PictureBox();
            this.AristaColor = new System.Windows.Forms.PictureBox();
            this.ColorRellenoNodo = new System.Windows.Forms.PictureBox();
            this.numericAnchoArista = new System.Windows.Forms.NumericUpDown();
            this.numericAnchoNodo = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.FuenteColor = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.Radio = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.Nodo = new System.Windows.Forms.GroupBox();
            this.Arista = new System.Windows.Forms.GroupBox();
            this.Fuente = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.ColorContornoNodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AristaColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorRellenoNodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAnchoArista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAnchoNodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FuenteColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Radio)).BeginInit();
            this.Nodo.SuspendLayout();
            this.Arista.SuspendLayout();
            this.Fuente.SuspendLayout();
            this.SuspendLayout();
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(12, 314);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 50);
            this.Cancel.TabIndex = 0;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(300, 314);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 50);
            this.OK.TabIndex = 1;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Default
            // 
            this.Default.Location = new System.Drawing.Point(155, 314);
            this.Default.Name = "Default";
            this.Default.Size = new System.Drawing.Size(75, 50);
            this.Default.TabIndex = 2;
            this.Default.Text = "Default";
            this.Default.UseVisualStyleBackColor = true;
            this.Default.Click += new System.EventHandler(this.Default_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Color de linea";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Color Relleno";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ancho de linea";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Color de linea";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Ancho de linea";
            // 
            // ColorContornoNodo
            // 
            this.ColorContornoNodo.BackColor = System.Drawing.Color.Black;
            this.ColorContornoNodo.Location = new System.Drawing.Point(140, 10);
            this.ColorContornoNodo.Name = "ColorContornoNodo";
            this.ColorContornoNodo.Size = new System.Drawing.Size(38, 20);
            this.ColorContornoNodo.TabIndex = 8;
            this.ColorContornoNodo.TabStop = false;
            this.ColorContornoNodo.Click += new System.EventHandler(this.ContornoNodo_Click);
            // 
            // AristaColor
            // 
            this.AristaColor.BackColor = System.Drawing.Color.Black;
            this.AristaColor.Location = new System.Drawing.Point(140, 19);
            this.AristaColor.Name = "AristaColor";
            this.AristaColor.Size = new System.Drawing.Size(38, 20);
            this.AristaColor.TabIndex = 9;
            this.AristaColor.TabStop = false;
            this.AristaColor.Click += new System.EventHandler(this.ColorArista_Click);
            // 
            // ColorRellenoNodo
            // 
            this.ColorRellenoNodo.BackColor = System.Drawing.Color.White;
            this.ColorRellenoNodo.Location = new System.Drawing.Point(140, 67);
            this.ColorRellenoNodo.Name = "ColorRellenoNodo";
            this.ColorRellenoNodo.Size = new System.Drawing.Size(38, 20);
            this.ColorRellenoNodo.TabIndex = 10;
            this.ColorRellenoNodo.TabStop = false;
            this.ColorRellenoNodo.Click += new System.EventHandler(this.RellenoNodo_Click);
            // 
            // numericAnchoArista
            // 
            this.numericAnchoArista.Location = new System.Drawing.Point(140, 50);
            this.numericAnchoArista.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericAnchoArista.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericAnchoArista.Name = "numericAnchoArista";
            this.numericAnchoArista.Size = new System.Drawing.Size(38, 20);
            this.numericAnchoArista.TabIndex = 12;
            this.numericAnchoArista.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericAnchoArista.ValueChanged += new System.EventHandler(this.AnchoArista_ValueChanged);
            // 
            // numericAnchoNodo
            // 
            this.numericAnchoNodo.Location = new System.Drawing.Point(140, 41);
            this.numericAnchoNodo.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericAnchoNodo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericAnchoNodo.Name = "numericAnchoNodo";
            this.numericAnchoNodo.Size = new System.Drawing.Size(38, 20);
            this.numericAnchoNodo.TabIndex = 11;
            this.numericAnchoNodo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericAnchoNodo.ValueChanged += new System.EventHandler(this.AnchoNodo_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Color de Fuente";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Fuente";
            // 
            // FuenteColor
            // 
            this.FuenteColor.BackColor = System.Drawing.Color.Black;
            this.FuenteColor.Location = new System.Drawing.Point(140, 45);
            this.FuenteColor.Name = "FuenteColor";
            this.FuenteColor.Size = new System.Drawing.Size(38, 20);
            this.FuenteColor.TabIndex = 15;
            this.FuenteColor.TabStop = false;
            this.FuenteColor.Click += new System.EventHandler(this.ColorFuente_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(131, 15);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(56, 23);
            this.button4.TabIndex = 16;
            this.button4.Text = "Fuente";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Fuente_Click);
            // 
            // Radio
            // 
            this.Radio.AccessibleName = "Radio";
            this.Radio.Location = new System.Drawing.Point(140, 101);
            this.Radio.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.Radio.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.Radio.Name = "Radio";
            this.Radio.Size = new System.Drawing.Size(38, 20);
            this.Radio.TabIndex = 18;
            this.Radio.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.Radio.ValueChanged += new System.EventHandler(this.Radio_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Radio Nodo";
            // 
            // Nodo
            // 
            this.Nodo.Controls.Add(this.label3);
            this.Nodo.Controls.Add(this.Radio);
            this.Nodo.Controls.Add(this.label1);
            this.Nodo.Controls.Add(this.label8);
            this.Nodo.Controls.Add(this.label2);
            this.Nodo.Controls.Add(this.ColorContornoNodo);
            this.Nodo.Controls.Add(this.ColorRellenoNodo);
            this.Nodo.Controls.Add(this.numericAnchoNodo);
            this.Nodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nodo.Location = new System.Drawing.Point(12, 4);
            this.Nodo.Name = "Nodo";
            this.Nodo.Size = new System.Drawing.Size(200, 129);
            this.Nodo.TabIndex = 19;
            this.Nodo.TabStop = false;
            this.Nodo.Text = "Nodo";
            // 
            // Arista
            // 
            this.Arista.Controls.Add(this.label4);
            this.Arista.Controls.Add(this.label5);
            this.Arista.Controls.Add(this.AristaColor);
            this.Arista.Controls.Add(this.numericAnchoArista);
            this.Arista.Location = new System.Drawing.Point(12, 137);
            this.Arista.Name = "Arista";
            this.Arista.Size = new System.Drawing.Size(200, 78);
            this.Arista.TabIndex = 20;
            this.Arista.TabStop = false;
            this.Arista.Text = "Arista";
            // 
            // Fuente
            // 
            this.Fuente.Controls.Add(this.label6);
            this.Fuente.Controls.Add(this.label7);
            this.Fuente.Controls.Add(this.FuenteColor);
            this.Fuente.Controls.Add(this.button4);
            this.Fuente.Location = new System.Drawing.Point(12, 221);
            this.Fuente.Name = "Fuente";
            this.Fuente.Size = new System.Drawing.Size(200, 78);
            this.Fuente.TabIndex = 21;
            this.Fuente.TabStop = false;
            this.Fuente.Text = "Fuente";
            // 
            // Configuracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 372);
            this.Controls.Add(this.Fuente);
            this.Controls.Add(this.Arista);
            this.Controls.Add(this.Nodo);
            this.Controls.Add(this.Default);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.Cancel);
            this.Name = "Configuracion";
            this.Text = "Configuracion";
            this.Load += new System.EventHandler(this.Configuracion_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Configuracion_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.ColorContornoNodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AristaColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorRellenoNodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAnchoArista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAnchoNodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FuenteColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Radio)).EndInit();
            this.Nodo.ResumeLayout(false);
            this.Nodo.PerformLayout();
            this.Arista.ResumeLayout(false);
            this.Arista.PerformLayout();
            this.Fuente.ResumeLayout(false);
            this.Fuente.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Default;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox ColorContornoNodo;
        private System.Windows.Forms.PictureBox AristaColor;
        private System.Windows.Forms.PictureBox ColorRellenoNodo;
        private System.Windows.Forms.NumericUpDown numericAnchoArista;
        private System.Windows.Forms.NumericUpDown numericAnchoNodo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox FuenteColor;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.NumericUpDown Radio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox Nodo;
        private System.Windows.Forms.GroupBox Arista;
        private System.Windows.Forms.GroupBox Fuente;
    }
}