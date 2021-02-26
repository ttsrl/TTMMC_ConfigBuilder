using System;
using System.Windows.Forms;

namespace TTMMC_ConfigBuilder
{
    public partial class inputGroup : Form
    {

        private DataGroupMode mode = DataGroupMode.Read;

        public string GroupName { get; set; }
        public DataGroupMode Mode { get => mode; set => mode = value; }


        public inputGroup()
        {
            InitializeComponent();
        }

        private void inputGroup_Load(object sender, EventArgs e)
        {
            textBox1.Text = GroupName;
            comboBox1.Items.AddRange(Enum.GetNames(typeof(DataGroupMode)));
            comboBox1.SelectedItem = Enum.GetName(typeof(DataGroupMode), mode);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && comboBox1.Text != "")
            {
                GroupName = textBox1.Text;
                Mode = (DataGroupMode)Enum.Parse(typeof(DataGroupMode), comboBox1.Text);
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Insert all required datas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

    }
}
