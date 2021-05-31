using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTMMC_ConfigBuilder
{
    public partial class inputRecipe : Form
    {
        public List<string> Items { get; set; }

        public RecipeLayout Recipe { get; set; }

        public inputRecipe()
        {
            InitializeComponent();
        }

        private void inputRecipe_Load(object sender, EventArgs e)
        {
            if (Recipe == null)
                Recipe = new RecipeLayout();
            textBox1.Text = Recipe.Name;
            textBox2.Text = Recipe.Label;
            reloadListbox();
        }

        private void btt_ok_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || Recipe.Machines == null || Recipe.Machines.Count == 0)
            {
                MessageBox.Show("Insert all data requested.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Recipe.Name = textBox1.Text;
            Recipe.Label = textBox2.Text;
            DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btt_add_Click(object sender, EventArgs e)
        {
            var frm = new inputSelect();
            frm.List = Items.Where(it => !Recipe.Machines.Contains(it)).ToList();
            frm.LblTxt = "Machine:";
            frm.Text = "Select Machine";
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Recipe.Machines.Add(frm.Value);
                reloadListbox();
            }
        }

        private void btt_edit_Click(object sender, EventArgs e)
        {
            var item = listBox1.SelectedItem;
            if (item != null)
            {
                var listIt = Recipe.Machines.Where(i => i == item.ToString()).FirstOrDefault();
                var frm = new inputSelect();
                frm.List = Items.Where(it => !Recipe.Machines.Contains(it)).ToList();
                frm.LblTxt = "Machine:";
                frm.Text = "Select Machine";
                frm.Value = listIt;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    listIt = frm.Value;
                    reloadListbox();
                }
            }
        }

        private void btt_delete_Click(object sender, EventArgs e)
        {
            var item = listBox1.SelectedItem;
            if (item != null)
            {
                var listIt = Recipe.Machines.Where(i => i == item.ToString()).FirstOrDefault();
                if (listIt != null)
                {
                    Recipe.Machines.Remove(listIt);
                    reloadListbox();
                }
            }
        }

        private void reloadListbox()
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(Recipe.Machines.ToArray());
        }

    }
}
