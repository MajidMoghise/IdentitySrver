namespace Persistance.ModelBuilders
{
    public static class UserRoleClaimActionModelBuider
    {
        public static void UserRoleClaimActionBuilder(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuider)
        {
            modelBuider.Entity<Domain.UserRoleClaimAction>(entity =>
            {
                entity.Property(e => e.UserID)
                      .IsRequired();
                entity.HasKey(e => new
                {
                    e.RoleID,
                    e.UserID,
                    e.ClaimID,
                    e.ActionID
                });
                
                entity.HasOne(e => e.User)
                      .WithMany()
                      .HasForeignKey(e => e.UserID)
                      .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

                entity.HasOne(e => e.Claim)
                      .WithMany()
                      .HasForeignKey(e => e.ClaimID)
                      .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

                entity.HasOne(e => e.Role)
                      .WithMany()
                      .HasForeignKey(e => e.RoleID)
                      .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

                entity.HasOne(e => e.Action)
                      .WithMany()
                      .HasForeignKey(e => e.ActionID)
                      .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

                entity.Property(e => e.CurrentRowVersion).IsRowVersion();

            });
        }
    }
}