using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpCheck.DAL.Domain
{
    using Common.Domain;

    // TODO: ThingBase to VocabulareItemBase

    public abstract class ServiceCategoryBase : ThingBase
    {
        #region Fields

        private int id;

        private string name;

        private int pareentId;

        #endregion

        #region Properties

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

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

        public int ParentId
        {
            get
            {
                return this.pareentId;
            }
            set
            {
                this.pareentId = value;
            }
        }

        #endregion
    }
}
