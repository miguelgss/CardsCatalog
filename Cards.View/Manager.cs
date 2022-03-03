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
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            opc = "Update";
            startOpc();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            opc = "Delete";
            startOpc();
        }

        private string opc = "";

        private void startOpc()
        {
            switch (opc)
            {
                case "New":
                    EnableFields();
                    ClearFields();
                    break;
                case "Save":
                    try
                    {
                        objTable.Name = txtName.Text;
                        objTable.Type = txtCT.Text;

                        int x = CardModel.Insert(objTable);

                        if(x > 0)
                        {
                            MessageBox.Show(String.Format("Carta {0} inserida.", txtName.Text));
                        }
                        else
                        {
                            MessageBox.Show("Falha na inserção.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao salvar. " + ex.Message);
                        throw;
                    }
                    break;
                case "Update":
                    break;
                case "Delete":
                    break;
                default:
                    break;
            }

            ListGrid(); // Da update na lista do grid
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

        private void ListGrid()
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
    }
}
