using rwaAPI.Data.Models;
using rwaAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rwaAPI.Data.Repositories
{
    public interface ItowerRespository
    {

        towers Savetower(towers objtower);
        towers UpdateTower(towers objtower);
    }
    public class towerRespsitory : ItowerRespository
    {
        private readonly rwaAPIContext _context;
        public towerRespsitory(rwaAPIContext context)
        {
            _context = context;

        }

        public towers Savetower(towers request)
        {
            var objtowers = _context.towers.Where(x => x.name == request.name && x.towerno == request.towerno).FirstOrDefault();
            if (objtowers == null)
            {
                objtowers = new towers();
                objtowers.name = request.name;

                objtowers.towerno = request.towerno;
                objtowers.phone = request.phone;
                objtowers.noflats = request.noflats;
                objtowers.nofloors = request.nofloors;

                _context.towers.Add(objtowers);
                _context.SaveChanges();
            }
            return request;
        }

        public towers UpdateTower(towers request)
        {
            var objtowers = _context.towers.Where(x => x.id == request.id).FirstOrDefault();
            if (objtowers != null)
            {
                objtowers.id = request.id;
                objtowers.name = request.name;

                objtowers.towerno = request.towerno;
                objtowers.phone = request.phone;
                objtowers.noflats = request.noflats;
                objtowers.nofloors = request.nofloors;

                _context.towers.Update(objtowers);
                _context.SaveChanges();
            }

            return request;
        }
    }
}
