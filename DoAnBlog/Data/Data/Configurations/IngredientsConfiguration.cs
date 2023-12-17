using Data.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Data.Data.Configurations
{
    public class IngredientsConfiguration : IEntityTypeConfiguration<Ingredients>
    {
        public void Configure(EntityTypeBuilder<Ingredients> builder)
        {
            builder.ToTable("Ingredients");
            builder.HasKey(lp => lp.ID);



            builder.Property(p => p.NameIngredient)
                .IsRequired();

            builder.Property(p => p.FoodIngredientId)
                .IsRequired();

            builder.Property(p => p.FoodIngredientId)
                .IsRequired();

            builder.HasOne(r => r.FoodIngredient)
         .WithMany(n => n.Ingredients)
         .HasForeignKey(r => r.FoodIngredientId)
           .OnDelete(DeleteBehavior.Cascade);


        }
    
    }
}
