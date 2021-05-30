using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Supermarket
{
    public partial class SellerForm : Form
    {
        public SellerForm()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\smarketdb.mdf;Integrated Security=True;Connect Timeout=30");


        private void SellerForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void populate()
        {
            Con.Open();
            string query = "select * from SellerTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            SellerDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductForm prod = new ProductForm();
            this.Hide();
            prod.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CategoryForm cat = new CategoryForm();
            this.Hide();
            cat.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string query = "insert into SellerTbl values(" + SellerId.Text + ",'" + SellerName.Text + "'," + SellerAge.Text + ",'" + SellerPhn.Text + "','" + SellerPass.Text + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Information Added Successfully");
                Con.Close();
                populate();
                SellerId.Text = "";
                SellerName.Text = "";
                SellerAge.Text = "";
                SellerPhn.Text = "";
                SellerPass.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (SellerId.Text == "")
                {
                    MessageBox.Show("Select Information to Delete");
                }
                else
                {
                    Con.Open();
                    string query = "delete from SellerTbl where SellerId=" + SellerId.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Information Deleted Successfully");
                    Con.Close();
                    populate();
                    SellerId.Text = "";
                    SellerName.Text = "";
                    SellerAge.Text = "";
                    SellerPhn.Text = "";
                    SellerPass.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (SellerId.Text == "" || SellerName.Text == "" || SellerAge.Text == "" || SellerPhn.Text == "" || SellerPass.Text == "")
                {
                    MessageBox.Show("Missing Information!!!!");
                }
                else
                {
                    Con.Open();
                    string query = "update SellerTbl set SellerName='" + SellerName.Text + "',SellerAge=" + SellerAge.Text + ",SellerPhone='" + SellerPhn.Text + "',SellerPass='"+SellerPass.Text+"' where SellerId=" + SellerId.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Seller Information Successfully Updated!!!");
                    Con.Close();
                    populate();
                    SellerId.Text = "";
                    SellerName.Text = "";
                    SellerAge.Text = "";
                    SellerPhn.Text = "";
                    SellerPass.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }

        private void SellerDGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            SellerId.Text = SellerDGV.SelectedRows[0].Cells[0].Value.ToString();
            SellerName.Text = SellerDGV.SelectedRows[0].Cells[1].Value.ToString();
            SellerAge.Text = SellerDGV.SelectedRows[0].Cells[2].Value.ToString();
            SellerPhn.Text = SellerDGV.SelectedRows[0].Cells[3].Value.ToString();
            SellerPass.Text = SellerDGV.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            this.Hide();
            login.Show();
        }
    }
}
