//  This file was generated by CSLA Object Generator - CslaGenFork v4.5
//
// Filename:    DocCirc
// ObjectType:  DocCirc
// CSLAType:    EditableChild

using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using DocStore.Business.Util;
using Csla.Rules;
using Csla.Rules.CommonRules;
using DocStore.Business.Admin;
using DocStore.Business.Security;
using UsingLibrary;

namespace DocStore.Business.Circulations
{

    /// <summary>
    /// Circulation of this document (editable child object).<br/>
    /// This is a generated base class of <see cref="DocCirc"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="DocCircColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class DocCirc : MyBusinessBase<DocCirc>
    {

        #region Static Fields

        private static int _lastID;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="CircID"/> property.
        /// </summary>
        [NotUndoable]
        public static readonly PropertyInfo<int> CircIDProperty = RegisterProperty<int>(p => p.CircID, "Circ ID");
        /// <summary>
        /// Gets the Circ ID.
        /// </summary>
        /// <value>The Circ ID.</value>
        public int CircID
        {
            get { return GetProperty(CircIDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="NeedsReply"/> property.
        /// </summary>
        public static readonly PropertyInfo<bool> NeedsReplyProperty = RegisterProperty<bool>(p => p.NeedsReply, "Needs Reply");
        /// <summary>
        /// Gets or sets the Needs Reply.
        /// </summary>
        /// <value><c>true</c> if Needs Reply; otherwise, <c>false</c>.</value>
        public bool NeedsReply
        {
            get { return GetProperty(NeedsReplyProperty); }
            set { SetProperty(NeedsReplyProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="NeedsReplyDecision"/> property.
        /// </summary>
        public static readonly PropertyInfo<bool> NeedsReplyDecisionProperty = RegisterProperty<bool>(p => p.NeedsReplyDecision, "Needs Reply Decision");
        /// <summary>
        /// Gets or sets the Needs Reply Decision.
        /// </summary>
        /// <value><c>true</c> if Needs Reply Decision; otherwise, <c>false</c>.</value>
        public bool NeedsReplyDecision
        {
            get { return GetProperty(NeedsReplyDecisionProperty); }
            set { SetProperty(NeedsReplyDecisionProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="CircTypeTag"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> CircTypeTagProperty = RegisterProperty<string>(p => p.CircTypeTag, "Circ Type Tag");
        /// <summary>
        /// Gets or sets the Circ Type Tag.
        /// </summary>
        /// <value>The Circ Type Tag.</value>
        public string CircTypeTag
        {
            get { return GetProperty(CircTypeTagProperty); }
            set { SetProperty(CircTypeTagProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Notes"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> NotesProperty = RegisterProperty<string>(p => p.Notes, "Notes");
        /// <summary>
        /// Gets or sets the Notes.
        /// </summary>
        /// <value>The Notes.</value>
        public string Notes
        {
            get { return GetProperty(NotesProperty); }
            set { SetProperty(NotesProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="TagNotesCert"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> TagNotesCertProperty = RegisterProperty<string>(p => p.TagNotesCert, "Tag Notes Cert");
        /// <summary>
        /// Gets or sets the Tag Notes Cert.
        /// </summary>
        /// <value>The Tag Notes Cert.</value>
        public string TagNotesCert
        {
            get { return GetProperty(TagNotesCertProperty); }
            set { SetProperty(TagNotesCertProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="SenderEntityID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int?> SenderEntityIDProperty = RegisterProperty<int?>(p => p.SenderEntityID, "Sender Entity ID");
        /// <summary>
        /// Gets or sets the Sender Entity ID.
        /// </summary>
        /// <value>The Sender Entity ID.</value>
        public int? SenderEntityID
        {
            get { return GetProperty(SenderEntityIDProperty); }
            set { SetProperty(SenderEntityIDProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="SentDateTime"/> property.
        /// </summary>
        public static readonly PropertyInfo<SmartDate> SentDateTimeProperty = RegisterProperty<SmartDate>(p => p.SentDateTime, "Sent Date Time");
        /// <summary>
        /// Gets or sets the Sent Date Time.
        /// </summary>
        /// <value>The Sent Date Time.</value>
        public SmartDate SentDateTime
        {
            get { return GetProperty(SentDateTimeProperty); }
            set { SetProperty(SentDateTimeProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DaysToReply"/> property.
        /// </summary>
        public static readonly PropertyInfo<short> DaysToReplyProperty = RegisterProperty<short>(p => p.DaysToReply, "Days To Reply");
        /// <summary>
        /// Gets or sets the Days To Reply.
        /// </summary>
        /// <value>The Days To Reply.</value>
        public short DaysToReply
        {
            get { return GetProperty(DaysToReplyProperty); }
            set { SetProperty(DaysToReplyProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DaysToLive"/> property.
        /// </summary>
        public static readonly PropertyInfo<short> DaysToLiveProperty = RegisterProperty<short>(p => p.DaysToLive, "Days To Live");
        /// <summary>
        /// Gets or sets the Days To Live.
        /// </summary>
        /// <value>The Days To Live.</value>
        public short DaysToLive
        {
            get { return GetProperty(DaysToLiveProperty); }
            set { SetProperty(DaysToLiveProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="CreateDate"/> property.
        /// </summary>
        public static readonly PropertyInfo<SmartDate> CreateDateProperty = RegisterProperty<SmartDate>(p => p.CreateDate, "Create Date");
        /// <summary>
        /// Gets the Create Date.
        /// </summary>
        /// <value>The Create Date.</value>
        public SmartDate CreateDate
        {
            get { return GetProperty(CreateDateProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="CreateUserID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> CreateUserIDProperty = RegisterProperty<int>(p => p.CreateUserID, "Create User ID");
        /// <summary>
        /// Gets the Create User ID.
        /// </summary>
        /// <value>The Create User ID.</value>
        public int CreateUserID
        {
            get { return GetProperty(CreateUserIDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="ChangeDate"/> property.
        /// </summary>
        public static readonly PropertyInfo<SmartDate> ChangeDateProperty = RegisterProperty<SmartDate>(p => p.ChangeDate, "Change Date");
        /// <summary>
        /// Gets the Change Date.
        /// </summary>
        /// <value>The Change Date.</value>
        public SmartDate ChangeDate
        {
            get { return GetProperty(ChangeDateProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="ChangeUserID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> ChangeUserIDProperty = RegisterProperty<int>(p => p.ChangeUserID, "Change User ID");
        /// <summary>
        /// Gets the Change User ID.
        /// </summary>
        /// <value>The Change User ID.</value>
        public int ChangeUserID
        {
            get { return GetProperty(ChangeUserIDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="RowVersion"/> property.
        /// </summary>
        [NotUndoable]
        public static readonly PropertyInfo<byte[]> RowVersionProperty = RegisterProperty<byte[]>(p => p.RowVersion, "Row Version");
        /// <summary>
        /// Gets the Row Version.
        /// </summary>
        /// <value>The Row Version.</value>
        public byte[] RowVersion
        {
            get { return GetProperty(RowVersionProperty); }
        }

        /// <summary>
        /// Gets the Create User Name.
        /// </summary>
        /// <value>The Create User Name.</value>
        public string CreateUserName
        {
            get
            {
                var result = string.Empty;
                if (UserNVL.GetUserNVL().ContainsKey(CreateUserID))
                    result = UserNVL.GetUserNVL().GetItemByKey(CreateUserID).Value;
                return result;
            }
        }

        /// <summary>
        /// Gets the Change User Name.
        /// </summary>
        /// <value>The Change User Name.</value>
        public string ChangeUserName
        {
            get
            {
                var result = string.Empty;
                if (UserNVL.GetUserNVL().ContainsKey(ChangeUserID))
                    result = UserNVL.GetUserNVL().GetItemByKey(ChangeUserID).Value;
                return result;
            }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="DocCirc"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="DocCirc"/> object.</returns>
        internal static DocCirc NewDocCirc()
        {
            return DataPortal.CreateChild<DocCirc>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="DocCirc"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="DocCirc"/> object.</returns>
        internal static DocCirc GetDocCirc(SafeDataReader dr)
        {
            DocCirc obj = new DocCirc();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            obj.MarkOld();
            // check all object rules and property rules
            obj.BusinessRules.CheckRules();
            return obj;
        }

        /// <summary>
        /// Factory method. Asynchronously creates a new <see cref="DocCirc"/> object.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        internal static void NewDocCirc(EventHandler<DataPortalResult<DocCirc>> callback)
        {
            DataPortal.BeginCreate<DocCirc>(callback);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DocCirc"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public DocCirc()
        {
            // Use factory methods and do not use direct creation.

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Object Authorization

        /// <summary>
        /// Adds the object authorization rules.
        /// </summary>
        protected static void AddObjectAuthorizationRules()
        {
            BusinessRules.AddRule(typeof (DocCirc), new IsInRole(AuthorizationActions.GetObject, "User"));

            AddObjectAuthorizationRulesExtend();
        }

        /// <summary>
        /// Allows the set up of custom object authorization rules.
        /// </summary>
        static partial void AddObjectAuthorizationRulesExtend();

        /// <summary>
        /// Checks if the current user can create a new DocCirc object.
        /// </summary>
        /// <returns><c>true</c> if the user can create a new object; otherwise, <c>false</c>.</returns>
        public static bool CanAddObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.CreateObject, typeof(DocCirc));
        }

        /// <summary>
        /// Checks if the current user can retrieve DocCirc's properties.
        /// </summary>
        /// <returns><c>true</c> if the user can read the object; otherwise, <c>false</c>.</returns>
        public static bool CanGetObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.GetObject, typeof(DocCirc));
        }

        /// <summary>
        /// Checks if the current user can change DocCirc's properties.
        /// </summary>
        /// <returns><c>true</c> if the user can update the object; otherwise, <c>false</c>.</returns>
        public static bool CanEditObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.EditObject, typeof(DocCirc));
        }

        /// <summary>
        /// Checks if the current user can delete a DocCirc object.
        /// </summary>
        /// <returns><c>true</c> if the user can delete the object; otherwise, <c>false</c>.</returns>
        public static bool CanDeleteObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.DeleteObject, typeof(DocCirc));
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="DocCirc"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            LoadProperty(CircIDProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            LoadProperty(CreateDateProperty, new SmartDate(DateTime.Now));
            LoadProperty(CreateUserIDProperty, UserInformation.UserId);
            LoadProperty(ChangeDateProperty, ReadProperty(CreateDateProperty));
            LoadProperty(ChangeUserIDProperty, ReadProperty(CreateUserIDProperty));
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="DocCirc"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(CircIDProperty, dr.GetInt32("CircID"));
            LoadProperty(NeedsReplyProperty, dr.GetBoolean("NeedsReply"));
            LoadProperty(NeedsReplyDecisionProperty, dr.GetBoolean("NeedsReplyDecision"));
            LoadProperty(CircTypeTagProperty, dr.GetString("CircTypeTag"));
            LoadProperty(NotesProperty, dr.GetString("Notes"));
            LoadProperty(TagNotesCertProperty, dr.GetString("TagNotesCert"));
            LoadProperty(SenderEntityIDProperty, (int?)dr.GetValue("SenderEntityID"));
            LoadProperty(SentDateTimeProperty, dr.GetSmartDate("SentDateTime", true));
            LoadProperty(DaysToReplyProperty, dr.GetInt16("DaysToReply"));
            LoadProperty(DaysToLiveProperty, dr.GetInt16("DaysToLive"));
            LoadProperty(CreateDateProperty, dr.GetSmartDate("CreateDate", true));
            LoadProperty(CreateUserIDProperty, dr.GetInt32("CreateUserID"));
            LoadProperty(ChangeDateProperty, dr.GetSmartDate("ChangeDate", true));
            LoadProperty(ChangeUserIDProperty, dr.GetInt32("ChangeUserID"));
            LoadProperty(RowVersionProperty, dr.GetValue("RowVersion") as byte[]);
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Inserts a new <see cref="DocCirc"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        private void Child_Insert(Doc parent)
        {
            SimpleAuditTrail();
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.DocStoreConnection, false))
            {
                using (var cmd = new SqlCommand("AddDocCirc", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DocID", parent.DocID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@CircID", ReadProperty(CircIDProperty)).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@NeedsReply", ReadProperty(NeedsReplyProperty)).DbType = DbType.Boolean;
                    cmd.Parameters.AddWithValue("@NeedsReplyDecision", ReadProperty(NeedsReplyDecisionProperty)).DbType = DbType.Boolean;
                    cmd.Parameters.AddWithValue("@CircTypeTag", ReadProperty(CircTypeTagProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@Notes", ReadProperty(NotesProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@TagNotesCert", ReadProperty(TagNotesCertProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@SenderEntityID", ReadProperty(SenderEntityIDProperty) == null ? (object)DBNull.Value : ReadProperty(SenderEntityIDProperty).Value).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SentDateTime", ReadProperty(SentDateTimeProperty).DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@DaysToReply", ReadProperty(DaysToReplyProperty)).DbType = DbType.Int16;
                    cmd.Parameters.AddWithValue("@DaysToLive", ReadProperty(DaysToLiveProperty)).DbType = DbType.Int16;
                    cmd.Parameters.AddWithValue("@CreateDate", ReadProperty(CreateDateProperty).DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@CreateUserID", ReadProperty(CreateUserIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@ChangeDate", ReadProperty(ChangeDateProperty).DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@ChangeUserID", ReadProperty(ChangeUserIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                    LoadProperty(CircIDProperty, (int) cmd.Parameters["@CircID"].Value);
                    LoadProperty(RowVersionProperty, (byte[]) cmd.Parameters["@NewRowVersion"].Value);
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="DocCirc"/> object.
        /// </summary>
        private void Child_Update()
        {
            if (!IsDirty)
                return;

            SimpleAuditTrail();
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.DocStoreConnection, false))
            {
                using (var cmd = new SqlCommand("UpdateDocCirc", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CircID", ReadProperty(CircIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@NeedsReply", ReadProperty(NeedsReplyProperty)).DbType = DbType.Boolean;
                    cmd.Parameters.AddWithValue("@NeedsReplyDecision", ReadProperty(NeedsReplyDecisionProperty)).DbType = DbType.Boolean;
                    cmd.Parameters.AddWithValue("@CircTypeTag", ReadProperty(CircTypeTagProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@Notes", ReadProperty(NotesProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@TagNotesCert", ReadProperty(TagNotesCertProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@SenderEntityID", ReadProperty(SenderEntityIDProperty) == null ? (object)DBNull.Value : ReadProperty(SenderEntityIDProperty).Value).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SentDateTime", ReadProperty(SentDateTimeProperty).DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@DaysToReply", ReadProperty(DaysToReplyProperty)).DbType = DbType.Int16;
                    cmd.Parameters.AddWithValue("@DaysToLive", ReadProperty(DaysToLiveProperty)).DbType = DbType.Int16;
                    cmd.Parameters.AddWithValue("@ChangeDate", ReadProperty(ChangeDateProperty).DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@ChangeUserID", ReadProperty(ChangeUserIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@RowVersion", ReadProperty(RowVersionProperty)).DbType = DbType.Binary;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    var args = new DataPortalHookArgs(cmd);
                    OnUpdatePre(args);
                    cmd.ExecuteNonQuery();
                    OnUpdatePost(args);
                    LoadProperty(RowVersionProperty, (byte[]) cmd.Parameters["@NewRowVersion"].Value);
                }
            }
        }

        private void SimpleAuditTrail()
        {
            LoadProperty(ChangeDateProperty, DateTime.Now);
            LoadProperty(ChangeUserIDProperty, UserInformation.UserId);
            OnPropertyChanged("ChangeUserName");
            if (IsNew)
            {
                LoadProperty(CreateDateProperty, ReadProperty(ChangeDateProperty));
                LoadProperty(CreateUserIDProperty, ReadProperty(ChangeUserIDProperty));
                OnPropertyChanged("CreateUserName");
            }
        }

        /// <summary>
        /// Self deletes the <see cref="DocCirc"/> object from database.
        /// </summary>
        private void Child_DeleteSelf()
        {
            // audit the object, just in case soft delete is used on this object
            SimpleAuditTrail();
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.DocStoreConnection, false))
            {
                using (var cmd = new SqlCommand("DeleteDocCirc", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CircID", ReadProperty(CircIDProperty)).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd);
                    OnDeletePre(args);
                    cmd.ExecuteNonQuery();
                    OnDeletePost(args);
                }
            }
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