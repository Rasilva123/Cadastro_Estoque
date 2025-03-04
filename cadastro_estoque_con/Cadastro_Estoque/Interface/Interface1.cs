using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro_Estoque.Interface
{
    internal interface Interface1<T>
    {
        void Salvar(T enternal);
        void Update(T enternal);
        void Delete(T enternal);
    }
}
