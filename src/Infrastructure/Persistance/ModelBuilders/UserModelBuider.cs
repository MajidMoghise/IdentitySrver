namespace Persistance.ModelBuilders
{
    public static class UserModelBuider
    {
        public static void UserBuilder(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuider)
        {
            modelBuider.Entity<Domain.User>(entity =>
            {
                entity.Property(e => e.UserName)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(e => e.Password)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.HasKey(e => e.UserID);
                entity.Property(e => e.CurrentRowVersion).IsRowVersion();
            });
        }
    }
}