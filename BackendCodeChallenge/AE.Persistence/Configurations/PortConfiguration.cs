using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AE.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AE.Persistence.Configurations
{
    public class PortConfiguration : IEntityTypeConfiguration<Port>
    {
        public void Configure(EntityTypeBuilder<Port> builder)
        {
            builder.HasData(
                new Port { Id = 1, Name = "Port of Shanghai", Latitude = 31.2304, Longitude = 121.4737, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Port { Id = 2, Name = "Port of Singapore", Latitude = 1.3521, Longitude = 103.8198, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Port { Id = 3, Name = "Port of Ningbo-Zhoushan", Latitude = 29.8683, Longitude = 121.5440, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Port { Id = 4, Name = "Port of Shenzhen", Latitude = 22.5431, Longitude = 114.0579, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Port { Id = 5, Name = "Port of Guangzhou", Latitude = 23.1291, Longitude = 113.2644, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Port { Id = 6, Name = "Port of Busan", Latitude = 35.1796, Longitude = 129.0756, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Port { Id = 7, Name = "Port of Hong Kong", Latitude = 22.3193, Longitude = 114.1694, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Port { Id = 8, Name = "Port of Qingdao", Latitude = 36.0671, Longitude = 120.3826, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Port { Id = 9, Name = "Port of Tianjin", Latitude = 39.3434, Longitude = 117.3616, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Port { Id = 10, Name = "Port of Rotterdam", Latitude = 51.9225, Longitude = 4.4792, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Port { Id = 11, Name = "Port of Jebel Ali", Latitude = 25.0674, Longitude = 55.1372, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Port { Id = 12, Name = "Port of Hamburg", Latitude = 53.5511, Longitude = 9.9937, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Port { Id = 13, Name = "Port of Antwerp", Latitude = 51.2602, Longitude = 4.4028, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Port { Id = 14, Name = "Port of Los Angeles", Latitude = 33.7405, Longitude = -118.2727, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Port { Id = 15, Name = "Port of Long Beach", Latitude = 33.7701, Longitude = -118.1937, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Port { Id = 16, Name = "Port of Tanjung Pelepas", Latitude = 1.3622, Longitude = 103.5683, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Port { Id = 17, Name = "Port of Kaohsiung", Latitude = 22.6273, Longitude = 120.3014, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Port { Id = 18, Name = "Port of Felixstowe", Latitude = 51.9640, Longitude = 1.3514, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Port { Id = 19, Name = "Port of Algeciras", Latitude = 36.1408, Longitude = -5.4562, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now },
                new Port { Id = 20, Name = "Port of Yokohama", Latitude = 35.4437, Longitude = 139.6380, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now }
            );

        }
    }
}
