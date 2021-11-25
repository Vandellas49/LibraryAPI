namespace Entities.Dtos
{
    public class CategoryUpdateDto
    {
        /// <summary>
        ///Kategori  Id
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        ///Kategori İsmi
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///Kategori Tanımı
        /// </summary>
        public string Description { get; set; }
        public static implicit operator Category(CategoryUpdateDto category)
        {
            return new Category
            {
                Description = category.Description,
                Name = category.Name,
                Id = category.Id.Value
            };
        }

    }
}
