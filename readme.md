# WebApi.DbFactorySample

This project demonstrates how to create a factory that managages multiple db connection strings. The factory will load the correct db connection based on a querystring parameter.

## Use Cases

This is often used in a multi-tenant environments where each tenant has a different database but the webapi is on a single instance or autoscaling group. Any instance can handle a call to any of the configured databases.

## Flow

The `Startup.cs` registers the `DbConnectionServiceMiddleware` which wires up the `DbConnectionFactory` and the `AppDbContext`

The `DbConnectionFactory` loads all available connections from the `appSettings.json` file. *You can change this to environment variables or Secrets Managers, etc*.

The `AppDbContext` attempts a connection on each request, which pulls the connection information from the `DbConnectionFactory`

The `DbConnectionFactory`  determines which connection string to use based on a querystring value of `tenantId` e.g. `?tenantId=001`.  This can of course be changed to any querystring key/value, header or other token you desire.

## Recommendations

Package the DbConnectionFactory up into it's own project and make it reusable.
