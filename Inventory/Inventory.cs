using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Linq.Expressions;

namespace Inventory
{
    public partial class frmAddProduct : Form
    {
        private string _ProductName;
        private string _Category;
        private string _MfgDate;
        private string _ExpDate;
        private string _Description;
        private int _Quantity;
        private double _SellPrice;
        BindingSource showProductList;


        public frmAddProduct()
        {
            showProductList = new BindingSource();
            InitializeComponent();
        }

        private void frmAddProduct_Load(object sender, EventArgs e)
        {
            string[] ListOfProductCategory = new string[] {
               "Beverages",
               "Bread/Bakey",
               "Canned/Jarred Goods",
               "Dairy",
               "Frozen Goods",
               "Meat",
               "Personal Care",
               "Other",
            };
            foreach (string item in ListOfProductCategory)
            {
                cbCategory.Items.Add(item);
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            _ProductName = Product_Name(txtProductName.Text);
            _Category = cbCategory.Text;
            _MfgDate = dtPickerMfDate.Value.ToString("yyyy-MM-dd");
            _ExpDate = dtPickerExpDate.Value.ToString("yyyy-MM-dd");
            _Description = richTxtDescription.Text;
            _Quantity = Quantity(txtQuantity.Text);
            _SellPrice = SellingPrice(txtSellPrice.Text);
            showProductList.Add(new Product_Class(_ProductName, _Category, _MfgDate, _ExpDate, _SellPrice, _Quantity, _Description));
            gridViewProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridViewProductList.DataSource = showProductList;

        }

    public string Product_Name(string name)
    {
        try
        {
            if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
            {

            }
        }
        catch (FormatException fe)
        {
            Console.WriteLine(fe.Message);
        }
        return name;
    }
    public int Quantity(string qty)
    {
        try
        {
            if (!Regex.IsMatch(qty, @"^[0-9]"))
            {

            }
        }
        catch (NumberFormatException fe)
        {
            Console.WriteLine(fe.Message);
        }
        return Convert.ToInt32(qty);
    }
    public double SellingPrice(string price)
    {
        try
        {

            if (!Regex.IsMatch(price.ToString(), @"^(\d*\.)?\d+$"))
            {

            }
        }
        catch (CurrencyFormatException fe)
        {
            Console.WriteLine(fe.Message);
        }
        return Convert.ToDouble(price);
    }
}
    class StringFormatException : Exception
{
    public StringFormatException(String name) : base(String.Format("Invalid Input", name))
    {

    }
}
    class NumberFormatException : Exception
{
    public NumberFormatException(int num) : base(String.Format("Invalid Input", num))
    {

    }
}
    class CurrencyFormatException : Exception
{
    public CurrencyFormatException(int num1) : base(String.Format("Invalid Input", num1))
    {

    }
}}





       