using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TugasBesar.Core.Models;

namespace TugasBesar.Core.Services
{
    public class DataGeneric<T>
    {
        private List<T> data = new List<T>();

        public void Add(T item)
        {
            data.Add(item);
        }

        public IReadOnlyList<T> GetAll()
        {
            return data.AsReadOnly();
        }

        public void RemoveAt(int index)
        {
            if (index >= 0 && index < data.Count)
                data.RemoveAt(index);
        }

        public void Update(int index, T item)
        {
            if (index >= 0 && index < data.Count)
                data[index] = item;
        }
    }
    public static class DataManager
    {
        public static DataGeneric<KategoriModels> Kategori = new DataGeneric<KategoriModels>();
        public static DataGeneric<ProdukModels> Produk = new DataGeneric<ProdukModels>();
        public static DataGeneric<OperasionalModels> Operasional = new DataGeneric<OperasionalModels>();
    }
}