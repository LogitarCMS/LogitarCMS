# LogitarCMS Setup

The configuration required by the CMS depends on the database provider used.

First, provide the `DatabaseProvider` configuration using an environment variable (_recommended way_) or editing `appsettings.json` using one of the following values, then follow the steps described in the corresponding section.

While developing and/or debugging, you can also provide the configurations as user secrets. Right-click the `Logitar.Cms` project, then click on `Manage User Secrets`. The `secrets.sample.json` file is provided as an example. You can copy and paste the values in that file and replace the placeholder values surrounded by brackets `{}`. Make sure the startup project is set to `Logitar.Cms`. You may then launch the CMS by pressing the `Start Debugging` button (**F5 key**). If the CMS homepage appears, then you succeeded!

## EntityFrameworkCorePostgreSQL

You also need to provide the `POSTGRESQLCONNSTR_CmsContext` configuration. This is the connection string used by the CMS to connect to PostgreSQL.

It generally uses the following format: `User ID={USER_ID};Password={PASSWORD};Host={HOST};Port=5432;Database={DB_NAME};`. Generally speaking, `localhost` (same as `127.0.0.1`) can be used as `{HOST}`.

**Please note that if you're using Docker, you must provide your local IP address, such as `192.168.X.Y` as host.** You may want to manually set you local IP address instead of using a DHCP to avoid changing the connection string when your IP address changes. You must also allow connections from your local IP address in the `pg_hba.conf` file of your PostgreSQL server. Please refer to this [official PostgreSQL documentation page](https://www.postgresql.org/docs/current/auth-pg-hba-conf.html).
