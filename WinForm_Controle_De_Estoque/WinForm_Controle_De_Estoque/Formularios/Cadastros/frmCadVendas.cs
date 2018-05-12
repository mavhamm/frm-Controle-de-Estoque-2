using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm_Controle_De_Estoque.db_05579_1_C_1_2017DataSetTableAdapters;

namespace WinForm_Controle_De_Estoque.Formularios.Cadastros
{
    public partial class frmCadVendas : Form
    {
        public frmCadVendas()
        {
            InitializeComponent();
        }

        int vld_VendaAtual, vQuantidadeDigitada, vSaldoAtual;
        double vValorTotalProduto, vTotalDoPedido, vValorUnitDigitado;   
        string vUsuario;

        private void frmCadVendas_Load(object sender, EventArgs e)
        {
            this.clienteTableAdapter.Fill(this.dataSet_Dados_Do_Banco.Cliente);
            vUsuario = Properties.Settings.Default.NomeUsuarioLogado.ToString();
        }

        private void btnAdicionarItem_Click(object sender, EventArgs e)
        {
            // Grava item na tabela temporária
            Item_TempTableAdapter taItemTemp = new Item_TempTableAdapter();
            taItemTemp.Insert(vld_VendaAtual, int.Parse(txtCodigo.Text), lblDescricaoProduto.Text,
            int.Parse(txtQtdVenda.Text), decimal.Parse(txtValorUnit.Text), vUsuario);
            // -----------------------------------------------
            Limpa_Campos_Item();
            CarregaGridItems(); // Carrega o grid com os dados, atualizados
            vTotalDoPedido = vTotalDoPedido + vValorTotalProduto;
            lblTotalPedido.Text = (vTotalDoPedido).ToString("###,##0.00");
        }

        private void CarregaGridItens()
        {
            Item_TempTableAdapter taItemTemp = new Item_TempTableAdapter();
            dgvItem.DataSource = taItemTemp.GetData();
        }

        private void Limpa_Campos_Item()
        {
            txtCodigo.Text = ""; // ou String.Empty;
            lblDescricaoProduto.Text = string.Empty; // ou ""
            txtQtdVenda.Text = "";
            txtValorUnit.Text = "";
            lblTotalProduto.Text = "";
        }



    }
}
