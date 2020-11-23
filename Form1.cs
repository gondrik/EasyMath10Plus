using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyMath10plus
{
    public partial class Form1 : Form
    {
        Color myRed = Color.FromArgb(255, 128, 128);
        Color myBlue = Color.FromArgb(0, 192, 192);

        enum PICKED_COLOR { RED = 0, BLUE = 1, NONE = 2 };
        private PICKED_COLOR PickedColor = PICKED_COLOR.NONE;
        public Form1()
        {
            InitializeComponent();
        }

        private void PickRed_Click(object sender, EventArgs e)
        {
            this.PickedColor = PICKED_COLOR.RED;
        }

        private void PickBlue_Click(object sender, EventArgs e)
        {
            this.PickedColor = PICKED_COLOR.BLUE;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            switch (this.PickedColor)
            {
                case PICKED_COLOR.RED:
                    (sender as PictureBox).BackColor = this.myRed;
                    break;
                case PICKED_COLOR.BLUE:
                    (sender as PictureBox).BackColor = this.myBlue;
                    break;
                default:
                    (sender as PictureBox).BackColor = Color.FromKnownColor(KnownColor.Control);
                    break;
            }
        }
        private void vymaz_Click(object sender, EventArgs e)
        {
            //PictureBox pb = null;
            Dictionary<int,Control> controls = new Dictionary<int,Control>();
            GetAllControlsOfType(this, typeof(PictureBox), ref controls, "pictureBox");
            Dictionary<int, Control> controlsTxts = new Dictionary<int, Control>();
            GetAllControlsOfType(this, typeof(TextBox), ref controlsTxts, "textBox");
            foreach (int num in controls.Keys)
            {
                if (num > 20) continue;

                if (controls[num] is PictureBox)
                {
                    controls[num].BackColor = Color.FromKnownColor(KnownColor.Control);
                }
            }

            foreach (int num in controlsTxts.Keys)
            {
                if (num > 20) continue;

                if (controlsTxts[num] is TextBox)
                {
                    controlsTxts[num].ForeColor = Color.Black;
                }
            }
        }
         private void zkontroluj_Click(object sender, EventArgs e)
        {
            Dictionary<int, Control> controls = new Dictionary<int, Control>();
            GetAllControlsOfType(this, typeof(PictureBox), ref controls, "pictureBox");
            Dictionary<int, Control> controlsTxts = new Dictionary<int, Control>();
            GetAllControlsOfType(this, typeof(TextBox), ref controlsTxts, "textBox");

            for (int i = 0; i < numericUpDown1.Value; ++i)
            {
                if (controls[i + 1].BackColor == this.myRed)
                {
                    controlsTxts[i + 1].ForeColor = Color.LimeGreen;
                }
                else
                {
                    controlsTxts[i + 1].ForeColor = Color.Red;
                }
            }
            for (int j = (int)numericUpDown1.Value; j < numericUpDown1.Value + numericUpDown2.Value; ++j)
            {
                if (controls[j + 1].BackColor == this.myBlue)
                {
                    controlsTxts[j + 1].ForeColor = Color.LimeGreen;
                }
                else
                {
                    controlsTxts[j + 1].ForeColor = Color.Red;
                }
            }
        }
        private void reseni_Click(object sender, EventArgs e)
        {
            Dictionary<int, Control> controls = new Dictionary<int, Control>();
            GetAllControlsOfType(this, typeof(PictureBox), ref controls, "pictureBox");
            for (int i = 0; i<numericUpDown1.Value;++i)
            {
                controls[i + 1].BackColor = this.myRed;
            }
            for (int j = (int)numericUpDown1.Value; j < numericUpDown1.Value + numericUpDown2.Value; ++j)
            {
                controls[j + 1].BackColor = this.myBlue;
            }
        }        
   
        private void GetAllControlsOfType(Control control, Type type, ref Dictionary<int, Control> controls, string pattern)
        {

            if (control.Controls.Count > 0) 
            {
                for (int i = 0; i < control.Controls.Count; ++i)
                {
                    GetAllControlsOfType(control.Controls[i], type, ref controls, pattern);
                }
            }
            else
            {
                if(control.GetType() == type)
                {
                    int pbnum = 0;
                    if(int.TryParse(control.Name.Replace(pattern, ""),out pbnum))
                        controls.Add(pbnum,control);
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value + numericUpDown2.Value > 20)
            {
                (sender as NumericUpDown).Value--;                
            }
        }


    }
}
