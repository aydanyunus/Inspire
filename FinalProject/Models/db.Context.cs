﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalProject.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BlogInspireEntities : DbContext
    {
        public BlogInspireEntities()
            : base("name=BlogInspireEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AboutUsBg> AboutUsBgs { get; set; }
        public virtual DbSet<AdminInfo> AdminInfoes { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Banner> Banners { get; set; }
        public virtual DbSet<BeautyBg> BeautyBgs { get; set; }
        public virtual DbSet<Bg404> Bg404 { get; set; }
        public virtual DbSet<Bg503> Bg503 { get; set; }
        public virtual DbSet<BrandImg> BrandImgs { get; set; }
        public virtual DbSet<Career> Careers { get; set; }
        public virtual DbSet<CareersBg> CareersBgs { get; set; }
        public virtual DbSet<ComingSoon> ComingSoons { get; set; }
        public virtual DbSet<CompetitionsBg> CompetitionsBgs { get; set; }
        public virtual DbSet<CompetitionsImg> CompetitionsImgs { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<ContactsBg> ContactsBgs { get; set; }
        public virtual DbSet<Cooperation> Cooperations { get; set; }
        public virtual DbSet<FitnessBg> FitnessBgs { get; set; }
        public virtual DbSet<FoodBg> FoodBgs { get; set; }
        public virtual DbSet<Footer> Footers { get; set; }
        public virtual DbSet<FreeOffer> FreeOffers { get; set; }
        public virtual DbSet<GreenIconSection> GreenIconSections { get; set; }
        public virtual DbSet<HealthBg> HealthBgs { get; set; }
        public virtual DbSet<HomePageImg> HomePageImgs { get; set; }
        public virtual DbSet<HowItAllBegan> HowItAllBegans { get; set; }
        public virtual DbSet<InstagramPic> InstagramPics { get; set; }
        public virtual DbSet<LookingForWork> LookingForWorks { get; set; }
        public virtual DbSet<LoveBg> LoveBgs { get; set; }
        public virtual DbSet<MaintenanceBg> MaintenanceBgs { get; set; }
        public virtual DbSet<MiniPic> MiniPics { get; set; }
        public virtual DbSet<NewsLetter> NewsLetters { get; set; }
        public virtual DbSet<OurPartner> OurPartners { get; set; }
        public virtual DbSet<OurTeam> OurTeams { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<PartnerProgram> PartnerPrograms { get; set; }
        public virtual DbSet<PartnerWithUsBg> PartnerWithUsBgs { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<PostCategory> PostCategories { get; set; }
        public virtual DbSet<PostImgLarge> PostImgLarges { get; set; }
        public virtual DbSet<PostImgMedium> PostImgMediums { get; set; }
        public virtual DbSet<PostImgSmall> PostImgSmalls { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PrivacyPolicy> PrivacyPolicies { get; set; }
        public virtual DbSet<PrivacyPolicyBg> PrivacyPolicyBgs { get; set; }
        public virtual DbSet<Product_to_Brands> Product_to_Brands { get; set; }
        public virtual DbSet<Product_to_Categories> Product_to_Categories { get; set; }
        public virtual DbSet<Product_to_SingleLarge> Product_to_SingleLarge { get; set; }
        public virtual DbSet<Product_to_SingleMini> Product_to_SingleMini { get; set; }
        public virtual DbSet<ProductBrand> ProductBrands { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductImgMedium> ProductImgMediums { get; set; }
        public virtual DbSet<ProductImgMini> ProductImgMinis { get; set; }
        public virtual DbSet<ProductImgSingleLarge> ProductImgSingleLarges { get; set; }
        public virtual DbSet<ProductImgSingleMini> ProductImgSingleMinis { get; set; }
        public virtual DbSet<ProductImgSmall> ProductImgSmalls { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ShopBg> ShopBgs { get; set; }
        public virtual DbSet<Sidebar> Sidebars { get; set; }
        public virtual DbSet<SinglePost> SinglePosts { get; set; }
        public virtual DbSet<SinglePostBg> SinglePostBgs { get; set; }
        public virtual DbSet<SiteMapBg> SiteMapBgs { get; set; }
        public virtual DbSet<Slider> Sliders { get; set; }
        public virtual DbSet<SliderCategory> SliderCategories { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Trending> Trendings { get; set; }
        public virtual DbSet<Vacancy> Vacancies { get; set; }
    }
}
