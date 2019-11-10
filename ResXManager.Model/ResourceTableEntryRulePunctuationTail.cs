﻿namespace tomenglertde.ResXManager.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using tomenglertde.ResXManager.Model.Properties;
    
    [LocalizedDisplayName(StringResourceKey.ResourceTableEntryRulePunctuationTail_Name)]
    [LocalizedDescription(StringResourceKey.ResourceTableEntryRulePunctuationTail_Description)]
    internal sealed class ResourceTableEntryRulePunctuationTail : ResourceTableEntryRulePunctuation
    {
        internal const string PunctuationTail = "punctuationTail";

        public override string RuleId => PunctuationTail;

        protected override IEnumerable<char> GetCharIterator(string value) => value.Reverse();

        protected override string GetErrorMessage(string reference)
        {
            var intro = Resources.ResourceTableEntryRulePunctuationTail_Error_Intro;
            if (string.IsNullOrEmpty(reference))
                return intro + " " + Resources.ResourceTableEntryRulePunctuationTail_Error_NoPunctuationExpected;

            return intro + " " + string.Format(Resources.Culture,
                       Resources.ResourceTableEntryRulePunctuationTail_Error_PunctuationSeqExpected,
                       ReverseString(reference));
        }

        private static string ReverseString(string s)
        {
            var arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}