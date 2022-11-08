using System;
using System.Collections.Generic;
using System.Text;

namespace Exelon.Domain.Entities
{
   public class CompletedPoleAndMile
    {
        public Int64 CompletedPoleMileId { get; set; }
        public Int64 ExecutionLinkingId { get; set; }
        public int TotalNoOfPolesNeeded { get; set; }
        public int PoleInstalled { get; set; }
        public int OHMilesTotal { get; set; }
        public int MakeReadyOHMilesCompleted { get; set; }
        public int UGMilesTotal { get; set; }
        public int UGMilesCompleted { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
