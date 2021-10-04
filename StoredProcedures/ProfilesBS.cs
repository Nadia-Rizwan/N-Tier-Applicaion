using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoredProcedures
{
   public class ProfilesBS
    {
        private ProfilesDB profilesDB;
        public ProfilesBS()
        {
            profilesDB = new ProfilesDB();
        }
        public void Insert(Profile profile)
        {
            profilesDB.Insert(profile);
           // profileDb.Insert(profile);

        }

    }
}
