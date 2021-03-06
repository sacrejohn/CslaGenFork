'  This file was generated by CSLA Object Generator - CslaGenFork v4.5
'
' Filename:    DocStatusColl
' ObjectType:  DocStatusColl
' CSLAType:    EditableRootCollection

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports DocStore.Business.Util

Namespace DocStore.Business

    ''' <summary>
    ''' DocStatusColl (editable root list).<br/>
    ''' This is a generated base class of <see cref="DocStatusColl"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' The items of the collection are <see cref="DocStatus"/> objects.
    ''' </remarks>
    <Serializable>
    Public Partial Class DocStatusColl
#If WINFORMS Then
        Inherits BusinessBindingListBase(Of DocStatusColl, DocStatus)
#Else
        Inherits BusinessListBase(Of DocStatusColl, DocStatus)
#End If

        #Region " Collection Business Methods "

        ''' <summary>
        ''' Removes a <see cref="DocStatus"/> item from the collection.
        ''' </summary>
        ''' <param name="docStatusID">The DocStatusID of the item to be removed.</param>
        Public Overloads Sub Remove(docStatusID As Integer)
            For Each item As DocStatus In Me
                If item.DocStatusID = docStatusID Then
                    MyBase.Remove(item)
                    Exit For
                End If
            Next
        End Sub

        ''' <summary>
        ''' Determines whether a <see cref="DocStatus"/> item is in the collection.
        ''' </summary>
        ''' <param name="docStatusID">The DocStatusID of the item to search for.</param>
        ''' <returns><c>True</c> if the DocStatus is a collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function Contains(docStatusID As Integer) As Boolean
            For Each item As DocStatus In Me
                If item.DocStatusID = docStatusID Then
                    Return True
                End If
            Next
            Return False
        End Function

        ''' <summary>
        ''' Determines whether a <see cref="DocStatus"/> item is in the collection's DeletedList.
        ''' </summary>
        ''' <param name="docStatusID">The DocStatusID of the item to search for.</param>
        ''' <returns><c>True</c> if the DocStatus is a deleted collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function ContainsDeleted(docStatusID As Integer) As Boolean
            For Each item As DocStatus In DeletedList
                If item.DocStatusID = docStatusID Then
                    Return True
                End If
            Next
            Return False
        End Function

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Creates a new <see cref="DocStatusColl"/> collection.
        ''' </summary>
        ''' <returns>A reference to the created <see cref="DocStatusColl"/> collection.</returns>
        Public Shared Function NewDocStatusColl() As DocStatusColl
            Return DataPortal.Create(Of DocStatusColl)()
        End Function

        ''' <summary>
        ''' Factory method. Loads a <see cref="DocStatusColl"/> collection.
        ''' </summary>
        ''' <returns>A reference to the fetched <see cref="DocStatusColl"/> collection.</returns>
        Public Shared Function GetDocStatusColl() As DocStatusColl
            Return DataPortal.Fetch(Of DocStatusColl)()
        End Function

        ''' <summary>
        ''' Factory method. Asynchronously creates a new <see cref="DocStatusColl"/> collection.
        ''' </summary>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub NewDocStatusColl(callback As EventHandler(Of DataPortalResult(Of DocStatusColl)))
            DataPortal.BeginCreate(Of DocStatusColl)(callback)
        End Sub

        ''' <summary>
        ''' Factory method. Asynchronously loads a <see cref="DocStatusColl"/> collection.
        ''' </summary>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub GetDocStatusColl(ByVal callback As EventHandler(Of DataPortalResult(Of DocStatusColl)))
            DataPortal.BeginFetch(Of DocStatusColl)(callback)
        End Sub

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="DocStatusColl"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.

            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            AllowNew = True
            AllowEdit = True
            AllowRemove = True
            RaiseListChangedEvents = rlce
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads a <see cref="DocStatusColl"/> collection from the database.
        ''' </summary>
        Protected Overloads Sub DataPortal_Fetch()
            Using ctx = ConnectionManager(Of SqlConnection).GetManager(Database.DocStoreConnection, False)
                Using cmd = New SqlCommand("GetDocStatusColl", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    Dim args As New DataPortalHookArgs(cmd)
                    OnFetchPre(args)
                    LoadCollection(cmd)
                    OnFetchPost(args)
                End Using
            End Using
        End Sub

        Private Sub LoadCollection(cmd As SqlCommand)
            Using dr As New SafeDataReader(cmd.ExecuteReader())
                Fetch(dr)
            End Using
        End Sub

        ''' <summary>
        ''' Loads all <see cref="DocStatusColl"/> collection items from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            While dr.Read()
                Add(DocStatus.GetDocStatus(dr))
            End While
            RaiseListChangedEvents = rlce
        End Sub

        ''' <summary>
        ''' Updates in the database all changes made to the <see cref="DocStatusColl"/> object.
        ''' </summary>
        Protected Overrides Sub DataPortal_Update()
            Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.DocStoreConnection, False)
                Child_Update()
                ctx.Commit()
            End Using
        End Sub

        #End Region

        #Region " DataPortal Hooks "

        ''' <summary>
        ''' Occurs after setting query parameters and before the fetch operation.
        ''' </summary>
        Partial Private Sub OnFetchPre(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs after the fetch operation (object or collection is fully loaded and set up).
        ''' </summary>
        Partial Private Sub OnFetchPost(args As DataPortalHookArgs)
        End Sub

        #End Region

    End Class
End Namespace
