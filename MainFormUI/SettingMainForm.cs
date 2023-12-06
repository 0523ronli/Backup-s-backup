using Bachup_s_backup;
using Bachup_s_backup.Setting_items;
using Bachup_s_backup.Setting_items.form1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows.Forms;
using static UItestv2.UIv2Global;


namespace UItestv2
{
    public partial class SettingMainForm : Form
    {
        public static SettingMainForm Instance;
        public SettingMainForm()
        {
            InitializeComponent();
            Instance = this;
        }
        public Button checkedbtn = new();
        public bool leftfold;
        public List<Leftbtn> originalleftbtn = new();
        public void ReFreshColor()
        {
            foreach (Flatbtn button in originalleftbtn.Reverse<Flatbtn>())
            {
                button.repaint();
            }
        }
        public void leftrestore()
        {
            foldablePanel.Controls.Clear();
            foreach (Flatbtn button in originalleftbtn.Reverse<Flatbtn>())
            {
                button.repaint(true);
                foldablePanel.Controls.Add(button);
            }

        }
        public async Task ExpandAsync(Leftbtn leftbtn)
        {
            if (foldablePanel.Contains(leftbtn.expandPanel) || leftbtn.expandPanel.Controls.Count == 0) return;
            leftrestore();
            int index = foldablePanel.Controls.IndexOf(leftbtn);
            List<Control> controlList = new();
            controlList.AddRange(foldablePanel.Controls.OfType<Control>());
            controlList.Insert(index, leftbtn.expandPanel);
            foldablePanel.Controls.Clear();
            foreach (Control control in controlList)
            {
                foldablePanel.Controls.Add(control);
            }
            leftbtn.expandPanel.Size = new Size(0, 0);
            foreach (int i in Enumerable.Range(0, leftbtn.expandPanel.Controls.Count * 5+1))
            {
                leftbtn.expandPanel.Size = new Size(0, i * 6);
                await Task.Delay(1);
            }
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            originalleftbtn.Add(new Leftbtn()
            {

                Text = "Form Setting",
                subbtnList = new List<Subbtn>
                {
                    new Subbtn() {Text="Opacity", Linkform = new Form_Opacity() }
                }
            });
            originalleftbtn.Add(new Leftbtn()
            {

                Text = "Desktop item Setting",
                subbtnList = new List<Subbtn>
                {
                    new Subbtn() {Text="Desktop_Color",Linkform = new Form_DI_Color()},
                    new Subbtn() {Text="Desktop_Size", Linkform = new Form_DI_Size()},
                }
            });
            leftrestore();
        }
    }
}