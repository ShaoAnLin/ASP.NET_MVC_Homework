namespace BillingRecord.Models
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class BillingDatabaseEntities : DbContext
	{
		public BillingDatabaseEntities()
			: base("name=BillingDatabaseEntities")
		{
		}

		public virtual DbSet<AccountBook> AccountBook { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
		}
	}
}
