using Oqtane.Models;
using Oqtane.Modules;
using Oqtane.Shared;

namespace mdmontesinos.Module.Issue4812
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "Issue4812",
            Description = "Minimal module to reproduce Oqtane issue 4812",
            Version = "1.1.0",
            ServerManagerType = "mdmontesinos.Module.Issue4812.Manager.Issue4812Manager, mdmontesinos.Module.Issue4812.Server.Oqtane",
            ReleaseVersions = "1.0.0,1.1.0",
            Dependencies = "mdmontesinos.Module.Issue4812.Shared.Oqtane",
            PackageName = "mdmontesinos.Module.Issue4812",
            Resources = [
                new Resource {
                    ResourceType = ResourceType.Script,
                    Url = "https://cdn.jsdelivr.net/npm/masonry-layout@4.2.2/dist/masonry.pkgd.min.js",
                    CrossOrigin = "anonymous",
                    Integrity = "sha384-GNFwBvfVxBkLMJpYMOABq3c+d3KnQxudP/mGPkzpZSTYykLBNsZEnG2D9G/X/+7D",
                    Fingerprint = "4.2.2",
                    Location = ResourceLocation.Body,
                    LoadBehavior = ResourceLoadBehavior.Once
                },
                new Resource {
                    ResourceType = ResourceType.Script,
                    Url = "https://unpkg.com/imagesloaded@5.0.0/imagesloaded.pkgd.min.js",
                    CrossOrigin = "anonymous",
                    Integrity = "sha384-e3sbGkYzJZpi7OdZc2eUoj7saI8K/Qbn+kPTdWyUQloiKIc9HRH4RUWFVxTonzTg",
                    Fingerprint = "5.0.0",
                    Location = ResourceLocation.Body,
                    LoadBehavior = ResourceLoadBehavior.Once
                },
                new Resource {
                    ResourceType = ResourceType.Script,
                    Location = ResourceLocation.Body,
                    Url = "~/Module.js",
                    Type = "Module",
                    Fingerprint = "1.1.0",
                    LoadBehavior = ResourceLoadBehavior.BlazorPageScript,
                }
            ]
        };
    }
}
