using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WannaDuo.Repository;

namespace WannaDuo.Services
{
    public class EntradaService :IEntrada
    {
        private readonly IRepositoryBase<Model.Entrada> _entradaRepository;

        public EntradaService(IRepositoryBase<Model.Entrada> entradaRepository)
        {
            _entradaRepository = entradaRepository;
        }

    }
}
