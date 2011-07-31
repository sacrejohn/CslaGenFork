<% %>

        #region Factory Methods
<%
if (UseBoth() &&
    (CurrentUnit.GenerationParams.GenerateSynchronous || CurrentUnit.GenerationParams.SilverlightUsingServices))
{
    %>

#if !SILVERLIGHT
<%
}
if (CurrentUnit.GenerationParams.GenerateSynchronous)
{
    if (Info.IsCreator)
    {
        %>
<!-- #include file="NewObjectUnitOfWork.asp" -->
<%
    }
    if (Info.IsGetter)
    {
        %>
<!-- #include file="GetObject.asp" -->
<%
    }
    if (Info.IsDeleter)
    {
        %>
<!-- #include file="DeleteObject.asp" -->
<%
    }
}
if (CurrentUnit.GenerationParams.GenerateAsynchronous && !CurrentUnit.GenerationParams.GenerateSilverlight4)
{
    if (Info.IsCreator)
    {
        %>
<!-- #include file="NewObjectUnitOfWorkAsync.asp" -->
<%
    }
    if (Info.IsGetter)
    {
        %>
<!-- #include file="GetObjectAsync.asp" -->
<%
    }
    if (Info.IsDeleter)
    {
        %>
<!-- #include file="DeleteObjectAsync.asp" -->
<%
    }
}
if (UseBoth() && (!CurrentUnit.GenerationParams.GenerateAsynchronous || CurrentUnit.GenerationParams.SilverlightUsingServices))
{
    %>

#else
<%
}
if (CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    if (Info.IsCreator)
    {
        %>
<!-- #include file="NewObjectUnitOfWorkSilverlight.asp" -->
<%
    }
    if (Info.IsGetter)
    {
        %>
<!-- #include file="GetObjectSilverlight.asp" -->
<%
    }
    if (Info.IsDeleter)
    {
        %>
<!-- #include file="DeleteObjectSilverlight.asp" -->
<%
    }
}
else if (!CurrentUnit.GenerationParams.GenerateAsynchronous)
{
    if (Info.IsCreator)
    {
        %>
<!-- #include file="NewObjectUnitOfWorkAsync.asp" -->
<%
    }
    if (Info.IsGetter)
    {
        %>
<!-- #include file="GetObjectAsync.asp" -->
<%
    }
    if (Info.IsDeleter)
    {
        %>
<!-- #include file="DeleteObjectAsync.asp" -->
<%
    }
}
if (UseBoth() &&
    (CurrentUnit.GenerationParams.GenerateSynchronous || CurrentUnit.GenerationParams.SilverlightUsingServices))
{
    %>

#endif
<%
}
if (CurrentUnit.GenerationParams.GenerateAsynchronous && CurrentUnit.GenerationParams.GenerateSilverlight4)
{
    if (Info.IsCreator)
    {
        %>
<!-- #include file="NewObjectUnitOfWorkAsync.asp" -->
<%
    }
    if (Info.IsGetter)
    {
        %>
<!-- #include file="GetObjectAsync.asp" -->
<%
    }
    if (Info.IsDeleter)
    {
        %>
<!-- #include file="DeleteObjectAsync.asp" -->
<%
    }
}
%>

        #endregion