using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Data.Data.Entities;

namespace Data.Data.Configurations
{
    public class FoodIngredientConfiguration :IEntityTypeConfiguration<FoodIngredient>
    {
        public void Configure(EntityTypeBuilder<FoodIngredient> builder)
    {
        builder.ToTable("FoodIngredients");
        builder.HasKey(lp => lp.FoodID);

     

            builder.Property(p => p.PostID)
                .IsRequired();

            builder.Property(p => p.CookingTime)
                .IsRequired();


            builder.HasOne(lp => lp.Post)
            .WithOne()
            .HasForeignKey<FoodIngredient>(lp => lp.PostID)
             .OnDelete(DeleteBehavior.Cascade);


        }
    

    }
}
