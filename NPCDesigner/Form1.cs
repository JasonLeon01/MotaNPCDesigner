using System.Text;

namespace NPCDesigner
{
    public partial class Form1 : Form
    {
        List<NPC> npc;
        int list1Index, list2Index;
        public Form1()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            list1Index = 0;
            list2Index = 0;
            npc = new List<NPC>();
            InitializeComponent();
        }
        public void Form1_load(object sender, EventArgs e)
        {
            int idx = 0;
            string path = Application.StartupPath + @"..\data\npc\";
            while (File.Exists(path + @"npc_" + idx.ToString() + ".dat"))
            {
                string file = @"npc_" + idx.ToString() + ".dat";
                string datatext = System.IO.File.ReadAllText(path + file);
                string[] data = datatext.Split(Environment.NewLine.ToCharArray());
                data = data.Where(s => !string.IsNullOrEmpty(s)).ToArray();
                listBox1.Items.Add(idx.ToString().PadLeft(3, '0') + "：" + file);
                List<int> id = data[1].Split(':')[1].Split(",").Select(int.Parse).ToList();
                List<string> name = data[2].Split(':')[1].Split(",").ToList();
                List<string> message = data[3].Split(':')[1].Replace("\\n", "\r\n").Split(",").ToList();
                List<(int, string, string)> temp = new List<(int, string, string)>();
                for (int i = 0; i < id.Count; i++)
                {
                    temp.Add((id[i], name[i], message[i]));
                    listBox2.Items.Add(name[i]);
                }
                npc.Add(new NPC(temp, data[4].Split(':')[1].Replace("none", ""), Convert.ToBoolean(int.Parse(data[5].Split(':')[1])), Convert.ToBoolean(int.Parse(data[6].Split(':')[1]))));
                ++idx;
            }
            if (npc.Count == 0)
            {
                MessageBox.Show("未检测到NPC数据！");
                Application.Exit();
                return;
            }
            listBox1.SelectedIndex = 0;
            listBox2.SelectedIndex = 0;
            textBox2.Text = npc[0].info[0].id.ToString();
            textBox3.Text = npc[0].info[0].name;
            textBox1.Text = npc[0].info[0].message;
            textBox4.Text = npc[0].transName;
            checkBox1.Checked = npc[0].fade;
            checkBox2.Checked = npc[0].directlyFunction;
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || textBox4.Text == "none" && checkBox2.Checked)
            {
                MessageBox.Show("未设置转换名称，无法勾选");
                npc[listBox1.SelectedIndex].directlyFunction = false;
                checkBox2.Checked = false;
                return;
            }
            npc[listBox1.SelectedIndex].directlyFunction = checkBox2.Checked;
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            npc[listBox1.SelectedIndex].transName = textBox4.Text;
            if (textBox4.Text == "")
            {
                npc[listBox1.SelectedIndex].directlyFunction = false;
                checkBox2.Checked = false;
            }
            if (textBox4.Text == "none")
            {
                MessageBox.Show("none和空白等同，将会变回空白，如有更多设置请更改这段源码");
                textBox4.Text = "";
                npc[listBox1.SelectedIndex].directlyFunction = false;
                checkBox2.Checked = false;
            }
        }
        private void refreshList1()
        {
            listBox1.Items.Clear();
            int idx = 0;
            foreach (NPC n in npc)
            {
                listBox1.Items.Add(idx.ToString().PadLeft(3, '0') + "：npc_" + idx.ToString() + ".dat");
                idx++;
            }
            listBox1.SelectedIndex = list1Index;
        }
        private void refreshList2()
        {
            listBox2.Items.Clear();
            foreach (var v in npc[listBox1.SelectedIndex].info)
                listBox2.Items.Add(v.name);
            listBox2.SelectedIndex = list2Index;
        }
        private void updateMessage()
        {
            textBox2.Text = npc[listBox1.SelectedIndex].info[listBox2.SelectedIndex].id.ToString();
            textBox3.Text = npc[listBox1.SelectedIndex].info[listBox2.SelectedIndex].name;
            textBox1.Text = npc[listBox1.SelectedIndex].info[listBox2.SelectedIndex].message;
            textBox4.Text = npc[listBox1.SelectedIndex].transName;
            checkBox1.Checked = npc[listBox1.SelectedIndex].fade;
            checkBox2.Checked = npc[listBox1.SelectedIndex].directlyFunction;
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            list1Index = listBox1.SelectedIndex;
            listBox2.Items.Clear();
            foreach (var info in npc[listBox1.SelectedIndex].info)
                listBox2.Items.Add(info.name);
            listBox2.SelectedIndex = 0;
            list2Index = 0;
            updateMessage();
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            list2Index = listBox2.SelectedIndex;
            updateMessage();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            npc[listBox1.SelectedIndex].info[listBox2.SelectedIndex] = (-1, npc[listBox1.SelectedIndex].info[listBox2.SelectedIndex].name, npc[listBox1.SelectedIndex].info[listBox2.SelectedIndex].message);
            updateMessage();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            npc[listBox1.SelectedIndex].info[listBox2.SelectedIndex] = (-2, npc[listBox1.SelectedIndex].info[listBox2.SelectedIndex].name, npc[listBox1.SelectedIndex].info[listBox2.SelectedIndex].message);
            updateMessage();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "") npc[listBox1.SelectedIndex].info[listBox2.SelectedIndex] = (0, npc[listBox1.SelectedIndex].info[listBox2.SelectedIndex].name, npc[listBox1.SelectedIndex].info[listBox2.SelectedIndex].message);
            else npc[listBox1.SelectedIndex].info[listBox2.SelectedIndex] = (int.Parse(textBox2.Text), npc[listBox1.SelectedIndex].info[listBox2.SelectedIndex].name, npc[listBox1.SelectedIndex].info[listBox2.SelectedIndex].message);

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            npc[listBox1.SelectedIndex].info[listBox2.SelectedIndex] = (npc[listBox1.SelectedIndex].info[listBox2.SelectedIndex].id, textBox3.Text, npc[listBox1.SelectedIndex].info[listBox2.SelectedIndex].message);
            if (textBox3.Text == "none")
            {
                MessageBox.Show("none和空白等同，将会变回空白，如有更多设置请更改这段源码");
                textBox3.Text = "";
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            npc[listBox1.SelectedIndex].fade = checkBox1.Checked;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            npc[listBox1.SelectedIndex].info.Add((0, "name", ""));
            refreshList2();
            updateMessage();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (npc[listBox1.SelectedIndex].info.Count == 1)
            {
                MessageBox.Show("不允许删除最后一段对话");
                return;
            }
            npc[listBox1.SelectedIndex].info.RemoveAt(listBox2.SelectedIndex);
            if (list2Index >= npc[listBox1.SelectedIndex].info.Count) list2Index = npc[listBox1.SelectedIndex].info.Count - 1;
            refreshList2();
            updateMessage();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            npc.Add(new NPC(new List<(int, string, string)> { (0, "name", "") }, "", false, false));
            refreshList1();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (npc.Count == 1)
            {
                MessageBox.Show("不允许删除最后剩余的文件");
                return;
            }
            npc.RemoveAt(listBox1.SelectedIndex);
            if (list1Index >= npc.Count) list1Index = npc.Count - 1;
            refreshList1();
            refreshList2();
            updateMessage();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            npc[listBox1.SelectedIndex].info[listBox2.SelectedIndex] = (npc[listBox1.SelectedIndex].info[listBox2.SelectedIndex].id, npc[listBox1.SelectedIndex].info[listBox2.SelectedIndex].name, textBox1.Text);
            if (textBox1.Text == "none")
            {
                MessageBox.Show("none和空白等同，将会变回空白，如有更多设置请更改这段源码");
                textBox1.Text = "";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int idx = 0;
            string file = Application.StartupPath + @"..\data\npc\";
            foreach (NPC n in npc)
            {
                string data = "[npc]\n";
                List<string> id = new List<string>();
                List<string> name = new List<string>();
                List<string> message = new List<string>();
                for (int i = 0; i < n.info.Count; i++)
                {
                    id.Add(n.info[i].id.ToString());
                    name.Add(n.info[i].name == "" ? "none" : n.info[i].name);
                    message.Add(n.info[i].message == "" ? "none" : n.info[i].message);
                }
                data = data + "ID:" + string.Join(",", id) + "\n";
                data = data + "name:" + string.Join(",", name) + "\n";
                data = data + "message:" + string.Join(",", message).Replace("\r\n", "\\n") + "\n";
                data = data + "transName:" + (n.transName == "" ? "none" : n.transName) + "\n";
                data = data + "fade:" + Convert.ToInt32(n.fade).ToString() + "\n";
                data = data + "directFunc:" + Convert.ToInt32(n.directlyFunction).ToString() + "\n";
                System.IO.File.WriteAllText(file + @"npc_" + idx.ToString() + ".dat", data);
                idx++;
            }
            while (File.Exists(file + @"npc_" + idx.ToString() + ".dat"))
            {
                System.IO.File.Delete(file + @"npc_" + (idx++).ToString() + ".dat");
            }
            MessageBox.Show("保存成功！");
            refreshList2();
            return;
        }
    }
}

class NPC
{
    public List<(int id, string name, string message)> info;
    public string transName;
    public bool fade, directlyFunction;
    public NPC(List<(int, string, string)> info, string transName, bool fade, bool directlyFunction)
    {
        this.info = info;
        this.transName = transName;
        this.fade = fade;
        this.directlyFunction = directlyFunction;
    }
}