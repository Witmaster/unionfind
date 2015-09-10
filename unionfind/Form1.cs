using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace unionfind
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            Print(ids);
        }

        public int[] ids = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        private void Print(int[] array)
        {
            textBox1.Text = "";
            for (int i = 0; i < array.Length; i++)
            {
                textBox1.Text += array[i].ToString()+" ";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Print(ids);
        }

        private int GetRoot(int[] array, int ID)
        {
            int root = array[ID];
            if (root!=ID)
            {
               root = GetRoot(array, root);
            }
            return root;
        }
        private void QuickUnion(int[] array, int pid, int qid)
        {
            pid = GetRoot(array, pid);
            qid = GetRoot(array, qid);
            array[pid] = array[qid];
        }

        private void QuickFind(int[] array, int pid, int qid)
        {
            pid = array[pid];
            qid = array[qid];
            if (pid!=qid)
            {
                for(int i = 0; i<array.Length; i++)
                {
                    if (array[i]==pid)
                    {
                        array[i] = qid;
                    }
                }
            }
        }

        private void QuickUnionWeighted(int[] array, int pid, int qid)
        {
            int[] weightMap = WeightTree(array);
            int pRoot = GetRoot(array, pid);
            int qRoot = GetRoot(array, qid);
            if (weightMap[pRoot]>=weightMap[qRoot])
            {
                array[qRoot] = array[pRoot];
            }
            else
            {
                array[pRoot] = array[qRoot];
            }
        }

        private int[] WeightTree(int[] array)
        {
            int[] result = new int[array.Length];
            for (int i = 0; i<array.Length; i++)
            {
                result[GetRoot(array, i)]++;
            }
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "QuickFind": {
                        QuickFind(ids, (int)(float.Parse(p.Text)), (int)(float.Parse(q.Text)));
                        break;
                    }
                case "QuickUnion":
                    {
                        QuickUnion(ids, (int)(float.Parse(p.Text)), (int)(float.Parse(q.Text)));
                        break;
                    }
                case "QuickUnionWeighted":
                    {
                        QuickUnionWeighted(ids, (int)(float.Parse(p.Text)), (int)(float.Parse(q.Text)));
                        break;
                    }

                default: { break; }
            }

        }
    }
}
