using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Liso.Tangent
{
    public class TangentContext : DbContext
    {
        #region Properties

        public virtual DbSet<Favourite> Favourite { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TangentContext"/> class.
        /// </summary>
        /// <param name="options"></param>
        public TangentContext(DbContextOptions<TangentContext> options) : base(options)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TangentContext"/> class.
        /// </summary>
        public TangentContext()
        {

        }

        #endregion

        #region Methods

        /// <summary>
        /// Creating the model
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException("modelBuilder");
            }

            modelBuilder.Entity<Favourite>();

            modelBuilder.ApplyConfiguration(new FavouriteConfiguration());

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                                .SelectMany(t => t.GetProperties())
                                .Where(p => p.ClrType == typeof(string)))
            {
                if (property.GetMaxLength() == null)
                    property.SetMaxLength(int.MaxValue);
            }
        }

        #endregion
    }
}
