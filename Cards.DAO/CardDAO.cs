using Cards.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.DAO
{
    public class CardDAO // Faz a comunicação com o model e obtem dados do banco de dados
    {
        public int Insert(Card objTable)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.database;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = System.Data.CommandType.Text;
                con.Open();
                // Nesse caso, os colchetes são mandatórios para que o insert funcione
                cn.CommandText = "INSERT INTO Card ([Name],[Type]) VALUES (@Name, @Type)";
                cn.Parameters.Add("Name", System.Data.SqlDbType.VarChar).Value = objTable.Name;
                cn.Parameters.Add("Type", System.Data.SqlDbType.VarChar).Value = objTable.Type;

                cn.Connection = con; // Isso permite o uso da conexão estabelecida em con
                int qtd = cn.ExecuteNonQuery();

                return qtd;
            }
        }

        public List<Card> ListAllCards()
        {
            throw new NotImplementedException();
        }
    }
}
