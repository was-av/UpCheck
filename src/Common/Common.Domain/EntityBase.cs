namespace Common.Domain
{
    using System;

    public abstract class EntityBase : ThingBase
    {

        #region Fields

        protected DateTime modified = DateTime.Now;
        protected int userId;
        protected int isUpdated;

        #endregion


        #region Properties

        public virtual DateTime Modified
        {
            get { return this.modified; }
            set { this.modified = value; }
        }

        public virtual int UserId
        {
            get { return this.userId; }
            set { this.userId = value; }
        }

        public virtual int IsUpdated
        {
            get { return this.isUpdated; }
            set { this.isUpdated = value; }
        }


        #endregion

    }
}

