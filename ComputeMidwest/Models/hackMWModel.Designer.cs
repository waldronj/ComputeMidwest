﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
namespace ComputeMidwest.Models
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class hackMWEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new hackMWEntities object using the connection string found in the 'hackMWEntities' section of the application configuration file.
        /// </summary>
        public hackMWEntities() : base("name=hackMWEntities", "hackMWEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new hackMWEntities object.
        /// </summary>
        public hackMWEntities(string connectionString) : base(connectionString, "hackMWEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new hackMWEntities object.
        /// </summary>
        public hackMWEntities(EntityConnection connection) : base(connection, "hackMWEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
    }

    #endregion

    
}
