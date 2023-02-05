using Microsoft.EntityFrameworkCore;
using Warhammer_Collection.Data;

namespace Warhammer_Collection.Models
{
    

    

    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Warhammer_CollectionContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Warhammer_CollectionContext>>()))
            {
                if (context == null || context.Mini == null)
                {
                    throw new ArgumentNullException("Null Warhammer_CollectionContext");
                }

                // Look for any Minis.
                if (context.Mini.Any())
                {
                    return;   // DB has been seeded
                }

                context.Mini.AddRange(
                    new Mini
                    {
                        game = "Warhammer 40k",
                        faction = "Necrons",
                        modelName = "Necron Warrior",
                        amount = 0
                    },

                    new Mini
                    {
                        game = "Warhammer 40k",
                        faction = "Necrons",
                        modelName = "Necron Immortal",
                        amount = 0
                    },

                    new Mini
                    {
                        game = "Warhammer 40k",
                        faction = "Necrons",
                        modelName = "Necron Lychguard",
                        amount = 0
                    },

                    new Mini
                    {
                        game = "Warhammer 40k",
                        faction = "Necrons",
                        modelName = "Necron Overlord",
                        amount = 0
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
