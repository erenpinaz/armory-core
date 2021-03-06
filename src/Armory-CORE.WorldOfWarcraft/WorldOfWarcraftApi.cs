using Armory_CORE.Core.Models;
using Armory_CORE.Core.WorldOfWarcraft.Models.GameData;
using Armory_CORE.Core.WorldOfWarcraft.Models.Profile;
using System.Threading.Tasks;

namespace Armory_CORE.Core.WorldOfWarcraft
{
    public class WorldOfWarcraftApi
    {
        private readonly ApiClient _baseApi;

        public WorldOfWarcraftApi(ApiClient baseApi)
        {
            _baseApi = baseApi;
        }

        #region Game Data 

        #region Realm

        public async Task<RealmIndex> GetRealmsAsync(RequestOptions requestOptions = null)
        {
            return await _baseApi.GetAsync<RealmIndex>(requestUri: $"/data/wow/realm/index", @namespace: "dynamic", requestOptions);
        }

        public async Task<Models.GameData.Realm> GetRealmAsync(int realmId, RequestOptions requestOptions = null)
        {
            return await _baseApi.GetAsync<Models.GameData.Realm>(requestUri: $"/data/wow/realm/{realmId}", @namespace: "dynamic", requestOptions);
        }

        #endregion

        #region Item

        public async Task<ItemClassIndex> GetItemClassesAsync(RequestOptions requestOptions = null)
        {
            return await _baseApi.GetAsync<ItemClassIndex>(requestUri: $"/data/wow/item-class/index", @namespace: "static", requestOptions);
        }

        public async Task<ItemClass> GetItemClassAync(int itemClassId, RequestOptions requestOptions = null)
        {
            return await _baseApi.GetAsync<ItemClass>(requestUri: $"/data/wow/item-class/{itemClassId}", @namespace: "static", requestOptions);
        }

        public async Task<ItemSubclass> GetItemSubclassAsync(int itemClassId, int itemSubclassId, RequestOptions requestOptions = null)
        {
            return await _baseApi.GetAsync<ItemSubclass>(requestUri: $"/data/wow/item-class/{itemClassId}/item-subclass/{itemSubclassId}", @namespace: "static", requestOptions);
        }

        public async Task<Item> GetItemAsync(int itemId, RequestOptions requestOptions = null)
        {
            return await _baseApi.GetAsync<Item>(requestUri: $"/data/wow/item/{itemId}", @namespace: "static", requestOptions);
        }

        public async Task<ItemSetsIndex> GetItemSetsAsync(RequestOptions requestOptions = null)
        {
            return await _baseApi.GetAsync<ItemSetsIndex>(requestUri: $"/data/wow/item-set/index", @namespace: "static", requestOptions);
        }

        public async Task<ItemSet> GetItemSetAsync(int itemSetId, RequestOptions requestOptions = null)
        {
            return await _baseApi.GetAsync<ItemSet>(requestUri: $"/data/wow/item-set/{itemSetId}", @namespace: "static", requestOptions);
        }

        public async Task<ItemMedia> GetItemMediaAsync(int itemId, RequestOptions requestOptions = null)
        {
            return await _baseApi.GetAsync<ItemMedia>(requestUri: $"/data/wow/media/item/{itemId}", @namespace: "static", requestOptions);
        }

        #endregion

        #endregion

        #region Profile

        #region Character Summary

        public async Task<CharacterProfileSummary> GetCharacterProfileSummaryAsync(string realmSlug, string characterName, RequestOptions requestOptions = null)
        {
            return await _baseApi.GetAsync<CharacterProfileSummary>(requestUri: $"/profile/wow/character/{realmSlug}/{characterName.ToLowerInvariant()}", @namespace: "profile", requestOptions);
        }

        public async Task<CharacterMediaSummary> GetCharacterMediaSummaryAsync(string realmSlug, string characterName, RequestOptions requestOptions = null)
        {
            return await _baseApi.GetAsync<CharacterMediaSummary>(requestUri: $"/profile/wow/character/{realmSlug}/{characterName.ToLowerInvariant()}/character-media", @namespace: "profile", requestOptions);
        }

        public async Task<CharacterEquipmentSummary> GetCharacterEquipmentSummaryAsync(string realmSlug, string characterName, RequestOptions requestOptions = null)
        {
            return await _baseApi.GetAsync<CharacterEquipmentSummary>(requestUri: $"/profile/wow/character/{realmSlug}/{characterName.ToLowerInvariant()}/equipment", @namespace: "profile", requestOptions);
        }

        #endregion

        #endregion
    }
}
