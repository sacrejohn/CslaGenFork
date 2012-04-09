using System;
using System.Data;
using Csla;
using Csla.Data;
using ParentLoadSoftDelete.DataAccess.ERCLevel;
using ParentLoadSoftDelete.DataAccess;

namespace ParentLoadSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// F03_Continent_ReChild (editable child object).<br/>
    /// This is a generated base class of <see cref="F03_Continent_ReChild"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="F02_Continent"/> collection.
    /// </remarks>
    [Serializable]
    public partial class F03_Continent_ReChild : BusinessBase<F03_Continent_ReChild>
    {

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int continent_ID2 = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Continent_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Continent_Child_NameProperty = RegisterProperty<string>(p => p.Continent_Child_Name, "2_SubContinents Child Name");
        /// <summary>
        /// Gets or sets the 2_SubContinents Child Name.
        /// </summary>
        /// <value>The 2_SubContinents Child Name.</value>
        public string Continent_Child_Name
        {
            get { return GetProperty(Continent_Child_NameProperty); }
            set { SetProperty(Continent_Child_NameProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="F03_Continent_ReChild"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="F03_Continent_ReChild"/> object.</returns>
        internal static F03_Continent_ReChild NewF03_Continent_ReChild()
        {
            return DataPortal.CreateChild<F03_Continent_ReChild>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="F03_Continent_ReChild"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="F03_Continent_ReChild"/> object.</returns>
        internal static F03_Continent_ReChild GetF03_Continent_ReChild(SafeDataReader dr)
        {
            F03_Continent_ReChild obj = new F03_Continent_ReChild();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            obj.MarkOld();
            obj.BusinessRules.CheckRules();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="F03_Continent_ReChild"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private F03_Continent_ReChild()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="F03_Continent_ReChild"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="F03_Continent_ReChild"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Continent_Child_NameProperty, dr.GetString("Continent_Child_Name"));
            continent_ID2 = dr.GetInt32("Continent_ID2");
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Inserts a new <see cref="F03_Continent_ReChild"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(F02_Continent parent)
        {
            var args = new DataPortalHookArgs();
            using (var dalManager = DalFactoryParentLoadSoftDelete.GetManager())
            {
                OnInsertPre(args);
                var dal = dalManager.GetProvider<IF03_Continent_ReChildDal>();
                using (BypassPropertyChecks)
                {
                    dal.Insert(
                        parent.Continent_ID,
                        Continent_Child_Name
                        );
                }
                OnInsertPost(args);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="F03_Continent_ReChild"/> object.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update(F02_Continent parent)
        {
            var args = new DataPortalHookArgs();
            using (var dalManager = DalFactoryParentLoadSoftDelete.GetManager())
            {
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<IF03_Continent_ReChildDal>();
                using (BypassPropertyChecks)
                {
                    dal.Update(
                        parent.Continent_ID,
                        Continent_Child_Name
                        );
                }
                OnUpdatePost(args);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="F03_Continent_ReChild"/> object from database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf(F02_Continent parent)
        {
            var args = new DataPortalHookArgs();
            using (var dalManager = DalFactoryParentLoadSoftDelete.GetManager())
            {
                OnDeletePre(args);
                var dal = dalManager.GetProvider<IF03_Continent_ReChildDal>();
                using (BypassPropertyChecks)
                {
                    dal.Delete(parent.Continent_ID);
                }
                OnDeletePost(args);
            }
        }

        #endregion

        #region Pseudo Events

        /// <summary>
        /// Occurs after setting all defaults for object creation.
        /// </summary>
        partial void OnCreate(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Delete, after setting query parameters and before the delete operation.
        /// </summary>
        partial void OnDeletePre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Delete, after the delete operation, before Commit().
        /// </summary>
        partial void OnDeletePost(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after setting query parameters and before the fetch operation.
        /// </summary>
        partial void OnFetchPre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after the fetch operation (object or collection is fully loaded and set up).
        /// </summary>
        partial void OnFetchPost(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after the low level fetch operation, before the data reader is destroyed.
        /// </summary>
        partial void OnFetchRead(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after setting query parameters and before the update operation.
        /// </summary>
        partial void OnUpdatePre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Insert, after the update operation, before setting back row identifiers (RowVersion) and Commit().
        /// </summary>
        partial void OnUpdatePost(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Insert, after setting query parameters and before the insert operation.
        /// </summary>
        partial void OnInsertPre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Insert, after the insert operation, before setting back row identifiers (ID and RowVersion) and Commit().
        /// </summary>
        partial void OnInsertPost(DataPortalHookArgs args);

        #endregion

    }
}