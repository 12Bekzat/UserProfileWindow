using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserProfileWindow
{
	public class Context : DbContext
	{
		private readonly string connectionString;
		public Context(string connectionString)
		{
			this.connectionString = connectionString;
			Database.EnsureCreated();
		}

		public DbSet<UserProfile> Profiles { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(connectionString);
		}
	}
}
