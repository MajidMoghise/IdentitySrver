namespace Persistance.ModelBuilders
{
    public static class TokenModelBuider
    {
        public static void TokenBuilder(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuider)
        {
            modelBuider.Entity<Domain.Token>(entity =>
            {
                entity.Property(e => e.TokenStr)
                      .IsRequired();

                entity.Property(e => e.TokenCreate)
                      .IsRequired();
                entity.Property(e => e.TokenDateValid)
                      .IsRequired();
                entity.Property(e => e.TokenGuid)
                      .IsRequired();
                entity.Property(e => e.TokenIsValid)
                      .IsRequired();
                entity.HasKey(e => new
                {
                    e.TokenID,
                    e.UserID
                });
                entity.Property(e => e.TokenID)
                      .ValueGeneratedOnAdd();
            });
        }
    }
}