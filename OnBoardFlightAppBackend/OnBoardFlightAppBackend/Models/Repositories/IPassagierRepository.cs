using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_board_flight_app_backend.Models
{
    public interface IPassagierRepository
    {
        IEnumerable<Passagier> GetAll();
        Passagier GetbyId(int id);
        void Add(Passagier passagier);
        void Remove(Passagier passagier);
        IEnumerable<Passagier> getReisgezelschap(int passagier);
        void SaveChanges();
    }
}
