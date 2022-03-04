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

                con.Close();
                return qtd;
            }
        }

        public int Update(Card objTable)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.database;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = System.Data.CommandType.Text;
                con.Open();
                cn.CommandText = "UPDATE Card SET Name = @Name, Type = @Type WHERE Id = @Id";
                cn.Parameters.Add("Id", System.Data.SqlDbType.Int).Value = objTable.Id;
                cn.Parameters.Add("Name", System.Data.SqlDbType.VarChar).Value = objTable.Name;
                cn.Parameters.Add("Type", System.Data.SqlDbType.VarChar).Value = objTable.Type;

                cn.Connection = con; // Isso permite o uso da conexão estabelecida em con
                int qtd = cn.ExecuteNonQuery();

                con.Close();
                return qtd;
            }
        }

        public int Delete(Card objTable)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.database;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = System.Data.CommandType.Text;
                con.Open();
                cn.CommandText = "DELETE FROM Card WHERE Id = @Id";
                cn.Parameters.Add("Id", System.Data.SqlDbType.Int).Value = objTable.Id;

                cn.Connection = con; // Isso permite o uso da conexão estabelecida em con
                int qtd = cn.ExecuteNonQuery();

                con.Close();
                return qtd;
            }
        }

        public List<Card> ListAllCards()
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.database;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = System.Data.CommandType.Text;
                con.Open();
                cn.CommandText = "SELECT * from Card ";
                cn.Connection = con; // Isso permite o uso da conexão estabelecida em con

                SqlDataReader reader;
                List<Card> listCards = new List<Card>();

                reader = cn.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read()) // Enquanto houver dados...
                    {
                        Card data = new Card();
                        data.Id = Convert.ToInt32(reader["Id"]);
                        data.Name = Convert.ToString(reader["Name"]);
                        data.Type = Convert.ToString(reader["Type"]);

                        listCards.Add(data);
                    }
                }
                con.Close();

                return listCards;
            }
        }

        public List<Card> Search(Card objTable)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.database;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = System.Data.CommandType.Text;
                con.Open();
                cn.CommandText = "SELECT * from Card WHERE Name LIKE @Name";
                cn.Connection = con; // Isso permite o uso da conexão estabelecida em con

                cn.Parameters.Add("Name", System.Data.SqlDbType.VarChar).Value = "%" + objTable.Name + "%";

                SqlDataReader reader;
                List<Card> listCards = new List<Card>();

                reader = cn.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read()) // Enquanto houver dados...
                    {
                        Card data = new Card();
                        data.Id = Convert.ToInt32(reader["Id"]);
                        data.Name = Convert.ToString(reader["Name"]);
                        data.Type = Convert.ToString(reader["Type"]);

                        listCards.Add(data);
                    }
                }
                con.Close();

                return listCards;
            }
        }
    }
}
