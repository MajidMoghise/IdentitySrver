using Microsoft.EntityFrameworkCore;

namespace Persistance.ModelBuilders
{
    public static class ControllerModelBuider
    {
        public static void ControllerBuilder(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuider)
        {
            modelBuider.Entity<Domain.Controller>(entity =>
            {
                entity.Property(e => e.ControllerName)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.HasKey(e => e.ControllerID);

                entity.HasOne(e => e.Area)
              .WithMany()
              .HasForeignKey(e => e.AreaID)
              .OnDelete(DeleteBehavior.Restrict);

                entity.Property(e => e.CurrentRowVersion).IsRowVersion();

            });
        }
    }
}