Build started...
Build succeeded.
The Entity Framework tools version '6.0.2' is older than that of the runtime '6.0.4'. Update the tools for the latest features and bug fixes. See https://aka.ms/AAc1fbw for more information.
info: Microsoft.EntityFrameworkCore.Infrastructure[10403]
      Entity Framework Core 6.0.4 initialized 'AghanimsWagerContext' using provider 'Npgsql.EntityFrameworkCore.PostgreSQL:6.0.4+6cb649128e3e7aa8eddd77dfa75b34bad51e6e94' with options: None
START TRANSACTION;

DROP TABLE "Kali".dota_match_details_picks_bans;

DROP TABLE "Kali".dota_match_details_players_ability_upgrades;

DROP TABLE "Kali".dota_match_history_players;

DROP TABLE "Kali".dota_match_details_players;

DROP TABLE "Kali".dota_match_details;

DELETE FROM "__EFMigrationsHistory"
WHERE "MigrationId" = '20231231054941_MatchDetails';

COMMIT;


