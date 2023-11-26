using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.Unicode;

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
            while (File.Exists(path + @"npc_" + idx.ToString() + ".json"))
            {
                string file = @"npc_" + idx.ToString() + ".json";
                string jsonstr = System.IO.File.ReadAllText(path + file);
                jsonstr = jsonstr.Replace("\\n", "\\r\\n");
                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    DefaultIgnoreCondition = JsonIgnoreCondition.Never,
                    IncludeFields = true,
                    WriteIndented = true
                };
                NPC tempnpc = JsonSerializer.Deserialize<NPC>(jsonstr, options);
                npc.Add(tempnpc);
                listBox1.Items.Add(idx.ToString().PadLeft(3, '0') + "：" + file);
                ++idx;
            }
            if (npc.Count == 0)
            {
                MessageBox.Show("未检测到NPC数据！");
                Application.Exit();
                return;
            }
            for (int i = 0; i < npc[0].npcInfo.Count; i++)
            {
                listBox2.Items.Add(npc[0].npcInfo[i].name);
            }
            listBox1.SelectedIndex = 0;
            listBox2.SelectedIndex = 0;
            textBox2.Text = npc[0].npcInfo[0].id.ToString();
            textBox3.Text = npc[0].npcInfo[0].name;
            textBox1.Text = npc[0].npcInfo[0].message;
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
            foreach (var v in npc[listBox1.SelectedIndex].npcInfo)
                listBox2.Items.Add(v.name);
            listBox2.SelectedIndex = list2Index;
        }
        private void updateMessage()
        {
            textBox2.Text = npc[listBox1.SelectedIndex].npcInfo[listBox2.SelectedIndex].id.ToString();
            textBox3.Text = npc[listBox1.SelectedIndex].npcInfo[listBox2.SelectedIndex].name;
            textBox1.Text = npc[listBox1.SelectedIndex].npcInfo[listBox2.SelectedIndex].message;
            textBox4.Text = npc[listBox1.SelectedIndex].transName;
            checkBox1.Checked = npc[listBox1.SelectedIndex].fade;
            checkBox2.Checked = npc[listBox1.SelectedIndex].directlyFunction;
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            list1Index = listBox1.SelectedIndex;
            listBox2.Items.Clear();
            foreach (var npcInfo in npc[listBox1.SelectedIndex].npcInfo)
                listBox2.Items.Add(npcInfo.name);
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
            npc[listBox1.SelectedIndex].npcInfo[listBox2.SelectedIndex] = (-1, npc[listBox1.SelectedIndex].npcInfo[listBox2.SelectedIndex].name, npc[listBox1.SelectedIndex].npcInfo[listBox2.SelectedIndex].message);
            updateMessage();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            npc[listBox1.SelectedIndex].npcInfo[listBox2.SelectedIndex] = (-2, npc[listBox1.SelectedIndex].npcInfo[listBox2.SelectedIndex].name, npc[listBox1.SelectedIndex].npcInfo[listBox2.SelectedIndex].message);
            updateMessage();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out int intValue)) npc[listBox1.SelectedIndex].npcInfo[listBox2.SelectedIndex] = (0, npc[listBox1.SelectedIndex].npcInfo[listBox2.SelectedIndex].name, npc[listBox1.SelectedIndex].npcInfo[listBox2.SelectedIndex].message);
            else npc[listBox1.SelectedIndex].npcInfo[listBox2.SelectedIndex] = (int.Parse(textBox2.Text), npc[listBox1.SelectedIndex].npcInfo[listBox2.SelectedIndex].name, npc[listBox1.SelectedIndex].npcInfo[listBox2.SelectedIndex].message);

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            npc[listBox1.SelectedIndex].npcInfo[listBox2.SelectedIndex] = (npc[listBox1.SelectedIndex].npcInfo[listBox2.SelectedIndex].id, textBox3.Text, npc[listBox1.SelectedIndex].npcInfo[listBox2.SelectedIndex].message);
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
            npc[listBox1.SelectedIndex].npcInfo.Add((0, "name", ""));
            refreshList2();
            updateMessage();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (npc[listBox1.SelectedIndex].npcInfo.Count == 1)
            {
                MessageBox.Show("不允许删除最后一段对话");
                return;
            }
            npc[listBox1.SelectedIndex].npcInfo.RemoveAt(listBox2.SelectedIndex);
            if (list2Index >= npc[listBox1.SelectedIndex].npcInfo.Count) list2Index = npc[listBox1.SelectedIndex].npcInfo.Count - 1;
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
            npc[listBox1.SelectedIndex].npcInfo[listBox2.SelectedIndex] = (npc[listBox1.SelectedIndex].npcInfo[listBox2.SelectedIndex].id, npc[listBox1.SelectedIndex].npcInfo[listBox2.SelectedIndex].name, textBox1.Text);
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
                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    DefaultIgnoreCondition = JsonIgnoreCondition.Never,
                    IncludeFields = true,
                    WriteIndented = true
                };
                string jsonstr = JsonSerializer.Serialize(n, options);
                jsonstr = jsonstr.Replace("\\r\\n", "\\n");
                System.IO.File.WriteAllText(file + @"npc_" + idx.ToString() + ".json", jsonstr);
                idx++;
            }
            while (File.Exists(file + @"npc_" + idx.ToString() + ".json"))
            {
                System.IO.File.Delete(file + @"npc_" + (idx++).ToString() + ".json");
            }
            MessageBox.Show("保存成功！");
            refreshList2();
            return;
        }
    }
}

class NPC
{
    public List<(int id, string name, string message)> npcInfo { get; set; }
    public string transName { get; set; }
    public bool fade { get; set; }
    public bool directlyFunction { get; set; }
    public NPC(List<(int, string, string)> npcInfo, string transName, bool fade, bool directlyFunction)
    {
        this.npcInfo = npcInfo;
        this.transName = transName;
        this.fade = fade;
        this.directlyFunction = directlyFunction;
    }
}