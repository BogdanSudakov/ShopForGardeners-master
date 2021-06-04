SELECT[Name]
     , AllCategories.CategoryName
  FROM [ShopGarden].[dbo].[AllItems]  LEFT JOIN AllCategories
  on AllItems.CategoryID = AllCategories.Id 