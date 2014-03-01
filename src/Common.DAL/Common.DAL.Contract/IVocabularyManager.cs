// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IVocabularyManager.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   The vocabulary object relation mapping data manager interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.DAL.Contract
{
    using Common.Domain;

    /// <summary>
    /// The vocabulary object relation mapping data manager interface.
    /// </summary>
    /// <typeparam name="T">
    /// Entity type
    /// </typeparam>
    /// <typeparam name="TK">
    /// Key Id
    /// </typeparam>
    public interface IVocabularyManager<T, TK> : IDataManager<T, TK>
        where T : VocabularyItemBase
    {
        
    }
}
