using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace 再現コード
{
    public partial class Form1 : Form
    {
        private Account John;
        private Account Paul;
        private Account Bank;

        public Form1()
        {
            InitializeComponent();

            John = new Account("John", 10000);
            Paul = new Account("Paul", 20000);
            Bank = new Account("Bank", 0);

            // 名前の初期表示
            label1.Text = John.GetName();
            label2.Text = Paul.GetName();
            label3.Text = Bank.GetName();


            // 残高の初期表示
            label4.Text = "残高: " + Convert.ToString(John.GetBalance()) + "円";
            label5.Text = "残高: " + Convert.ToString(Paul.GetBalance()) + "円";
            label6.Text = "残高: " + Convert.ToString(Bank.GetBalance()) + "円";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            John.transfer(Convert.ToInt32(textBox1.Text), Bank);
            // Thread thread1 = new Thread(() => { John.transfer(Convert.ToInt32(textBox1.Text), Bank); });

            // thread1.Start();
            // thread1.Join();

            // 残高の更新
            label4.Text = "残高: " + Convert.ToString(John.GetBalance()) + "円";
            label5.Text = "残高: " + Convert.ToString(Paul.GetBalance()) + "円";
            label6.Text = "残高: " + Convert.ToString(Bank.GetBalance()) + "円";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Paul.transfer(Convert.ToInt32(textBox2.Text), Bank);
            // Thread thread2 = new Thread(() => { Paul.transfer(Convert.ToInt32(textBox1.Text), Bank); });

            // thread2.Start();
            // thread2.Join();

            label4.Text = "残高: " + Convert.ToString(John.GetBalance()) + "円";
            label5.Text = "残高: " + Convert.ToString(Paul.GetBalance()) + "円";
            label6.Text = "残高: " + Convert.ToString(Bank.GetBalance()) + "円";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Thread thread1 = new Thread(() => { John.transfer(Convert.ToInt32(textBox1.Text), Bank); });
            Thread thread2 = new Thread(() => { Paul.transfer(Convert.ToInt32(textBox1.Text), Bank); });

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            label4.Text = "残高: " + Convert.ToString(John.GetBalance()) + "円";
            label5.Text = "残高: " + Convert.ToString(Paul.GetBalance()) + "円";
            label6.Text = "残高: " + Convert.ToString(Bank.GetBalance()) + "円";
        }
    }

    public partial class Account
    {
        private string name; // 名前
        private int balance; // 残高

        public Account()
        {
            this.name = "";
            this.balance = 0;
        }
        public Account(string registerd_name, int registerd_balance)
        {
            this.name = registerd_name;
            this.balance = registerd_balance;
        }

        // 口座の名前を取得
        public string GetName() { return this.name; }

        // 口座の残金を取得
        public int GetBalance() { return this.balance; }

        // 送金
        public void transfer(int money, Account a)
        // public async void transfer(int money, Account a)
        {
            this.balance -= money;
            // System.Threading.Thread.Sleep(1000 * 1);
            // await Task.Delay(1000 * 2);
            for (int i = 0; i < int.MaxValue; i++) { }
            a.balance += money;
        }
    }
}
