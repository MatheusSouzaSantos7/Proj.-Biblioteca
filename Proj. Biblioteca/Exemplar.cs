
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Biblioteca
{
    internal class Exemplar
    {
        private int _tombo;
        public int Tombo
        {
            get { return _tombo; }
            set { _tombo = value; }
        }

        List<Emprestimo> emprestimos;

        public Exemplar()
        {
            Tombo = 0;
            emprestimos = new List<Emprestimo>();
        }

        public bool emprestar()
        {
            
            if (disponivel())
            {
                emprestimos.Add(new Emprestimo());
                return true;
            }
            else { return false; }
        }

        public bool devolver() 
        {
            // Verifica se há algum empréstimo realizado (lista não vazia)
            if (emprestimos.Count > 0)
            {
                if (!disponivel())
                {
                    // Remove o último empréstimo, representando a devolução
                    emprestimos.RemoveAt(emprestimos.Count - 1);
                    return true;
                }
            }
            return false;
        }

        public bool disponivel()
        {
            /* da empréstimo em andamento adiciona um item à lista. Se o número total de registros 
             for par (emprestimos.Count % 2 == 0), significa que todos os empréstimos foram devolvidos e o 
             exemplar está disponível. Se for ímpar, há um empréstimo em andamento. */
             return emprestimos.Count % 2 == 0;
        }

        public int qtdeEmprestimos()
        {
            return emprestimos.Count;
        }
    }
}
/* UML de classe
------------------------------------
| Exemplar                         | 
|----------------------------------|
| - tombo: int                     |
| - emprestimos: List<Emprestimo>  |
|----------------------------------|
| + emprestar(): bool              |
| + devolver(): bool               |
| + disponivel(): bool             |
| + qtdeEmprestimos(): int         |
------------------------------------ 
 */