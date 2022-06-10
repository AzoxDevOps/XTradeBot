namespace Azox.Data.Mappings
{
    using Azox.DomainModel;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public abstract class MappingBase<TEntity> :
        IEntityTypeConfiguration<TEntity>
        where TEntity : class, IEntity
    {
        #region Methods

        protected virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            Type entityType = typeof(TEntity);

            builder.ToTable(entityType.Name);
            builder.HasKey(nameof(EntityBase.Id));

            int columnOrder = 1;

            if (typeof(IBasicEntity).IsAssignableFrom(entityType))
            {
                builder.Property(nameof(IBasicEntity.Code))
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnOrder(columnOrder++);

                builder.Property(nameof(IBasicEntity.Name))
                    .IsRequired()
                    .HasMaxLength(1024)
                    .HasColumnOrder(columnOrder++);

                builder.Property(nameof(IBasicEntity.Description))
                    .HasMaxLength(4000)
                    .HasColumnOrder(columnOrder++);

                builder.HasIndex(nameof(IBasicEntity.Code)).IsUnique();
            }

            if (typeof(ITrackableEntity).IsAssignableFrom(entityType))
            {
                builder.Property(nameof(ITrackableEntity.CreationTime))
                    .IsRequired()
                    .HasDefaultValueSql("GETUTCDATE()")
                    .HasColumnOrder(columnOrder++);

                builder.Property(nameof(ITrackableEntity.LastUpdatedTime))
                    .HasColumnOrder(columnOrder++);

                builder.HasIndex(nameof(ITrackableEntity.CreationTime));
            }

            if (typeof(IDeletableEntity).IsAssignableFrom(entityType))
            {
                builder.Property(nameof(IDeletableEntity.IsDeleted))
                    .IsRequired()
                    .HasDefaultValue(false)
                    .HasColumnOrder(columnOrder++);

                builder.Property(nameof(IDeletableEntity.DeletionTime))
                    .HasColumnOrder(columnOrder++);
            }
        }

        #endregion Methods

        #region IEntityTypeConfiguration<TEntity> Members

        void IEntityTypeConfiguration<TEntity>.Configure(EntityTypeBuilder<TEntity> builder)
        {
            Configure(builder);
        }

        #endregion IEntityTypeConfiguration<TEntity> Members
    }
}
