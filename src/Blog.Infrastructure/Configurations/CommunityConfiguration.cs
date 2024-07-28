using Blog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Configurations
{
    public sealed class CommunityConfiguration : IEntityTypeConfiguration<Community>
    {
        public void Configure(EntityTypeBuilder<Community> builder)
        {
            builder
                .HasMany(community => community.Subscribers)
                .WithMany(subscription => subscription.Subscriptions)
                .UsingEntity<Subscription>(l => l.HasOne<User>().WithMany().HasForeignKey(x=>x.UserId),
                                           r => r.HasOne<Community>().WithMany().HasForeignKey(x=>x.CommunityId));

            builder
                  .HasMany(community => community.Administrators)
                  .WithMany(admin => admin.AdministeredCommunities)
                  .UsingEntity<CommunityAdmin>(
                      l => l.HasOne<User>().WithMany().HasForeignKey(e => e.UserId),
                      r => r.HasOne<Community>().WithMany().HasForeignKey(e => e.CommunityId));

            builder
           .HasData(
               CreateCommunity(
                   "84367e0d-5b35-4ae1-81ef-ce2ba6974f19",
                   "C#, .NET, Azure",
                   "Tajriba almashish, eng so'nggi texnologiyalarni muhokama qilish va qiziqarli loyihalarni topishingiz mumkin bo'lgan dasturchilar hamjamiyati.",
                   true),

               CreateCommunity(
                   "92d6b5bb-4977-4507-a281-9872a2f93590",
                   "Angular, TypeScript, RxJs",   //Ishqibozlar
                   "UI Design, foydalanuvchilarga qulay interface  bilan bo'lishishingiz mumkin bo'lgan FrontEndga ixlosmandlari jamoasi.",
                   false),

               CreateCommunity(
                   "01a705ae-7f35-46a5-b8d6-e07be527893b",
                   "DevOps, CI/CD, Docker, Jenkins",
                   "Ushbu sahifa DevOps hamjamiyatiga bag'ishlangan bo'lib, u erda siz o'z g'oyalaringiz va fikrlaringizni baham ko'rishingiz mumkin. Bu uzoq muddatli muvaffaqiyatni ta'minlash uchun qo'shimcha ma'lumot olish, savollar berish va muhim ilovalaringiz haqida ma'lumot olish uchun hamjamiyatdir..",
                   false),

               CreateCommunity(
                   "a7aba6b2-31ce-45d4-be78-17ff89a3b04a",
                   "SQl, DBMS",
                   "SQL Ma'lumotlar bazasi, boshqarish, tahlil, optimallashtirish, o'rganish, tajriba, yordam, MySQL, PostgreSQL, Oracle hamjamiyati.",
                   true),

               CreateCommunity(
                   "53817554-2518-406d-b1f6-4b1f2e4cedc3",
                   "Tech Startups",
                   "Axborot texnologiyalari sohasidagi startaplar hamjamiyati, bu yerda siz hamkasblar topishingiz, g‘oyalar bo‘yicha fikr-mulohaza olishingiz va loyihangiz uchun investorlarni topishingiz mumkin.",
                   true)
               );
        }

        private static Community CreateCommunity(string id, string name, string description, bool isClosed) =>
        new()
        {
            Id = new Guid(id),
            Name = name,
            Description = description,
            IsClosed = isClosed,
            CreateAt = DateTime.UtcNow
        };
    }
}
