using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TesteSimpress.Models
{
    public class ProdutoDB
    {
        //declare connection string
        string cs = ConfigurationManager.ConnectionStrings["ConnectionSQLServerLocal"].ConnectionString;

        //Return list of all Products
        public List<Produto> ListAll()
        {
            List<Produto> lst = new List<Produto>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SelectProdutoCategoria", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new Produto
                    {
                        Id = Convert.ToInt32(rdr["id"]),
                        Nome = rdr["Nome"].ToString(),
                        Descricao = rdr["Descricao"].ToString(),
                        Ativo = Convert.ToBoolean(rdr["Ativo"]),
                        Perecivel = Convert.ToBoolean(rdr["Perecivel"]),
                        CategoriaID = Convert.ToInt32(rdr["CategoriaID"]),
                        Categoria = (rdr["nome"]).ToString(),
                    });
                }
                return lst;
            }
        }


        //Method fro Adding a Product
        public int AddProd(Produto prod)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("InsertProduto", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Nome", prod.Nome);
                com.Parameters.AddWithValue("@Descricao", prod.Descricao);
                com.Parameters.AddWithValue("@Ativo", prod.Ativo);
                com.Parameters.AddWithValue("@Perecivel", prod.Perecivel);
                com.Parameters.AddWithValue("@CategoriaID", prod.CategoriaID);
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Method for updating a Product
        public int UpdateProd(Produto prod)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("UpdateProduto", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", prod.Id);
                com.Parameters.AddWithValue("@Nome", prod.Nome);
                com.Parameters.AddWithValue("@Descricao", prod.Descricao);                 
                com.Parameters.AddWithValue("@Ativo", prod.Ativo);
                com.Parameters.AddWithValue("@Perecivel", prod.Perecivel);
                com.Parameters.AddWithValue("@CategoriaID", prod.CategoriaID);
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Method for Deleting a Product
        public int DeleteProd(int ID)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                SqlCommand com = new SqlCommand("DeleteProduto", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", ID);
                i = com.ExecuteNonQuery();
            }
            return i;
        }
    }
}