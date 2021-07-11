using RimWorld;
using UnityEngine;
using Verse;

namespace KillerRabbits
{
    // Token: 0x02000002 RID: 2
    public class IncidentWorker_KillerRabbitPack : IncidentWorker
    {
        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            var map = (Map) parms.target;
            var rabbit_of_Caerbannog = KillerRabbitsDefOf.Rabbit_of_Caerbannog;
            if (!RCellFinder.TryFindRandomPawnEntryCell(out var intVec, map, CellFinder.EdgeRoadChance_Animal))
            {
                return false;
            }

            var num = Rand.RangeInclusive(2, 6);
            for (var i = 0; i < num; i++)
            {
                var intVec2 = CellFinder.RandomClosewalkCellNear(intVec, map, 10);
                var pawn = PawnGenerator.GeneratePawn(rabbit_of_Caerbannog);
                var percentageThreshUrgentlyHungry = pawn.needs.food.PercentageThreshUrgentlyHungry;
                var percentageThreshHungry = pawn.needs.food.PercentageThreshHungry;
                var curLevelPercentage = Random.Range(percentageThreshUrgentlyHungry, percentageThreshHungry);
                pawn.needs.food.CurLevelPercentage = curLevelPercentage;
                GenSpawn.Spawn(pawn, intVec2, map);
            }

            Find.LetterStack.ReceiveLetter("LetterLabelKillerRabbitPackArrived".Translate(),
                "KillerRabbitPackArrived".Translate(), LetterDefOf.ThreatSmall, new TargetInfo(intVec, map));
            return true;
        }
    }
}