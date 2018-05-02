using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject.Models;

namespace FinalProject.ViewModels.HomeViewModel
{
    public class HomeViewModel
    {
        public List<Slider> Slider { get; set; }
        public Footer footer { get; set; }
        public List<Sidebar> sidebar { get; set; }
        public Trending trending { get; set; }
        public List<InstagramPic> instagramPics { get; set; }
        public AboutUsBg aboutUsBg { get; set; }
        public OurTeam ourTeam { get; set; }
        public HowItAllBegan howItAllBegan { get; set; }
        public FreeOffer freeOffer { get; set; }
        public NewsLetter newsLetter { get; set; }
        public CareersBg careersBg { get; set; }
        public Career career { get; set; }
        public List<Vacancy> vacancies { get; set; }
        public List<Position> positions { get; set; }
        public LookingForWork lookingForWork { get; set; }
        public CompetitionsBg competitionsBg { get; set; }
        public PartnerWithUsBg partnerWithUsBg { get; set; }
        public Cooperation cooperation { get; set; }
        public List<GreenIconSection> greeniconsection { get; set; }
        public OurPartner ourPartner { get; set; }
        public List<BrandImg> brandimgs { get; set; }
        public List<MiniPic> minipics { get; set; }
        public ComingSoon comingSoon { get; set; }
        public Bg503 bg503 { get; set; }
        public Bg404 bg404 { get; set; }
        public SiteMapBg SiteMapBg { get; set; }
        public PrivacyPolicyBg PrivacyPolicyBg { get; set; } /* not ready */
        public List<PrivacyPolicy> privacypolicy { get; set; } /* not ready */
        public MaintenanceBg maintenanceBg { get; set; } /* not ready */
        public Contact Contact { get; set; }
        public ContactsBg contactsBg { get; set; }
        public List<Post> posts { get; set; }
        public List<Product> products { get; set; }
        public List<Product_to_Categories> product_to_categories { get; set; }
        public ShopBg ShopBg { get; set; }
        public List<ProductImgSingleLarge> ProductImgSingleLarge { get; set; }
        public List<ProductImgSingleMini> ProductImgSingleMini { get; set; }
        public AdminInfo AdminInfo { get; set; }
        public List<Post> mustread { get; set; }
        public Post video { get; set; }

    }
}