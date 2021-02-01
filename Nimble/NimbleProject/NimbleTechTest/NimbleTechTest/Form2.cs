using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace NimbleTechTest
{
    public partial class Form2 : Form
    {
        //Vars
        Thread thread;

        public Form2()
        {
            InitializeComponent();

            if (Vars.changetab == true)
            {
                tabControl1.SelectedIndex = 1;
            }
        }

        //Back to menu Button
        private void button2_Click(object sender, EventArgs e)
        {
            //Close Window
            this.Close();

            //Assign thread to new form login function
            thread = new Thread(MenuForm);

            //Setting the State and Starting the Tread
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        //Openning new Form function
        private void MenuForm(object obj)
        {
            //Reset Bool when going back
            Vars.changetab = false;

            Application.Run(new Form1());
        }

        //Enter Button
        private void Button1_Click(object sender, EventArgs e)
        {
            //Adds Text from textboxes
            ListViewAdd(FirstNameBox.Text, LastNameBox.Text, DOBBox.Text);

            //Clear Text Boxes
            FirstNameBox.Text = "";
            LastNameBox.Text = "";
            DOBBox.Text = "";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //Setting ListView props
            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            //Add col
            listView1.Columns.Add("FirstName", 150); //Width
            listView1.Columns.Add("LastName", 150);
            listView1.Columns.Add("DOB", 150);

        }
        
        //Adding rows to col
        private void ListViewAdd(String firstname, String secondname, String dob)
        {
            //Array to rep row
            String[] row = { firstname, secondname, dob };

            //Add item to row array
            ListViewItem item = new ListViewItem(row);

            //Add item to listview
            listView1.Items.Add(item);

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            //Clears items in list
            listView1.Items.Clear();
        }

        private void ListView1_MouseClick(object sender, MouseEventArgs e)
        {
            string firstname = listView1.SelectedItems[0].SubItems[0].Text;
            string lastname = listView1.SelectedItems[0].SubItems[1].Text;
            string dob = listView1.SelectedItems[0].SubItems[2].Text;

            //Assign selected elements to text box
            FirstNameBox.Text = firstname;
            LastNameBox.Text = lastname;
            DOBBox.Text = dob;

        }
    }
}
