using Microsoft.EntityFrameworkCore;

namespace Persistance.ModelBuilders
{
    public static class ClaimModelBuider
    {
        public static void ClaimModelBuilder(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuider)
        {
            modelBuider.Entity<Domain.Claim>(entity =>
            {
                entity.Property(e => e.ClaimName)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.HasKey(e => e.ClaimID);

                entity.HasOne(e => e.ParentClaim)
                      .WithMany()
                      .HasForeignKey(e => e.ParentClaimID)
                      .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);


                entity.Property(e => e.CurrentRowVersion).IsRowVersion();
            });
        }
    }
}