namespace NPCDesigner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void Form1_load(object sender, EventArgs e)
        {

        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "" && checkBox2.Checked)
            {
                MessageBox.Show("未设置转换名称，无法勾选");
                checkBox2.Checked = false;
                return;
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
                checkBox2.Checked = false;
        }
    }
}