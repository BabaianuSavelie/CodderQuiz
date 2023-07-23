using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;
public class QuizzConfiguration : IEntityTypeConfiguration<Quizz>
{
    public void Configure(EntityTypeBuilder<Quizz> builder)
    {
        builder.ToTable("Quizzes");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.HasOne(q => q.Category)
            .WithMany()
            .HasForeignKey(q => q.CategoryId);

        builder.HasMany(q => q.Questions)
            .WithOne()
            .HasForeignKey(q=>q.QuizzId);

        builder.Property(q => q.Description)
            .HasMaxLength(200);
    }
}
