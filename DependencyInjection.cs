using System;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure;
public static class DependencyInjection
{

	public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
	{
		// Add your service registrations here
		return services;
    }
}
