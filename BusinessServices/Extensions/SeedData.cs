using Aspose.Cells;
using DataModels.Entities;
using DataServices.Interfaces;
using Extensions;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;

namespace BusinessServices.Extensions
{
    public class SeedData(IWebHostEnvironment env, IRestaurantDataServices _restaurantService, IMenuDataServices _menuService, ISystemPromotionDataServices _promotionService)
    {
        public async Task<List<RestaurantInfo>> SeedRestaurants(IBrowserFile file)
        {
            try
            {
                var catePath = Path.Combine(env.WebRootPath, "uploads");

                if (!Directory.Exists(catePath))
                    Directory.CreateDirectory(catePath);

                await using FileStream fileStream = new(Path.Combine(catePath, file.Name), FileMode.Create);

                await file.OpenReadStream(file.Size).CopyToAsync(fileStream);

                Workbook workbook = new Workbook(fileStream);

                Worksheet worksheet = workbook.Worksheets["restaurant"];

                List<RestaurantInfo> restaurants = new List<RestaurantInfo>();

                int maxRow = worksheet.Cells.MaxDataRow;

                if (maxRow <= 0)
                    return null;

                Cells data = worksheet.Cells;

                for (int i = 2; i <= maxRow + 1; i++)
                {
                    RestaurantInfo resraurant = new RestaurantInfo();
                    try
                    {
                        resraurant.Id = Guid.NewGuid();
                        resraurant.restaurantName = data[$"A{i}"].Value.ToString();
                        resraurant.restaurantArea = data[$"C{i}"].Value.ToString();
                        resraurant.restaurantAddress = data[$"D{i}"].Value.ToString();
                        resraurant.restaurantPhone = "0" + data[$"E{i}"].Value.ToString();
                        resraurant.restaurantAliasName = resraurant.restaurantName.ToAliasString();
                    }
                    catch (Exception ex)
                    {
                        resraurant = new RestaurantInfo();
                    }
                    restaurants.Add(resraurant);
                }

                var result = await _restaurantService.CreateListRestaurants(restaurants);

                if (result == null)
                    return null;

                return restaurants;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<List<RestaurantMenu>> SeedMenu(IBrowserFile file)
        {
            try
            {
                var catePath = Path.Combine(env.WebRootPath, "uploads");

                if (!Directory.Exists(catePath))
                    Directory.CreateDirectory(catePath);

                await using FileStream fileStream = new(Path.Combine(catePath, file.Name), FileMode.Create);

                await file.OpenReadStream(file.Size).CopyToAsync(fileStream);

                Workbook workbook = new Workbook(fileStream);

                Worksheet worksheet = workbook.Worksheets["menu"];

                List<RestaurantMenu> menus = new List<RestaurantMenu>();

                int maxRow = worksheet.Cells.MaxDataRow;

                if (maxRow <= 0)
                    return null;

                Cells data = worksheet.Cells;

                for (int i = 2; i <= maxRow + 1; i++)
                {
                    RestaurantMenu menu = new RestaurantMenu();
                    try
                    {
                        menu.Id = Guid.NewGuid();
                        menu.menuName = data[$"A{i}"].Value.ToString();
                        menu.menuPrice = Convert.ToInt32(data[$"C{i}"].Value.ToString());
                        menu.menuType = data[$"D{i}"].Value.ToString();
                        menu.menuAliasName = menu.menuName.ToAliasString();
                    }
                    catch (Exception ex)
                    {
                        menu = new RestaurantMenu();
                    }
                    menus.Add(menu);
                }

                var result = await _menuService.CreateListMenuAsync(menus);

                if (result == null)
                    return null;

                return menus;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<List<SystemPromotion>> SeedPromotion(IBrowserFile file)
        {
            try
            {
                var catePath = Path.Combine(env.WebRootPath, "uploads");

                if (!Directory.Exists(catePath))
                    Directory.CreateDirectory(catePath);

                await using FileStream fileStream = new(Path.Combine(catePath, file.Name), FileMode.Create);

                await file.OpenReadStream(file.Size).CopyToAsync(fileStream);

                Workbook workbook = new Workbook(fileStream);

                Worksheet worksheet = workbook.Worksheets["promotion"];

                List<SystemPromotion> promotions = new List<SystemPromotion>();

                int maxRow = worksheet.Cells.MaxDataRow;

                if (maxRow <= 0)
                    return null;

                Cells data = worksheet.Cells;

                for (int i = 2; i <= maxRow + 1; i++)
                {
                    SystemPromotion promotion = new SystemPromotion();
                    try
                    {
                        promotion.Id = Guid.NewGuid();
                        promotion.promotionName = data[$"A{i}"].Value.ToString();
                        promotion.promotionAlias = promotion.promotionName.ToAliasString();
                    }
                    catch (Exception ex)
                    {
                        promotion = new SystemPromotion();
                    }
                    promotions.Add(promotion);
                }

                var result = await _promotionService.CreateListPromotion(promotions);

                if (result == null)
                    return null;

                return promotions;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<List<ZaloToken>> SeedZaloToken()
        {
            return new List<ZaloToken> { new ZaloToken() };
        }
    }
}
