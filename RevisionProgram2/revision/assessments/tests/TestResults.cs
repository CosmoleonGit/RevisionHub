using System;
using System.Collections.Generic;
using System.Linq;
using static RevisionProgram2.revision.assessments.tests.TestTester;

namespace RevisionProgram2.revision.assessments.tests
{
    public readonly struct TestResults
    {
        public TestResults(IEnumerable<AskingQuestion> questions)
        {
            All = questions;
            Correct = questions.Where(x => x.Correct);
            Incorrect = questions.Where(x => !x.Correct);
        }

        public readonly IEnumerable<AskingQuestion> Correct, Incorrect, All;
        public float Percentage => (float)Correct.Count() / All.Count() * 100;
        public string PercentageString => 
            $"{Math.Round(Percentage, 1, MidpointRounding.AwayFromZero)}%";
    }
}
