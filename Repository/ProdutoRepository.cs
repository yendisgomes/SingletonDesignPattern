using SingletonDesignPattern.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDesignPattern.Repository
{
    public sealed class ProdutoRepository
    {
        /*
         * Singleton
         * 
         * Garante a existência de apenas uma instância de uma classe em memória
         */

        private readonly IList<Produto> _produtos;
        private static ProdutoRepository _instance = null;
        private static readonly object SyncObj = new object();

        private ProdutoRepository()
        {
            _produtos = new List<Produto>();
        }

        public static ProdutoRepository GetInstance()
        {
            if (_instance != null) return _instance;

            lock (SyncObj)
            {
                if (_instance == null)
                {
                    _instance = new ProdutoRepository();
                }
            }

            return _instance;
        }

        public IList<Produto> GetAll()
        {
            return _instance._produtos;
        }

        public void Insert(Produto produto)
        {
            _instance._produtos.Add(produto);
        }
    }
}
