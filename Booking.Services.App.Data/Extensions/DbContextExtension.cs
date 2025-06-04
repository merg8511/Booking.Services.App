using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Booking.Services.App.Data.Extensions
{
    public static class DbContextExtension
    {
        public static void ApplyGlobalSoftDeleteQueryFilter(this ModelBuilder modelBuilder)
        {
            System.Diagnostics.Debug.WriteLine(">>> Ejecutando filtro global");

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var clrType = entityType.ClrType;
                if (clrType is null || !clrType.IsClass || clrType.IsAbstract)
                    continue;

                var deletedProp = clrType.GetProperty("Deleted");

                if (deletedProp != null &&
                   (deletedProp.PropertyType == typeof(sbyte) || deletedProp.PropertyType == typeof(sbyte?)))
                {
                    System.Diagnostics.Debug.WriteLine($">>> Filtro aplicado a: {clrType.Name}");

                    var parameter = Expression.Parameter(clrType, "e");
                    var propertyAccess = Expression.Property(parameter, deletedProp);

                    // Convert to correct constant type
                    var zeroValue = deletedProp.PropertyType == typeof(sbyte?)
                        ? (object)(sbyte?)0
                        : (object)(sbyte)0;

                    var zero = Expression.Constant(zeroValue, deletedProp.PropertyType);
                    var equality = Expression.Equal(propertyAccess, zero);
                    var lambda = Expression.Lambda(equality, parameter);

                    modelBuilder.Entity(clrType).HasQueryFilter(lambda);
                }
            }
        }
    }

}

