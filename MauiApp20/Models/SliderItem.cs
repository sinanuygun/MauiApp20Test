using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp20.Models
{
    public class SliderItem
    {
        public string Image { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Subtitle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ButtonText { get; set; } = "SHOP NOW";
        public string ButtonLink { get; set; } = "/shop";
    }
}
