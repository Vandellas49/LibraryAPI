namespace Entities.Dtos
{
    public class CategoryAddDto
    {
        /// <summary>
        ///Kategori İsmi
        /// </summary>
        /// <example>Roman</example>
        public string Name { get; set; }
        /// <summary>
        ///Açıklaması
        /// </summary>
        public string Description { get; set; }


        public static implicit operator Category(CategoryAddDto category)
        {
            return new Category
            {
                Description = category.Description,
                Name = category.Name,
                Id = 0
            };
        }
    }
}
