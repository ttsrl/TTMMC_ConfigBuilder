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
    public partial class inputListRecipes : Form
    {
        public List<string> Items { get; set; }
        
        public List<RecipeLayout> List { get; set; }

        public inputListRecipes()
        {
            InitializeComponent();
        }

        private void inputListRecipes_Load(object sender, EventArgs e)
        {
            if (List != null && List.Count > 0)
                reloadList();
            else
                List = new List<RecipeLayout>();
        }

        private void btt_ok_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btt_add_Click(object sender, EventArgs e)
        {
            var frm = new inputRecipe();
            frm.Items = Items.Where(it => List.Select(l => l.Machines).Where(l => l.Contains(it)).Count() == 0).ToList();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                List.Add(frm.Recipe);
                reloadList();
            }
        }

        private void btt_edit_Click(object sender, EventArgs e)
        {
            var item = listBox1.SelectedItem;
            if (item != null)
            {
                var listIt = List.Where(i => i.Name == item.ToString()).FirstOrDefault();
                var frm = new inputRecipe();
                frm.Items = Items.Where(it => List.Select(l => l.Machines).Where(l => l.Contains(it)).Count() == 0).ToList();
                frm.Recipe = (RecipeLayout)listIt.Clone();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (listIt != null)
                        listIt = frm.Recipe;
                }
            }
        }

        private void btt_delete_Click(object sender, EventArgs e)
        {
            var item = listBox1.SelectedItem;
            if (item != null)
            {
                var listIt = List.Where(i => i.Name == item.ToString()).FirstOrDefault();
                if (listIt != null)
                {
                    List.Remove(listIt);
                    reloadList();
                }
            }
        }

        private void reloadList()
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(List.Select(it => it.Name).ToArray());
        }

        private void moveUp_Click(object sender, EventArgs e)
        {
            var item = listBox1.SelectedItem;
            if (item != null)
            {
                var elm = List.Where(it => it.Name == listBox1.SelectedItem.ToString()).FirstOrDefault();
                var indx = List.IndexOf(elm);
                if (indx == 0)
                    return;
                var ma = elm;
                List.Remove(ma);
                List.Insert(indx - 1, ma);
                reloadList();
            }
        }

        private void moveDown_Click(object sender, EventArgs e)
        {
            var item = listBox1.SelectedItem;
            if (item != null)
            {
                var elm = List.Where(it => it.Name == listBox1.SelectedItem.ToString()).FirstOrDefault();
                var indx = List.IndexOf(elm);
                if (indx == List.Count - 1)
                    return;
                var ma = elm;
                List.Remove(ma);
                List.Insert(indx + 1, ma);
                reloadList();
            }
        }
    }
}
