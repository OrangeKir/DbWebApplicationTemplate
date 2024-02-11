using DbWebApplicationTemplate;

await Host
    .CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webHostBuilder => webHostBuilder.UseStartup<Startup>())
    .Build()
    .RunAsync();