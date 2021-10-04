using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DAL
{
   public class ProfilesDB
    {

        private StoredProcedureDBEntities db;
        public ProfilesDB()
        {
            db = new StoredProcedureDBEntities();
        }

        public IEnumerable<Profile> getAll()   // select list
        {

            return db.sp_GetAll();

        }


        public IEnumerable<Profile> sp_GetById(int id)
        {
            var ProfileObj = db.GetProfilesById(id).ToList();


            return ProfileObj;
           

        }
        public void Insert(Profile profile)
        {

           // db.Profiles.Add(profile);
            db.Profiles_Insert(profile.Profile_ID,profile.FirstName,profile.LastName,profile.DateOfBirth,profile.PhoneNumber,profile.Email_ID);
            Save();
        }
        public void sp_Update(Profile profile)
        {

            // db.Profiles.Add(profile);
            db.Profiles_Update(profile.Profile_ID, profile.FirstName, profile.LastName, profile.DateOfBirth, profile.PhoneNumber, profile.Email_ID);
            Save();
        }
        public void sp_Delete(int id)
        {
            db.Profiles_Delete(id);
            Save();
        }

        public void Save()
        {

            db.SaveChanges();
        }

    }
}
