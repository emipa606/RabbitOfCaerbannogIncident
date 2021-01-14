using RimWorld;
using Verse;

namespace KillerRabbits
{
    // Token: 0x02000002 RID: 2
    public class IncidentWorker_KillerRabbitPack : IncidentWorker
    {
        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            var map = (Map)parms.target;
            PawnKindDef rabbit_of_Caerbannog = KillerRabbitsDefOf.Rabbit_of_Caerbannog;
            if (!RCellFinder.TryFindRandomPawnEntryCell(out IntVec3 intVec, map, CellFinder.EdgeRoadChance_Animal, false, null))
            {
                return false;
            }
            var num = Rand.RangeInclusive(2, 6);
            for (var i = 0; i < num; i++)
            {
                IntVec3 intVec2 = CellFinder.RandomClosewalkCellNear(intVec, map, 10, null);
                Pawn pawn = PawnGenerator.GeneratePawn(rabbit_of_Caerbannog, null);
                var percentageThreshUrgentlyHungry = pawn.needs.food.PercentageThreshUrgentlyHungry;
                var percentageThreshHungry = pawn.needs.food.PercentageThreshHungry;
                var curLevelPercentage = UnityEngine.Random.Range(percentageThreshUrgentlyHungry, percentageThreshHungry);
                pawn.needs.food.CurLevelPercentage = curLevelPercentage;
                GenSpawn.Spawn(pawn, intVec2, map);
            }
            Find.LetterStack.ReceiveLetter(Translator.Translate("LetterLabelKillerRabbitPackArrived"), Translator.Translate("KillerRabbitPackArrived"), LetterDefOf.ThreatSmall, new TargetInfo(intVec, map, false), null);
            return true;
        }
    }
}
