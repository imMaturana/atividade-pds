using System.Collections.Generic;

namespace ds_atividade.Intefaces
{
    interface IDAO<T>
    {
        void Insert(T t);
        void Update(T t);
        void Delete(T t);
        List<T> List();
        T GetById(uint id);
    }
}