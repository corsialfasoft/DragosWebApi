﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Codice generato da un modello.
//
//     Le modifiche manuali a questo file potrebbero causare un comportamento imprevisto dell'applicazione.
//     Se il codice viene rigenerato, le modifiche manuali al file verranno sovrascritte.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DragosWebApi
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RICHIESTEEntities : DbContext
    {
        public RICHIESTEEntities()
            : base("name=RICHIESTEEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<OrdiniSet> OrdiniSet { get; set; }
        public virtual DbSet<OridiniProdotti> OridiniProdotti { get; set; }
        public virtual DbSet<ProdottiSet> ProdottiSet { get; set; }
    }
}