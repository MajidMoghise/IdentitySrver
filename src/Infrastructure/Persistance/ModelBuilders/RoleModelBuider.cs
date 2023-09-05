namespace Persistance.ModelBuilders
{
    public static class RoleModelBuider
    {
        public static void RoleBuilder(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuider)
        {
            modelBuider.Entity<Domain.Role>(entity =>
            {
                entity.Property(e => e.RoleName)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.HasKey(e => e.RoleID);
                entity.HasOne(e => e.ParentRole)
                      .WithMany()
                      .HasForeignKey(e => e.ParentRoleID)
                      .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
                entity.Property(e => e.CurrentRowVersion).IsRowVersion();
            });
        }
    }
}