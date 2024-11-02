using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Biblioteca
{
    internal class Emprestimo
    {
        private DateTime dtEmprestimo { get; set; }
        private DateTime dtDevolucao { get; set; }

        public Emprestimo(DateTime dtEmprestimo, DateTime dtDevolucao)
        {
            this.dtEmprestimo = dtEmprestimo;
            this.dtDevolucao = dtDevolucao;
        }
        public Emprestimo(DateTime dtEmprestimo)
        {
            this.dtEmprestimo = dtEmprestimo;
            dtDevolucao =  DateTime.MinValue; // Marca a data de devolução como "não definida" por utilizar o valor mínimo
        }

        public Emprestimo() 
        {
            this.dtEmprestimo = DateTime.Now;
            dtDevolucao = DateTime.MinValue; // Marca a data de devolução como "não definida" por utilizar o valor mínimo
        }
    }
}
