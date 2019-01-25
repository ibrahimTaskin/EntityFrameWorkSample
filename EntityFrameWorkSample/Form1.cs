using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameWorkSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ProductDal _productDal=new ProductDal();

        private void Form1_Load(object sender, EventArgs e)
        {
            VeriGetir();
        }

        private void VeriGetir()
        {
            dgvProducts.DataSource = _productDal.GetAll();
        }

        private void UrunAra(string key)
        {
            var result = _productDal.GetByName(key);
            dgvProducts.DataSource = result;
            //direk databaseden çektiğimiz için büyük küçük harfe göre arama yapabilir.
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            UrunAra(tbxSearch.Text);
            //textbox a yazdığımız değere göre arama yapar.
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxNameUpdate.Text = dgvProducts.CurrentRow.Cells[1].Value.ToString();
            tbxUnitPriceUpdate.Text = dgvProducts.CurrentRow.Cells[2].Value.ToString();
            tbxStockAmountUpdate.Text = dgvProducts.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product
            {
                Name = tbxName.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                StockAmount = Convert.ToInt32(tbxStockAmount.Text)
            });
            VeriGetir();
            MessageBox.Show("ÜRÜN EKLENDİ !!!");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productDal.Uodate(new Product
            {
                Id = Convert.ToInt32(dgvProducts.CurrentRow.Cells[0].Value),
                Name = tbxNameUpdate.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text),
                StockAmount = Convert.ToInt32(tbxStockAmountUpdate.Text)
            });
            VeriGetir();
            MessageBox.Show("ÜRÜN GÜNCELLENDİ !!!");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            _productDal.Delete(new Product
            {
                Id = Convert.ToInt32(dgvProducts.CurrentRow.Cells[0].Value)
            });
            VeriGetir();
            MessageBox.Show("ÜRÜN SİLİNDİ !!!");
        }
    }
}
