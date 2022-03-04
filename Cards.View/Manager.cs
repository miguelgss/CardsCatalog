using Cards.Entity;
using Cards.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cards.View
{
    public partial class frmCardManager : Form
    {

        Card objTable = new Card();
        public frmCardManager()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            opc = "New";
            startOpc();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            opc = "Save";
            startOpc();
            ListGrid();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("Informe uma carta que exista clicando na tabela.");
            }
            else
            {
                opc = "Update";
                startOpc();
            }
            ListGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("Informe uma carta que exista clicando na tabela.");
            }
            else
            {
                opc = "Delete";
                startOpc();
            }
            ListGrid();
        }

        private string opc = "";

        private void startOpc()
        {
            switch (opc)
            {
                case "New":
                    EnableFields();
                    ClearFields();
                    lblMessage.Text = "Insira uma nova carta.";
                    break;
                case "Save":
                    try
                    {
                        objTable.Name = txtName.Text;
                        objTable.Type = txtCT.Text;

                        int x = 0;

                        if (!String.IsNullOrEmpty(txtName.Text) && !String.IsNullOrEmpty(txtCT.Text))
                        {
                            x = CardModel.Insert(objTable);
                        }

                        if(x > 0)
                        {
                            //MessageBox.Show(String.Format("Carta {0} inserida.", txtName.Text));
                            lblMessage.Text = String.Format("Carta {0} inserida.", txtName.Text);
                        }
                        else
                        {
                            //MessageBox.Show("Falha na inserção.");
                            lblMessage.Text = "Falha na inserção. Verifique se o nome e tipo estão preenchidos.";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao salvar. " + ex.Message);
                        throw;
                    }
                    break;
                case "Update":
                    try
                    {
                        objTable.Id = Convert.ToInt32(txtCode.Text);
                        objTable.Name = txtName.Text;
                        objTable.Type = txtCT.Text;

                        int x = 0;

                        if (objTable.Id > 0)
                        {
                            x = CardModel.Update(objTable);
                        }

                        if (x > 0)
                        {
                            lblMessage.Text = String.Format("Carta {0} atualizada.", txtName.Text);
                        }
                        else
                        {
                            lblMessage.Text = "Falha na atualização. Verifique se o nome e tipo estão preenchidos.";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao atualizar. " + ex.Message);
                        throw;
                    }
                    break;
                case "Delete":
                    try
                    {
                        objTable.Id = Convert.ToInt32(txtCode.Text);

                        int x = 0;

                        if (objTable.Id > 0)
                        {
                            x = CardModel.Delete(objTable);
                        }

                        if (x > 0)
                        {
                            lblMessage.Text = String.Format("Carta {0} excluida.", txtName.Text);
                        }
                        else
                        {
                            lblMessage.Text = "Falha na exclusão. Verifique se o nome e tipo estão preenchidos.";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao excluir. " + ex.Message);
                        throw;
                    }
                    break;
                case "Search":
                    try
                    {
                        objTable.Name = txtSearch.Text;

                        List<Card> listCards = new List<Card>();
                        listCards = new CardModel().Search(objTable);

                        lblMessage.Text = String.Format("Foram encontrados {0} resultados.",listCards.Count);

                        DGView.AutoGenerateColumns = false;
                        DGView.DataSource = listCards;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Algo deu zebra. " + ex);
                        throw;
                    }
                    break;
                default:
                    break;
            }
        }

        private void EnableFields() // Habilita os campos para digitação
        {
            txtName.Enabled = true;
            txtCT.Enabled = true;
        }

        private void ClearFields() // Limpa os campos de digitação
        {
            txtName.Text = "";
            txtCT.Text = "";
        }

        private void ListGrid() // Imprime a lista de cartas no DataGridView
        {
            try
            {
                List<Card> listCards = new List<Card>();
                listCards = new CardModel().ListAllCards();
                DGView.AutoGenerateColumns = false;
                DGView.DataSource = listCards;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu zebra. " + ex);
                throw;
            }
        }

        private void frmCardManager_Load(object sender, EventArgs e)
        {
            ListGrid();
        }

        // Obtem os dados da linha selecionada e os transcreve nas caixas de texto
        private void DGView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCode.Text = DGView.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = DGView.CurrentRow.Cells[1].Value.ToString();
            txtCT.Text = DGView.CurrentRow.Cells[2].Value.ToString();
            EnableFields();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSearch.Text))
            {
                ListGrid();
            }
            else
            {
                opc = "Search";
                startOpc();
            }
        }
    }
}
