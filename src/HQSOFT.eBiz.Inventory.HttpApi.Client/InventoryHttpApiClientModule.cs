﻿using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace HQSOFT.eBiz.Inventory;

[DependsOn(
    typeof(InventoryApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class InventoryHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(InventoryApplicationContractsModule).Assembly,
            InventoryRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<InventoryHttpApiClientModule>();
        });
    }
}
