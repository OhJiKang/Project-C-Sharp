﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace doanNet.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KTXTDTUEntities : DbContext
    {
        public KTXTDTUEntities()
            : base("name=KTXTDTUEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Fee> Fees { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Mistake> Mistakes { get; set; }
        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<Priority> Priorities { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<SinhVien> SinhViens { get; set; }
    }
}
