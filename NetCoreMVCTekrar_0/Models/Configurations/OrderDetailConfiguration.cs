using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreMVCTekrar_0.Models.Entities;

namespace NetCoreMVCTekrar_0.Models.Configurations
{
    public class OrderDetailConfiguration : BaseConfiguration<OrderDetail>
    {
        public override void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            base.Configure(builder);

            builder.Ignore(x => x.Id);
            builder.HasKey(x => new
            {
                x.OrderId,
                x.ProductId
            });
        }
    }
}
