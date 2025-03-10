using dnd_domain.Items.Enums;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace dnd_domain.Items.Models;

public abstract class Item
{
    public string Id => GetUniqueIdentifier(Name);

    public required string Description { get; set; }
    public List<Effect> Effects { get; set; } = [];
    public string? Explanation { get; set; }
    public bool IsUnique { get; set; } = false;
    public required int Level { get; set; }
    public required string Name { get; set; }
    public required ItemType Type { get; set; }

    private static string GetUniqueIdentifier(string itemName)
    {
        byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(itemName));
        StringBuilder builder = new();
        foreach (byte b in bytes)
        {
            builder.Append(b.ToString("x2"));
        }

        return builder.ToString();
    }
}
