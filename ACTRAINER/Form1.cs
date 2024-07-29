using System;
using System.Threading;
using System.Windows.Forms;
using Memory;

namespace ACTRAINER
{
    public partial class Form1 : Form
    {
        Mem memory = new Mem();
        public static string rAmmo = "ac_client.exe+0x0017E0A8,140";
        public static string health = "ac_client.exe+0x0017E0A8,EC";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread rAmmo = new Thread(F);
            rAmmo.Start();

            Thread health = new Thread(H);
            health.Start();
        }

        private void F()
        {
            while (true)
            {
                if (checkBox1.Checked)
                {
                    memory.WriteMemory(rAmmo, "int", "100");
                    Thread.Sleep(5);
                }
                Thread.Sleep(10);
            }
        }

        private void H()
        {
            while (true)
            {
                if (checkBox2.Checked)
                {
                    memory.WriteMemory(health, "int", "1000");
                    Thread.Sleep(5);
                }
                Thread.Sleep(10);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int processID = memory.GetProcIdFromName("ac_client");
            if (processID > 0)
            {
                memory.OpenProcess(processID);
                MessageBox.Show($"Found process, {processID}"); 
            }
            else
            {
                MessageBox.Show($"Process not found");
            }

        }
    }
}
