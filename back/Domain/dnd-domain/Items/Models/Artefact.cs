﻿namespace dnd_domain.Items.Models;

public class Artefact : StoredItem
{
    public bool? DiscardAfterUsage { get; set; }
    public bool? CastDieToDiscardAfterUsage { get; set; }

    public List<ArtefactEffect> Effects { get; set; } = new();
}