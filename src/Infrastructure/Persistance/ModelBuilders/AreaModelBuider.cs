using Microsoft.EntityFrameworkCore;

namespace Persistance.ModelBuilders
{
    public static class AreaModelBuider
    {
        public static void AreaBuilder(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuider)
        {
            modelBuider.Entity<Domain.Area>(entity =>
            {
                entity.Property(e => e.AreaName)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.HasKey(e => e.AreaID);

                entity.HasOne(e => e.Site)
                  .WithMany()
                  .HasForeignKey(e => e.SiteID)
                  .OnDelete(DeleteBehavior.Restrict);

                entity.Property(e => e.CurrentRowVersion).IsRowVersion();
            });
        }
    }
}