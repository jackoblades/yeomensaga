using yeomensaga.Models.Management;
using yeomensaga.Extensions;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yeomensaga.Repository.Charters
{
    public static class SettingsCharter
    {
        public static async Task<Settings> ReadAsync()
        {
            Settings result = null;

            using (var db = await Orm.GetDatabaseAsync())
            {
                using (var cmd = new SqliteCommand($"SELECT * FROM {nameof(Settings)} LIMIT 1", db))
                {
                    using (var query = await cmd.ExecuteReaderAsync())
                    {
                        var row = query.ReadValues();

                        if (row.Any())
                        {
                            result = Map(new Settings(), row.First());
                        }
                    }
                }
            }

            return result;
        }

        public static async Task UpsertAsync(Settings settings, SqliteCommand parentCmd = null)
        {
            using (var database = parentCmd?.Connection == null ? await Orm.GetDatabaseAsync() : null)
            {
                var db = database ?? parentCmd.Connection;

                using (var transaction = parentCmd?.Transaction == null ? db.BeginTransaction() : null)
                {
                    var t = transaction ?? parentCmd.Transaction;

                    using (var cmd = new SqliteCommand(string.Empty, db, t))
                    {
                        // Amend.
                        AmendParameters(settings, cmd);
                        cmd.GenerateUpsert(nameof(Settings));

                        // Upsert our foreign key components, if any.

                        // Execute.
                        await cmd.ExecuteNonQueryAsync();

                        // Upsert other components, if any.

                        // Commit, if we newly created the transaction.
                        transaction?.Commit();
                    }
                }
            }
        }

        private static Settings Map(Settings settings, IDictionary<string, object> row)
        {
            settings.Id          = Orm.MapGuid(row[nameof(settings.Id)]);
            settings.MusicVolume = Orm.MapInt(row[nameof(settings.MusicVolume)]);
            settings.Preferences = (Preferences)Orm.MapInt(row[nameof(settings.Preferences)]);
            return settings;
        }

        private static void AmendParameters(Settings settings, SqliteCommand cmd)
        {
            cmd.AddParameter($"@{nameof(settings.Id)}",          settings.Id);
            cmd.AddParameter($"@{nameof(settings.MusicVolume)}", settings.MusicVolume);
            cmd.AddParameter($"@{nameof(settings.Preferences)}", settings.Preferences);
        }
    }
}
