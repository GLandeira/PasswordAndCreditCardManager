﻿// <auto-generated />
namespace Repository.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.4.4")]
    public sealed partial class ChangeKeyAndIVToByteArray : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(ChangeKeyAndIVToByteArray));
        
        string IMigrationMetadata.Id
        {
            get { return "202106171802427_ChangeKeyAndIVToByteArray"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}