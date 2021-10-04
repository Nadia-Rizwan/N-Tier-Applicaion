using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProfilesBS
    {
        private ProfilesDB profilesDB;
        public ProfilesBS()
        {
            profilesDB = new ProfilesDB();
        }
        public IEnumerable<Profile> GetAll()
        {


            return profilesDB.getAll();


        }
        public IEnumerable<Profile> GetByIdBS(int id)
        {


            return profilesDB.sp_GetById(id);

        }

        public void Insert(Profile profile)
        {
            profilesDB.Insert(profile);
            // profileDb.Insert(profile);

        }
        public void Update(Profile profile)
        {
            profilesDB.sp_Update(profile);
            // profileDb.Insert(profile);

        }
        public void Delete(int id)
        {
            profilesDB.sp_Delete(id);
            // profileDb.Insert(profile);

        }

    }
}
