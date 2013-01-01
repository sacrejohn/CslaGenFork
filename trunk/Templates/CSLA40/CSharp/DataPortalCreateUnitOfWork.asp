<%
Criteria crit = GetCriteriaObjects(Info)[0];
if (crit.CreateOptions.DataPortal)
{
    string createUowParam = string.Empty;
    string createUowCrit = string.Empty;
    string createUowCritParam = string.Empty;
    if (crit.Properties.Count > 1)
    {
        createUowParam = "crit";
        createUowCrit = crit.Name + " crit";
    }
    else if (crit.Properties.Count > 0)
    {
        createUowParam = HookSingleCriteria(crit, "crit");
        createUowCrit = ReceiveSingleCriteria(crit, "crit");
    }
        %>

        /// <summary>
        /// Loads a new <see cref="<%= Info.ObjectName %>"/> unit of objects<%= crit.Properties.Count > 0 ? ", based on given criteria" : "" %>.
        /// </summary>
        <%
    if (crit.Properties.Count > 0)
    {
        %>/// <param name="<%= createUowParam %>">The create criteria.</param>
        <%
    }
        %>/// <remarks>
        /// ReadOnlyBase&lt;T&gt; doesn't allow the use of DataPortal_Create and thus DataPortal_Fetch is used.
        /// </remarks>
        protected void DataPortal_Fetch(<%= createUowCrit %>)
        {
            <%
    foreach (UnitOfWorkProperty uowProp in Info.UnitOfWorkProperties)
    {
        bool isGetter = ForceIsGetter(Info, uowProp);
        if (CheckTargetPropertiesFound(Info, uowProp, crit))
        {
            createUowCritParam = string.Empty;
            if (crit.Properties.Count > 0)
            {
                bool firstUoW = true;
                foreach (Property prop in crit.Properties)
                {
                    if (IsTargetProperty(Info, uowProp, crit, prop))
                    {
                        if (firstUoW) firstUoW = false; else createUowCritParam += ", ";
                        createUowCritParam = HookSingleCriteria(crit, "crit");
                    }
                }
            }
            %>
            <%= GetFieldLoaderStatement(uowProp, uowProp.TypeName + (isGetter ? ".Get" : ".New") + uowProp.TypeName +"(" + createUowCritParam + ")") %>;
            <%
        }
        else
        {
                %>
            <%= GetFieldLoaderStatement(uowProp, uowProp.TypeName + (isGetter ? ".Get" : ".New") + uowProp.TypeName +"()") %>;
            <%
        }
    }
    %>
        }
<%
}
%>