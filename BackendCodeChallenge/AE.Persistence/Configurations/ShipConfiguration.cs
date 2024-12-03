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
    public class ShipConfiguration : IEntityTypeConfiguration<Ship>
    {
        public void Configure(EntityTypeBuilder<Ship> builder)
        {
            builder.HasData(
                new Ship { Id = 1, Name = "Sea Voyager", Latitude = 31.2320, Longitude = 121.4745, Velocity = 14.2 }, // Near Port of Shanghai
                new Ship { Id = 2, Name = "Ocean Explorer", Latitude = 1.3540, Longitude = 103.8205, Velocity = 16.5 }, // Near Port of Singapore
                new Ship { Id = 3, Name = "Wave Rider", Latitude = 29.8695, Longitude = 121.5450, Velocity = 12.8 }, // Near Port of Ningbo-Zhoushan
                new Ship { Id = 4, Name = "Harbor Queen", Latitude = 22.5440, Longitude = 114.0585, Velocity = 10.4 }, // Near Port of Shenzhen
                new Ship { Id = 5, Name = "Maritime Spirit", Latitude = 23.1305, Longitude = 113.2650, Velocity = 11.3 }, // Near Port of Guangzhou
                new Ship { Id = 6, Name = "Blue Horizon", Latitude = 35.1810, Longitude = 129.0760, Velocity = 9.7 }, // Near Port of Busan
                new Ship { Id = 7, Name = "Silver Anchor", Latitude = 22.3200, Longitude = 114.1700, Velocity = 15.1 }, // Near Port of Hong Kong
                new Ship { Id = 8, Name = "Pacific Wind", Latitude = 36.0680, Longitude = 120.3830, Velocity = 13.4 }, // Near Port of Qingdao
                new Ship { Id = 9, Name = "Northern Star", Latitude = 39.3440, Longitude = 117.3620, Velocity = 12.2 }, // Near Port of Tianjin
                new Ship { Id = 10, Name = "Coastal Runner", Latitude = 51.9235, Longitude = 4.4800, Velocity = 14.9 }  // Near Port of Rotterdam
            );

        }
    }
}
