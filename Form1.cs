using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteTakingApp
{
    public partial class NoteTaker : Form
    {
        DataTable notes = new DataTable();
        bool editing = false;
        public NoteTaker()
        {
            InitializeComponent();
        }

        private void NoteTaker_Load(object sender, EventArgs e)
        {
            notes.Columns.Add("Title");
            notes.Columns.Add("Notes");

            previousNote.DataSource = notes;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void previousNote_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = notes.Rows[previousNote.CurrentCell.RowIndex].ItemArray[0].ToString();
            notebox.Text = notes.Rows[previousNote.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            textBox1.Text= notes.Rows[previousNote.CurrentCell.RowIndex].ItemArray[0].ToString();
            notebox.Text= notes.Rows[previousNote.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing= true;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                notes.Rows[previousNote.CurrentCell.RowIndex].Delete();
            }
            catch(Exception ex) { Console.WriteLine("Not a valid note"); }

        }

        private void newNoteButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            notebox.Text = "";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (editing)
            {
                notes.Rows[previousNote.CurrentCell.RowIndex]["Title"] = textBox1.Text;
                notes.Rows[previousNote.CurrentCell.RowIndex]["Notes"] = notebox.Text;
            }
            else
            {
                notes.Rows.Add(textBox1.Text, notebox.Text);
            }
            textBox1.Text = "";
            notebox.Text = "";
            editing= false;
        }
    }
}
