using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core.InfoAboutMe;
using MyPortfolio.Core.Users;

namespace MyPortfolio.Core.Context.Seeds;

public class DataSeeder
{
    public static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AboutMe>().HasData(
            new AboutMe
            {
                AboutMeID = 1,
                Name = "Petro",
                Surname = "Yevenchuk",
                Age = 22,
                Location = "Ukraine",
                Position = ".Net Developer",
                PhotoMeUrl = "photo-me.jpg",
                Description = "On my portfolio site, I present myself as a highly skilled " +
                ".NET developer ready to contribute significantly to your projects. " +
                "I have more than 1.5 years of experience in C# and more than a year of " +
                "experience as a .NET backend developer. In addition, I have successfully " +
                "worked as a full-stack developer (.NET + React) for the past six months, " +
                "which enhances my effectiveness in teamwork and provides a wider range of " +
                "skills.\r\n\r\nMy strengths include the ability to write maintainable code " +
                "according to best practices, developed analytical thinking, responsibility in " +
                "the execution of tasks and effective time management. My adaptability allows me " +
                "to work effectively both remotely and in the office, ensuring productivity and " +
                "communication with the team regardless of location.\r\n\r\nThanks to my versatile " +
                "experience and skills, I am always ready to take on new challenges. On my portfolio " +
                "site, you can learn more about my work achievements and examples of projects that I have " +
                "successfully completed. I will be happy to cooperate."
            }
        );

        modelBuilder.Entity<User>().HasData(
            new User
            {
                UserID = 1,
                Login = "myportfolioadmin@gmail.com",
                Password = "WPGiUXw7hL1fwEY68x3pWDe/AtVHgo7bh0UaifjOexY=",
                Salt = "ex9mX76oqyQ27+pahx7ywg==",
                Role = Role.Admin
            }
        );
    }
}
