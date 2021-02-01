using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using System.Data;

namespace NimbleTechTest
{
    public partial class Form1 : Form
    {
        //Vars
        Thread thread;
        int currentTotalItemCost = 0;
        int numofToppings = 0;
        DataTable table = new DataTable();
        public System.Windows.Forms.TabControl tabControl1;
        private Form2 form2;
        public static string baseTeaText;
        public static string flavourtText;
        public static string toppings;

        public Form1()
        {
            InitializeComponent();
            this.form2 = form2;
        }

        private void newLoginFormOpen(object obj)
        {
            Application.Run(new Form2());
        }

        //HyperLink Button
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Closes current windowform
            this.Close();

            //Assign thread to new form login function
            thread = new Thread(newLoginFormOpen);

            //Setting the State and Starting the Tread
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        //Form1 Loading Objs Function
        private void Form1_Load(object sender, EventArgs e)
        {
            //Assign textbox to int val
            CurrentTotal.Text = "$" + currentTotalItemCost.ToString();

            //New Lists (BaseTea + Flavours)
            List<BaseTea> list = new List<BaseTea>();
            List<Flavour> list2 = new List<Flavour>();

            //Ref to Base Tea List Instance
            ListCopy.MyList = list;
            ListCopy.MyList2 = list2;

            //DataTableSetup
            table.Columns.Add("Size", typeof(string));
            table.Columns.Add("Base", typeof(string));
            table.Columns.Add("Tea", typeof(string));
            table.Columns.Add("Toppings", typeof(string));
            table.Columns.Add("Price", typeof(string));
            //Assign Table DataSource
            dataGridView1.DataSource = table;

            //Button Col (EDIT)
            DataGridViewButtonColumn Btn1 = new DataGridViewButtonColumn();
            Btn1.HeaderText = "Edit";
            Btn1.Text = "Edit";
            Btn1.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(Btn1);

            //Button Col (Delete)
            DataGridViewButtonColumn Btn2 = new DataGridViewButtonColumn();
            Btn2.HeaderText = "Delete";
            Btn2.Text = "Delete";
            Btn2.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(Btn2);

            //Adding List Items to base tea
            list.Add(new BaseTea() { id = 0, name = "Green Tea", price = 1});
            list.Add(new BaseTea() { id = 1, name = "Black Tea", price = 1 });
            list.Add(new BaseTea() { id = 2, name = "Milk Tea", price = 2 });
            
            //Assigning combobox the list
            coboBaseTea.DataSource = list;
            
            //Assigning Vals
            coboBaseTea.ValueMember = "id";
            coboBaseTea.DisplayMember = "Name";

            //Adding List Items to flav
            list2.Add(new Flavour() { id = 0, name = "- None -" , price = 0});
            list2.Add(new Flavour() { id = 1, name = "Lemon", price = 1 });
            list2.Add(new Flavour() { id = 2, name = "Passionfruit", price = 2 });
            list2.Add(new Flavour() { id = 3, name = "Yogurt", price = 2 });
            
            //Assigning combo the list
            coboFlav.DataSource = list2;
            
            //Assigning Vals
            coboFlav.ValueMember = "id";
            coboFlav.DisplayMember = "Name";

            BaseTea listItem1 = ListCopy.MyList.Find(x => (x.name == "Green Tea"));

            //StartUp Check Checking Base Tea Box for adding price to currentItemTotal
            if (coboBaseTea.Text == listItem1.name)
            {
                //Increament Item Cost Value
                currentTotalItemCost += listItem1.price;
                CurrentTotal.Text = "$" + currentTotalItemCost.ToString();
            }
        }

        private void AddToCart_Button_Click(object sender, EventArgs e)
        {
            //Local Vars
            string small = "S";
            string medium = "M";
            string large = "L";
            string toppings = " Toppings";

            if (radioButton1.Checked) //S
            {
                //Add to datagridview in form 1
                table.Rows.Add(small, coboBaseTea.Text, coboFlav.Text, numofToppings + toppings, CurrentTotal.Text);
                radioButton1.Checked = false;

                //Add to Listview in form2                          ------ This is my attempt at trying to access the list box in form2 but didn't know how to do it. So I just left my working out here. :)
                //form2.listView2.Columns.Add(coboBaseTea.Text);
                //form2.listView3.Columns.Add(coboFlav.Text);
                //form2.listView4.Columns.Add(numofToppings + toppings);
            }
            if (radioButton2.Checked) //M
            {
                table.Rows.Add(medium, coboBaseTea.Text, coboFlav.Text, numofToppings + toppings, CurrentTotal.Text);
                radioButton2.Checked = false;
            }
            if (radioButton3.Checked) //L
            {
                table.Rows.Add(large, coboBaseTea.Text, coboFlav.Text, numofToppings + toppings, CurrentTotal.Text);
                radioButton3.Checked = false;
            }

            //Clear Vars/Boxes
            coboBaseTea.SelectedValue = 0;
            coboFlav.SelectedValue = 0;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            numofToppings = 0;
            currentTotalItemCost = 1;
        }

        //CHECKBOX STATE CHANGES (TOPPINGS)------------------------------------------------
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                currentTotalItemCost++;
                numofToppings++;
            }
            else
            {
                currentTotalItemCost--;
                numofToppings--;
            }
            CurrentTotal.Text = "$" + currentTotalItemCost.ToString();
        }


        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                currentTotalItemCost++;
                numofToppings++;
            }
            else
            {
                currentTotalItemCost--;
                numofToppings--;
            }
            CurrentTotal.Text = "$" + currentTotalItemCost.ToString();
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                currentTotalItemCost++;
                numofToppings++;
            }
            else
            {
                currentTotalItemCost--;
                numofToppings--;
            }
            CurrentTotal.Text = "$" + currentTotalItemCost.ToString();
        }

        private void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                currentTotalItemCost++;
                numofToppings++;
            }
            else
            {
                currentTotalItemCost--;
                numofToppings--;
            }
            CurrentTotal.Text = "$" + currentTotalItemCost.ToString();
        }
        //--------------------------------------------------------------------------------------

        //CHECK STATE CHANGE Radio buttons (SIZES)----------------------------------------------
        private void RadioButton1_CheckedChanged(object sender, EventArgs e) //S
        {
            if (radioButton1.Checked)
            {
                //Add to totalcurrent cost
                currentTotalItemCost += 1;
            }
            else
            {
                currentTotalItemCost -= 1;
            }
            CurrentTotal.Text = "$" + currentTotalItemCost.ToString();
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e) //M
        {
            if (radioButton2.Checked)
            {
                //Add to totalcurrent cost
                currentTotalItemCost += 2;
            }
            else
            {
                currentTotalItemCost -= 2;
            }
            CurrentTotal.Text = "$" + currentTotalItemCost.ToString();
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e) //L
        {
            if (radioButton3.Checked)
            {
                //Add to totalcurrent cost
                currentTotalItemCost += 3;
            }
            else
            {
                currentTotalItemCost -= 3;
            }
            CurrentTotal.Text = "$" + currentTotalItemCost.ToString();
        }
        //---------------------------------------------------------------------------------------

        //Base Tea Change Button
        private void CoboBaseTea_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            var selectedItemPrice = (coboBaseTea.SelectedItem as BaseTea).price;
            var selectedItemName = (coboBaseTea.SelectedItem as BaseTea).name;

            //Item List
            BaseTea listItem1 = ListCopy.MyList.Find(x => (x.name == "Green Tea"));
            BaseTea listItem2 = ListCopy.MyList.Find(x => (x.name == "Black Tea"));
            BaseTea listItem3 = ListCopy.MyList.Find(x => (x.name == "Milk Tea"));

            //Checking Base Tea Box for adding price to currentItemTotal
            if (coboBaseTea.Text == listItem1.name || coboBaseTea.Text == listItem2.name || coboBaseTea.Text == listItem3.name)
            {
                //Increament Item Cost Value
                currentTotalItemCost = selectedItemPrice;
            }

            //Update CurrentTotal Text
            CurrentTotal.Text = "$" + currentTotalItemCost.ToString();
        }

        //Flavour Change Button
        private void CoboFlav_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var selectedItemPrice = (coboFlav.SelectedItem as Flavour).price;
            var selectedItemName = (coboFlav.SelectedItem as Flavour).name;

            //Item List
            Flavour listItem1 = ListCopy.MyList2.Find(x => (x.name == "- None -"));
            Flavour listItem2 = ListCopy.MyList2.Find(x => (x.name == "Lemon"));
            Flavour listItem3 = ListCopy.MyList2.Find(x => (x.name == "Passionfruit"));
            Flavour listItem4 = ListCopy.MyList2.Find(x => (x.name == "Yogurt"));

            //Checking Base Tea Box for adding price to currentItemTotal
            if (coboFlav.Text == listItem1.name || coboFlav.Text == listItem2.name || coboFlav.Text == listItem3.name || coboFlav.Text == listItem4.name)
            {
                //Increament Item Cost Value & take away previous item cost 
                currentTotalItemCost += selectedItemPrice; //- pre_item;
            }

            //Update CurrentTotal Text
            CurrentTotal.Text = "$" + currentTotalItemCost.ToString();
        }

        //DataGridView Button Click Evenet
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Local Vars
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;

            //Delete Button
            if (selectedIndex > -1 && dataGridView1.CurrentCell.Value == "Delete")
            {
                dataGridView1.Rows.RemoveAt(selectedIndex);
                dataGridView1.Refresh();
            }

            //Edit Button
            if (selectedIndex > -1 && dataGridView1.CurrentCell.Value == "Edit")
            {                
                //Open up 2nd Form and Close Current Form
                this.Close();
                
                //Assign thread to new form login function
                thread = new Thread(newLoginFormOpen);

                //Setting the State and Starting the Tread
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();

                //Changing tab to Bubble Tea Editor
                using (Form2 frm = new Form2())
                {
                    //Bool to change
                    Vars.changetab = true;
                }
            }
        }
    }

    /// <summary>
    /// Class to copy BaseTea and Flavour List objects
    /// </summary>
    public class ListCopy
    {
        //Global List Ref
        public static List<BaseTea> MyList { get; set; }
        public static List<Flavour> MyList2 { get; set; }
    }

}

//Global Vars for other form to access
class Vars
{
    public static bool changetab = false;
}
