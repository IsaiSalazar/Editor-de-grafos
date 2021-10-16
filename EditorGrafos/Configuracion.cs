using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorGrafos
{
    public partial class Configuracion : Form
    {
        Graphics g;

        public Font font;
        private Color CONTORNON;
        public Color ContornoNodo { set { CONTORNON = value; } get { return CONTORNON; } }
        private Color RELLENON;
        public Color rellenoNodo { set { RELLENON = value; } get { return RELLENON; } }
        private Color COLORA;
        public Color colorArista { set { COLORA = value; } get { return COLORA; } }
        private Color COLORF;
        public Color colorFuente { set { COLORF = value; } get { return COLORF; } }

        private float ANCHON;
        public float anchoNodo { set { ANCHON = value; } get { return ANCHON; } }
        private float ANCHOA;
        public float anchoArista { set { ANCHOA = value; } get { return ANCHOA; } }
        private int RADIO;
        public int radio { set { RADIO = value; } get { return RADIO; } }

        public Pen penA, penN;
        public SolidBrush brushA, brushN, brushF;
        

        public Configuracion()
        {
            InitializeComponent();
        }

        public Configuracion(float anchoNodo, float anchoArista, int r, Color CFuente, Color CArista, Color NodoRelleno, Color NodoContorno, Font f)
        {
            ANCHON = anchoNodo;
            ANCHOA = anchoArista;
            RADIO = r;
            COLORF = CFuente;
            COLORA = CArista;
            RELLENON = NodoRelleno;
            CONTORNON = NodoContorno;
            font = f;

            

            InitializeComponent();
        }

        private void Configuracion_Load(object sender, EventArgs e)
        {
            g = CreateGraphics();
            
            brushA = new SolidBrush(COLORA);
            penA = new Pen(brushA, ANCHOA);
            brushN = new SolidBrush(RELLENON);
            penN = new Pen(CONTORNON, ANCHON);
            brushF = new SolidBrush(COLORF);

            ColorContornoNodo.BackColor = CONTORNON;
            numericAnchoNodo.Value = (decimal)ANCHON;
            ColorRellenoNodo.BackColor = RELLENON;
            Radio.Value = RADIO;
            AristaColor.BackColor = COLORA;
            numericAnchoArista.Value = (decimal)ANCHOA;
            fontDialog1.Font = font;
            FuenteColor.BackColor = COLORF;
        }

        private void Configuracion_Paint(object sender, PaintEventArgs e)
        {
            g.DrawLine(penA, 250 + radio, 10 + radio, 300 + radio, 150 + radio);

            g.FillEllipse(brushN, 250, 10, radio*2, radio*2);
            g.DrawEllipse(penN, 250 + (penN.Width / 2), 10 + (penN.Width / 2), (radio * 2) - (penN.Width / 2), (radio * 2) - (penN.Width / 2));
            g.FillEllipse(brushN, 300, 150, radio * 2, radio * 2);
            g.DrawEllipse(penN, 300 + (penN.Width / 2), 150 + (penN.Width / 2), (radio * 2) - (penN.Width / 2), (radio * 2) - (penN.Width / 2));

            g.DrawString("A", font, brushF, 250 + radio - 6, 10 + radio - 6);
            g.DrawString("B", font, brushF, 300 + radio - 6, 150 + radio - 6);
        }

        private void ContornoNodo_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                penN.Color = colorDialog1.Color;
                ColorContornoNodo.BackColor = colorDialog1.Color;
                CONTORNON = ColorContornoNodo.BackColor;
                Invalidate();
            }
        }

        private void RellenoNodo_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                brushN.Color = colorDialog1.Color;
                ColorRellenoNodo.BackColor = colorDialog1.Color;
                RELLENON = ColorRellenoNodo.BackColor;
                Invalidate();
            }
        }

        private void ColorFuente_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                brushF.Color = colorDialog1.Color;
                FuenteColor.BackColor = colorDialog1.Color;
                COLORF = FuenteColor.BackColor;
                Invalidate();
            }
        }

        private void Radio_ValueChanged(object sender, EventArgs e)
        {
            radio = (int)Radio.Value;
            Invalidate();
        }

        private void ColorArista_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                penA.Color = colorDialog1.Color;
                AristaColor.BackColor = colorDialog1.Color;
                COLORA = AristaColor.BackColor;
                Invalidate();
            }
        }

        private void AnchoNodo_ValueChanged(object sender, EventArgs e)
        {
            penN.Width = (int)numericAnchoNodo.Value;
            ANCHON = (int)numericAnchoNodo.Value;
            Invalidate();
        }

        private void AnchoArista_ValueChanged(object sender, EventArgs e)
        {
            penA.Width = (int)numericAnchoArista.Value;
            ANCHOA = (int)numericAnchoArista.Value;
            Invalidate();
        }

        private void Fuente_Click(object sender, EventArgs e)
        {
            if( fontDialog1.ShowDialog() == DialogResult.OK )
            {
                font = fontDialog1.Font;
                Invalidate();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Default_Click(object sender, EventArgs e)
        {
            brushA = new SolidBrush(Color.Black);
            penA = new Pen(Color.Black, 1);
            brushN = new SolidBrush(Color.White);
            penN = new Pen(Color.Black, 1);
            brushF = new SolidBrush(Color.Black);

            ColorContornoNodo.BackColor = Color.Black;
            ColorRellenoNodo.BackColor = Color.White;
            AristaColor.BackColor = Color.Black;
            FuenteColor.BackColor = Color.Black;
            numericAnchoArista.Value = 1;
            numericAnchoNodo.Value = 1;
            font = new Font("Times New Roman", 10, FontStyle.Bold);

            CONTORNON = ColorContornoNodo.BackColor;
            RELLENON = ColorRellenoNodo.BackColor;
            COLORA = AristaColor.BackColor;
            COLORF = FuenteColor.BackColor;
            radio = (int)Radio.Value;
            ANCHOA = (int)numericAnchoArista.Value;
            ANCHON = (int)numericAnchoNodo.Value;
            Invalidate();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
