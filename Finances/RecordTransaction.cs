using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESIS.Base_classes;

namespace ESIS.Finances
{
    public partial class RecordTransaction : Form
    {
        Connector fees = new Connector();
        InputValidator validator = new InputValidator();
        
        public RecordTransaction()
        {
           
            InitializeComponent();
            string user = fees.UserName;
           
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void classTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void admissionButton_Click(object sender, EventArgs e)
        {
            string admNo = admNoText.Text;
            if (validator.alphaNumericCheck(admNo))
            {
                List<string>[] details = fees.feesDetails("select studentsName,surname,AcademicLevel,balance from transactionhistory,students where transactionhistory.registrationnumber=students.registrationnumber and students.registrationnumber= '" + admNo + "'");
                if (details != null)
                {
                    
                    for (int i = 0; i < details[0].Count; i++)
                    {
                        nameTextBox.Text = details[0][i] + " " + details[1][i];
                        classTextBox.Text = details[2][i];
                        balanceTextBox.Text = details[3][i];
                    }
                    

                }
                else
                {
                    admNoText.Text = "";
                }
            }
            else
            {
                admNoText.Text = "";
            }
            return;
        }

        private void RecordTransaction_Load(object sender, EventArgs e)
        {
            DataSet items = fees.studentDetails("select name,amount from feesstructure");
            paymentComboBox.DataSource = items.Tables[0];
            paymentComboBox.ValueMember = "amount";
            paymentComboBox.DisplayMember = "name";
        }

        private void admNoText_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void nameButton_Click(object sender, EventArgs e)
        {
            if (validator.alphaCheck(nameText.Text))
            {
                DataSet items = fees.studentDetails("select studentsname from students where surname='" + nameText.Text + "'");
                if (items.Tables[0].Rows.Count != 0)
                {
                    namecomboBox.DataSource = items.Tables[0];
                    namecomboBox.DisplayMember = "StudentsName";
                }
                else
                {
                    MessageBox.Show("No student by such a name was found!");
                    nameText.Text = "";
                }
                    
            }
            else
                nameText.Text = "";
        }

        private void namecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            string surname = nameText.Text;
            string name = namecomboBox.Text;
            List<string>[] detail = fees.feesDetails("select studentsName,surname,AcademicLevel,balance from transactionhistory,students where transactionhistory.registrationnumber=students.registrationnumber and students.surname= '" + surname + "'" + " and students.studentsname= '" + name + "'");
            if (detail != null) 
            {
                nameTextBox.Text = detail[0][0] + " " + detail[1][0];
                classTextBox.Text = detail[2][0];
                balanceTextBox.Text = detail[3][0];
            }
        }

        private void paymentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(balanceTextBox.Text == ""))
            {
                int balance = int.Parse(balanceTextBox.Text);
                var newBalance= (int) paymentComboBox.SelectedValue;
                newBalance += balance;
                balanceTextBox.Text = newBalance + "";
            }
            
        }
    }
}
