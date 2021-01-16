using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'libraryDataSet1.Enroll' table. You can move, or remove it, as needed.
            this.enrollTableAdapter.Fill(this.libraryDataSet1.Enroll);
            // TODO: This line of code loads data into the 'libraryDataSet1.Author' table. You can move, or remove it, as needed.
            this.authorTableAdapter.Fill(this.libraryDataSet1.Author);
            // TODO: This line of code loads data into the 'libraryDataSet1.Type' table. You can move, or remove it, as needed.
            this.typeTableAdapter.Fill(this.libraryDataSet1.Type);
            // TODO: This line of code loads data into the 'libraryDataSet1.Book' table. You can move, or remove it, as needed.
            this.bookTableAdapter.Fill(this.libraryDataSet1.Book);
            // TODO: This line of code loads data into the 'libraryDataSet1.Borrowing' table. You can move, or remove it, as needed.
            this.borrowingTableAdapter.Fill(this.libraryDataSet1.Borrowing);
            // TODO: This line of code loads data into the 'libraryDataSet1.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.libraryDataSet1.Student);

        }
        
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.studentTableAdapter.InsertQuery(textBox1.Text, textBox2.Text);
            this.studentTableAdapter.Fill(this.libraryDataSet1.Student);                            /////ADD STUDENT
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ID;
            int.TryParse(textBox3.Text, out ID);
            textBox4.Text = this.studentTableAdapter.ScalarQuery1(ID);
            textBox5.Text = this.studentTableAdapter.ScalarQuery2(ID);                            ///// SEARCH STUDENT
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int ID;
            int.TryParse(textBox3.Text, out ID);
            this.studentTableAdapter.UpdateQuery(textBox4.Text, textBox5.Text, ID);
            this.studentTableAdapter.Fill(this.libraryDataSet1.Student);                        ////// UPDATE STUDENT

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int ID;
            int.TryParse(textBox3.Text, out ID);
            this.studentTableAdapter.DeleteQuery(ID);
            this.studentTableAdapter.Fill(this.libraryDataSet1.Student);

            this.borrowingTableAdapter.UpdateQuery_Delete_Student(ID);
            this.borrowingTableAdapter.Fill(this.libraryDataSet1.Borrowing);                    //////DELETE STUDENT             
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int Name;
            int.TryParse(comboBox1.SelectedValue.ToString(), out Name);

            this.borrowingTableAdapter.InsertQuery(dateTimePicker1.Text, dateTimePicker2.Text, Name);
            this.borrowingTableAdapter.Fill(this.libraryDataSet1.Borrowing);                                /////ADD BORROWİNG
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int ID;
            int.TryParse(textBox6.Text, out ID);
            dateTimePicker3.Text = this.borrowingTableAdapter.ScalarQuery1(ID).ToString();
            dateTimePicker4.Text = this.borrowingTableAdapter.ScalarQuery2(ID).ToString();
            comboBox2.SelectedValue = this.borrowingTableAdapter.ScalarQuery3(ID);                       /////SEARCH BORROWİNG
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int Bor_ID, Stu_ID;
            int.TryParse(textBox6.Text, out Bor_ID);
            int.TryParse(comboBox2.SelectedValue.ToString(), out Stu_ID);

            this.borrowingTableAdapter.UpdateQuery(dateTimePicker3.Text, dateTimePicker4.Text, Stu_ID, Bor_ID);
            this.borrowingTableAdapter.Fill(this.libraryDataSet1.Borrowing);                              ///// UPDATE BORROWİNG
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int ID;
            int.TryParse(textBox6.Text, out ID);
            this.borrowingTableAdapter.DeleteQuery(ID);
            this.borrowingTableAdapter.Fill(this.libraryDataSet1.Borrowing);

            this.bookTableAdapter.UpdateQuery_Delete_Borrowing(ID);
            this.bookTableAdapter.Fill(this.libraryDataSet1.Book);                                        ////// DELETE BORROWİNG
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int Page, Bor_ID;

            int.TryParse(textBox8.Text, out Page);
            int.TryParse(comboBox3.SelectedValue.ToString(), out Bor_ID);

            this.bookTableAdapter.InsertQuery(textBox7.Text, Page, Bor_ID);
            this.bookTableAdapter.Fill(this.libraryDataSet1.Book);                     /////ADD BOOK
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int ID;
            int.TryParse(textBox9.Text, out ID);
            textBox10.Text = this.bookTableAdapter.ScalarQuery1(ID);
            textBox11.Text = this.bookTableAdapter.ScalarQuery2(ID).ToString();
            comboBox4.SelectedValue = this.bookTableAdapter.ScalarQuery3(ID);      //////SEARCH BOOK
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int Book_ID, Page, Bor_ID;
            int.TryParse(textBox9.Text, out Book_ID);
            int.TryParse(textBox11.Text, out Page);
            int.TryParse(comboBox5.SelectedValue.ToString(), out Bor_ID);

            this.bookTableAdapter.UpdateQuery(textBox10.Text, Page, Bor_ID, Book_ID);
            this.bookTableAdapter.Fill(this.libraryDataSet1.Book);                  ////// UPDATE BOOK
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int ID;
            int.TryParse(textBox9.Text, out ID);
            this.bookTableAdapter.DeleteQuery(ID);
            this.bookTableAdapter.Fill(this.libraryDataSet1.Book);

            this.typeTableAdapter.UpdateQuery_Delete_Book(ID);
            this.typeTableAdapter.Fill(this.libraryDataSet1.Type);

            this.enrollTableAdapter.UpdateQuery_Delete_Book(ID);
            this.enrollTableAdapter.Fill(this.libraryDataSet1.Enroll);              //////DELETE BOOK
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int Book_ID;
            int.TryParse(comboBox5.SelectedValue.ToString(), out Book_ID);

            this.typeTableAdapter.InsertQuery(textBox12.Text, textBox13.Text, Book_ID);               //////ADD TYPE
            this.typeTableAdapter.Fill(this.libraryDataSet1.Type);

        }

        private void button14_Click(object sender, EventArgs e)
        {
            int ID;
            int.TryParse(textBox14.Text, out ID);
            textBox15.Text = this.typeTableAdapter.ScalarQuery1(ID);
            textBox16.Text = this.typeTableAdapter.ScalarQuery2(ID);
            comboBox6.SelectedValue = this.typeTableAdapter.ScalarQuery3(ID);                        /////SEARCH TYPE
        }

        private void button15_Click(object sender, EventArgs e)
        {
            int Type_ID, Book_ID;
            int.TryParse(textBox14.Text, out Type_ID);
            int.TryParse(comboBox6.SelectedValue.ToString(), out Book_ID);

            this.typeTableAdapter.UpdateQuery(textBox15.Text, textBox16.Text, Book_ID, Type_ID);
            this.typeTableAdapter.Fill(this.libraryDataSet1.Type);                                   //////UPDATE TYPE
        }

        private void button16_Click(object sender, EventArgs e)
        {
            int ID;
            int.TryParse(textBox14.Text, out ID);
            this.typeTableAdapter.DeleteQuery(ID);
            this.typeTableAdapter.Fill(this.libraryDataSet1.Type);                                    //////DELETE TYPE
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.authorTableAdapter.InsertQuery(textBox17.Text, textBox18.Text);
            this.authorTableAdapter.Fill(this.libraryDataSet1.Author);                   //////ADD AUTHOR
        }

        private void button18_Click(object sender, EventArgs e)
        {
            int ID;
            int.TryParse(textBox19.Text, out ID);
            textBox20.Text = this.authorTableAdapter.ScalarQuery1(ID);
            textBox21.Text = this.authorTableAdapter.ScalarQuery2(ID);                   /////SEARCH AUTHOR
        }

        private void button19_Click(object sender, EventArgs e)
        {
            int ID;
            int.TryParse(textBox19.Text, out ID);
            this.authorTableAdapter.UpdateQuery(textBox20.Text, textBox21.Text, ID);
            this.authorTableAdapter.Fill(this.libraryDataSet1.Author);                  //////UPDATE AUTHOR
        }

        private void button20_Click(object sender, EventArgs e)
        {
            int ID;
            int.TryParse(textBox19.Text, out ID);
            this.authorTableAdapter.DeleteQuery(ID);
            this.authorTableAdapter.Fill(this.libraryDataSet1.Author);

            this.enrollTableAdapter.UpdateQuery_Delete_Author(ID);
            this.enrollTableAdapter.Fill(this.libraryDataSet1.Enroll);               ////////DELETE AUTHOR

        }

        private void button21_Click(object sender, EventArgs e)
        {
            int Book_ID, Aut_ID;
            int.TryParse(comboBox7.SelectedValue.ToString(), out Book_ID);
            int.TryParse(comboBox8.SelectedValue.ToString(), out Aut_ID);

            this.enrollTableAdapter.InsertQuery(Book_ID, Aut_ID);
            this.enrollTableAdapter.Fill(this.libraryDataSet1.Enroll);                                ////////Add ENROLL
        }

        
    }
}
