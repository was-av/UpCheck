// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VocabularyItemBase.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   The vocabulary item base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.Domain
{
    /// <summary>
    /// The vocabulary item base.
    /// </summary>
    public abstract class VocabularyItemBase : EntityBase
    {
        #region Fields

        /// <summary>
        /// The description.
        /// </summary>
        protected DescriptionBase description;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public virtual DescriptionBase Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        #endregion
    }
}
