using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteSimpress.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public bool Ativo { get; set; }
    }
}