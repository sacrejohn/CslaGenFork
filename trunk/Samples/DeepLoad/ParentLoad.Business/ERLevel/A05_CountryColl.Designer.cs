using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoad.Business.ERLevel
{

    /// <summary>
    /// A05_CountryColl (editable child list).<br/>
    /// This is a generated base class of <see cref="A05_CountryColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="A04_SubContinent"/> editable child object.<br/>
    /// The items of the collection are <see cref="A06_Country"/> objects.
    /// </remarks>
    [Serializable]
    public partial class A05_CountryColl : BusinessListBase<A05_CountryColl, A06_Country>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="A06_Country"/> item from the collection.
        /// </summary>
        /// <param name="country_ID">The Country_ID of the item to be removed.</param>
        public void Remove(int country_ID)
        {
            foreach (var a06_Country in this)
            {
                if (a06_Country.Country_ID == country_ID)
                {
                    Remove(a06_Country);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="A06_Country"/> item is in the collection.
        /// </summary>
        /// <param name="country_ID">The Country_ID of the item to search for.</param>
        /// <returns><c>true</c> if the A06_Country is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int country_ID)
        {
            foreach (var a06_Country in this)
            {
                if (a06_Country.Country_ID == country_ID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="A06_Country"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="country_ID">The Country_ID of the item to search for.</param>
        /// <returns><c>true</c> if the A06_Country is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int country_ID)
        {
            foreach (var a06_Country in DeletedList)
            {
                if (a06_Country.Country_ID == country_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="A06_Country"/> item of the <see cref="A05_CountryColl"/> collection, based on item key properties.
        /// </summary>
        /// <param name="country_ID">The Country_ID.</param>
        /// <returns>A <see cref="A06_Country"/> object.</returns>
        public A06_Country FindA06_CountryByParentProperties(int country_ID)
        {
            for (var i = 0; i < this.Count; i++)
            {
                if (this[i].Country_ID.Equals(country_ID))
                {
                    return this[i];
                }
            }

            return null;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="A05_CountryColl"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="A05_CountryColl"/> collection.</returns>
        internal static A05_CountryColl NewA05_CountryColl()
        {
            return DataPortal.CreateChild<A05_CountryColl>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="A05_CountryColl"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="A05_CountryColl"/> object.</returns>
        internal static A05_CountryColl GetA05_CountryColl(SafeDataReader dr)
        {
            A05_CountryColl obj = new A05_CountryColl();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="A05_CountryColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public A05_CountryColl()
        {
            // Use factory methods and do not use direct creation.

            // show the framework that this is a child object
            MarkAsChild();

            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AllowNew = true;
            AllowEdit = true;
            AllowRemove = true;
            RaiseListChangedEvents = rlce;
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads all <see cref="A05_CountryColl"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            var args = new DataPortalHookArgs(dr);
            OnFetchPre(args);
            while (dr.Read())
            {
                Add(A06_Country.GetA06_Country(dr));
            }
            OnFetchPost(args);
            RaiseListChangedEvents = rlce;
        }

        /// <summary>
        /// Loads <see cref="A06_Country"/> items on the A05_CountryObjects collection.
        /// </summary>
        /// <param name="collection">The grand parent <see cref="A03_SubContinentColl"/> collection.</param>
        internal void LoadItems(A03_SubContinentColl collection)
        {
            foreach (var item in this)
            {
                var obj = collection.FindA04_SubContinentByParentProperties(item.parent_SubContinent_ID);
                var rlce = obj.A05_CountryObjects.RaiseListChangedEvents;
                obj.A05_CountryObjects.RaiseListChangedEvents = false;
                obj.A05_CountryObjects.Add(item);
                obj.A05_CountryObjects.RaiseListChangedEvents = rlce;
            }
        }

        #endregion

        #region DataPortal Hooks

        /// <summary>
        /// Occurs after setting query parameters and before the fetch operation.
        /// </summary>
        partial void OnFetchPre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after the fetch operation (object or collection is fully loaded and set up).
        /// </summary>
        partial void OnFetchPost(DataPortalHookArgs args);

        #endregion

    }
}
