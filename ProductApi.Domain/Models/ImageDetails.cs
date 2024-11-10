using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Domain.Models
{
    public class ImageDetails
    {
        public int Id { get; set; }
        public string ProductImage { get; set; } = null!;
    }
}
