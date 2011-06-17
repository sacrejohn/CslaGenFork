<%
if (CurrentUnit.GenerationParams.GenerateAsynchronous || CurrentUnit.GenerationParams.GenerateSilverlight4)
{
    if (!Info.UseCustomLoading)
    {
        foreach (Criteria c in GetCriteriaObjects(Info))
        {
            if (c.GetOptions.Factory)
            {
                for (int i = 0; i < c.Properties.Count; i++)
                {
                    if (string.IsNullOrEmpty(c.Properties[i].ParameterValue))
                    {
                        Errors.Append("Property: " + c.Properties[i].Name + " on criteria: " + c.Name + " must have a ParameterValue. Ignored." + Environment.NewLine);
                        return;
                    }
                    else
                    {
                        c.Properties[i].ReadOnly = true;
                    }
                }
                %>

        /// <summary>
        /// Factory method. Asynchronously loads an existing <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        <%
                string critAsync = string.Empty;
                for (int i = 0; i < c.Properties.Count; i++)
                {
                    if (string.IsNullOrEmpty(c.Properties[i].ParameterValue))
                    {
                        Errors.Append("Property: " + c.Properties[i].Name + " on criteria: " + c.Name + " must have a ParameterValue. Ignored." + Environment.NewLine);
                        return;
                    }
                    else
                    {
                        c.Properties[i].ReadOnly = true;
                    }
                }
                if (c.Properties.Count > 1)
                    critAsync = "new " + c.Name + "()";
                else if (c.Properties.Count > 0)
                    critAsync = SendSingleCriteria(c, c.Properties[0].ParameterValue);
                critAsync += (critAsync.Length > 0 ? ", " : "") + "(o, e) =>";
                %>
        /// <param name="callback">The completion callback method.</param>
        public static void Get<%= Info.ObjectName %><%= c.GetOptions.FactorySuffix %>(<%= "EventHandler<DataPortalResult<" + Info.ObjectName + ">> callback" %>)
        {
            <%
                if (CurrentUnit.GenerationParams.GenerateAuthorization != Authorization.None &&
                    CurrentUnit.GenerationParams.GenerateAuthorization != Authorization.PropertyLevel &&
                    Info.GetRoles.Trim() != String.Empty)
                {
                    %>if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to load a <%= Info.ObjectName %>.");

            <%
                }
                if (Info.SimpleCacheOptions != SimpleCacheResults.None)
                {
                    %>if (_list == null)
                DataPortal.BeginFetch<<%= Info.ObjectName %>>(<%= critAsync %>
                    {
                        _list = e.Object;
                        callback(o, e);
                    });
            else
                callback(null, new DataPortalResult<<%= Info.ObjectName %>>(_list, null, null));<%
                }
                else
                {
                    %>DataPortal.BeginFetch<<%= Info.ObjectName %>>(<%= critAsync %>
                {
                    _list = e.Object;
                    callback(o, e);
                });<%
                }
                %>
        }
<%
            }
        }
    }
}
%>
