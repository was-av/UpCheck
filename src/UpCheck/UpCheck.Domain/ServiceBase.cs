using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpCheck.DAL.Domain
{
    using Common.Domain;

    public abstract class ServiceBase : ThingBase
    {
        #region Fields

        private string name;

        private float price;

        private ServiceCategoryBase category;

        #endregion

        #region Properties

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public float Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
        }

        public ServiceCategoryBase Category
        {
            get
            {
                return this.category;
            }
            set
            {
                this.category = value;
            }
        }

        #endregion
    }
}
