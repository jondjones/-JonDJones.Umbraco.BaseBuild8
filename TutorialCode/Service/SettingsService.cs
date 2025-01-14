﻿using System.Linq;
using Umbraco.Web;
using Umbraco.Web.PublishedModels;

namespace TutorialCode.Service
{
    public class SettingsService : ISettingsService
    {
        private IUmbracoContextFactory _umbracoContextFactory;

        public SettingsService(
            IUmbracoContextFactory umbracoContextFactory)
        {
            _umbracoContextFactory = umbracoContextFactory;
        }

        public Settings SettingsPage => GetSettings();

        private Settings GetSettings()
        {
            using (var cref = _umbracoContextFactory.EnsureUmbracoContext())
            {
                var cache = cref.UmbracoContext.Content;
                return cache.GetAtRoot().DescendantsOrSelf<Settings>().First();
            }
        }

        public FeatureFlags FeatureFlags => GetFeatureFlag();

        private FeatureFlags GetFeatureFlag()
        {
            var item = SettingsPage
                         .FeatureFlags
                         .Where(x => x.Content.ContentType.Alias == FeatureFlags.ModelTypeAlias)
                         .First();

            return new FeatureFlags(item.Content);
        }


    }
}
