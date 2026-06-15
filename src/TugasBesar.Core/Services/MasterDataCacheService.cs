using System;
using System.Collections.Generic;
using System.Text;
using TugasBesar.Core.DTO.Response;
using TugasBesar.Core.Models;
using TugasBesar.Core.Services.Interfaces;

namespace TugasBesar.Core.Services
{
    public class MasterDataCacheService
    {
        public List<ProdukResponseDTO> DaftarProduk { get; set; } = new List<ProdukResponseDTO>();
        public List<KategoriResponseDTO> DaftarKategori { get; set; } = new List<KategoriResponseDTO>();
        public bool IsLoaded { get; set; } = false;

        //public List<OperasionalResponseDTO> DaftarOperasional { get; set; } = new List<OperasionalResponseDTO>();
        private readonly List<IOperasionalObserver> _observers = new List<IOperasionalObserver>();

        private List<OperasionalResponseDTO> _daftarOperasional = new List<OperasionalResponseDTO>();
        public List<OperasionalResponseDTO> DaftarOperasional
        {
            get => _daftarOperasional;
            set
            {
                _daftarOperasional = value;
                NotifyOperasionalChanged(); 
            }
        }

        public void Subscribe(IOperasionalObserver observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
        }

        public void Unsubscribe(IOperasionalObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyOperasionalChanged()
        {
            foreach (var observer in _observers)
            {
                observer.OnOperasionalChanged();
            }
        }
    }
}
