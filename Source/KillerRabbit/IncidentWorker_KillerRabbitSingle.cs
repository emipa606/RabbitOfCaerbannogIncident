using RimWorld;
using UnityEngine;
using Verse;

namespace KillerRabbits
{
    // Token: 0x02000003 RID: 3
    public class IncidentWorker_KillerRabbitSingle : IncidentWorker
    {
        // Token: 0x06000003 RID: 3 RVA: 0x00002158 File Offset: 0x00000358
        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            var map = (Map) parms.target;
            var rabbit_of_Caerbannog = KillerRabbitsDefOf.Rabbit_of_Caerbannog;
            if (!RCellFinder.TryFindRandomPawnEntryCell(out var intVec, map, CellFinder.EdgeRoadChance_Animal))
            {
                return false;
            }

            var intVec2 = CellFinder.RandomClosewalkCellNear(intVec, map, 10);
            var pawn = PawnGenerator.GeneratePawn(rabbit_of_Caerbannog);
            var percentageThreshUrgentlyHungry = pawn.needs.food.PercentageThreshUrgentlyHungry;
            var percentageThreshHungry = pawn.needs.food.PercentageThreshHungry;
            var curLevelPercentage = Random.Range(percentageThreshUrgentlyHungry, percentageThreshHungry);
            pawn.needs.food.CurLevelPercentage = curLevelPercentage;
            GenSpawn.Spawn(pawn, intVec2, map);
            Find.LetterStack.ReceiveLetter("LetterLabelKillerRabbitSingleArrived".Translate(),
                "KillerRabbitSingleArrived".Translate(), LetterDefOf.ThreatSmall, new TargetInfo(intVec, map));
            return true;
        }
    }
}