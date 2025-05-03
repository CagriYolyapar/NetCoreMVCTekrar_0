using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreMVCTekrar_0.Models.Entities;

namespace NetCoreMVCTekrar_0.Models.Configurations
{
    public class AppUserConfiguration : BaseConfiguration<AppUser>
    {

        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            base.Configure(builder); //Orijinal görevini yapsın

            builder.HasOne(x => x.AppUserProfile).WithOne(x => x.AppUser).HasForeignKey<AppUserProfile>(x => x.Id);
        }
    }
}
