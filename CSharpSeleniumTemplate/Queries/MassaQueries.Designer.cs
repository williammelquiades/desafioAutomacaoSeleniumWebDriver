﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CSharpSeleniumTemplate.Queries {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class MassaQueries {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal MassaQueries() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CSharpSeleniumTemplate.Queries.MassaQueries", typeof(MassaQueries).Assembly);
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
        ///   Looks up a localized string similar to BEGIN;
        ///TRUNCATE TABLE mantis_filters_table; 
        ///TRUNCATE TABLE mantis_bug_text_table;
        ///TRUNCATE TABLE mantis_bug_table;
        ///TRUNCATE TABLE mantis_tag_table;
        ///TRUNCATE TABLE mantis_bug_tag_table;
        ///TRUNCATE TABLE mantis_custom_field_table;
        ///TRUNCATE TABLE mantis_user_profile_table;
        ///TRUNCATE TABLE mantis_project_table;
        ///TRUNCATE TABLE mantis_category_table;
        ///#DELETE FROM mantis_category_table WHERE id !=1;
        ///COMMIT;.
        /// </summary>
        internal static string LimparBaseFullStack {
            get {
                return ResourceManager.GetString("LimparBaseFullStack", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to BEGIN;
        ///#Criar um  projeto em base
        ///INSERT into mantis_project_table (NAME,description,inherit_global) values (&apos;Proj Trigger&apos; , &apos;Descrition Trigger&apos;, 1) ;
        ///#Criar uma tarefa base
        ///INSERT INTO mantis_bug_table 
        ///(project_id,reporter_id,handler_id,duplicate_id,priority,severity,reproducibility,STATUS,resolution,projection,
        ///eta,bug_text_id,os,os_build,platform,version,fixed_in_version,build,profile_id,view_state,summary,sponsorship_total,sticky,target_version,
        ///category_id)
        ///VALUES(1,1,0,0,30,50,70,10,10,10,1 [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string TarefasVerFullStack {
            get {
                return ResourceManager.GetString("TarefasVerFullStack", resourceCulture);
            }
        }
    }
}
