namespace dnd_infra.Items.DALs;

internal abstract class ItemDal
{
    public int Id { get; set; }
    public int SessionId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = string.Empty;
    public string Explanation { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public int Level { get; set; }
}
