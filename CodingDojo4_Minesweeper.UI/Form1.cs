using CodingDojo4_Minesweeper.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CodingDojo4_Minesweeper.UI
{
    public partial class Form1 : Form
    {
        private Minesweeper _minesweeper;


        public Form1()
        {
            InitializeComponent();
        }

        private void Create_Click(object sender, EventArgs e)
        {
            Int32 dimension = Convert.ToInt32(this.txtDimension.Text);
            _minesweeper = new Minesweeper(dimension);            

            this.DrawMinesweeper();
        }

        private void DrawMinesweeper()
        {
            grid.Columns.Clear();

            for (int i = 0; i < _minesweeper.Dimension; i++)
            {
                this.grid.Columns.Add(String.Format("Column_{0}", i), String.Empty);
            }

            this.grid.Rows.Add(_minesweeper.Dimension);

            for (int x = 0; x < _minesweeper.Dimension; x++)
            {
                for (int y = 0; y < _minesweeper.Dimension; y++)
                {
                    this.grid.Rows[y].Cells[x].Value = _minesweeper.HasBombAt(x, y) ? "*" : _minesweeper.GetValue(x, y).ToString();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Int32 x = Convert.ToInt32(this.txtX.Text);
            Int32 y = Convert.ToInt32(this.txtY.Text);
            _minesweeper.AddBomb(x, y);
            this.DrawMinesweeper();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Int32 x = Convert.ToInt32(this.txtX.Text);
            Int32 y = Convert.ToInt32(this.txtY.Text);
            _minesweeper.RemoveBomb(x, y);
            this.DrawMinesweeper();
        }
    }
}
