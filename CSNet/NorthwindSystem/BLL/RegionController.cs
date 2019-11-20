
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region Additional Namespaces
using NorthwindSystem.Data;
using NorthwindSystem.DAL;
#endregion

namespace NorthwindSystem.BLL
{
    public class RegionController
    {
        //EntityFramework realizes that certain requests for data are common
        //EntityFramework has created methods that can be called to do the common
        //   requests

        //method that will return all Region records
        public List<Region> Regions_List()
        {
            //create an instance of the context class that will handle the data request
            //most of CRUD requires using a transaction
            //to ensure that your data request is handled as a transaction
            //    we will encase all  controller action within a transaction
            using (var context = new NorthwindContext())
            {
                //transaction code
                return context.Regions.ToList();
            }
                

        }

        // method that will return a specific Region record based on its pkey
        public Region Regions_FindByID(int regionid)
        {

            using (var context = new NorthwindContext())
            {
                //transaction code
                return context.Regions.Find(regionid);
            }


        }
        #region Filter Search Demo Interface
        public List<Region> Region_List()
        {
            //need to connect to the Context class
            //this connection will be done in a transaction coding group
            using (var context = new NorthwindContext())
            {
                //via EnityFrame, make a request for all records,
                //all attributes from the specified DbSet property
                return context.Regions.ToList();
            }
        }

        public Region Region_Get(int regionid)
        {
            //return the record from the database via the DbSet collection
            //where the pkey matches the supplied value
            using (var context = new NorthwindContext())
            {
                return context.Regions.Find(regionid);
            }
        }

        #endregion
    }
}
