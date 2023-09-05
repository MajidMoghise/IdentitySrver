using Microsoft.EntityFrameworkCore;
using System;

namespace Persistance.ModelBuilders
{
    public static class ActionModelBuider
    {
        public static void ActionBuilder(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuider)
        {
            modelBuider.Entity<Domain.Action>(entity =>
            {
                entity.HasKey(e => e.ActionID);
                entity.Property(e => e.ActionName)
                     .IsRequired()
                     .HasMaxLength(100);
                entity.HasOne(e => e.Controller)
                      .WithMany()
                      .HasForeignKey(e => e.ControllerID)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.Property(e => e.CurrentRowVersion).IsRowVersion();

            });
        }
    }
}