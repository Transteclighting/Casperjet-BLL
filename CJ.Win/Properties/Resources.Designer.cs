﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CJ.Win.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CJ.Win.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;DSPermission xmlns=&quot;http://tempuri.org/DSPermission.xsd&quot;&gt;
        ///	&lt;Permission&gt;
        ///		&lt;PermissionKey&gt;M1&lt;/PermissionKey&gt;
        ///		&lt;PermissionName&gt;System Security&lt;/PermissionName&gt;
        ///		&lt;IsLeaf&gt;false&lt;/IsLeaf&gt;
        ///		&lt;AvailableApplication&gt;3&lt;/AvailableApplication&gt;
        ///		&lt;MenuType&gt;0&lt;/MenuType&gt;
        ///	&lt;/Permission&gt;
        ///	&lt;Permission&gt;
        ///		&lt;PermissionKey&gt;M1.1&lt;/PermissionKey&gt;
        ///		&lt;PermissionName&gt;User Information &amp;amp; Permission&lt;/PermissionName&gt;
        ///		&lt;ParentKey&gt;M1&lt;/ParentKey&gt;
        ///		&lt;NavigateUrl&gt;~/frmUsers.aspx&lt;/NavigateUrl&gt;
        ///		&lt;IsLeaf&gt;true&lt;/IsLeaf&gt;
        ///		&lt;Ava [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string MenuTree {
            get {
                return ResourceManager.GetString("MenuTree", resourceCulture);
            }
        }
    }
}