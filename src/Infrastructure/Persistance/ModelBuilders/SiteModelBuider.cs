namespace Persistance.ModelBuilders
{
    public static class SiteModelBuider
    {
        public static void SiteBuilder(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuider)
        {
            modelBuider.Entity<Domain.Site>(entity =>
            {
                entity.Property(e => e.SiteDomain)
                      .IsRequired()
                      .HasMaxLength(4000);
                entity.Property(e => e.SiteName)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(e => e.SitePath)
                      .IsRequired();
                entity.Property(e => e.SitePort)
                      .IsRequired();

                entity.HasKey(e => e.SiteID);

                entity.Property(e => e.CurrentRowVersion).IsRowVersion();
            });
        }
    }
}