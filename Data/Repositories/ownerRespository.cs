
using rwaAPI.Data.Models;
using rwaAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections;


using System.Text;


namespace rwaAPI.Data.Repositories
{
    public interface IownerRespository
    {

        owners Saveowner(owners objowner);
        owners Updateowner(owners objowner);
        List<ownerList> Getowner();
    }
    public class ownerRespsitory : IownerRespository
    {
        private readonly rwaAPIContext _context;
        public ownerRespsitory(rwaAPIContext context)
        {
            _context = context;

        }

        public owners Saveowner(owners request)
        {

            owners objowners = new owners();

                objowners.ownername = request.ownername;
                objowners.towerid = request.towerid;
                objowners.flatno = request.flatno;
                objowners.adderess = request.adderess;
                objowners.phone = request.phone;
                objowners.noofmembers = request.noofmembers;
                objowners.profession = request.profession;
                objowners.officeaddress = request.officeaddress;
                objowners.noofvechicles = request.noofvechicles;
                objowners.isparkingspace = request.isparkingspace;
            
                _context.owners.Add(objowners);
                _context.SaveChanges();
            

            return request;
        }

        public owners Updateowner(owners request)
        {
            var objowners = _context.owners.Where(x => x.ownerid == request.ownerid).FirstOrDefault();
            if (objowners != null)
            {

                objowners = new owners();

                objowners.ownername = request.ownername;
                objowners.towerid = request.towerid;
                objowners.flatno = request.flatno;
                objowners.adderess = request.adderess;
                objowners.phone = request.phone;
                objowners.noofmembers = request.noofmembers;
                objowners.profession = request.profession;
                objowners.officeaddress = request.officeaddress;
                objowners.noofvechicles = request.noofvechicles;
                objowners.isparkingspace = request.isparkingspace;
                _context.owners.Update(objowners);
                _context.SaveChanges();
            }

            return request;
        }


        public List<ownerList> Getowner()
        {

            var objowners = (from mowner in _context.owners
                            join mtower in _context.towers on new { a = mowner.towerid } equals new { a = mtower.id }
                            select new ownerList
                            {

                                ownerid = mowner.ownerid,
                                ownername = mowner.ownername,
                                towerid = mowner.towerid,
                                ownertowername = mtower.name,
                                flatno = mowner.flatno,
                                adderess = mowner.adderess,
                                phone = mowner.phone,
                                noofmembers = mowner.noofmembers,
                                profession = mowner.profession,
                                officeaddress = mowner.officeaddress,
                                noofvechicles = mowner.noofvechicles,
                                isparkingspace = mowner.isparkingspace,


                            }).ToList();
            
                return objowners;

        }



    }
}

