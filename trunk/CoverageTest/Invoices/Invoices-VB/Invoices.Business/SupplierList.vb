Imports System
Imports Csla

Namespace Invoices.Business

    Public Partial Class SupplierList

        #Region " OnDeserialized actions "

        ''' <summary>
        ''' This method is called on a newly deserialized object
        ''' after deserialization is complete.
        ''' </summary>
        Protected Overrides Sub OnDeserialized()
            MyBase.OnDeserialized()
            SupplierEditSaved.Register(Me)
            ' add your custom OnDeserialized actions here.
        End Sub

        #End Region

        #Region " Inline queries "

        ' Private Sub GetQueryGetSupplierList()
        '     getSupplierListInlineQuery = ""
        ' End Sub

        ' Private Sub GetQueryGetSupplierListByName(name As String)
        '     getSupplierListByNameInlineQuery = ""
        ' End Sub

        #End Region

        #Region " Implementation of DataPortal Hooks "

        ' Private Sub OnFetchPre(args As DataPortalHookArgs)
        '     Throw New NotImplementedException()
        ' End Sub

        ' Private Sub OnFetchPost(args As DataPortalHookArgs)
        '     Throw New NotImplementedException()
        ' End Sub

        #End Region

    End Class

End Namespace
