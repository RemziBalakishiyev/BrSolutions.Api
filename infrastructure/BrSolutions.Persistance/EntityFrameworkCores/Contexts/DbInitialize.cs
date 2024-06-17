using BrSolution.Domain.Entities.App;
using BrSolution.Domain.Entities.Libraries;
using BrSolution.Infrastructure.PredefinedValues;
using Microsoft.EntityFrameworkCore;

namespace BrSolutions.Persistance.EntityFrameworkCores.Contexts
{
    public static class DbInitialize
    {
        public static void Init(ModelBuilder modelBuilder)
        {
            IEnumerable<PostStatus> postStatuses =
            [
                new PostStatus
                {
                    Id = PostStatusValue.NotStarted,
                    CreateDate = DateTime.Now ,
                    Name = PostStatusValue.NotStarted.ToString()
                },
                new PostStatus
                {
                    Id = PostStatusValue.Progress,
                    CreateDate = DateTime.Now ,
                    Name = PostStatusValue.Progress.ToString()
                },
                new PostStatus
                {
                    Id = PostStatusValue.Stoped,
                    CreateDate = DateTime.Now ,
                    Name = PostStatusValue.Stoped.ToString()
                },
                new PostStatus
                {
                    Id = PostStatusValue.Shared,
                    CreateDate = DateTime.Now ,
                    Name = PostStatusValue.Shared.ToString()
                },

            ];


            modelBuilder.Entity<PostStatus>()
                .HasData(postStatuses);


            IEnumerable<Gender> genders =
            [
                new()
                {
                    Id = GenderValue.Male,
                    CreateDate = DateTime.Now ,
                    Name = GenderValue.Male.ToString()
                },
                new()
                {
                    Id = GenderValue.Female,
                    CreateDate = DateTime.Now ,
                    Name = GenderValue.Female.ToString()
                },
            ];

            modelBuilder.Entity<Gender>()
                .HasData(genders);


            IEnumerable<PostType> postTypes =
            [
                new() {
                   Id = PostTypeValue.Carousel,
                   Name = PostTypeValue.Carousel.ToString(),
                   CreateDate = DateTime.Now
                },

                new() {
                   Id = PostTypeValue.OnePost,
                   Name = PostTypeValue.OnePost.ToString(),
                   CreateDate = DateTime.Now
                },

                new() {
                   Id = PostTypeValue.Reels,
                   Name = PostTypeValue.Reels.ToString(),
                   CreateDate = DateTime.Now
                },
            ];

            modelBuilder.Entity<PostType>()
              .HasData(postTypes);


            IEnumerable<UserStatus> userStatuses =
            [
                new()
                {
                    Id = UserStatusValue.Register,
                    Name = UserStatusValue.Register.ToString(),
                    CreateDate = DateTime.Now ,
                },

                new()
                {
                    Id = UserStatusValue.Active,
                    Name = UserStatusValue.Active.ToString(),
                    CreateDate = DateTime.Now ,
                },

                new()
                {
                    Id = UserStatusValue.Deactive,
                    Name = UserStatusValue.Deactive.ToString(),
                    CreateDate = DateTime.Now ,
                }
            ];

            modelBuilder.Entity<UserStatus>()
                .HasData(userStatuses);

        }
    }
}
