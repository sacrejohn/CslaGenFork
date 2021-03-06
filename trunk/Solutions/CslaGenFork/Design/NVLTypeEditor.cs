﻿using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CslaGenerator.Metadata;
using CslaGenerator.Util;

namespace CslaGenerator.Design
{
    public class NVLTypeEditor : UITypeEditor, IDisposable
    {
        private IWindowsFormsEditorService _editorService;
        private ListBox _lstProperties;

        public NVLTypeEditor()
        {
            _lstProperties = new ListBox();
            _lstProperties.DoubleClick += LstPropertiesDoubleClick;
            _lstProperties.SelectionMode = SelectionMode.One;
            _lstProperties.Width = 300;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            _editorService = (IWindowsFormsEditorService) provider.GetService(typeof(IWindowsFormsEditorService));
            if (_editorService != null)
            {
                if (context.Instance != null)
                {
                    // CR modifying to accomodate PropertyBag
                    Type instanceType = null;
                    object objinfo = null;
                    ContextHelper.GetConvertValuePropertyContextInstanceObject(context, ref objinfo, ref instanceType);
                    var obj = (ConvertValueProperty) objinfo;

                    _lstProperties.Items.Clear();
                    _lstProperties.Items.Add("(None)");
                    foreach (var o in GeneratorController.Current.CurrentUnit.CslaObjects)
                    {
                        if (o.IsNameValueList())
                        {
                            var prefix = string.Empty;
                            var objectNamespace = GeneratorController.Current.CurrentCslaObject.ObjectNamespace;
                            if (objectNamespace != o.ObjectNamespace)
                            {
                                var idx = objectNamespace.IndexOf(o.ObjectNamespace);
                                if (idx == 0)
                                {
                                    prefix = objectNamespace.Substring(o.ObjectNamespace.Length + 1) + ".";
                                }
                                else if (idx == -1)
                                {
                                    idx = o.ObjectNamespace.IndexOf(objectNamespace);
                                    if (idx == 0)
                                        prefix = o.ObjectNamespace.Substring(objectNamespace.Length + 1) + ".";
                                }
                                else
                                {
                                    prefix = o.ObjectNamespace + ".";
                                }
                            }
                            _lstProperties.Items.Add(prefix + o.ObjectName + ".Get" + o.ObjectName);
                        }
                    }
                    _lstProperties.Sorted = true;

                    if (_lstProperties.Items.Contains(obj.NVLConverter))
                        _lstProperties.SelectedItem = obj.NVLConverter;
                    else
                        _lstProperties.SelectedItem = "(None)";

                    _editorService.DropDownControl(_lstProperties);
                    if (_lstProperties.SelectedIndex < 0 || _lstProperties.SelectedItem.ToString() == "(None)")
                        return string.Empty;

                    return _lstProperties.SelectedItem.ToString();
                }
            }

            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        void LstPropertiesDoubleClick(object sender, EventArgs e)
        {
            _editorService.CloseDropDown();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose managed resources
                if (_lstProperties != null)
                {
                    _lstProperties.Dispose();
                    _lstProperties = null;
                }
            }
            // free native resources
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}