using Microsoft.EntityFrameworkCore.Migrations;

namespace SamuraiApp.Data.Migrations
{
    public partial class DbFunctonAndView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
              @"CREATE FUNCTION[dbo].[EarliestBattleFoughtBySamurai](@samuraiId int)
          RETURNS char(30) AS
          BEGIN
            DECLARE @ret char(30)
            SELECT TOP 1 @ret = Name
            FROM Battles
            WHERE Battles.Id IN(SELECT BattelId
                               FROM SamuraiBattel
                              WHERE SamuraiId = 2)
            ORDER BY StartDate
            RETURN @ret
          END");
            migrationBuilder.Sql(
              @"CREATE OR ALTER VIEW dbo.SamuraiBattleStats
          AS
          SELECT dbo.SamuraiBattel.SamuraiId, dbo.Samurais.Name,
          COUNT(dbo.SamuraiBattel.BattelId) AS NumberOfBattles,
                  dbo.EarliestBattleFoughtBySamurai(MIN(dbo.Samurais.Id)) AS EarliestBattle
          FROM dbo.SamuraiBattel INNER JOIN
               dbo.Samurais ON dbo.SamuraiBattel.SamuraiId = dbo.Samurais.Id
          GROUP BY dbo.Samurais.Name, dbo.SamuraiBattel.SamuraiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW dbo.SamuraiBattleStats");
            migrationBuilder.Sql("DROP FUNCTION dbo.EarliestBattleFoughtBySamurai");
        }
    }
}
