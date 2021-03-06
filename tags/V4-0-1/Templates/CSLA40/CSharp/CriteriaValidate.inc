<%
bool isCollection2 =
    Info.ObjectType == CslaObjectType.EditableRootCollection ||
    Info.ObjectType == CslaObjectType.DynamicEditableRootCollection ||
    Info.ObjectType == CslaObjectType.EditableChildCollection ||
    //Info.ObjectType == CslaObjectType.ChildReadOnlyCollection ||
    Info.ObjectType == CslaObjectType.ReadOnlyCollection;

bool isSelfLoadCollection =
    (Info.ObjectType == CslaObjectType.EditableChildCollection ||
    //Info.ObjectType == CslaObjectType.ChildReadOnlyCollection ||
    Info.ObjectType == CslaObjectType.ReadOnlyCollection) &&
    GetSelfLoad(Info);

bool createOptionsFactory;
bool createOptionsDataPortal;
bool getOptionsFactory = false;
bool getOptionsDataPortal;
bool deleteOptionsFactory;
bool deleteOptionsDataPortal;

if (GetSelfLoad(Info))
{
    foreach (Criteria crit in Info.CriteriaObjects)
    {
        getOptionsFactory = getOptionsFactory | crit.GetOptions.Factory;
    }

    if (!getOptionsFactory)
    {
        Errors.Append("Object " + Info.ObjectName + " is missing get criteria; to \"SelfLoad\" an object, that object must have a criteria with GetOptions.Factory set." + Environment.NewLine);
        return;
    }
}
getOptionsFactory = false;

if (Info.ObjectType == CslaObjectType.EditableRoot || (Info.ObjectType == CslaObjectType.ReadOnlyObject && Info.ParentType == string.Empty))
{
    foreach (Criteria crit in Info.CriteriaObjects)
    {
        getOptionsFactory = getOptionsFactory | crit.GetOptions.Factory;
    }

    if (!getOptionsFactory)
    {
        Warnings.Append(Info.ObjectName + "; root objects must have a criteria with GetOptions.Factory set." + Environment.NewLine);
    }
}
else
{
    foreach (Criteria crit in Info.CriteriaObjects)
    {
        createOptionsFactory = crit.CreateOptions.Factory;
        createOptionsDataPortal = crit.CreateOptions.DataPortal;
        getOptionsFactory = crit.GetOptions.Factory;
        getOptionsDataPortal = crit.GetOptions.DataPortal;
        deleteOptionsFactory = crit.DeleteOptions.Factory;
        deleteOptionsDataPortal = crit.DeleteOptions.DataPortal;

        if (isCollection2)
        {
            // only get criteria
            if (createOptionsFactory || createOptionsDataPortal)
            {
                Warnings.Append(Info.ObjectName + "." + crit.Name + ".CreateOptions: all options should be \"False\" or empty." + Environment.NewLine);
            }
            if (deleteOptionsFactory || deleteOptionsDataPortal)
            {
                Warnings.Append(Info.ObjectName + "." + crit.Name + ".DeleteOptions: all options should be \"False\" or empty." + Environment.NewLine);
            }

            // not even get?
            if (!isSelfLoadCollection && Info.ParentType != string.Empty)
            {
                if (getOptionsFactory || getOptionsDataPortal)
                {
                    Warnings.Append(Info.ObjectName + "." + crit.Name + ".GetOptions: all options should be \"False\" or empty." + Environment.NewLine);
                }
            }
        }
        else if (!(Info.ObjectType == CslaObjectType.EditableRoot || Info.ObjectType == CslaObjectType.EditableSwitchable ||
            (Info.ObjectType == CslaObjectType.ReadOnlyObject && Info.ParentType == string.Empty)))
        {
            if (getOptionsFactory || getOptionsDataPortal)
            {
                Warnings.Append(Info.ObjectName + "." + crit.Name + ".GetOptions: all options should be \"False\" or empty (neither a root object nor a SelfLoad object)." + Environment.NewLine);
            }
            if (deleteOptionsFactory || deleteOptionsDataPortal)
            {
                Warnings.Append(Info.ObjectName + "." + crit.Name + ".DeleteOptions:" +
                    (deleteOptionsFactory ? " \"Factory\"" : "") +
                    ((deleteOptionsFactory && deleteOptionsDataPortal) ? " and" : "") +
                    (deleteOptionsDataPortal ? " \"DataPortal\"" : "") +
                    " should be set to \"False\"." +
                    Environment.NewLine);
                if (!(createOptionsFactory || createOptionsDataPortal || getOptionsFactory || getOptionsDataPortal))
                {
                    Warnings.Append("Useless \"" + crit.Name + "\" class will be generated as no other \"Factory\" or \"DataPortal\" options are set." + Environment.NewLine);
                }
            }
        }
    }
}
%>