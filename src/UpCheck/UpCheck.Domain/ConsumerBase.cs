using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpCheck.DAL.Domain
{
    using Common.Domain;

    public abstract class ConsumerBase : ThingBase
    {
        #region Fields

        private string name;

        private string tel;

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

        public string Tel
        {
            get
            {
                return this.tel;
            }
            set
            {
                this.tel = value;
            }
        }

        #endregion
    }
}
