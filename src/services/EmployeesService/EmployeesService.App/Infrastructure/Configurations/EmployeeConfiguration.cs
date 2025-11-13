using EmployeesService.App.Domain.Entities;
using EmployeesService.App.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeesService.App.Infrastructure.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("employee");

        builder.HasKey(e => e.Id);

        builder.HasIndex(e => e.Username).IsUnique();

        builder
            .Property(e => e.Id)
            .ValueGeneratedNever()
            .HasColumnName("id");

        builder
            .Property(e => e.Surname)
            .HasMaxLength(128)
            .HasColumnName("surname");

        builder
            .Property(e => e.Name)
            .HasMaxLength(128)
            .HasColumnName("name");
        
        builder
            .Property(e => e.Patronymic)
            .HasMaxLength(128)
            .HasColumnName("patronymic");
        
        builder
            .Property(e => e.Username)
            .HasMaxLength(64)
            .HasColumnName("username");
        
        builder
            .Property(e => e.Role)
            .HasConversion<string>()
            .HasColumnName("role");

        builder.HasData(GenerateTestEmployees());
    }
    private static List<Employee> GenerateTestEmployees()
    {
        return new List<Employee>
            {
                new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Surname = "Иванов", Name = "Алексей", Patronymic = "Петрович", Username = "ivanov.ap", Role = Role.MANAGER },
                new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111112"), Surname = "Петрова", Name = "Мария", Patronymic = "Сергеевна", Username = "petrova.ms", Role = Role.MANAGER },
                new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111113"), Surname = "Сидоров", Name = "Дмитрий", Patronymic = "Игоревич", Username = "sidorov.di", Role = Role.MANAGER },

                new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111114"), Surname = "Козлова", Name = "Анна", Patronymic = "Владимировна", Username = "kozlova.av", Role = Role.ANALYST },
                new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111115"), Surname = "Федоров", Name = "Михаил", Patronymic = "Олегович", Username = "fedorov.mo", Role = Role.ANALYST },
                new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111116"), Surname = "Никитина", Name = "Елена", Patronymic = "Дмитриевна", Username = "nikitina.ed", Role = Role.ANALYST },
                new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111117"), Surname = "Орлов", Name = "Сергей", Patronymic = "Викторович", Username = "orlov.sv", Role = Role.ANALYST },

                new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111118"), Surname = "Волков", Name = "Андрей", Patronymic = "Александрович", Username = "volkov.aa", Role = Role.DEVELOPER },
                new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111119"), Surname = "Зайцева", Name = "Ольга", Patronymic = "Ивановна", Username = "zaitseva.oi", Role = Role.DEVELOPER },
                new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111120"), Surname = "Павлов", Name = "Игорь", Patronymic = "Сергеевич", Username = "pavlov.is", Role = Role.DEVELOPER },
                new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111121"), Surname = "Семенова", Name = "Татьяна", Patronymic = "Петровна", Username = "semenova.tp", Role = Role.DEVELOPER },
                new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111122"), Surname = "Морозов", Name = "Артем", Patronymic = "Вадимович", Username = "morozov.av", Role = Role.DEVELOPER },
                new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111123"), Surname = "Алексеев", Name = "Владимир", Patronymic = "Николаевич", Username = "alekseev.vn", Role = Role.DEVELOPER },
                new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111124"), Surname = "Ковалева", Name = "Юлия", Patronymic = "Андреевна", Username = "kovaleva.ya", Role = Role.DEVELOPER },

                new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111125"), Surname = "Григорьев", Name = "Павел", Patronymic = "Олегович", Username = "grigorev.po", Role = Role.QA },
                new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111126"), Surname = "Белова", Name = "Наталья", Patronymic = "Викторовна", Username = "belova.nv", Role = Role.QA },
                new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111127"), Surname = "Киселев", Name = "Антон", Patronymic = "Денисович", Username = "kiselev.ad", Role = Role.QA },
                new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111128"), Surname = "Соколова", Name = "Ирина", Patronymic = "Алексеевна", Username = "sokolova.ia", Role = Role.QA },
                new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111129"), Surname = "Титов", Name = "Роман", Patronymic = "Михайлович", Username = "titov.rm", Role = Role.QA },
                new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111130"), Surname = "Медведева", Name = "Светлана", Patronymic = "Геннадьевна", Username = "medvedeva.sg", Role = Role.QA }
            };
    }
}
