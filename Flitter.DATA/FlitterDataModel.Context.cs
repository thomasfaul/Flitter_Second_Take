﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Flitter.DATA
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_FlitterEntities : DbContext
    {
        public DB_FlitterEntities()
            : base("name=DB_FlitterEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ProductPic> ProductPics { get; set; }
        public virtual DbSet<Followr> Followers { get; set; }
        public virtual DbSet<HashMessage> HashMessages { get; set; }
        public virtual DbSet<HashAbo> HashAbos { get; set; }
        public virtual DbSet<HashTag> HashTags { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<MessagePic> MessagePics { get; set; }
        public virtual DbSet<MessageRating> MessageRatings { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<ReportType> ReportTypes { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Avatar> Avatar { get; set; }
        public virtual DbSet<Data> Data { get; set; }
        public virtual DbSet<UserMessage> UserMessages { get; set; }
        public virtual DbSet<Role> Role { get; set; }
    }
}