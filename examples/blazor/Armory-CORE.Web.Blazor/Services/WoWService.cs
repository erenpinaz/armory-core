using Armory_CORE.Core.Models;
using Armory_CORE.Core.Models.Enums;
using Armory_CORE.Core.WorldOfWarcraft;
using Armory_CORE.Core.WorldOfWarcraft.Models.GameData;
using Armory_CORE.Web.Blazor.Helpers;
using Armory_CORE.Web.Blazor.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Armory_CORE.Web.Blazor.Services
{
    public class WoWService
    {
        private readonly IWebHostEnvironment _env;
        private readonly WorldOfWarcraftApi _wowApi;

        public WoWService(IWebHostEnvironment env, WorldOfWarcraftApi wowApi)
        {
            _env = env;
            _wowApi = wowApi;
        }

        public async Task<IEnumerable<Realm>> GetRealmsAsync(RegionEnum region)
        {
            var gameDataRequestOptions = new RequestOptions(region: region, useCache: true);

            var realmIndex = await _wowApi.GetRealmsAsync(gameDataRequestOptions);
            return realmIndex.Realms.OrderBy(q => q.Name);
        }

        public async Task<SummaryModel> GetSummaryAsync(RegionEnum region, string realmSlug, string characterName)
        {
            var profileRequestOptions = new RequestOptions(region: region, useCache: true); //TODO: useCache: false

            var characterProfile = await _wowApi.GetCharacterProfileSummaryAsync(realmSlug, characterName, profileRequestOptions);
            var characterMedia = await _wowApi.GetCharacterMediaSummaryAsync(realmSlug, characterName, profileRequestOptions);
            var characterEquipment = await _wowApi.GetCharacterEquipmentSummaryAsync(realmSlug, characterName, profileRequestOptions);

            #region Get and store item media

            var itemIds = new HashSet<int>();
            foreach (var equippedItem in characterEquipment.EquippedItems.Where(q => q.ItemKey?.Id != null))
            {
                itemIds.Add(equippedItem.ItemKey.Id);
                if (equippedItem.Sockets != null && equippedItem.Sockets.Any())
                {
                    foreach (var socket in equippedItem.Sockets?.Where(q => q?.ItemKey?.Id != null))
                    {
                        itemIds.Add(socket.ItemKey.Id);
                    }
                }
            }

            var gameDataRequestOptions = new RequestOptions(region: region, useCache: true);
            var itemAssets = await Task.WhenAll(itemIds.Select(async itemId =>
            {
                var itemMedia = await _wowApi.GetItemMediaAsync(itemId, gameDataRequestOptions);
                var remoteIconAsset = itemMedia?.Assets?.FirstOrDefault(t => t.Key == "icon")?.Value;
                var storedIconAsset = IOHelpers.DownloadFile(remoteIconAsset, _env.WebRootPath, $"images/wow/item/");

                return new
                {
                    Id = itemId,
                    Icon = storedIconAsset ?? remoteIconAsset
                };
            }));

            #endregion

            var model = new SummaryModel
            {
                AvatarUrl = characterMedia.Assets?.FirstOrDefault(q => q.Key == "avatar")?.Value,
                RenderUrl = characterMedia.Assets?.FirstOrDefault(q => q.Key == "main")?.Value,
                Character = new CharacterModel
                {
                    DisplayName = characterProfile.Name,
                    Title = characterProfile.ActiveTitle?.Name,
                    Description = $"{characterProfile.Level} {characterProfile.Race.Name} {characterProfile.ActiveSpec.Name} {characterProfile.Class.Name}",
                    Guild = characterProfile.Guild == null ? null : new GuildModel
                    {
                        Id = characterProfile.Guild.Id,
                        Name = characterProfile.Guild.Name
                    },
                    FactionImageUrl = $"images/wow/game/{characterProfile.Faction.Name.ToLowerInvariant()}.png",
                    RealmName = characterProfile.Realm.Name,
                    AchievementPoints = characterProfile.AchievementPoints,
                    ItemLevel = characterProfile.EquippedItemLevel,
                    LastLogin = characterProfile.LastLogin.ToString("dd.MM.yyyy"),
                    Equipment = characterEquipment.EquippedItems.Select(q => new EquipmentModel
                    {
                        Slot = Enum.Parse<EquipmentSlot>(q.Slot.Type),
                        Name = q.Name,
                        Quality = q.Quality.Type,
                        Level = q.Level.Value,
                        Transmog = q.Transmog?.DisplayString,
                        Icon = itemAssets.FirstOrDefault(a => a.Id == q.ItemKey.Id)?.Icon,
                        Sockets = q.Sockets?.Select(s => new SocketModel
                        {
                            SocketType = s.SocketType.Type,
                            Name = s.ItemKey?.Name,
                            DisplayString = s.DisplayString,
                            Icon = itemAssets.FirstOrDefault(a => a.Id == s.ItemKey?.Id)?.Icon
                        }),
                        Enchantments = q.Enchantments?.Select(e => new EnchantmentModel
                        {
                            DisplayString = e.DisplayString
                        })
                    })
                }
            };

            return model;
        }
    }
}
