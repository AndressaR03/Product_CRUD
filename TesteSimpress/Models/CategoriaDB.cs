using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TesteSimpress.Models
{
    public class CategoriaDB
    {
        //declare connection string
        string cs = ConfigurationManager.ConnectionStrings["ConnectionSQLServerLocal"].ConnectionString;

        //Return list of all Products
        public List<Categoria> ListAll()
        {
            List<Categoria> lst = new List<Categoria>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SelectCategoria", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new Categoria
                    {
                        Id = Convert.ToInt32(rdr["id"]),
                        Nome = rdr["nome"].ToString(),
                        Descricao = rdr["Descricao"].ToString(),
                        Ativo = Convert.ToBoolean(rdr["Ativo"]),
                    });
                }
                return lst;
            }
        }
    }
}