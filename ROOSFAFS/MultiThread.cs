using System;
using System.Linq;
using System.Windows.Forms;

namespace Searcher {
	internal class MultiThread {
		private delegate void PropertyDelegate( Control control, string property, object value);
	    private delegate object GetPropertyDelegate(Control control, string property);
		private delegate void MethodDelegate( Control control, string method, object[] parameters );
		private delegate void ChildPropertyDelegate( Control control, object child, string property, object value );
		private delegate void ChildMethodDelegate( Control control, object child, string method, object[] parameters );

		/// <summary>
		/// Does magic cross thread stuff, mostly used for GUI updates from background threads.
		/// </summary>
		/// <param name="control">Control that might be on a different Thread</param>
		/// <param name="propertyName">Method or Property to set or execute</param>
		/// <param name="propertyValue">object in setting property</param>
		public static void SetProperty(Control control, string propertyName, object propertyValue)
		{
			if ( control.InvokeRequired )
			{
				PropertyDelegate d = SetProperty;
				control.Invoke( d, control, propertyName, propertyValue );
			}
			else
			{
				var property = control.GetType().GetProperty( propertyName );
				if ( property == null )
				{
					throw new Exception(
						$"Could not find Property {propertyName} on {control.GetType()}" );
				}

				//Set Property
				property.SetValue(control, propertyValue);
			}
		}

        /// <summary>
        /// Does magic cross thread stuff, mostly used for to get property values in background threads.
        /// </summary>
        /// <param name="control">Control that might be on a different Thread</param>
        /// <param name="propertyName">Method or Property to get the value of</param>
        /// <returns></returns>
	    public static object GetProperty(Control control, string propertyName)
	    {
	        if (control.InvokeRequired)
	        {
	            GetPropertyDelegate d = GetProperty;
	            return control.Invoke(d, control, propertyName);
	        }

	        var property = control.GetType().GetProperty(propertyName);
	        if (property == null)
	        {
	            throw new Exception(
	                $"Could not find Property {propertyName} on {control.GetType()}");
	        }

	        //Get Property
	        return property.GetValue(control);
        }

		/// <summary>
		/// Does magic cross thread stuff, mostly used for GUI updates from background threads.
		/// </summary>
		/// <param name="control">Control that might be on a different Thread</param>
		/// <param name="methodName">name of method to execute</param>
		/// <param name="parameters">objects used in invoking method</param>
		public static void InvokeMethod(Control control, string methodName, object[] parameters)
		{
			if (control.InvokeRequired)
			{
				MethodDelegate d = InvokeMethod;
				control.Invoke(d, control, methodName, parameters);
			}
			else
			{
				var paramTypes = new Type[0];
				if (parameters != null && parameters.Length > 0)
				{
					paramTypes = parameters.Select(o => o.GetType()).ToArray();
				}

				var method = control.GetType().GetMethod( methodName, paramTypes );
				if ( method == null )
				{
					throw new Exception(
						$"Could not find Property {methodName.Split( '=' )[0]} on {control.GetType()}" );
				}

				//specify which method if two have the same name and invoke
				method.Invoke( control, parameters );
			}
		}
		
		/// <summary>
		/// Does magic cross thread stuff, mostly used for GUI updates from background threads.
		/// </summary>
		/// <param name="control">Control that might be on a different Thread</param>
		/// <param name="propertyName">Property to set</param>
		/// <param name="child">child component of control that will have property set</param>
		/// <param name="propertyValue">object used in setting proprty</param>
		public static void SetChildProperty( Control control, object child, string propertyName, object propertyValue )
		{
			if ( control.InvokeRequired )
			{
				ChildPropertyDelegate d = SetChildProperty;
				control.Invoke( d, control, child, propertyName, propertyValue );
			}
			else
			{
				//Get Property Name
				var property = child.GetType().GetProperty( propertyName );
				if ( property == null )
				{
					throw new Exception(
						$"Could not find Property {propertyName.Split( '=' )[0]} on {child.GetType()}" );
				}

				//Set Parameter
				property.SetValue( child, propertyValue);
			}
		}
		
		/// <summary>
		/// Does magic cross thread stuff, mostly used for GUI updates from background threads.
		/// </summary>
		/// <param name="control">Control that might be on a different Thread</param>
		/// <param name="methodName">name of method to invoke</param>
		/// <param name="child">sub-component of control that will have property set</param>
		/// <param name="parameters">objects used in invoking method</param>
		public static void InvokeChildMethod( Control control, object child, string methodName, object[] parameters )
		{
			if ( control.InvokeRequired )
			{
				ChildMethodDelegate d = InvokeChildMethod;
				control.Invoke( d, control, methodName, parameters );
			}
			else
			{
				//Get Method Name
				var paramTypes = new Type[0];
				if ( parameters != null && parameters.Length > 0 )
				{
					paramTypes = parameters.Select( o => o.GetType() ).ToArray();
				}
				var method = child.GetType().GetMethod( methodName, paramTypes );
				if ( method == null )
				{
					throw new Exception(
						$"Could not find Property {methodName.Split( '=' )[0]} on {child.GetType()}" );
				}

				//specify which method if two have the same name and invoke
				method.Invoke( child, parameters );
			}
		}

		private delegate void StatusDelegate(ToolStripStatusLabel label, string value);
        public static void UpdateToolStripStatus(ToolStripStatusLabel label, string value) {
            if (label.GetCurrentParent().InvokeRequired) {
                var d = new StatusDelegate(UpdateToolStripStatus);
                label.GetCurrentParent().Invoke(d, label, value);
            }
            else {
	            if (value.Length > 50)
	            {
		            value = "..." + value.Substring(value.Length - 50);
	            }
	            label.Text = value;
            }
        }

    }
}
