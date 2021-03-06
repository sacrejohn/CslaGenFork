using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoad.Business.ERLevel
{

    /// <summary>
    /// C02_Continent (editable root object).<br/>
    /// This is a generated base class of <see cref="C02_Continent"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="C03_SubContinentObjects"/> of type <see cref="C03_SubContinentColl"/> (1:M relation to <see cref="C04_SubContinent"/>)
    /// </remarks>
    [Serializable]
    public partial class C02_Continent : BusinessBase<C02_Continent>
    {

        #region Static Fields

        private static int _lastID;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Continent_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> Continent_IDProperty = RegisterProperty<int>(p => p.Continent_ID, "Continents ID");
        /// <summary>
        /// Gets the Continents ID.
        /// </summary>
        /// <value>The Continents ID.</value>
        public int Continent_ID
        {
            get { return GetProperty(Continent_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Continent_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Continent_NameProperty = RegisterProperty<string>(p => p.Continent_Name, "Continents Name");
        /// <summary>
        /// Gets or sets the Continents Name.
        /// </summary>
        /// <value>The Continents Name.</value>
        public string Continent_Name
        {
            get { return GetProperty(Continent_NameProperty); }
            set { SetProperty(Continent_NameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="C03_Continent_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<C03_Continent_Child> C03_Continent_SingleObjectProperty = RegisterProperty<C03_Continent_Child>(p => p.C03_Continent_SingleObject, "C03 Continent Single Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the C03 Continent Single Object ("self load" child property).
        /// </summary>
        /// <value>The C03 Continent Single Object.</value>
        public C03_Continent_Child C03_Continent_SingleObject
        {
            get { return GetProperty(C03_Continent_SingleObjectProperty); }
            private set { LoadProperty(C03_Continent_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="C03_Continent_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<C03_Continent_ReChild> C03_Continent_ASingleObjectProperty = RegisterProperty<C03_Continent_ReChild>(p => p.C03_Continent_ASingleObject, "C03 Continent ASingle Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the C03 Continent ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The C03 Continent ASingle Object.</value>
        public C03_Continent_ReChild C03_Continent_ASingleObject
        {
            get { return GetProperty(C03_Continent_ASingleObjectProperty); }
            private set { LoadProperty(C03_Continent_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="C03_SubContinentObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<C03_SubContinentColl> C03_SubContinentObjectsProperty = RegisterProperty<C03_SubContinentColl>(p => p.C03_SubContinentObjects, "C03 SubContinent Objects", RelationshipTypes.Child);
        /// <summary>
        /// Gets the C03 Sub Continent Objects ("self load" child property).
        /// </summary>
        /// <value>The C03 Sub Continent Objects.</value>
        public C03_SubContinentColl C03_SubContinentObjects
        {
            get { return GetProperty(C03_SubContinentObjectsProperty); }
            private set { LoadProperty(C03_SubContinentObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="C02_Continent"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="C02_Continent"/> object.</returns>
        public static C02_Continent NewC02_Continent()
        {
            return DataPortal.Create<C02_Continent>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="C02_Continent"/> object, based on given parameters.
        /// </summary>
        /// <param name="continent_ID">The Continent_ID parameter of the C02_Continent to fetch.</param>
        /// <returns>A reference to the fetched <see cref="C02_Continent"/> object.</returns>
        public static C02_Continent GetC02_Continent(int continent_ID)
        {
            return DataPortal.Fetch<C02_Continent>(continent_ID);
        }

        /// <summary>
        /// Factory method. Deletes a <see cref="C02_Continent"/> object, based on given parameters.
        /// </summary>
        /// <param name="continent_ID">The Continent_ID of the C02_Continent to delete.</param>
        public static void DeleteC02_Continent(int continent_ID)
        {
            DataPortal.Delete<C02_Continent>(continent_ID);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="C02_Continent"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public C02_Continent()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="C02_Continent"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void DataPortal_Create()
        {
            LoadProperty(Continent_IDProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            LoadProperty(C03_Continent_SingleObjectProperty, DataPortal.CreateChild<C03_Continent_Child>());
            LoadProperty(C03_Continent_ASingleObjectProperty, DataPortal.CreateChild<C03_Continent_ReChild>());
            LoadProperty(C03_SubContinentObjectsProperty, DataPortal.CreateChild<C03_SubContinentColl>());
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.DataPortal_Create();
        }

        /// <summary>
        /// Loads a <see cref="C02_Continent"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="continent_ID">The Continent ID.</param>
        protected void DataPortal_Fetch(int continent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetC02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", continent_ID).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, continent_ID);
                    OnFetchPre(args);
                    Fetch(cmd);
                    OnFetchPost(args);
                }
            }
            FetchChildren();
            // check all object rules and property rules
            BusinessRules.CheckRules();
        }

        private void Fetch(SqlCommand cmd)
        {
            using (var dr = new SafeDataReader(cmd.ExecuteReader()))
            {
                if (dr.Read())
                {
                    Fetch(dr);
                }
            }
        }

        /// <summary>
        /// Loads a <see cref="C02_Continent"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Continent_IDProperty, dr.GetInt32("Continent_ID"));
            LoadProperty(Continent_NameProperty, dr.GetString("Continent_Name"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child objects.
        /// </summary>
        private void FetchChildren()
        {
            LoadProperty(C03_Continent_SingleObjectProperty, C03_Continent_Child.GetC03_Continent_Child(Continent_ID));
            LoadProperty(C03_Continent_ASingleObjectProperty, C03_Continent_ReChild.GetC03_Continent_ReChild(Continent_ID));
            LoadProperty(C03_SubContinentObjectsProperty, C03_SubContinentColl.GetC03_SubContinentColl(Continent_ID));
        }

        /// <summary>
        /// Inserts a new <see cref="C02_Continent"/> object in the database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddC02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", ReadProperty(Continent_IDProperty)).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Continent_Name", ReadProperty(Continent_NameProperty)).DbType = DbType.String;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                    LoadProperty(Continent_IDProperty, (int) cmd.Parameters["@Continent_ID"].Value);
                }
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="C02_Continent"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateC02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", ReadProperty(Continent_IDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Name", ReadProperty(Continent_NameProperty)).DbType = DbType.String;
                    var args = new DataPortalHookArgs(cmd);
                    OnUpdatePre(args);
                    cmd.ExecuteNonQuery();
                    OnUpdatePost(args);
                }
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="C02_Continent"/> object.
        /// </summary>
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(Continent_ID);
        }

        /// <summary>
        /// Deletes the <see cref="C02_Continent"/> object from database.
        /// </summary>
        /// <param name="continent_ID">The delete criteria.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected void DataPortal_Delete(int continent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
                using (var cmd = new SqlCommand("DeleteC02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", continent_ID).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, continent_ID);
                    OnDeletePre(args);
                    cmd.ExecuteNonQuery();
                    OnDeletePost(args);
                }
            }
            // removes all previous references to children
            LoadProperty(C03_Continent_SingleObjectProperty, DataPortal.CreateChild<C03_Continent_Child>());
            LoadProperty(C03_Continent_ASingleObjectProperty, DataPortal.CreateChild<C03_Continent_ReChild>());
            LoadProperty(C03_SubContinentObjectsProperty, DataPortal.CreateChild<C03_SubContinentColl>());
        }

        #endregion

        #region DataPortal Hooks

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
