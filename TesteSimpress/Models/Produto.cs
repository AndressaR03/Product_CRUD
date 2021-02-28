using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteSimpress.Models
{
    public class Produto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public bool Ativo { get; set; }

        public bool Perecivel { get; set; }

        public int CategoriaID { get; set; }

        public string  Categoria { get; set; }
    }
}