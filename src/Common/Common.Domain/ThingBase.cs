// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThingBase.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   The thing base class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.Domain
{
    /// <summary>
    /// The thing base class defines the highest level of abstraction.
    /// </summary>
    public abstract class ThingBase
    {
        #region Fields

        /// <summary>
        /// The id.
        /// </summary>
        protected int id;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public virtual int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        
        #endregion
    }
}
