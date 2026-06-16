using System;
using System.Collections.Generic;
using System.Text;

namespace TugasBesar.Core.Models
{
    public class UsersModels
    {
        public long IdUser { get; set; }
        public required string NamaUser { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public string Role { get; set; } = "PEGAWAI";
        public string? RememberToken { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public ICollection<TransaksiModels> Transaksi { get; set; } = new List<TransaksiModels>();
    }
}
