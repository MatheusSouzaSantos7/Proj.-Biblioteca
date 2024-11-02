using Proj.Biblioteca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Biblioteca
{
    internal class Livro
    {
        private int _isbn;
        public int ISBN
        {
            get{ return _isbn; }
            set{ _isbn = value;}
        }
        private string _titulo;
        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }

        private string _autor;
        public string Autor
        {
            get { return _autor; }
            set { _autor = value; }
        }

        private string _editora;
        public string Editora
        {
            get { return _editora; }
            set { _editora = value; }
        }

        private List<Exemplar> _exemplares = new List<Exemplar>();
        public List<Exemplar> Exemplares
        {
            get { return _exemplares; }
        }


        public Livro(int isbn, string titulo, string autor, string editora)
        {
            this.ISBN = isbn;
            this.Titulo = titulo;
            this.Autor = autor;
            this.Editora = editora;
        }

        public void adicionarExemplar(Exemplar exemplar)
        {
            Exemplares.Add(exemplar);
        }

        public int qtdeExemplares()
        {
            return Exemplares.Count;
        }

        public int qtdeDisponiveis()
        {
            // Conta quantos exemplares estão disponíveis
            return Exemplares.Count(ex => ex.disponivel());
        }

        public int qtdeEmprestimos()
        {
            // Soma a quantidade total de empréstimos de todos os exemplares
            return Exemplares.Sum(ex => ex.qtdeEmprestimos());
        }

        public double percDisponibilidade()
        {
            int totalExemplares = qtdeExemplares();
            if (totalExemplares == 0)
            {
                return 0.0; // Evita divisão por zero se não houver exemplares
            }

            // Calcula a porcentagem de exemplares disponíveis
            return (double)qtdeDisponiveis() / totalExemplares * 100;
        }
    }
}