// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DescriptionBase.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the DescriptionBase type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.Domain
{
    /// <summary>
    /// The description base class. Used in vocabulary entities to define description field.
    /// </summary>
    public abstract class DescriptionBase
    {
        #region Fields

        /// <summary>
        /// The description.
        /// </summary>
        protected string description;

        /// <summary>
        /// The name.
        /// </summary>
        protected string name;

        /// <summary>
        /// The name 1.
        /// </summary>
        protected string name1;

        /// <summary>
        /// The name 2.
        /// </summary>
        protected string name2;

        /// <summary>
        /// The name 3.
        /// </summary>
        protected string name3;

        /// <summary>
        /// The note.
        /// </summary>
        protected string note;

        /// <summary>
        /// The note 1.
        /// </summary>
        protected string note1;

        /// <summary>
        /// The note 2.
        /// </summary>
        protected string note2;

        /// <summary>
        /// The note 3.
        /// </summary>
        protected string note3;

        #endregion


        #region Properties

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public virtual string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public virtual string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>
        /// Gets or sets the name alternative. Could be used for translation in multi-language support systems.
        /// </summary>
        public virtual string Name1
        {
            get { return this.name1; }
            set { this.name1 = value; }
        }

        /// <summary>
        /// Gets or sets the second name alternative. Could be used for translation in multi-language support systems.
        /// </summary>
        public virtual string Name2
        {
            get { return this.name2; }
            set { this.name2 = value; }
        }

        /// <summary>
        /// Gets or sets the third name alternative. Could be used for translation in multi-language support systems.
        /// </summary>
        public virtual string Name3
        {
            get { return this.name3; }
            set { this.name3 = value; }
        }

        /// <summary>
        /// Gets or sets the Note. 
        /// </summary>
        public virtual string Note
        {
            get { return this.note; }
            set { this.note = value; }
        }

        /// <summary>
        /// Gets or sets the second note alternative. Could be used for translation in multi-language support systems.
        /// </summary>
        public virtual string Note1
        {
            get { return this.note1; }
            set { this.note1 = value; }
        }

        /// <summary>
        /// Gets or sets the third note alternative. Could be used for translation in multi-language support systems.
        /// </summary>
        public virtual string Note2
        {
            get { return this.note2; }
            set { this.note2 = value; }
        }

        /// <summary>
        /// Gets or sets the fourth note alternative. Could be used for translation in multi-language support systems.
        /// </summary>
        public virtual string Note3
        {
            get { return this.note3; }
            set { this.note3 = value; }
        }

        #endregion
    }
}
