using System;
using System.Data;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for F11_City_ReChild type
    /// </summary>
    public partial interface IF11_City_ReChildDal
    {
        /// <summary>
        /// Inserts a new F11_City_ReChild object in the database.
        /// </summary>
        /// <param name="city_ID2">The parent City ID2.</param>
        /// <param name="city_Child_Name">The City Child Name.</param>
        void Insert(int city_ID2, string city_Child_Name);

        /// <summary>
        /// Updates in the database all changes made to the F11_City_ReChild object.
        /// </summary>
        /// <param name="city_ID2">The parent City ID2.</param>
        /// <param name="city_Child_Name">The City Child Name.</param>
        void Update(int city_ID2, string city_Child_Name);

        /// <summary>
        /// Deletes the F11_City_ReChild object from database.
        /// </summary>
        /// <param name="city_ID2">The parent City ID2.</param>
        void Delete(int city_ID2);
    }
}
