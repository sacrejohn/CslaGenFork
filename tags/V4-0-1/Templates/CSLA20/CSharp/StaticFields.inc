<%
foreach (ValueProperty prop in Info.ValueProperties) { %>
    <% if (prop.DefaultValue != String.Empty) { 
                    if (prop.DefaultValue.Trim().ToUpper() == "_LASTID" && 
                    prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK && 
                    (prop.PropertyType == TypeCodeEx.Int16 || 
                    prop.PropertyType == TypeCodeEx.Int32 || 
                    prop.PropertyType == TypeCodeEx.Int64)) {%>

        #region Static Fields

        private static <%=GetDataType(prop)%> <%=prop.DefaultValue.Trim()%>;

        #endregion
    <% } 
    } %>
<% } %>
